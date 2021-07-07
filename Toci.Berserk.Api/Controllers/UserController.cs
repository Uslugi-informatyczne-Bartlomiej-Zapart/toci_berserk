using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;
using Toci.Berserk.Microservices;

namespace Toci.Berserk.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiControllerBase<IUserLogic, User>
    {
        public UserController(IUserLogic userLogic) : base(userLogic)
        {

        }

        [HttpGet]
        [Route("Register")]
        public void Register()
        {

        }

        [HttpPost]
        [Route("Register")]
        public void RegisterUser(UserDto User)
        {

        }


        [HttpGet]
        [Route("Login")]
        public void Login()
        {

        }

        [HttpPost]
        [Route("Login")]
        public void LoginUser(UserDto User)
        {

        }
    }
}
