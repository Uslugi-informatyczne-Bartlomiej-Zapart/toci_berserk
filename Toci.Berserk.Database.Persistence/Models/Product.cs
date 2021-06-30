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
            Chemistrypops = new HashSet<Chemistrypop>();
            Orderproducts = new HashSet<Orderproduct>();
            Productscodes = new HashSet<Productscode>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int? Reference { get; set; }

        public virtual ICollection<Chemistry> Chemistries { get; set; }
        public virtual ICollection<Chemistrypop> Chemistrypops { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
        public virtual ICollection<Productscode> Productscodes { get; set; }
    }
}
