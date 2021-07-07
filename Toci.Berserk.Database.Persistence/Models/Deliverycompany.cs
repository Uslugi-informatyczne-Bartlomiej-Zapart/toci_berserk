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
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
