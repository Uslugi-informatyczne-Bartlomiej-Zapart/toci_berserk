using System;
using System.Collections.Generic;
using System.Linq;
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
        public void UpdateDatesRandom()
        {
            LogicBase<Chemistrypop> chemistry = new LogicBase<Chemistrypop>();
            Random r = new Random();

            for (int j = 0, z=0; j < 1000; j+=50, z++)
            {
                IQueryable <Chemistrypop> chemistrypops = chemistry.Select(model => model.Id > j && model.Id < j+50);

                foreach (Chemistrypop el in chemistrypops)
                {
                    el.Idproducts = r.Next(1, 20);
                    el.Date = DateTime.Now.AddDays(-(z));
                    chemistry.Update(el);
                }
            }
        }

        [TestMethod]
        public void GenerateOrderHistory()
        {
            Order order = new Order();
            SuspectOrderLogic suspectOrderLogic = new SuspectOrderLogic();
            Dictionary<int, List<Chemistrypop>> orderHistory = new Dictionary<int, List<Chemistrypop>>();
            int depth = 5;

            order = new Order()
            {
                Date = DateTime.Now.AddDays(-4)
            };
                //suspectOrderLogic.LastAccomplishedOrderDate();
                

            orderHistory = suspectOrderLogic.GetOrdersHistory(order, depth);

            ArithmeticAverageProductOrderLogic arithmeticAverage = new ArithmeticAverageProductOrderLogic();

            arithmeticAverage.CalculateAverages(orderHistory);
        }
    }
}