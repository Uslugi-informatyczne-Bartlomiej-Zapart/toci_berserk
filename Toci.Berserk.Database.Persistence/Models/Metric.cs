using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Metric
    {
        public Metric()
        {
            Metrichistories = new HashSet<Metrichistory>();
            Predictedorderquantities = new HashSet<Predictedorderquantity>();
        }

        public int Id { get; set; }
        public int? Metric1 { get; set; }
        public int? Algorithm { get; set; }

        public virtual ICollection<Metrichistory> Metrichistories { get; set; }
        public virtual ICollection<Predictedorderquantity> Predictedorderquantities { get; set; }
    }
}
