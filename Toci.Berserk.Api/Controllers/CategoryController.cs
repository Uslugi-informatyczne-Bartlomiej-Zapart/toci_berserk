using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;
using Toci.Berserk.Microservices;

namespace Toci.Berserk.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ApiControllerBase<ICategoryLogic, Category>
    {
        public CategoryController(ICategoryLogic categoryLogic) : base(categoryLogic)
        {
        }

        [HttpGet]
        [Route("getAllCategories")]
        public List<Category> getAllCategories()
        {
            return Logic.Select(category => category.Id > 0).ToList();
        }
    }
}