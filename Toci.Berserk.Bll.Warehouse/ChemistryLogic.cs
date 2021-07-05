using System.Linq;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class ChemistryLogic : LogicBase<Chemistry>, IChemistryLogic
    {
        protected LogicBase<Chemistrypop> ChemistryPop = new LogicBase<Chemistrypop>();
        public int ReceiveOrder(Chemistry chemistry)
        {
            Chemistry item = Select(model => model.Idproducts == chemistry.Idproducts).FirstOrDefault();

            if (item == null)
            {
                return Insert(chemistry).Id;
            }

            item.Quantity += chemistry.Quantity;

            Update(item);

            return item.Id;
        }

        public int Reduce(Chemistry chemistry, int userId)
        {
            Chemistry item = Select(model => model.Idproducts == chemistry.Idproducts).First();

            item.Quantity -= chemistry.Quantity;

            Update(item);

            ChemistryPop.Insert(new Chemistrypop()
            {
                Idproducts = item.Idproducts,
                Idusers = userId,
                Quantity = chemistry.Quantity
            });

            return item.Id;
        }
    }
}