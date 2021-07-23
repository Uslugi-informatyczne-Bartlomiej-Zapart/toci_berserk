using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Clubduel
    {
        public int Id { get; set; }
        public int? Idfirstclub { get; set; }
        public int? Idsecondclub { get; set; }
        public int? Idtournament { get; set; }
        public int? Winner { get; set; }

        public virtual Club IdfirstclubNavigation { get; set; }
        public virtual Club IdsecondclubNavigation { get; set; }
        public virtual Tournament IdtournamentNavigation { get; set; }
    }
}
