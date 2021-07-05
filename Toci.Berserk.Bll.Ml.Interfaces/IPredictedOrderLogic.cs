using Toci.Berserk.Bll.Models;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Ml.Interfaces
{
    public interface IPredictedOrderLogic
    {
        public int CreateOrder(PredictedOrderDto order);
    }
}