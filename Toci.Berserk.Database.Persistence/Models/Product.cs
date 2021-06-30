using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Product
    {
        public Product()
        {
            Chemistries = new HashSet<Chemistry>();
            Orderproducts = new HashSet<Orderproduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int? Code { get; set; }
        public int? Reference { get; set; }

        public virtual ICollection<Chemistry> Chemistries { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
