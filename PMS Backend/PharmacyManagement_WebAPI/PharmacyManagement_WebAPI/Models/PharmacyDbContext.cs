using Microsoft.EntityFrameworkCore;

namespace PharmacyManagement_WebAPI.Models
{
    public class PharmacyDbContext:DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
           : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<DoctorRegistration> Doctors { get; set; }
        public DbSet<LoginDetails> LoginDetails { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected readonly IConfiguration Configuration;

        

    }
}
