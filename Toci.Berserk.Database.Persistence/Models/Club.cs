using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Club
    {
        public Club()
        {
            ClubduelIdfirstclubNavigations = new HashSet<Clubduel>();
            ClubduelIdsecondclubNavigations = new HashSet<Clubduel>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public int? Idpoints { get; set; }

        public virtual Point IdpointsNavigation { get; set; }
        public virtual ICollection<Clubduel> ClubduelIdfirstclubNavigations { get; set; }
        public virtual ICollection<Clubduel> ClubduelIdsecondclubNavigations { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
