﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;
using Toci.Berserk.Microservices;

namespace Toci.Berserk.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductOrderController : ApiControllerBase<IProductOrderLogic, Orderproduct>
    {
        public ProductOrderController(IProductOrderLogic logic) : base(logic)
        {
            
        }

        [HttpGet]
        [Route("NewProductsOrder")]
        public List<OrderProductDto> GetNewProductsOrder()
        {
            return Logic.GetSuspectedOrder();
        }
    }
}