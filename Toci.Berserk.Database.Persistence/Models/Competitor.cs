using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Competitor
    {
        public int Id { get; set; }
        public int? Idfirstplayer { get; set; }
        public int? Idsecondplayer { get; set; }
        public int? Idtournament { get; set; }
        public int? Winner { get; set; }

        public virtual Player IdfirstplayerNavigation { get; set; }
        public virtual Player IdsecondplayerNavigation { get; set; }
        public virtual Tournament IdtournamentNavigation { get; set; }
    }
}
