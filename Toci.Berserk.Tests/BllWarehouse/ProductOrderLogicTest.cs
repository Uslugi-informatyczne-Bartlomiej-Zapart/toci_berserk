using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Berserk.Bll;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Tests.BllWarehouse
{
    [TestClass]
    public class ProductOrderLogicTest
    {
        [TestMethod]
        public void AddOrdersTest()
        {
            ProductOrderLogic productOrderLogic = new ProductOrderLogic();
            List<Orderproduct> orderProduct = new List<Orderproduct>();
            List<int> listProduct = new List<int>();

            listProduct.Add(1);
            listProduct.Add(2);
            listProduct.Add(3);
            listProduct.Add(4);

            int quantity = 5;

            foreach (int productId in listProduct)
            {
                Orderproduct orderPr = new Orderproduct()
                {
                    Quantity = quantity++,
                    Idproducts = productId
                };
                orderProduct.Add(orderPr);
            }

            productOrderLogic.AddOrders(orderProduct);
        }

        [TestMethod]
        public void ManipulateOrderTest()
        {
            ProductOrderLogic productOrderLogic = new ProductOrderLogic();
            productOrderLogic.ManipulateOrder(9);
            
        }
    }
}