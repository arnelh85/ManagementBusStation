﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagementBusStation.Models
{    
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ManagementBusStationDBEntities : DbContext
    {
        public ManagementBusStationDBEntities()
            : base("name=ManagementBusStation_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<BusLine> BusLines { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<TicketSale> TicketSales { get; set; }
        public virtual DbSet<TicketSalesByBusLine> TicketSalesByBusLines { get; set; }
    }
}