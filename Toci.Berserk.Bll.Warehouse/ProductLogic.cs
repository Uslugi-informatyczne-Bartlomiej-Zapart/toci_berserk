using System;
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

        public int SetProduct(ProductDto product, string deliveryCompany)
        {
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

                UpdateDeliveryTable(product.Product.Id, deliveryCompany);

                return product.Product.Id;
            }

            Product Pld = Insert(product.Product);
            ProductsCodeLogic.Insert(new Productscode()
            {
                Code = product.Code,
                Idproducts = Pld.Id
            });

            UpdateDeliveryTable(Pld.Id, deliveryCompany);

            return Pld.Id;
        }

        private bool UpdateDeliveryTable(int productId, string deliveryCompany)
        {
            return true;
        }
    }
}
