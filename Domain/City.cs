using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "City")]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}