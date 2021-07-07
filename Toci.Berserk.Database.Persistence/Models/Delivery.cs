using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Delivery
    {
        public int Id { get; set; }
        public int? Idproducts { get; set; }
        public int? Iddeliverycompany { get; set; }

        public virtual Deliverycompany IddeliverycompanyNavigation { get; set; }
        public virtual Product IdproductsNavigation { get; set; }
    }
}
