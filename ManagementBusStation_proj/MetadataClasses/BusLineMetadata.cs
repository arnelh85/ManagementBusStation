using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementBusStation.MetadataClasses
{
    public class BusLineMetadata
    {
        [DisplayName("Grad polaska")]
        [Required(ErrorMessage = "Polje grad polaska je obavezno za unos")]
        [StringLength(50, ErrorMessage = "Polje grad polaska mora sadržavati maksimalno 50 karaktera")]
        public string CityOfDeparture { get; set; }
        [DisplayName("Grad dolaska")]
        [Required(ErrorMessage = "Polje grad dolaska je obavezno za unos")]
        [StringLength(50, ErrorMessage = "Polje grad dolaska mora sadržavati maksimalno 50 karaktera")]
        public string CityOfArrival { get; set; }
        [DisplayName("Vrijeme polaska")]
        [Required(ErrorMessage = "Polje vrijeme polaska je obavezno za unos")]
        public DateTime TimeOfDeparture { get; set; }
        [DisplayName("Vrijeme dolaska")]
        [Required(ErrorMessage = "Polje vrijeme dolaska je obavezno za unos")]
        public DateTime TimeOfArrival { get; set; }
    }
}