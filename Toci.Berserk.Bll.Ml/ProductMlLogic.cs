using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Ml.Interfaces;

namespace Toci.Berserk.Bll.Ml
{
    public abstract class ProductMlLogic<TDbModel> : IProductMlLogic
    {
        protected virtual Dictionary<int, IOrderModel> GetProductsForOrder(IQueryable<TDbModel> data)
        {
            Dictionary<int, IOrderModel> result = new Dictionary<int, IOrderModel>();

            foreach (TDbModel item in data)
            {
                IOrderModel element = Mapper(item);

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

        protected abstract IOrderModel Mapper(TDbModel item);
    }
}
