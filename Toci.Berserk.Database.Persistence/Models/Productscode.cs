using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Productscode
    {
        public int Id { get; set; }
        public int? Idproducts { get; set; }
        public int? Code { get; set; }

        public virtual Product IdproductsNavigation { get; set; }
    }
}
