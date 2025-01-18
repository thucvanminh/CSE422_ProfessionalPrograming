using Microsoft.EntityFrameworkCore;

namespace Lab2_VanMinhThuc.Models
{
    public class DeviceDbContext : DbContext
    {
        public DeviceDbContext(DbContextOptions<DeviceDbContext> options) : base(options){}
        public DbSet<Device> Device { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<DeviceUser> DeviceUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasOne(ca => ca.Category)
                .WithMany(dv => dv.Device)
                .HasForeignKey(dv => dv.Category_ID);  // Explicitly specify the foreign key

        }



    }
}
