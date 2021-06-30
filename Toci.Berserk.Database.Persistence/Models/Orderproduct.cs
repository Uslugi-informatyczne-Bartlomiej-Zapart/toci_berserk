﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Orderproduct
    {
        public int Id { get; set; }
        public int? Orderid { get; set; }
        public int? Idcategories { get; set; }
        public int? Quantity { get; set; }
        public int? Idproducts { get; set; }

        public virtual Category IdcategoriesNavigation { get; set; }
        public virtual Product IdproductsNavigation { get; set; }
    }
}
