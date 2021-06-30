using System;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class ProductLogic : LogicBase<Product>, IProductLogic
    {
        public int SetProduct(Product prod)
        {
            return DbHandle.Insert(prod).Id;
        }
    }
}
