using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}