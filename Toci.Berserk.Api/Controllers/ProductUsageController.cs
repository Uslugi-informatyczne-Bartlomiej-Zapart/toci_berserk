using Microsoft.AspNetCore.Mvc;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;
using Toci.Berserk.Microservices;

namespace Toci.Berserk.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductUsageController : ApiControllerBase<IProductUsageLogic, Chemistrypop>
    {
        public ProductUsageController(IProductUsageLogic logic) : base(logic)
        {

        }
    }
}