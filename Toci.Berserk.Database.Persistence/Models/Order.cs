using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Order
    {
        public Order()
        {
            Metrichistories = new HashSet<Metrichistory>();
            Orderproducts = new HashSet<Orderproduct>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }

        public virtual ICollection<Metrichistory> Metrichistories { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
