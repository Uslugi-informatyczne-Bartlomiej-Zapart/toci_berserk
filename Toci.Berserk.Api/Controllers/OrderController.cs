using Microsoft.AspNetCore.Mvc;
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
    public class OrderController : ApiControllerBase<IOrderLogic, Order>
    {
        public OrderController(IOrderLogic orderLogic) : base(orderLogic)
        {
        }

        [HttpGet]
        [Route("Orders")]
        public IQueryable<Order> GetAllOrders()
        {
            return Logic.AllOrders();
        }

        [HttpPost]
        [Route("OrderByDeliveryCompany")]
        public Dictionary<int, List<Chemistrypop>> OrderByDeliveryCompany(OrderDto order)
        {
            return Logic.CreateOrderByDeliveryCompany(order);
        }
    }
}
