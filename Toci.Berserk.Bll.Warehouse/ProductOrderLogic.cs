using System.Collections.Generic;
using System.Linq;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class ProductOrderLogic : LogicBase<Orderproduct>, IProductOrderLogic
    {
        public const int OrderSent = 1;
        public const int OrderAccomplished = 2;

        protected LogicBase<Order> orderLogic = new LogicBase<Order>();
        protected IChemistryLogic chemistryLogic = new ChemistryLogic();

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

        public virtual bool ManipulateOrder(int orderId)
        {
            IQueryable<Orderproduct> orderProducts = Select(model => model.Idorder == orderId && model.Status == OrderSent);

            if (orderProducts.Any())
            {
                foreach (Orderproduct order in orderProducts)
                {
                    chemistryLogic.ReceiveOrder(new Chemistry()
                    {
                        Idproducts = order.Idproducts,
                        Quantity = order.Quantity
                    });

                    order.Status = OrderAccomplished;

                    Update(order);
                }

                return true;
            }

            return false;
        }

        public IQueryable<Orderproduct> GetProductsOrders(int status)
        {
            return Select(model => model.Status == status);
        }
    }
}