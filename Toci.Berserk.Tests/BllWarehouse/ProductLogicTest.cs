using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Tests.BllWarehouse
{
    [TestClass]
    public class ProductLogicTest
    {
        [TestMethod]
        public void AddProductToTestHistory()
        {
            ProductLogic productLogic = new ProductLogic();
            //productLogic.Update(new Product()
            //{
            //    Id = 1,
            //    Name = "XXX"
            //});
            Product newOne = productLogic.Insert(new Product()
            {
                Name = "Farba",
                Manufacturer = "Farby S.A."
            });

            ProductsCodeLogic productsCodeLogic = new ProductsCodeLogic();

            productsCodeLogic.Insert(new Productscode()
            {
                Idproducts = newOne.Id,
                Code = 111111
            });

            productLogic.SetProduct(new ProductDto()
            {
                Product = new Product()
                {
                    Id = newOne.Id,
                    Name = "Farba do metalu"
                },
                Code = 111111
            });
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