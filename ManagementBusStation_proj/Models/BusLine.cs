//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagementBusStation.Models
{    
    using System.Collections.Generic;
    
    public partial class BusLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusLine()
        {
            this.TicketSalesByBusLines = new HashSet<TicketSalesByBusLine>();
        }
    
        public int Id { get; set; }
        public string CityOfDeparture { get; set; }
        public string CityOfArrival { get; set; }
        public System.DateTime TimeOfDeparture { get; set; }
        public System.DateTime TimeOfArrival { get; set; }
        public int BusId { get; set; }
    
        public virtual Bus Bus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketSalesByBusLine> TicketSalesByBusLines { get; set; }
    }
}