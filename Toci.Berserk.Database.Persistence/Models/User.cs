using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class User
    {
        public User()
        {
            Chemistrypops = new HashSet<Chemistrypop>();
        }

        public int Id { get; set; }
        public string Companyname { get; set; }
        public string Ownersurname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Chemistrypop> Chemistrypops { get; set; }
    }
}
