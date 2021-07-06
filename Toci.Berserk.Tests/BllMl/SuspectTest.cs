using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Berserk.Bll;
using Toci.Berserk.Bll.Ml;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Tests.BllMl
{
    [TestClass]
    public class SuspectTest
    {
        [TestMethod]
        public void SuspectOrderTest()
        {
            SuspectOrderLogic suspectOrderLogic = new SuspectOrderLogic();
            Order lastOrder = suspectOrderLogic.LastAccomplishedOrderDate();
        }

        [TestMethod]
        public void GenerateOrderHistory()
        {
            Order order = new Order();
            SuspectOrderLogic suspectOrderLogic = new SuspectOrderLogic();
            Dictionary<int, List<Chemistrypop>> orderHistory = new Dictionary<int, List<Chemistrypop>>();
            int depth = 5;

            order = suspectOrderLogic.LastAccomplishedOrderDate();

            orderHistory = suspectOrderLogic.GetOrdersHistory(order, depth);

        }
    }
}