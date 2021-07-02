using System;
using System.Linq;
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

        public virtual IQueryable<TModel> Select(Func<TModel, bool> filter)
        {
            return DbHandle.Select().Where(x => filter(x));
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
