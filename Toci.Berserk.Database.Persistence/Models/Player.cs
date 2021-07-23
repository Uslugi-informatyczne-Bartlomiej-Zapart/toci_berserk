using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Player
    {
        public Player()
        {
            CompetitorIdfirstplayerNavigations = new HashSet<Competitor>();
            CompetitorIdsecondplayerNavigations = new HashSet<Competitor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Pesel { get; set; }
        public int? Idclub { get; set; }
        public int? Idpoints { get; set; }

        public virtual Club IdclubNavigation { get; set; }
        public virtual Point IdpointsNavigation { get; set; }
        public virtual ICollection<Competitor> CompetitorIdfirstplayerNavigations { get; set; }
        public virtual ICollection<Competitor> CompetitorIdsecondplayerNavigations { get; set; }
    }
}
