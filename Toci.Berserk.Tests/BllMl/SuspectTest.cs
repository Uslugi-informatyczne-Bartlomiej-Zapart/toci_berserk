using System;
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
        public void SuspectLastOrderTest()
        {
            SuspectOrderLogic suspectOrderLogic = new SuspectOrderLogic();
            Order lastOrder = suspectOrderLogic.LastAccomplishedOrderDate();
        }

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
    }
}