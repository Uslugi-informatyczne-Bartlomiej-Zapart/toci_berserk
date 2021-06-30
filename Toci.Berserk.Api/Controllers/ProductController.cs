using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        IProductLogic ProductLogic;
        public ProductController(IProductLogic productLogic)
        {
            ProductLogic = productLogic;
        }

        [HttpPost]
        public int SetProduct(Product prod)
        {
            return ProductLogic.SetProduct(prod);
        }
    }
}
