using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Toci.Berserk.Bll.Ml;
using Toci.Berserk.Bll.Ml.Interfaces;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    //This class is a connection point between the front and back of the application.
    //A user can create orders.
    public class OrderLogic : LogicBase<Order>, IOrderLogic
    {
        protected SuspectOrderLogic SuspectOrderLogic = new SuspectOrderLogic();
        protected DeliveryLogic DeliveryLogic = new DeliveryLogic();
        protected ProductLogic ProductLogic = new ProductLogic();
        protected ProductsCodeLogic ProductCodeLogic = new ProductsCodeLogic();
        protected ChemistryLogic ChemistryLogic = new ChemistryLogic();
        public IQueryable<Order> AllOrders()
        {
            return Select(model => model.Id > 0);
        }

        public Dictionary<int, List<Chemistrypop>> CreateOrderByDeliveryCompany(OrderDto order)
        {
            order.deliveryCompanyId = DeliveryLogic.SetNewDeliveryCompany(order.deliveryCompanyName);
            var respond = SuspectOrderLogic.GetOrdersHistory(order);
            return respond;
        }

        public IQueryable<Order> GetCompletedOrders(DateTime dateFrom, DateTime dateTo)
        {
            return Select(m => m.Date >= dateFrom && m.Date <= dateTo);
        }

        public int CreateOrder(OrderDto order)
        {
            order.deliveryCompanyId = DeliveryLogic.SetNewDeliveryCompany(order.deliveryCompanyName);

            return Insert(new Order()
            {
                Date = order.dateScope,
                Iddeliverycompany = order.deliveryCompanyId,
                Status = order.Status
            }).Id;
        }

        public Dictionary<int, string> AllCompanies()
        {
            return DeliveryLogic.GetDeliveryCompanies();
        }

        public List<ProductCompanyDto> AllProductsFromCompany(int companyId)
        {
            List<ProductCompanyDto> AllProductsFromCompany = new List<ProductCompanyDto>();
            Dictionary<int?, float?> deliveryProducts = DeliveryLogic.AllProductsFromDeliveryCompany(companyId);
            List<int?> productsId = deliveryProducts.Select(x => x.Key).ToList();
            IQueryable<Product> products = ProductLogic.Select(model => productsId.Contains(model.Id));
            IQueryable<Productscode> productscode = ProductCodeLogic.Select(model => productsId.Contains(model.Idproducts));
            IQueryable<Chemistry> chemistry = ChemistryLogic.Select(model => productsId.Contains(model.Idproducts));
            Dictionary<int, string> deliveryCompanies = DeliveryLogic.GetDeliveryCompanies();

            foreach(KeyValuePair<int?, float?> ele in deliveryProducts)
            {
                ProductCompanyDto ProductOfCurrentCompany = new ProductCompanyDto();
                ProductOfCurrentCompany.ProductId = ele.Key;
                ProductOfCurrentCompany.ProductPriceBasedOnCurrentCompany = ele.Value;
                ProductOfCurrentCompany.ProductName = products.Where(x => x.Id == ele.Key).FirstOrDefault().Name;
                ProductOfCurrentCompany.ProductCode = productscode.Where(x => x.Idproducts == ele.Key).FirstOrDefault().Code;
                ProductOfCurrentCompany.Quantity = chemistry.Where(x => x.Idproducts == ele.Key).First().Quantity;
                ProductOfCurrentCompany.PredictedQuantityToOrder = 0; // to implement
                Dictionary<string?, Tuple<int?, float?>> AllDeliveriesOfCurrentProduct = new Dictionary<string?, Tuple<int?, float?>>();
                IQueryable<Delivery> deliveriesOfProduct = DeliveryLogic.Select(model => model.Idproducts == ele.Key);
                foreach (Delivery entityProduct in deliveriesOfProduct)
                {
                    AllDeliveriesOfCurrentProduct.Add(deliveryCompanies[(int)entityProduct.Iddeliverycompany],
                        new Tuple<int?, float?>(entityProduct.Iddeliverycompany, entityProduct.Price));
                }
                ProductOfCurrentCompany.ProductDeliveryCompaniesWithPrices = AllDeliveriesOfCurrentProduct;
                AllProductsFromCompany.Add(ProductOfCurrentCompany);
            }

            return AllProductsFromCompany;
        }
    }
}