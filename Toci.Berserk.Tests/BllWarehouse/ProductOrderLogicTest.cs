using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Berserk.Bll;
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
            LogicBase<Order> order = new LogicBase<Order>();
            ProductOrderLogic productOrderLogic = new ProductOrderLogic();
            
            Order orderOne = new Order()
            {
                
            };

            int id = productOrderLogic.AddOrders();
        }
    }
}