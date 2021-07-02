using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Berserk.Database.Interfaces
{
    public interface IDbHandle<TModel>
    {
        IQueryable<TModel> Select();

        TModel Insert(TModel model);

        bool Update(TModel model);

        int Delete(TModel model);
    }
}
