using System.Collections.Generic;
using Toci.Berserk.Bll.Interfaces;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse.Interfaces
{
    public interface IProductOrderLogic : ILogicBase<Orderproduct>
    {
        int AddOrders(List<Orderproduct> products, int deliveryCompanyID);

        List<OrderProductDto> GetSuspectedOrder();

        int SetSuspectedOrder(List<OrderProductDto> products);

        OrderProductDto GetProductExpectedQuantity(int productId);
    }
}