using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Berserk.Bll.Warehouse.Interfaces
{
    public interface IDeliveryLogic
    {
        public void UpdateDeliveryPrice(int? productId, float? price, int? idOfDeliverCompany);
        public int SetNewDeliveryCompany(string deliveryCompany);
        public List<int?> AllProductsFromDeliveryCompany(List<int?> listOfIDs, int idOfDeliverCompany);
        public void SetNewDelivery(int productId, float price, int idOfDeliverCompany);
    }
}
