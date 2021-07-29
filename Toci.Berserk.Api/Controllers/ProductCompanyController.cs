using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;
using Toci.Berserk.Microservices;

namespace Toci.Berserk.Api.Controllers
{
    public class ProductCompanyController : ApiControllerBase<IProductCompanyLogic, Productcompanysearch>
    {
        public ProductCompanyController(IProductCompanyLogic Logic) : base(Logic)
        { }

        [HttpGet]
        [Route("Search")]
        public List<ProductCompanySearchDto> Search(string query)
        {
            return Logic.GetProductsOrCompanies(query);
        }
    }
}
