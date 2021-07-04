using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;
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

        [HttpPost]
        public virtual TModel Create(TModel model)
        {
            return Logic.Insert(model);
        }

        [HttpGet]
        public virtual IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter)
        {
            return Logic.Select(filter);
        }

        [HttpPut]
        public virtual bool Update(TModel model)
        {
            return Logic.Update(model);
        }

        [HttpDelete]
        public virtual int Delete(TModel model)
        {
            return Logic.Delete(model);
        }
    }
}
