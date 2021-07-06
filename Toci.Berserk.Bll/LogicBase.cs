using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Toci.Berserk.Bll.Interfaces;
using Toci.Berserk.Database;
using Toci.Berserk.Database.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll
{
    public class LogicBase<TModel> : ILogicBase<TModel> where TModel : class
    {
        protected virtual DbContext GetEfHandle()
        {
            return new BerserkWmsContext();
        }

        public virtual TModel Insert(TModel model)
        {
            IDbHandle<TModel> DbHandle = new DbHandle<TModel>(GetEfHandle);

            return DbHandle.Insert(model);
        }

        public virtual IQueryable<TModel> Select(Expression<Func<TModel, bool>> filter)
        {
            IDbHandle<TModel> DbHandle = new DbHandle<TModel>(GetEfHandle);
            
            return DbHandle.Select().Where(filter).AsQueryable();
        }

        public virtual bool Update(TModel model)
        {
            IDbHandle<TModel> DbHandle = new DbHandle<TModel>(GetEfHandle);

            return DbHandle.Update(model);
        }

        public virtual int Delete(TModel model)
        {
            IDbHandle<TModel> DbHandle = new DbHandle<TModel>(GetEfHandle);

            return DbHandle.Delete(model);
        }
    }
}
