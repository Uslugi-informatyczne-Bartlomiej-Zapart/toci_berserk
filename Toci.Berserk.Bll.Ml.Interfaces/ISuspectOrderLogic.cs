using System.Collections.Generic;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Ml.Interfaces
{
    public interface ISuspectOrderLogic
    {
        Dictionary<int, List<Chemistrypop>> GetOrdersHistory(Order order, int depth);

        Dictionary<int, List<Chemistrypop>> GetOrdersHistory(OrderDto order);
    }
}