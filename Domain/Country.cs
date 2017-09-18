using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public virtual ICollection<Department> Citys { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}