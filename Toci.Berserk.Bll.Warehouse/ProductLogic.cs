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
        public int SetProduct(ProductDto uniqueProduct)
        {
            Productscode item = ProductsCodeLogic.Select(model => model.Code == uniqueProduct.Code).AsNoTracking().FirstOrDefault();

            if (item != null)
            {
                uniqueProduct.Product.Id = item.Idproducts.Value;
                Update(uniqueProduct.Product);
            }
            else
            {
                
            }

            return 0;
        }
    }
}
