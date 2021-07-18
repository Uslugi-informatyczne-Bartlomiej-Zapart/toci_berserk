using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Productcompanyorder
    {
        public int? Productid { get; set; }
        public string Productname { get; set; }
        public int? Currentquantity { get; set; }
        public string Deliverycompany { get; set; }
        public float? Price { get; set; }
    }
}
