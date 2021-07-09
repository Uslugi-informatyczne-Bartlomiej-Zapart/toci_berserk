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
            Deliveries = new HashSet<Delivery>();
            Orderproducts = new HashSet<Orderproduct>();
            Predictedorders = new HashSet<Predictedorder>();
            Productscodes = new HashSet<Productscode>();
            Productshistories = new HashSet<Productshistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int? Reference { get; set; }

        public virtual ICollection<Chemistry> Chemistries { get; set; }
        public virtual ICollection<Chemistrypop> Chemistrypops { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
        public virtual ICollection<Predictedorder> Predictedorders { get; set; }
        public virtual ICollection<Productscode> Productscodes { get; set; }
        public virtual ICollection<Productshistory> Productshistories { get; set; }
    }
}
