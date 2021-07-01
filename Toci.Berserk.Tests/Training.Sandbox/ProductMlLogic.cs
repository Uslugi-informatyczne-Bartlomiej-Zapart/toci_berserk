using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Berserk.Tests.Training.Sandbox
{
    public abstract class ProductMlLogic<TDbModel> : IProductMl
    {
        protected virtual Dictionary<int, IOrderModel> TranslateRandomDatabaseTableToOneOrderModel(
            IQueryable<TDbModel> items)
        {
            Dictionary<int, IOrderModel> summary = new Dictionary<int, IOrderModel>();

            foreach (TDbModel item in items)
            {
                IOrderModel element = Mapper(item);
                if (summary.ContainsKey(element.IdProduct))
                {
                    summary[element.IdProduct].Quantity += element.Quantity;
                }
                else
                {
                    summary.Add(element.IdProduct, element);
                }
            }

            return summary;
        }

        protected abstract IOrderModel Mapper(TDbModel item);
    }
}
