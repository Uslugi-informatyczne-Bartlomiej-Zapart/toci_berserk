using System;
using System.Linq;
using System.Linq.Expressions;
using Toci.Berserk.Bll.Interfaces;
using Toci.Berserk.Database;
using Toci.Berserk.Database.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll
{
    public abstract class LogicBase<TModel> : ILogicBase<TModel> where TModel : class
    {
        protected IDbHandle<TModel> DbHandle = new DbHandle<TModel>(new BerserkWmsContext());

        public virtual TModel Insert(TModel model)
        {
            return DbHandle.Insert(model);
        }

        public virtual IQueryable<TModel> Select(Expression<Func<TModel, bool>> filter)
        {
            return DbHandle.Select().Where(filter).AsQueryable();
        }

        public virtual bool Update(TModel model)
        {
            return DbHandle.Update(model);
        }

        public virtual int Delete(TModel model)
        {
            return DbHandle.Delete(model);
        }
    }
}
