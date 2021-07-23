using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Berserk.Bll;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Tests.BllWarehouse
{
    [TestClass]
    public class TestyWladek
    {
        protected ProductLogic productLogic = new ProductLogic();
        protected LogicBase<Productscode> ProductsCode = new LogicBase<Productscode>();
        protected LogicBase<Delivery> Delivery = new LogicBase<Delivery>();
        protected LogicBase<Order> Orders = new LogicBase<Order>();
        protected LogicBase<Orderproduct> OrderProducts = new LogicBase<Orderproduct>();
        protected LogicBase<Chemistry> Chemistry = new LogicBase<Chemistry>();
        protected ChemistryLogic ChemistryLogic = new ChemistryLogic();
        protected LogicBase<Chemistrypop> ChemistryPop = new LogicBase<Chemistrypop>();

        [TestMethod]
        public void seedowanieChemistry()
        {
            Random random = new Random();
            for (int i = 1; i < 117; i++)
            {
                Chemistry wsad = Chemistry.Insert(new Chemistry()
                {
                    Quantity = random.Next(10, 50),
                    Idproducts = i
                });
                ChemistryLogic.Reduce(wsad, 1);
            }
        }

        [TestMethod]
        public void seedowanieBazy()
        {
            int kodzikKreskowy = 4600;


            for(int i = 1; i < 30; i++)

            productLogic.SetProduct(new ProductDto()
            {
                Product = new Product()
                {
                    Name = "Olej " + kodzikKreskowy,
                    Manufacturer = "DUpa2"
                },
                Code = kodzikKreskowy++,
                DeliveryCompany = "Frankfurt"
            });
        }

        [TestMethod]
        public void SeedowanieOrders()
        {
            DateTime datka = new DateTime(2021,06,15);
            Orders.Insert(new Order
            {
                Iddeliverycompany = 2,
                Date = datka,
                Status = 2
            });
        }
        [TestMethod]
        public void SeedowanieOrderProducts()
        {
            Random random = new Random();
            for(int i = 30; i < 60; i++)
            {
                int wsad = random.Next(10, 40);
                float cena = (float)(Math.Round(10.0 / random.Next(1, 8), 2));
                OrderProducts.Insert(new Orderproduct
                {
                    Idorder = 2,
                    Status = 2,
                    Idcategories = 2,
                    Quantity = wsad,
                    Idproducts = i + 1,
                    Price = cena
                });
                Chemistry.Insert(new Chemistry
                {
                    Idproducts = i + 1,
                    Quantity = wsad,
                    Idcategories = 2
                });
                Delivery.Insert(new Delivery
                {
                    Idproducts = i + 1,
                    Iddeliverycompany = 2,
                    Price = cena
                });
            }
        }
    }
}
