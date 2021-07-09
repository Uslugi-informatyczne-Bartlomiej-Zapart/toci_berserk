using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class ProductLogic : LogicBase<Product>, IProductLogic
    {
        protected LogicBase<Productscode> ProductsCodeLogic = new ProductsCodeLogic();
        protected LogicBase<Productshistory> ProductsHistoryLogic = new ProductHistoryLogic();
        protected LogicBase<Deliverycompany> DeliveryCompany = new LogicBase<Deliverycompany>();
        protected LogicBase<Delivery> DeliveryList = new LogicBase<Delivery>();

        protected List<int?> IDsOfProductsFromCurrentDeliveryCompany = new List<int?>();
        protected string deliveryCompanyName = null;
        protected bool flagOfHistoryDeliveryList = false;
        protected int idOfDeliverCompany;

        public int SetProduct(ProductDto product)
        {
            if (!flagOfHistoryDeliveryList)
                ObtainDeliverCompanyId(product.DeliveryCompany);

            Productscode item = ProductsCodeLogic.Select(model => model.Code == product.Code).FirstOrDefault();

            if (item != null)
            {
                Product productToUpdate = Select(model => model.Id == item.Idproducts).AsNoTracking().First();

                ProductsHistoryLogic.Insert(new Productshistory()
                {
                    Iddeletedproduct = productToUpdate.Id,
                    Name = productToUpdate.Name,
                    Manufacturer = productToUpdate.Manufacturer,
                    Reference = productToUpdate.Reference,
                    Iddeletedproductscodes = item.Id,
                    Code = item.Code
                });

                product.Product.Id = item.Idproducts.Value;
                
                Update(product.Product);

                UpdateDeliveryTable(product.Product.Id, product.Price);

                return product.Product.Id;
            }

            Product Pld = Insert(product.Product);
            ProductsCodeLogic.Insert(new Productscode()
            {
                Code = product.Code,
                Idproducts = Pld.Id
            });

            UpdateDeliveryTable(Pld.Id, product.Price);

            return Pld.Id;
        }

      

        private void ObtainDeliverCompanyId(string deliveryCompany)
        {
            if (string.IsNullOrEmpty(deliveryCompanyName) || !deliveryCompanyName.Equals(deliveryCompany))
            {
                deliveryCompanyName = deliveryCompany;
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

                flagOfHistoryDeliveryList = true;
                //If error than possibly by null list
                IDsOfProductsFromCurrentDeliveryCompany = DeliveryList.Select(model =>
                    model.Iddeliverycompany == idOfDeliverCompany).ToList().Select(x => x.Idproducts).ToList();
            }
        }

        private void UpdateDeliveryTable(int productId, float price)
        {
            if (!IDsOfProductsFromCurrentDeliveryCompany.Contains(productId))
            {
                IDsOfProductsFromCurrentDeliveryCompany.Add(productId);
                DeliveryList.Insert(new Delivery()
                {
                    Idproducts = productId,
                    Iddeliverycompany = idOfDeliverCompany,
                    Price = price
                });
            }
            else
            {
                var ele = DeliveryList
                    .Select(model => model.Idproducts == productId && model.Iddeliverycompany == idOfDeliverCompany).First();
                ele.Price = price;
                DeliveryList.Update(ele);
            }
        }
    }
}
/*
 *  It is the general rule about entering the records process into the delivery table.
 *  Obtain the delivery company ID
    Check the delivery name variable.
    Empty delivery history list if the delivery name has been updated.
    Fulfil delivery history list if empty.
    Check if the current product exists in the history list.
    If a current product doesn't exist in the delivery history list, insert a new record into the delivery table and delivery history list.
 */
