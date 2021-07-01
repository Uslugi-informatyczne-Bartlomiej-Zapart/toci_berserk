using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Ml.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Ml
{
    public class ProductHistoryMlLogic : ProductMlLogic<Chemistrypop>, IProductHistoryMlLogic
    {
        protected override IOrderModel Mapper(Chemistrypop item)
        {
            IOrderModel result = new OrderModel();

            result.Quantity = item.Quantity.Value;
            result.Date = item.Date.Value;
            result.IdProduct = item.Idproducts.Value;

            return result;
        }
    }
}
