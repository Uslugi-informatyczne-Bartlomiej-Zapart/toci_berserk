using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class ProductCompanyLogic : LogicBase<Productcompany>, IProductCompanyLogic
    {
        protected IDeliveryLogic DeliveryLogic = new DeliveryLogic();
        protected IProductLogic ProductLogic = new ProductLogic();

        public void List(string wildcard)
        {
             
        }
    }
}
