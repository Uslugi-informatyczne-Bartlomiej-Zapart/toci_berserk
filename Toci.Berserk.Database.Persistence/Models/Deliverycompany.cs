using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Deliverycompany
    {
        public Deliverycompany()
        {
            Deliveries = new HashSet<Delivery>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
