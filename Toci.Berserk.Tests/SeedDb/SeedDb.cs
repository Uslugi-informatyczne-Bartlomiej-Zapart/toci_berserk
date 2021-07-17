using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Berserk.Bll;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;
using Toci.Common.Utils;

namespace Toci.Berserk.Tests.SeedDb
{
    [TestClass]
    public class SeedDb
    {
        protected LogicBase<User> User = new LogicBase<User>();
        protected LogicBase<Productcompany> ProductcompanyLogic  = new LogicBase<Productcompany>();
        protected LogicBase<Category> Category = new LogicBase<Category>();
        protected LogicBase<Deliverycompany> DeliveryCompany = new LogicBase<Deliverycompany>();
        protected LogicBase<Product> Product = new LogicBase<Product>();
        protected LogicBase<Delivery> Delivery = new LogicBase<Delivery>();
        protected LogicBase<Productscode> ProductsCode = new LogicBase<Productscode>();
        protected LogicBase<Productshistory> ProductsHistory = new LogicBase<Productshistory>();
        protected LogicBase<Chemistry> Chemistry = new LogicBase<Chemistry>();
        protected LogicBase<Order> Order = new LogicBase<Order>();
        protected LogicBase<Orderproduct> OrderProduct = new LogicBase<Orderproduct>();
        protected LogicBase<Metric> Metric = new LogicBase<Metric>();
        protected LogicBase<Predictedorder> PredictedOrder = new LogicBase<Predictedorder>();
        protected LogicBase<Predictedorderquantity> PredictedOrderQuantity = new LogicBase<Predictedorderquantity>();
        protected LogicBase<Chemistrypop> ChemistryPop = new LogicBase<Chemistrypop>();
        protected LogicBase<Metrichistory> MetricHistory = new LogicBase<Metrichistory>();
        protected ProductLogic productLogic = new ProductLogic();
        protected ChemistryLogic chemLogic = new ChemistryLogic();
        protected IProductOrderLogic productOrderLogic = new ProductOrderLogic();
        protected RandomTextUtil TextUtil = new RandomTextUtil();

        [TestMethod]
        public void SeedEntireDatabase()
        {
            Users();
            Categories();
            DeliveryCompanies();
            Products();
            SeedRandomProducts();
            Chemistries();
            OrdersHistory();
            OrdersSetNewApproved();
            ProductsCompanies();
        }

        [TestMethod]
        public void Users()
        {
            User.Insert(new User()
            {
                Name = "Jan",
                Login = "Janko",
                Password = "Password"
            });
        }

        [TestMethod]
        public void Categories()
        {
            string[] categories = { "Farby", "Oleje", "Smary", "Filtry" };

            foreach (var category in categories)
            {
                Category.Insert(new Category()
                {
                    Name = category,
                });
            }
        }

        [TestMethod]
        public void DeliveryCompanies()
        {
            string[] companies = { "Śnieżka", "Cekol", "Dekoral", "Dulux", "Magnat" };

            foreach (var company in companies)
            {
                DeliveryCompany.Insert(new Deliverycompany()
                {
                    Name = company
                });
            }
        }

        [TestMethod]
        public void Products()
        {
            
            string[] names = { "Farba", "Olej", "Smar" };
            string[] manufacturers = { "Dekol", "Dekoral", "Delux" };
            int[] codes = { 1000, 1001, 1002 };
            int[] prices = {10, 20, 30};
            string[] deliverys = {"DPD", "GLS", "ABC"};

            for (int i = 0; i < names.Length; i++)
            {
                productLogic.SetProduct(new ProductDto()
                {
                    Product = new Product()
                    {
                        Name = names[i],
                        Manufacturer = manufacturers[i]
                    },
                    Code = codes[i],
                    Price = prices[i],
                    DeliveryCompany = deliverys[i]
                });
            }
        }

        [TestMethod]
        public void OrdersHistory()
        {
            OrderLogic orderLogic = new OrderLogic();
            //orderLogic.GetCompletedOrders()
            for (int i=0;i<10;i++)
            {
                orderLogic.CreateOrder(new OrderDto()
                {
                    dateScope = DateTime.Now.AddDays(-i * 3),
                    deliveryCompanyId = 2,
                    deliveryCompanyName = "DPD",
                    Status = 2
                });
            }
        }

        [TestMethod]
        public void OrdersSetNewApproved()
        {
            List<OrderProductDto> elements = new List<OrderProductDto>();
            Random rn = new Random();

            for (int i = 0; i < 15; i++)
            {
                OrderProductDto opd = new OrderProductDto()
                {
                    CurrentQuantity = 8,
                    ExpectedOrderQuantity = rn.Next(1, 20),
                    Price = 25,
                    ProductId = i+1
                };

                elements.Add(opd);
            }

            productOrderLogic.SetSuspectedOrder(elements);
        }

        //[TestMethod]
        //public void ProductsCodes()
        //{
        //    ProductsCode.Insert(new Productscode()
        //    {
        //        Idproducts = 1,
        //        Code = 1000
        //    });

        //    ProductsCode.Insert(new Productscode()
        //    {
        //        Idproducts = 2,
        //        Code = 1001
        //    });
        //}
        
        [TestMethod]
        public void SeedRandomProducts()
        {
            for (int i = 0; i < 50; i++)
            {
                productLogic.SetProduct(new ProductDto()
                {
                    Product = new Product()
                    {
                        Name = TextUtil.GenerateRandomText(4, 25),
                        Manufacturer = TextUtil.GenerateRandomText(5, 40),
                    },
                    Code = 1003+i,
                    Price = i,
                    DeliveryCompany = "GLS"
                });
            }
        }

        public void Chemistries()
        {
            Random rn = new Random();
            for (int i = 0; i < 500; i++)
            {
                Chemistry chem = new Chemistry()
                {
                    Idcategories = 1,
                    Quantity = rn.Next(1, 10),
                    Idproducts = rn.Next(1, 52)
                };
                Chemistry.Insert(chem);

                chemLogic.Reduce(chem, 1);
            }
        }

        [TestMethod]
        public void ProductsCompanies()
        {
            //for 7x
            //for 50 x
            Productcompany pc = new Productcompany();

            // ?????
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    Productcompany prodCompany = new Productcompany();
                    prodCompany.Idproducts = j + 1;
                    prodCompany.Iddeliverycompany = i + 1;
                    ProductcompanyLogic.Insert(prodCompany);
                }
            }
        }

        //[TestMethod]
        //public void Deliveries()
        //{
        //    Delivery.Insert(new Delivery()
        //    {
        //        Idproducts = 1,
        //        Iddeliverycompany = 1,
        //        Price = 30
        //    });
        //}

        //[TestMethod]
        //public void OrderProducts()
        //{
        //    OrderProduct.Insert(new Orderproduct()
        //    {
        //        Idorder = 1,
        //        Status = 1,
        //        Idcategories = 1,
        //        Quantity = 3,
        //        Idproducts = 1,
        //        Price = 30
        //    });
        //}

        //[TestMethod]
        //public void Metrics()
        //{
        //    Metric.Insert(new Metric()
        //    {
        //        Metric1 = 1,
        //        Algorithm = 1
        //    });
        //}

        //    [TestMethod]
        //    public void PredictedOrders()
        //    {
        //        PredictedOrder.Insert(new Predictedorder()
        //        {
        //            Idproducts = 1,
        //            Idorder = 1
        //        });
        //    }

        //    [TestMethod]
        //    public void PredictedOrderQuantities()
        //    {
        //        PredictedOrderQuantity.Insert(new Predictedorderquantity()
        //        {
        //            Idmetric = 1,
        //            Quantity = 5,
        //            Idpredictedorder = 1
        //        });
        //    }

        //    [TestMethod]
        //    public void ChemistryPops()
        //    {
        //        ChemistryPop.Insert(new Chemistrypop()
        //        {
        //            Idproducts = 1,
        //            Quantity = 3,
        //            Idusers = 1
        //        });
        //    }

        //    [TestMethod]
        //    public void MetricHistories()
        //    {
        //        MetricHistory.Insert(new Metrichistory()
        //        {
        //            Idorders = 1,
        //            Idmetrics = 1,
        //            Metric = 1
        //        });
        //    }
    }
}