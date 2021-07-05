using System.Collections.Generic;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class ProductOrderLogic : LogicBase<Orderproduct>, IProductOrderLogic
    {
        public const int OrderSent = 1;
        public const int OrderAccomplished = 2;
        protected LogicBase<Order> orderLogic = new LogicBase<Order>();
        public int AddOrders(List<Orderproduct> products)
        {
            int id = orderLogic.Insert(new Order()).Id;

            foreach (Orderproduct product in products)
            {
                product.Idorder = id;

                Insert(product);
            }

            return id;
        }

        //public List<Orderproduct> GetOrderByStatus(int status)
        //{

        //}
    }
}