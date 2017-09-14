using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Gener
    {
        [Key]
        public int GenerId { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
