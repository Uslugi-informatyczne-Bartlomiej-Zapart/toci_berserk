using System;
using System.Collections.Generic;

#nullable disable

namespace Toci.Berserk.Database.Persistence.Models
{
    public partial class Point
    {
        public Point()
        {
            Clubs = new HashSet<Club>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public float? Point1 { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
