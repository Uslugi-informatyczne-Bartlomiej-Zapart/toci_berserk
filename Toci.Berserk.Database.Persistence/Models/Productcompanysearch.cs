using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Productcompanysearch
    {
        public int? Idproducts { get; set; }
        public int? Iddeliverycompany { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int? Reference { get; set; }
        public int? Code { get; set; }
        public string Companyname { get; set; }
        public float? Price { get; set; }
    }
}
