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


            Random r = new Random();

            for (int i = 100; i < 117; i++)
            {
                listProduct.Add(i);
            }

        

            foreach (int productId in listProduct)
            {
                Orderproduct orderPr = new Orderproduct()
                {
                    Quantity = r.Next(10,20),
                    Idproducts = productId,
                    Status = 2
                   //id order wrzucamy w AddOrders
                };
                orderProduct.Add(orderPr);
            }

            productOrderLogic.AddOrders(orderProduct, 1);
        }

        [TestMethod]
        public void ManipulateOrderTest()
        {
            ProductOrderLogic productOrderLogic = new ProductOrderLogic();
            productOrderLogic.ManipulateOrder(7);
            
        }
    }
}