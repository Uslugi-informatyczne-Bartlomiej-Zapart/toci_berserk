using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Berserk.Database.Persistence.Models;

namespace Toci.Berserk.Bll.Models
{
    public class UserDto
    {
        public string CompanyName { get; set; }
        public string OwnerSurname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
