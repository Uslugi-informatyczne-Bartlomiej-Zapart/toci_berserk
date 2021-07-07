using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Berserk.Bll;
using Toci.Berserk.Bll.Ml;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Tests.BllWarehouse
{
    [TestClass]
    public class ProductLogicTest
    {
        protected int learningTPL()
        {
            ProductLogic productLogic = new ProductLogic();
            
            for (int i = 0, j=100; i < 3500; i++, j++)
            {
                Product newOne = productLogic.Insert(new Product()
                {
                    Name = "Farba" + i.ToString(),
                    Manufacturer = "Farby S.A."
                });
                ProductsCodeLogic productsCodeLogic = new ProductsCodeLogic();

                productsCodeLogic.Insert(new Productscode()
                {
                    Idproducts = newOne.Id,
                    Code = j
                });
            }

            return 1;
        }

        [TestMethod]
        public void dupa()
        {
            int x = System.Threading.ThreadPool.ThreadCount;
            List<Task<int>> tasks = new List<Task<int>>();
            TaskFactory<int> taskFactory = new TaskFactory<int>();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 8; i++)
            {
                tasks.Add(taskFactory.StartNew(learningTPL));
            }

            Task.WaitAll(tasks.ToArray());
            watch.Stop();

            TimeSpan time = watch.Elapsed;
        }

        [TestMethod]
        public void AddDeliveryCompanies()
        {
            LogicBase<Deliverycompany> delco = new LogicBase<Deliverycompany>();
            delco.Insert(new Deliverycompany()
            {
                Name = "FirmaDostawczaZdzicho"
            });
            delco.Insert(new Deliverycompany()
            {
                Name = "FirmaDostawczaChemicalBrothers"
            });
            delco.Insert(new Deliverycompany()
            {
                Name = "FirmaDostawczaUCiociNaImieninach"
            });
        }

        [TestMethod]
        public void AddUsers()
        {
            LogicBase<User> user = new LogicBase<User>();
            user.Insert(new User()
            {
                Name = "Enrike",
                Login = "z dupy",
                Password = "mega z dupy"
            });
            user.Insert(new User()
            {
                Name = "Eustachy",
                Login = "z pipy",
                Password = "pipa renifer"
            });
            user.Insert(new User()
            {
                Name = "Franio",
                Login = "zawiercie rulez",
                Password = "jprdle"
            });
        }

        [TestMethod]
        public void AddChemistryPop()
        {
            Random random = new Random();
            LogicBase<Chemistrypop> warehousePop = new LogicBase<Chemistrypop>();
            int user = 3; 
            DateTime datka = new DateTime(2021, 07, 06);
            for (int i = 1; i < 20; i++)
            {
                warehousePop.Insert(new Chemistrypop()
                {
                    Idproducts = random.Next(1, 40),
                    Quantity = random.Next(1, 15),
                    Idusers = user,
                    Date = datka
                });
            }
        }

        [TestMethod]
        public void AddProducts()
        {
            LogicBase<Product> product = new LogicBase<Product>();
            string nameOfProduct = "Farba 00";
            string manufact = "Wazowski Farby";
            for (int i = 1; i < 41; i++)
            {
                product.Insert(new Product()
                {
                    Name = nameOfProduct + i,
                    Manufacturer = manufact
                });
            }
        }

        [TestMethod]
        public void AddDelivery()
        {
            LogicBase<Delivery> delivery = new LogicBase<Delivery>();
            int company = 2; //FirmaDostawczaChemicalBrothers
            for (int i = 1; i < 20; i++)
            {
                delivery.Insert(new Delivery()
                {
                    Idproducts = i,
                    Iddeliverycompany = company
                });
            }
        }

        [TestMethod]
        public void AddProductToTestHistory()
        {
            ProductLogic productLogic = new ProductLogic();
            //productLogic.Update(new Product()
            //{
            //    Id = 1,
            //    Name = "XXX"
            //});
            
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int initialCode = 100;
            for (int i = 0; i < 5000; i++)
            {
                Product newOne = productLogic.Insert(new Product()
                {
                    Name = "Farba"+i.ToString(),
                    Manufacturer = "Farby S.A."
                });
                ProductsCodeLogic productsCodeLogic = new ProductsCodeLogic();

                productsCodeLogic.Insert(new Productscode()
                {
                    Idproducts = newOne.Id,
                    Code = initialCode++
                });
            }
            watch.Stop();
            TimeSpan time = watch.Elapsed;
            
            //productLogic.SetProduct(new ProductDto()
            //{
            //    Product = new Product()
            //    {
            //        Id = newOne.Id,
            //        Name = "Farba do metalu"
            //    },
            //    Code = 111111
            //});
        }

        [TestMethod]
        public void AddProductWithCode()
        {
            ProductLogic productLogic = new ProductLogic();
            int newOne = productLogic.SetProduct(new ProductDto()
            {
                Code = 123456,
                Product = new Product()
                {
                    Name = "Olej do silnika",
                    Reference = 1000,
                    Manufacturer = "engine"
                }
            });
        }
    }
}