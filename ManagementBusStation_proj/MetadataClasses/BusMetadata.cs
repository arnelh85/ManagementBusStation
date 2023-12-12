using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementBusStation.MetadataClasses
{
    public class BusMetadata
    {
        [DisplayName("Autobuska firma")]
        [Required(ErrorMessage = "Polje kompanija je obavezno za unos")]
        [StringLength(40, ErrorMessage = "Polje kompanija može imati maksimalno 40 karaktera")]
        public string BusCompany { get; set; }
        [DisplayName("Kapacitet sjedišta")]
        [Required(ErrorMessage = "Polje kapacitet sjedišta je obavezno za unos")]
        [Range(1, 100, ErrorMessage = "Polje kapacitet sjedišta može imati maksimalno 100")]
        public int SeatCapacity { get; set; }
    }
}