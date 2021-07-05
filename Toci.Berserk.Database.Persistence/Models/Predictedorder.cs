using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Predictedorder
    {
        public Predictedorder()
        {
            Predictedorderquantities = new HashSet<Predictedorderquantity>();
        }

        public int Id { get; set; }
        public int? Idproducts { get; set; }
        public int? Idorder { get; set; }

        public virtual Order IdorderNavigation { get; set; }
        public virtual Product IdproductsNavigation { get; set; }
        public virtual ICollection<Predictedorderquantity> Predictedorderquantities { get; set; }
    }
}
