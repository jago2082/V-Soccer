using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Domain
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [MaxLength(80, ErrorMessage = "The max length for the fiels {0} is {1} characters")]
        [Required]
        public string Name { get; set; }

        [MaxLength(256, ErrorMessage = "The max length for the fiels {0} is {1} characters")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Admin Email")]
        public string AdminEmail { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
        public DateTime creationdate { get; set; }

        public string Formato { get; set; }

        [Display(Name = "Players")]
        [Range(1, 22, ErrorMessage = "The minimun valu is {0} and maximun {1}")]
        public int NumJugadores { get; set; }


        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        public int CityId { get; set; }

        public int CountryId { get; set; }

        [Display(Name = "Matches Won")]
        [Range(1, int.MaxValue, ErrorMessage = "The minimun valu is {0} and maximun {1}")]
        public int MatchesWon { get; set; }

        [Display(Name = "Lost Matches")]
        [Range(1, int.MaxValue, ErrorMessage = "The minimun valu is {0} and maximun {1}")]
        public int LostMatches { get; set; }

        [Display(Name = "Drawn Matches")]
        [Range(1, int.MaxValue, ErrorMessage = "The minimun valu is {0} and maximun {1}")]
        public int DrawnMatches { get; set; }

        [Display(Name = "Goals Scored")]
        [Range(1, int.MaxValue, ErrorMessage = "The minimun valu is {0} and maximun {1}")]
        public int GoalsScored { get; set; }

        [Display(Name = "Goals Against")]
        [Range(1, int.MaxValue, ErrorMessage = "The minimun valu is {0} and maximun {1}")]
        public int GoalsAgainst { get; set; }

        public virtual Country Country { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<PlayerTeam> PlayersTeams { get; set; }
        public virtual ICollection<Match> Locals { get; set; }

        public virtual ICollection<Match> Visitors { get; set; }
    }
}
