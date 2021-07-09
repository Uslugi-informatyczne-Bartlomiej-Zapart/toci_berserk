using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse.Interfaces
{
    public interface IChemistryLogic
    {
        public int ReceiveOrder(Chemistry chemistry, float? price, int? idOfDeliverCompany);
        public int Reduce(Chemistry chemistry, int userId);
    }
}