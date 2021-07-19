using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class ProductCompanyLogic : LogicBase<Productcompanysearch>, IProductCompanyLogic
    {
        protected IDeliveryLogic DeliveryLogic = new DeliveryLogic();
        protected IProductLogic ProductLogic = new ProductLogic();

        public virtual List<Productcompanysearch> GetProductsOrCompanies(string query)
        {
            query = query.ToLower();

            int codeOrRef = 0;

            int.TryParse(query, out codeOrRef);

            if (codeOrRef > 0)
            {
                return Select(m => m.Code == codeOrRef || m.Reference.ToString().StartsWith(codeOrRef.ToString())).ToList();
            }

            return Select(m => m.Name.ToLower().StartsWith(query) || m.Companyname.ToLower().StartsWith(query) || m.Manufacturer.ToLower().StartsWith(query)).ToList();
        }
    }
}
