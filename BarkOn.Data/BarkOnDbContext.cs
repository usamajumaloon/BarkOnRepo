using BarkOn.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarkOn.Data
{
    public class BarkOnDbContext : IdentityDbContext<User>
    {
        public BarkOnDbContext(DbContextOptions<BarkOnDbContext> options) : base(options)
        {

        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingPackage> BookingPackages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageService> PackageServices { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
