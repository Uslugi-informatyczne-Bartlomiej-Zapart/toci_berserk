using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class DeliveryLogic : LogicBase<Delivery>, IDeliveryLogic
    {
        protected LogicBase<Deliverycompany> DeliveryCompany = new LogicBase<Deliverycompany>();
        public void UpdateDeliveryPrice(int? productId, float? price, int? idOfDeliverCompany)
        {
            var ele = 
                Select(model => model.Idproducts == productId && model.Iddeliverycompany == idOfDeliverCompany).First();
            ele.Price = price;
            Update(ele);
        }

        public int SetNewDeliveryCompany(string deliveryCompany)
        {
            int idOfDeliverCompany;

            Deliverycompany company = DeliveryCompany.Select(model => model.Name.Equals(deliveryCompany)).FirstOrDefault();

            if (company == null)
            {
                idOfDeliverCompany = DeliveryCompany.Insert(new Deliverycompany()
                {
                    Name = deliveryCompany
                }).Id;
            }
            else
                idOfDeliverCompany = company.Id;

            return idOfDeliverCompany;
        }

        public List<int?> AllProductsFromDeliveryCompany(List<int?> listOfIDs, int idOfDeliverCompany) => Select(model =>
                model.Iddeliverycompany == idOfDeliverCompany).ToList().Select(x => x.Idproducts).ToList();

        public void SetNewDelivery(int productId, float price, int idOfDeliverCompany)
        {
            Insert(new Delivery()
            {
                Idproducts = productId,
                Iddeliverycompany = idOfDeliverCompany,
                Price = price
            });
        }
    }
}
