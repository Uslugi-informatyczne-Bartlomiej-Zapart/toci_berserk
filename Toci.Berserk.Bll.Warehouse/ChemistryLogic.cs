using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class ChemistryLogic : LogicBase<Chemistry>, IChemistryLogic
    {
        protected LogicBase<Chemistrypop> ChemistryPop = new LogicBase<Chemistrypop>();
        protected IDeliveryLogic DeliveryLogic = new DeliveryLogic();
        public int ReceiveOrder(Chemistry chemistry, float? price, int? idOfDeliveryCompany)
        {
            /*Ta metoda odpowiada za przyjecie poszczegolnych produktow z zamowienia na stan
             deliverylogic musi za kazdym razem zrobic update ceny tak by przyszle zamownienie
            mialo na czym bazowa tzn wybrac zamowienie tego samego produktu ale do firmy oferujocej
            dany produkt taniej
            logika decyzji o wyboru firmy na podstawie ceny musi bazowac na cenie oraz ostatniej
            dacie dostarczenia danego produktu*/
            Chemistry item = Select(model => model.Idproducts == chemistry.Idproducts).FirstOrDefaultAsync().Result;

            DeliveryLogic.UpdateDeliveryPrice(chemistry.Idproducts, price, idOfDeliveryCompany);

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
            Random r = new Random();
            DateTime start = new DateTime(2016, 1, 1);
            item.Quantity -= chemistry.Quantity;

            Update(item);

            ChemistryPop.Insert(new Chemistrypop()
            {
                Idproducts = item.Idproducts,
                Idusers = userId,
                Quantity = chemistry.Quantity,
                Date = start.AddDays(r.Next((DateTime.Today - start).Days))
            });

            return item.Id;
        }
    }
}