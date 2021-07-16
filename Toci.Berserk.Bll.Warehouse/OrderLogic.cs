using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Toci.Berserk.Bll.Ml;
using Toci.Berserk.Bll.Ml.Interfaces;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    //This class is a connection point between the front and back of the application.
    //A user can create orders.
    public class OrderLogic : LogicBase<Order>, IOrderLogic
    {
        protected SuspectOrderLogic SuspectOrderLogic = new SuspectOrderLogic();
        protected DeliveryLogic DeliveryLogic = new DeliveryLogic();
        public IQueryable<Order> AllOrders()
        {
            return Select(model => model.Id > 0);
        }

        public Dictionary<int, List<Chemistrypop>> CreateOrderByDeliveryCompany(OrderDto order)
        {
            order.deliveryCompanyId = DeliveryLogic.SetNewDeliveryCompany(order.deliveryCompanyName);
            var respond = SuspectOrderLogic.GetOrdersHistory(order);
            return respond;
        }

        public IQueryable<Order> GetCompletedOrders(DateTime dateFrom, DateTime dateTo)
        {
            return Select(m => m.Date >= dateFrom && m.Date <= dateTo);
        }

        public int CreateOrder(OrderDto order)
        {
            order.deliveryCompanyId = DeliveryLogic.SetNewDeliveryCompany(order.deliveryCompanyName);

            return Insert(new Order()
            {
                Date = order.dateScope,
                Iddeliverycompany = order.deliveryCompanyId,
                Status = order.Status
            }).Id;
        }
    }
}