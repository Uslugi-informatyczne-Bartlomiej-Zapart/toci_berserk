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

        [TestMethod]
        public void seedowanieBazy()
        {
            int kodzikKreskowy = 4345;


            for(int i = 1; i < 30; i++)

            productLogic.SetProduct(new ProductDto()
            {
                Product = new Product()
                {
                    Name = "Owsiana Dupka " + kodzikKreskowy,
                    Manufacturer = "ROW Rybnik"
                },
                Code = kodzikKreskowy++,
                DeliveryCompany = "FirmaDostawczaZdzicho"
            });
        }

        [TestMethod]
        public void SeedowanieDelivery()
        {
            IQueryable orders = Orders.Select(model => model.Id > 0);
            foreach (Order order in orders)
            {
                IQueryable orderProducts = OrderProducts.Select(model => model.Idorder == order.Id);
                foreach (Orderproduct produkt in orderProducts )
                {
                    Delivery.Insert(new Delivery()
                        {
                            Idproducts = produkt.Idproducts,
                            Iddeliverycompany = order.Iddeliverycompany,
                            Price = produkt.Price
                        }
                    );
                }
            }
        }

        //[TestMethod]
        //public void updateCenyDelivery()
        //{
        //    productLogic.idOfDeliverCompany = 4;
        //    productLogic.IDsOfProductsFromCurrentDeliveryCompany.Add(1);
        //    productLogic.UpdateDeliveryTable(1, 9.99f);
        //}
    }
}
