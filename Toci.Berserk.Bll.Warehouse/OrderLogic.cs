using System;
using System.Linq;
using System.Linq.Expressions;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class OrderLogic : LogicBase<Orderproduct>, IOrderLogic
    {
        //public Order CreateOrderByDeliveryCompany
        public IQueryable<Order> Select(Expression<Func<Order, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Order Insert(Order model)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order model)
        {
            throw new NotImplementedException();
        }

        public int Delete(Order model)
        {
            throw new NotImplementedException();
        }
    }
}