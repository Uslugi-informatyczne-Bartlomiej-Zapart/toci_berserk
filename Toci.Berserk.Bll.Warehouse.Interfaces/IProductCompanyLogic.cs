using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse.Interfaces
{
    public interface IProductCompanyLogic : ILogicBase<Productcompanysearch>
    {
        List<Productcompanysearch> GetProductsOrCompanies(string query);
    }
}
