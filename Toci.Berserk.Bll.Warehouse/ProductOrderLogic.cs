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
        public const int OrderSent = 1;
        public const int OrderAccomplished = 2;

        protected LogicBase<Order> orderLogic = new LogicBase<Order>();
        protected IChemistryLogic chemistryLogic = new ChemistryLogic();
        protected ISuspectOrderLogic SuspectOrderLogic = new SuspectOrderLogic();
        protected IArithmeticAverageProductOrderLogic MlAvg = new ArithmeticAverageProductOrderLogic();
        protected IProductLogic ProductLogic = new ProductLogic();

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
            IQueryable<Orderproduct> orderProducts = Select(model => model.Idorder == orderId && model.Status == OrderSent);
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

                    order.Status = OrderAccomplished;

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
            List<OrderProductDto> result = new List<OrderProductDto>();

            Dictionary<int, List<Chemistrypop>> orderHistory = SuspectOrderLogic.GetOrdersHistory(new Order() { Date = DateTime.Now }, 4);

            List<List<Tuple<int?, decimal>>> averages = MlAvg.CalculateAverages(orderHistory);

            Dictionary<int, decimal> finalAverages = GetOneAvgForProduct(averages);

            foreach (KeyValuePair<int, decimal> item in finalAverages)
            {
                OrderProductDto element = new OrderProductDto() { ProductId = item.Key };

                Product pr = ProductLogic.Select(m => m.Id == item.Key).Include(p => p.Chemistries).Include(p => p.Deliveries).First();

                element.ProductName = pr.Name;
                element.ExpectedOrderQuantity = (int)item.Value;
                element.CurrentQuantity = pr.Chemistries.First().Quantity.Value;
                element.DeliveryCompany = pr.Deliveries.First().Iddeliverycompany.ToString(); // TODO
                element.Price = pr.Deliveries.First().Price.Value;

                result.Add(element);
            }

            return result;
        }

        protected virtual Dictionary<int, decimal> GetOneAvgForProduct(List<List<Tuple<int?, decimal>>> averages)
        {
            Dictionary<int, List<decimal>> temp = new Dictionary<int, List<decimal>>();

            foreach (List<Tuple<int?, decimal>> avg in averages)
            {
                foreach (Tuple<int?, decimal> item in avg)
                {
                    if (temp.ContainsKey(item.Item1.Value))
                    {
                        temp[item.Item1.Value].Add(item.Item2);
                    }
                    else
                    {
                        temp.Add(item.Item1.Value, new List<decimal>() { item.Item2 });
                    }
                }
            }

            Dictionary<int, decimal> result = new Dictionary<int, decimal>();

            foreach (KeyValuePair<int, List<decimal>> item in temp)
            {
                result.Add(item.Key, item.Value.Average());
            }

            return result;
        }
    }
}