using System;
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

            for (int i = 1; i < 100; i++)
            {
                listProduct.Add(i);
            }

            Random r = new Random();

            foreach (int productId in listProduct)
            {
                Orderproduct orderPr = new Orderproduct()
                {
                    Quantity = r.Next(1,10),
                    Idproducts = productId,
                    Status = 1
                };
                orderProduct.Add(orderPr);
            }

            productOrderLogic.AddOrders(orderProduct);
        }

        [TestMethod]
        public void ManipulateOrderTest()
        {
            ProductOrderLogic productOrderLogic = new ProductOrderLogic();
            productOrderLogic.ManipulateOrder(7);
            
        }
    }
}