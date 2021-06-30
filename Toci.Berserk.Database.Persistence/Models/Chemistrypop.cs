using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Chemistrypop
    {
        public int Id { get; set; }
        public int? Idproducts { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }
        public int? Idusers { get; set; }

        public virtual Product IdproductsNavigation { get; set; }
        public virtual User IdusersNavigation { get; set; }
    }
}
