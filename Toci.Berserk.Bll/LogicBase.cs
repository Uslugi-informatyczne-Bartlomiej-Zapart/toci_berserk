using System;
using Toci.Berserk.Bll.Interfaces;
using Toci.Berserk.Database;
using Toci.Berserk.Database.Persistence.Models;
using static Toci.Berserk.Database.Interfaces.IDbHandle;

namespace Toci.Berserk.Bll
{
    public class LogicBase<TModel> : ILogicBase<TModel> where TModel : class
    {
        protected IDbHandle<TModel> DbHandle = new DbHandle<TModel>(new BerserkWpsContext());
    }
}
