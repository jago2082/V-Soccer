using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Domain
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [MaxLength(80, ErrorMessage = "The max length for the fiels {0} is {1} characters")]
        [Required]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "The max length for the fiels {0} is {1} characters")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gener")]
        public int GenerId { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }

        [Display(Name = "City")]
        public int DepartmentId { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public double CoordX { get; set; }

        public double CoordY { get; set; }

        [MaxLength(256, ErrorMessage = "The max length for the fiels {0} is {1} characters")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "The minimun valu is {0} and maximun {1}")]
        public double Weight { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "The minimun valu is {0} and maximun {1}")]
        public double Height { get; set; }

        [MaxLength(10, ErrorMessage = "The max length for the fiels {0} is {1} characters")]
        public string Position { get; set; }

        public int Skill1 { get; set; }

        public int Skill2 { get; set; }

        public int Skill3 { get; set; }

        public int Skill4 { get; set; }
        public int Skill5 { get; set; }

        public int Stars { get; set; }

        public int Qualification { get; set; }

        public int Friendly { get; set; }

        public int Goals { get; set; }

        public int RedCards { get; set; }

        public int YellowCards { get; set; }

        [MaxLength(50, ErrorMessage = "The max length for the fiels {0} is {1} characters")]
        public string Nickname { get; set; }

        public bool Anickname { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        public virtual Gener Gener { get; set; }

        public virtual Country Country { get; set; }

        public virtual Department Department { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<PlayerTeam> PlayersTeams { get; set; }
    }
}