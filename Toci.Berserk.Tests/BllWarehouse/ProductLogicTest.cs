using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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