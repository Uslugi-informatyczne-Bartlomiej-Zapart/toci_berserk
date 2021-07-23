using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public IEnumerable<User> AllLogins()
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
                Companyname = user.CompanyName,
                Ownersurname = user.OwnerSurname,
                Login = user.Login,
                Password = HashPassword(user.Password)
            });

            return newUser.Id;
        }

        public bool Login(UserDto user)
        {
            var hash = HashPassword(user.Password);

            return Select(x => x.Login == user.Login && x.Password == hash).Any();
        }

        protected virtual bool isLoginAlreadyInDb(string login)
        {
            return Select(x => x.Login == login).Any();
        }

        private string HashPassword(string password)
        {
            var algorithm = SHA256.Create();
            StringBuilder sb = new StringBuilder();
            foreach (var b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(password)))
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
