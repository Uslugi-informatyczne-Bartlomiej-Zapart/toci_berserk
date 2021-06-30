using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Ml.Interfaces;

namespace Toci.Berserk.Bll.Ml
{
    public class ProductMlLogic : IProductMlLogic
    {
        protected virtual Dictionary<int, IOrderModel> GetProductsForOrder<TDbModel>(Func<TDbModel, IOrderModel> mapper, IQueryable<TDbModel> data)
        {
            Dictionary<int, IOrderModel> result = new Dictionary<int, IOrderModel>();

            foreach (TDbModel item in data)
            {
                IOrderModel element = mapper(item);

                if (result.ContainsKey(element.IdProduct))
                {
                    result[element.IdProduct].Quantity += element.Quantity;
                }
                else
                {
                    result.Add(element.IdProduct, element);
                }
            }
            return result;
        }
    }
}
