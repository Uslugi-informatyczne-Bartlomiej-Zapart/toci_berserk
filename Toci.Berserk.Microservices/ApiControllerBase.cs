using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Toci.Berserk.Bll.Interfaces;
using Toci.Berserk.Microservices.Interfaces;

namespace Toci.Berserk.Microservices
{
    public abstract class ApiControllerBase<TLogic, TModel> : ControllerBase, IApiControllerBase<TLogic, TModel> where TLogic : ILogicBase<TModel> where TModel : class
    {
        protected TLogic Logic;
        protected ApiControllerBase(TLogic logic)
        {
            Logic = logic;
        }

        public virtual TModel Create(TModel model)
        {
            return Logic.Insert(model);
        }

        public virtual IQueryable<TModel> Get(Func<TModel, bool> filter)
        {
            return Logic.Select(filter);
        }

        public virtual bool Update(TModel model)
        {
            return Logic.Update(model);
        }

        public virtual int Delete(TModel model)
        {
            return Logic.Delete(model);
        }
    }
}
