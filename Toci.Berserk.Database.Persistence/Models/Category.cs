using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseIdparentNavigation = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? Idparent { get; set; }
        public string Name { get; set; }

        public virtual Category IdparentNavigation { get; set; }
        public virtual ICollection<Category> InverseIdparentNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
