using Microsoft.EntityFrameworkCore;
using RentalManagement.API.Models;

namespace RentalManagement.API.Data
{
    public class RentalContext : DbContext
    {

        // Konstruktor:
        public RentalContext(DbContextOptions<RentalContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<RentalAgreement> RentalAgreements { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
