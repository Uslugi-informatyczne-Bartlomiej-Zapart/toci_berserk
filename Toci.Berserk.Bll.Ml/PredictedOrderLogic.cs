using Toci.Berserk.Bll.Ml.Interfaces;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Ml
{
    public class PredictedOrderLogic : LogicBase<Predictedorder>, IPredictedOrderLogic
    {
        protected LogicBase<Predictedorderquantity> PredictedOrderQuantity = new LogicBase<Predictedorderquantity>();
        public int CreateOrder(PredictedOrderDto order)
        {
            int id = Insert(new Predictedorder()
            {
                Idorder = order.IdOrder,
                Idproducts = order.IdProduct
            }).Id;

            return PredictedOrderQuantity.Insert(new Predictedorderquantity()
            {
                Idmetric = order.IdMetric,
                Quantity = order.Quantity,
                Idpredictedorder = id
            }).Id;
        }
    }
}