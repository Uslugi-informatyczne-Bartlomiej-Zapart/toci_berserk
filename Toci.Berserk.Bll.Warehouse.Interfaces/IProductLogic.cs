using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Interfaces;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse.Interfaces
{
    public interface IProductLogic : ILogicBase<Product>
    {
        public List<ProductDto> AllProducts();
        public int SetProduct(ProductDto product);
        int AddNewProduct(object product);

    }
}
