using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Category
    {
        public Category()
        {
            Chemistries = new HashSet<Chemistry>();
            InverseIdparentNavigation = new HashSet<Category>();
            Orderproducts = new HashSet<Orderproduct>();
        }

        public int Id { get; set; }
        public int? Idparent { get; set; }
        public string Name { get; set; }

        public virtual Category IdparentNavigation { get; set; }
        public virtual ICollection<Chemistry> Chemistries { get; set; }
        public virtual ICollection<Category> InverseIdparentNavigation { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
