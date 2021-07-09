using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Bll.Models;
using Toci.Berserk.Bll.Warehouse.Interfaces;
using Toci.Berserk.Database;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Warehouse
{
    public class UserLogic : LogicBase<User>, IUserLogic
    {
        public IEnumerable<User> GetAllUserLogins()
        {
            var users = Select(x => x.Id > 0).ToList();
            return users;
        }

        public int CreateAccount(UserDto user)
        {
            if (isLoginAlreadyInDb(user.Login))
            {
                return 0;
            }

            User newUser = Insert(new User()
            {
                Name = user.Name,
                Login = user.Login,
                Password = user.Password
            });

            return newUser.Id;
        }

        protected virtual bool isLoginAlreadyInDb(string login)
        {
            return Select(x => x.Login == login).Any();
        }
    }
}
