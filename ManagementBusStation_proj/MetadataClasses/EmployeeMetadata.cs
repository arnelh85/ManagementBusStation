using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementBusStation.MetadataClasses
{
    public class EmployeeMetadata
    {
        [DisplayName("Naziv")]
        [Required(ErrorMessage = "Polje naziv je obavezno za unos")]
        [StringLength(50, ErrorMessage = "Polje naziv mora sadržavati maksimalno 50 karaktera")]
        public string EmployeeName { get; set; }       
        [DisplayName("Dob")]
        [Required(ErrorMessage = "Polje dob je obavezno za unos")]
        [Range(22, 65, ErrorMessage = "Polje dob može imati maksimalno 65")]
        public int EmployeeAge { get; set; }       
        [DisplayName("JMBG")]
        [Required(ErrorMessage = "Polje JMBG je obavezno za unos")]
        [StringLength(15, ErrorMessage = "Polje JMBG mora sadržavati maksimalno 15 karaktera")]
        public string EmployeePersonalIdNo { get; set; }
        [DisplayName("Država")]
        [Required(ErrorMessage = "Polje država je obavezno za unos")]
        [StringLength(30, ErrorMessage = "Polje država mora sadržavati maksimalno 30 karaktera")]
        public string EmployeeCountry { get; set; }
        [DisplayName("Grad")]
        [Required(ErrorMessage = "Polje grad je obavezno za unos")]
        [StringLength(40, ErrorMessage = "Polje grad mora sadržavati maksimalno 40 karaktera")]
        public string EmployeeCity { get; set; }
        [DisplayName("Broj telefona")]
        [Required(ErrorMessage = "Polje broj telefona je obavezno za unos")]
        [StringLength(30, ErrorMessage = "Polje broj telefona mora sadržavati maksimalno 30 karaktera")]
        public string EmployeePhoneNumber { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Polje email je obavezno za unos")]
        [StringLength(50, ErrorMessage = "Polje email mora sadržavati maksimalno 50 karaktera")]
        public string EmployeeEmailAddress { get; set; }
        [DisplayName("Šifra")]
        [Required(ErrorMessage = "Polje šifra je obavezno za unos")]
        [StringLength(1000, ErrorMessage = "Polje šifra mora sadržavati maksimalno 1000 karaktera")]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
    }
}