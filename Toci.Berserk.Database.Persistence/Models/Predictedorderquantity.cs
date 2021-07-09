using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Predictedorderquantity
    {
        public int Id { get; set; }
        public int? Idpredictedorder { get; set; }
        public int? Idmetric { get; set; }
        public int? Quantity { get; set; }

        public virtual Metric IdmetricNavigation { get; set; }
        public virtual Predictedorder IdpredictedorderNavigation { get; set; }
    }
}
