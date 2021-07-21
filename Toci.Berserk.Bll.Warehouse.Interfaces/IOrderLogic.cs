using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Berserk.Bll.Interfaces;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse.Interfaces
{
    public interface IOrderLogic : ILogicBase<Order>
    {
        public IQueryable<Order> AllOrders();
        public Dictionary<int, List<Chemistrypop>> CreateOrderByDeliveryCompany(OrderDto order);

        public IQueryable<Order> GetCompletedOrders(DateTime dateFrom, DateTime dateTo);
        public int CreateOrder(OrderDto order);

        public Dictionary<int, string> AllCompanies();
    }
}