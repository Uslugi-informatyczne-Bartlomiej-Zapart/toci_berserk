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
    public class ProductLogicUpdateDeliveryTest
    {
        protected ProductLogic productLogic = new ProductLogic();
        protected LogicBase<Productscode> ProductsCode = new LogicBase<Productscode>();

        [TestMethod]
        public void updateDeliveryTest()
        {
            int kodzikKreskowy = 1;
            List<int?> kodziki = ProductsCode.Select(model => model.Code > 0).ToList().Select(x => x.Code).ToList();

            while (true)
            {
                if (kodziki.Contains(kodzikKreskowy))
                    kodzikKreskowy++;

                else
                    break;
            }

            productLogic.SetProduct(new ProductDto()
            {
                Product = new Product()
                {
                    Name = "dtoTest " + kodzikKreskowy,
                    Manufacturer = "Szprychy"
                },
                Code = kodzikKreskowy,
                DeliveryCompany = "FirmaDostawczaChemicalBrothers"
            });

        }
    }
}
