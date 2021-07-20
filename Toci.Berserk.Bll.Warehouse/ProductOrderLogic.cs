using Microsoft.EntityFrameworkCore;
using System;
 using System.Collections.Generic;
using System.Linq;
using Toci.Berserk.Bll.Ml;
using Toci.Berserk.Bll.Ml.Interfaces;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class ProductOrderLogic : LogicBase<Orderproduct>, IProductOrderLogic
    {
        protected IOrderLogic orderLogic = new OrderLogic();
        protected IChemistryLogic chemistryLogic = new ChemistryLogic();
        protected ISuspectOrderLogic suspectOrderLogic = new SuspectOrderLogic();
        protected IArithmeticAverageProductOrderLogic MlAvg = new ArithmeticAverageProductOrderLogic();
        protected IProductLogic ProductLogic = new ProductLogic();

        protected LogicBase<Delivery> deliveryLogic = new LogicBase<Delivery>();

        public int AddOrders(List<Orderproduct> products, int deliveryCompanyID)
        {
            int id = orderLogic.Insert(new Order()
            {
                Date = new DateTime(2021, 06, 20), // DAFAQ ?
                Iddeliverycompany = deliveryCompanyID
            }).Id;

            foreach (Orderproduct product in products)
            {
                product.Idorder = id;

                Insert(product);
            }

            return id;
        }

        public virtual bool ManipulateOrder(int orderId)
        {
            IQueryable<Orderproduct> orderProducts = Select(model => model.Idorder == orderId && model.Status == SuspectOrderLogic.OrderSent);
            int? deliveryCompanyId = orderLogic.Select(model => model.Id == orderId).FirstOrDefault().Iddeliverycompany;
            if (orderProducts.Any())
            {
                foreach (Orderproduct order in orderProducts)
                {
                    chemistryLogic.ReceiveOrder(new Chemistry()
                    {
                        Idproducts = order.Idproducts,
                        Quantity = order.Quantity
                    },order.Price, deliveryCompanyId);

                    order.Status = SuspectOrderLogic.OrderAccomplished;

                    Update(order);
                }

                return true;
            }

            return false;
        }

        public IQueryable<Orderproduct> GetProductsOrders(int status)
        {
            return Select(model => model.Status == status);
        }

        public virtual List<OrderProductDto> GetSuspectedOrder()
        {
            LogicBase<Productcompanyorder> pcoLogic = new LogicBase<Productcompanyorder>();

            List<OrderProductDto> result = new List<OrderProductDto>();

            Dictionary<int, List<Chemistrypop>> orderHistory = suspectOrderLogic.GetOrdersHistory(new Order() { Date = DateTime.Now }, 4);

            Dictionary<int, decimal> finalAverages = MlAvg.CalculateAverages(orderHistory);

            foreach (KeyValuePair<int, decimal> item in finalAverages)
            {
                Productcompanyorder pco = pcoLogic.Select(p => p.Productid == item.Key).First();

                OrderProductDto element = new OrderProductDto(pco);

                element.ExpectedOrderQuantity = (int)item.Value;
                element.CompaniesPerProduct = GetDeliveryCompanies(element.Productid.Value);

                result.Add(element);
            }

            return result;
        }

        public virtual OrderProductDto GetProductExpectedQuantity(int productId)
        {
            List<Chemistrypop> productUsage = suspectOrderLogic.GetProductUsage(productId);
            decimal average =  MlAvg.CalculateAverages(productUsage);

            Chemistry prod = chemistryLogic.Select(m => m.Idproducts == productId).First();

            OrderProductDto element = new OrderProductDto();

            element.CompaniesPerProduct = GetDeliveryCompanies(productId);
            element.ExpectedOrderQuantity = (int)average;
            element.Currentquantity = prod.Quantity;

            return element;
        }

        protected virtual List<DeliveryDto> GetDeliveryCompanies(int productId)
        {
            List<Delivery> del = deliveryLogic.Select(m => m.Idproducts == productId).Include(m=>m.IddeliverycompanyNavigation).ToList();

            List<DeliveryDto> result = new List<DeliveryDto>();

            foreach (Delivery el in del)
            {
                result.Add(new DeliveryDto()
                {
                    CompanyName = el.IddeliverycompanyNavigation.Name,
                    Idproducts = el.Idproducts,
                    Iddeliverycompany = el.Iddeliverycompany,
                    Price = el.Price
                });
            }

            return result;
        }

        public virtual int SetSuspectedOrder(List<OrderProductDto> products)
        {
            int newOrderId = orderLogic.CreateOrder(new OrderDto()
            {
                dateScope = DateTime.Now,
                Status = SuspectOrderLogic.OrderSent
            });

            foreach (OrderProductDto orderProduct in products)
            {
                Orderproduct op = new Orderproduct() 
                {
                    Idorder = newOrderId,
                    Idproducts = orderProduct.Productid,
                    Quantity = orderProduct.ExpectedOrderQuantity,
                    Status = SuspectOrderLogic.OrderSent
                };

                Insert(op);
            }

            return newOrderId;
        }
    }
}