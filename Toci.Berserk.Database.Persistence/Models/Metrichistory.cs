using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Metrichistory
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Idmetrics { get; set; }
        public int? Metric { get; set; }

        public virtual Metric IdmetricsNavigation { get; set; }
    }
}
