using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Berserk.Bll.Ml.Interfaces;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Ml
{
    public class SuspectOrderLogic : LogicBase<Chemistrypop>, ISuspectOrderLogic
    {
        public const int OrderSent = 1;
        public const int OrderAccomplished = 2;

        protected LogicBase<Order> Orders = new LogicBase<Order>();

        public Order LastAccomplishedOrderDate() => Orders
            .Select(model => model.Status == OrderAccomplished)
            .OrderByDescending(model => model.Date).First();

        protected int DaysDifferenceToToday(DateTime lastOrderData) => (int) (DateTime.Now - lastOrderData).TotalDays;

        public virtual Dictionary<int, List<Chemistrypop>> GetOrdersHistory(Order order, int depth)
        {
            Dictionary<int, List<Chemistrypop>> result = new Dictionary<int, List<Chemistrypop>>();

            DateTime pastOrderDate = LastAccomplishedOrderDate().Date.Value;
            int totalDaysFromLastOrder = DaysDifferenceToToday(pastOrderDate);
            
            DateTime current = DateTime.Now;

            for (int i = 0, j = 0; i < totalDaysFromLastOrder * depth; i += totalDaysFromLastOrder)
            {
                IQueryable<Chemistrypop> elements = Select(model => model.Date > pastOrderDate && model.Date < current);
                result.Add(j++, elements.ToList());

                current.AddDays(-totalDaysFromLastOrder);
                pastOrderDate.AddDays(-totalDaysFromLastOrder);
            }

            return result;
        }

        public virtual Dictionary<int, List<Chemistrypop>> GetOrdersHistory(OrderDto order)
        {
            //The prediction will base upon the name of the company and the scope of the date. 
            LogicBase<Delivery> delivery = new LogicBase<Delivery>();
            List<int?> idOfProducts = new List<int?>();
            Dictionary<int, List<Chemistrypop>> result = new Dictionary<int, List<Chemistrypop>>();
            List<List<Chemistrypop>> listsOfChemistrypops = new List<List<Chemistrypop>>();
            List<Chemistrypop> listOfChemistrypops = new List<Chemistrypop>();
            int deliveryCompanyId;

            deliveryCompanyId = order.deliveryCompanyId;
            //It is a collection of all goods ordered by the delivery company ever.
            idOfProducts = delivery.Select(model => model.Iddeliverycompany == deliveryCompanyId).Select(x => x.Idproducts).ToList();

            //The traverse process over the history of products pops which purpose is to collect pops based on product and date scope.
            listsOfChemistrypops = idOfProducts.Select(x => Select(model => model.Idproducts == x && model.Date >= order.dateScope).ToList()).ToList();

            listOfChemistrypops = listsOfChemistrypops.SelectMany(x => x.Select(y => y)).ToList();

            result.Add(1, listOfChemistrypops);

            return result;
            
            /*
             * Wnioski
             * delivery table musi uaktualniać rekordy w trakcie przyjęcia ordersa
             * delivery table rekordy muszą być na swój sposób unikalne
             * dlatego w trakcie przyjęcia ordersa danej firmy musi zostać wyfiltrowana tabela delivery w stosunku
             * do current delivery company (performance!!)
             * w trakcie tworzenia ordersa do danej firmy user dostaje liste wszystkich towarów kiedykolwiek dostarczonych przez
             * danego dostawce wraz z proponowaną liczbą sztuk
             * proponowana liczba sztuk musi brać pod uwagę obecny stan sztuk!!
             * chyba było by dobrze by user mógł zlikwidować przynależność danego produktu do danej delivery company (nie wiem albo flaga
             * albo wywalania rekordów z tabeli)
             *
             * Następny punkt -> napisać logikę dla sytuacji gdy jeden produkt ma kilka kodów 
             */
        }
    }
}