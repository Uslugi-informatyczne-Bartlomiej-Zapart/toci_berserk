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
            Predictedorders = new HashSet<Predictedorder>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Status { get; set; }
        public int? Iddeliverycompany { get; set; }

        public virtual Deliverycompany IddeliverycompanyNavigation { get; set; }
        public virtual ICollection<Metrichistory> Metrichistories { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
        public virtual ICollection<Predictedorder> Predictedorders { get; set; }
    }
}
