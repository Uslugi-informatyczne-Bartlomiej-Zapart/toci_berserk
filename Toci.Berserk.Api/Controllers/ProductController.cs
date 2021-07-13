using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;
using Toci.Berserk.Microservices;

namespace Toci.Berserk.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ApiControllerBase<IProductLogic, Product>
    {
        public ProductController(IProductLogic productlogic) : base(productlogic)
        {

        }

        [HttpPost]
        [Route("SetUniqueProduct")]
        public void SetUniqueProduct(ProductDto product)
        {
            Logic.SetProduct(product);
        }

        [HttpGet]
        [Route("Products")]
        public List<ProductDto> GetAll()
        {
            return Logic.AllProducts();
        }
    }
}
