using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            Clubduels = new HashSet<Clubduel>();
            Competitors = new HashSet<Competitor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string Town { get; set; }

        public virtual ICollection<Clubduel> Clubduels { get; set; }
        public virtual ICollection<Competitor> Competitors { get; set; }
    }
}
