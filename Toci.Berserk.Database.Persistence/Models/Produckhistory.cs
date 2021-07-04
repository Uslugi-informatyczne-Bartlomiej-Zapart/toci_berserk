using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Produckhistory
    {
        public int Id { get; set; }
        public int? Idproducts { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int? Reference { get; set; }
        public int? Iddeleteproductscodes { get; set; }
        public int? Code { get; set; }
        public DateTime? Dateofdeletion { get; set; }

        public virtual Productscode IddeleteproductscodesNavigation { get; set; }
        public virtual Product IdproductsNavigation { get; set; }
    }
}
