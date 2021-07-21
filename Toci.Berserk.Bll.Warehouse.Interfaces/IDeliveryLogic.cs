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
        public Dictionary<int?, float?> AllProductsFromDeliveryCompany(int idOfDeliverCompany);
        public void SetNewDelivery(int productId, float price, int idOfDeliverCompany);
        public Dictionary<int, string> GetDeliveryCompanies();
    }
}
