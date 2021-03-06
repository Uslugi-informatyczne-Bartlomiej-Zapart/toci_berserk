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

        

        public Dictionary<int?, float?> AllProductsFromDeliveryCompany(int idOfDeliverCompany)
        {
            Dictionary<int?, float?> AllProductsOfCurrentCompany = new Dictionary<int?, float?>();
            IQueryable < Delivery > deliveryProducts = Select(model =>
                   model.Iddeliverycompany == idOfDeliverCompany);

            foreach(Delivery deliveryProduct in deliveryProducts)
            {
                AllProductsOfCurrentCompany.Add(deliveryProduct.Idproducts, deliveryProduct.Price);
            }

            return AllProductsOfCurrentCompany;
        }

        public void SetNewDelivery(int productId, float price, int idOfDeliverCompany)
        {
            Insert(new Delivery()
            {
                Idproducts = productId,
                Iddeliverycompany = idOfDeliverCompany,
                Price = price
            });
        }

        public Dictionary<int, string> GetDeliveryCompanies()
        {
            Dictionary<int, string> AllDeliveryCompanies = new Dictionary<int, string>();

            IQueryable Companies = DeliveryCompany.Select(model => model.Id > 0);

            foreach(Deliverycompany company in Companies)
            {
                AllDeliveryCompanies.Add(company.Id, company.Name);
            }

            return AllDeliveryCompanies;
        }
    }
}
