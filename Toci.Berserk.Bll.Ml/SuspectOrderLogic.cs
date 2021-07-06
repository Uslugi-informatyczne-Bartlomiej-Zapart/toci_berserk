using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Berserk.Bll.Ml.Interfaces;
using Toci.Berserk.Bll.Warehouse;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Ml
{
    public class SuspectOrderLogic : LogicBase<Chemistrypop>, ISuspectOrderLogic
    {
        protected LogicBase<Order> orders = new LogicBase<Order>();
        
        public Order LastAccomplishedOrderDate() => orders.Select(model => model.Status == ProductOrderLogic.OrderAccomplished)
                .OrderByDescending(model => model.Date).First();

        protected int DaysDifferenceToToday(DateTime lastOrderData) => (int)(DateTime.Now - lastOrderData).TotalDays;

        public virtual Dictionary<int, List<Chemistrypop>> GetOrdersHistory(Order order, int depth)
        {
            Dictionary<int, List<Chemistrypop>> result = new Dictionary<int, List<Chemistrypop>>();
            
            int totalDaysFromLastOrder = DaysDifferenceToToday(order.Date.Value);
            DateTime current = order.Date.Value;
            DateTime interval = DateTime.Now;
            
            for (int i = 0, j = 0; i < totalDaysFromLastOrder * depth; i+= totalDaysFromLastOrder)
            {
                IQueryable<Chemistrypop> elements = Select(model => model.Date < interval && model.Date > current);
                result.Add(j++, elements.ToList());

                current.AddDays(-totalDaysFromLastOrder);
                interval.AddDays(-totalDaysFromLastOrder);
            }

            return result;
        }
    }
}