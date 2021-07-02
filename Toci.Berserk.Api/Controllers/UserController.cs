using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserLogic UserLogic;
        public UserController(IUserLogic userLogic)
        {
            UserLogic = userLogic;
        }

        [HttpPost]
        public int SetUser(User user)
        {
            return UserLogic.Insert(user).Id;
        }
    }
}
