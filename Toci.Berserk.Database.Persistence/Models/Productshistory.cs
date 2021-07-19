using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Productshistory
    {
        public int Id { get; set; }
        public int? Iddeletedproduct { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Reference { get; set; }
        public int? Iddeletedproductscodes { get; set; }
        public int? Code { get; set; }
        public DateTime? Dateofdeletion { get; set; }

        public virtual Product IddeletedproductNavigation { get; set; }
        public virtual Productscode IddeletedproductscodesNavigation { get; set; }
    }
}
