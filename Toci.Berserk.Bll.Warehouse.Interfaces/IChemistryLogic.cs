using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse.Interfaces
{
    public interface IChemistryLogic
    {
        public int ReceiveOrder(Chemistry chemistry);
        public int Reduce(Chemistry chemistry, int userId);
    }
}