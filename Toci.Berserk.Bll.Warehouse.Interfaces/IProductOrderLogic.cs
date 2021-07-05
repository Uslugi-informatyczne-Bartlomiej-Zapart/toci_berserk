using System.Collections.Generic;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse.Interfaces
{
    public interface IProductOrderLogic
    {
        int AddOrders(List<Orderproduct> products);
    }
}