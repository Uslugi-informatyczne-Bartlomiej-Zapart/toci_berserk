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
        public void AddUniqueProductWithCode()
        {
            ProductLogic productLogic = new ProductLogic();
            /*productLogic.Update(new Product()
            {
                Id = 1,
                Name = "XXX"
            });*/
            Product newOne = productLogic.Insert(new Product()
            {
                Name = "Farba do drewna",
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
    }
}