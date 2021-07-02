using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Berserk.Bll.Interfaces
{
    public interface ILogicBase<TModel> where TModel : class
    {
        IQueryable<TModel> Select(Func<TModel, bool> filter);

        TModel Insert(TModel model);

        bool Update(TModel model);

        int Delete(TModel model);
    }
}
