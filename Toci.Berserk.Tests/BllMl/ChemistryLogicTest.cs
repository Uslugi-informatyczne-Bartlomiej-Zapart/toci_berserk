using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Berserk.Bll;
using Toci.Berserk.Bll.Ml;
using Toci.Berserk.Bll.Warehouse;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Tests.BllMl
{
    [TestClass]
    public class ChemistryLogicTest
    {
        [TestMethod]
        public void AddChemistryHistory()
        {
            LogicBase<Category> category = new LogicBase<Category>();
            for (int i = 0; i < 100; i++)
            {
                AddChemistry();
            }
            
        }

        [TestMethod]
        public void AddChemistry()
        {
            Random r = new Random();

            ChemistryLogic chemistry = new ChemistryLogic();
            for (int i = 1; i < 50000; i++)
            {
                chemistry.ReceiveOrder(new Chemistry()
                {
                    Idproducts = i,
                    Quantity = r.Next(100, 200)
                },10f, 1);
            }
            
        }

        [TestMethod]
        public void ReduceChemistry()
        {
            //LogicBase<User> user = new LogicBase<User>();
            //user.Insert(new User()
            //{
            //    Login = "wladek",
            //    Name = "wladyslaw",
            //    Password = "123456"
            //});

            ChemistryLogic chemistry = new ChemistryLogic();
            Random r = new Random();
            for (int j = 1; j < 6; j++)
            {
                for (int i = 1; i < 1000; i++)
                {
                    chemistry.Reduce(new Chemistry()
                    {
                        Idproducts = i,
                        Quantity = r.Next(1, 10)
                    }, j);
                }
            }
            
        }
    }
}