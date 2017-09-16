using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PlayerTeam
    {
        [Key]
        public int PlayerTeamId { get; set; }
        public int PlayerId { get; set; }

        public int TeamId { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
