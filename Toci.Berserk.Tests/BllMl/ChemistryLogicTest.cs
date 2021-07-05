using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Berserk.Bll;
using Toci.Berserk.Bll.Ml;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Tests.BllMl
{
    [TestClass]
    public class ChemistryLogicTest
    {
        [TestMethod]
        public void AddChemistry()
        {
            LogicBase<Category> category = new LogicBase<Category>();
            category.Insert(new Category()
            {
                Name = "Smary"
            });

            ChemistryLogic chemistry = new ChemistryLogic();
            chemistry.ReceiveOrder(new Chemistry()
            {
                Idproducts = 1,
                Quantity = 3
            });
            chemistry.ReceiveOrder(new Chemistry()
            {
                Idproducts = 1,
                Quantity = 5
            });
            chemistry.ReceiveOrder(new Chemistry()
            {
                Idproducts = 1,
                Quantity = 8
            });
        }

        [TestMethod]
        public void ReduceChemistry()
        {
            LogicBase<User> user = new LogicBase<User>();
            user.Insert(new User()
            {
                Login = "maniek33",
                Name = "Stachu",
                Password = "123456"
            });
            ChemistryLogic chemistry = new ChemistryLogic();
            chemistry.Reduce(new Chemistry()
            {
                Idproducts = 1,
                Quantity = 2
            }, 1);

            chemistry.Reduce(new Chemistry()
            {
                Idproducts = 1,
                Quantity = 4
            }, 1);
        }
    }
}