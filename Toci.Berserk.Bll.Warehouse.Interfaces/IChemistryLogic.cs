using Toci.Berserk.Bll.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse.Interfaces
{
    public interface IChemistryLogic : ILogicBase<Chemistry>
    {
        public int ReceiveOrder(Chemistry chemistry, float? price, int? idOfDeliverCompany);
        public int Reduce(Chemistry chemistry, int userId);
    }
}