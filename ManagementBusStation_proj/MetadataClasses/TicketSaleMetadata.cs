using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementBusStation.MetadataClasses
{
    public class TicketSaleMetadata
    {
        [DisplayName("Naziv kupca")]
        [Required(ErrorMessage = "Polje naziv kupca je obavezno za unos")]
        [StringLength(50, ErrorMessage = "Polje naziv kupca mora sadržavati maksimalno 50 karaktera")]
        public string CustomerName { get; set; }
        [DisplayName("Dob kupca")]
        [Required(ErrorMessage = "Polje dob kupca je obavezno za unos")]
        [Range(15, 80, ErrorMessage = "Polje dob kupca može imati maksimalno 80")]
        public int CustomerAge { get; set; }
        [DisplayName("Valuta")]
        [Required(ErrorMessage = "Polje valuta je obavezno za unos")]       
        public string Currency { get; set; }
        [DisplayName("Cijena karte")]
        [Required(ErrorMessage = "Polje cijena karte je obavezno za unos")]
        public decimal TicketPrice { get; set; }
        [DisplayName("Popust")]
        [Required(ErrorMessage = "Polje popust je obavezno za unos")]
        public decimal Discount { get; set; }                      
    }
}