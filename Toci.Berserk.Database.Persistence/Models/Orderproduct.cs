using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Orderproduct
    {
        public int Id { get; set; }
        public int? Idorder { get; set; }
        public int? Status { get; set; }
        public int? Quantity { get; set; }
        public int? Idproducts { get; set; }

        public virtual Order IdorderNavigation { get; set; }
        public virtual Product IdproductsNavigation { get; set; }
    }
}
