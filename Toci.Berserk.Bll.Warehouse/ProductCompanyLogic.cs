using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class ProductCompanyLogic : LogicBase<Productcompanysearch>, IProductCompanyLogic
    {
        protected IDeliveryLogic DeliveryLogic = new DeliveryLogic();
        protected IProductOrderLogic ProductOrderLogic = new ProductOrderLogic();

        public virtual List<ProductCompanySearchDto> GetProductsOrCompanies(string query)
        {
            List<ProductCompanySearchDto> result = new List<ProductCompanySearchDto>();

            IQueryable<Productcompanysearch> res;

            query = query.ToLower();

            int codeOrRef = 0;

            int.TryParse(query, out codeOrRef);

            if (codeOrRef > 0)
            {
                res = Select(m => m.Code == codeOrRef || m.Reference.ToString().StartsWith(codeOrRef.ToString()));
            }
            else
            {
                res = Select(m => m.Name.ToLower().StartsWith(query) || m.Companyname.ToLower().StartsWith(query) || m.Manufacturer.ToLower().StartsWith(query));
            }

            foreach (Productcompanysearch item in res)
            {
                OrderProductDto opd = ProductOrderLogic.GetProductExpectedQuantity(item.Idproducts.Value);

                result.Add(new ProductCompanySearchDto() { 
                    Companyname = item.Companyname,
                    Code = item.Code,
                    CurrentQuantity = opd.Currentquantity,
                    ExpectedOrderQuantity = opd.ExpectedOrderQuantity,
                    Idproducts = item.Idproducts,
                    Iddeliverycompany = item.Iddeliverycompany,
                    Manufacturer = item.Manufacturer,
                    Name = item.Name,
                    Price = item.Price,
                    CompaniesPerProduct = opd.CompaniesPerProduct
                });
            }

            return result;
        }
    }
}
