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

        
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        

        public virtual ICollection<Player> Players { get; set; }
    }
}