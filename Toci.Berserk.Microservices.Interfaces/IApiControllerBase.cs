using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Berserk.Microservices.Interfaces
{
    public interface IApiControllerBase<TLogic, TModel>
    {
        public TModel Create(TModel model);
        public IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter);
        public bool Update(TModel model);
        public int Delete(TModel model);
    }
}
