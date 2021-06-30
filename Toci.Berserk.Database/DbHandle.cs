using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using static Toci.Berserk.Database.Interfaces.IDbHandle;

namespace Toci.Berserk.Database
{
    public class DbHandle<TModel> : IDbHandle<TModel> where TModel : class
    {
        protected DbContext DatabaseHandle;

        public DbHandle(DbContext databaseHandle)
        {
            DatabaseHandle = databaseHandle;
        }

        public int Delete(TModel model)
        {
            DatabaseHandle.Remove(model);

            return DatabaseHandle.SaveChanges();
        }

        public TModel Insert(TModel model)
        {
            EntityEntry entr = DatabaseHandle.Set<TModel>().Add(model);

            DatabaseHandle.SaveChanges();

            return (TModel)(entr.Entity);
        }

        public IQueryable<TModel> Select()
        {
            return DatabaseHandle.Set<TModel>();

        }

        public bool Update(TModel model)
        {
            DatabaseHandle.Update(model);

            return DatabaseHandle.SaveChanges() > 0;
        }
    }
}
