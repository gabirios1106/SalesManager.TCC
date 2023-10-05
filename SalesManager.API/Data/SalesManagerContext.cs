using Microsoft.EntityFrameworkCore;
using Models;

namespace SalesManager.API.Data
{
    public class SalesManagerContext : DbContext
    {
        public SalesManagerContext(DbContextOptions<SalesManagerContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<StockMovement> StockMovement { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);
                b.Property(u => u.Id).ValueGeneratedOnAdd();

                b.Property(u => u.Name).IsRequired().HasMaxLength(150);
                b.Property(u => u.Email).IsRequired().HasMaxLength(150);
                b.Property(u => u.Password).IsRequired().HasMaxLength(50);
                b.Property(u => u.CreatedAt).IsRequired();
            });

            builder.Entity<Department>(b =>
            {
                b.HasKey(d => d.Id);
                b.Property(d => d.Id).ValueGeneratedOnAdd();

                b.Property(d => d.DepartmentName).IsRequired().HasMaxLength(150);
                b.Property(d => d.CreatedAt).IsRequired();
            });

            builder.Entity<Product>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Id).ValueGeneratedOnAdd();

                b.Property(p => p.ProductName).IsRequired().HasMaxLength(150);
                b.Property(p => p.Price).IsRequired();

                b.HasOne(p => p.Department).WithMany().HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            });

            builder.Entity<StockMovement>(b =>
            {
                b.HasKey(sm => sm.Id);
                b.Property(sm => sm.Id).ValueGeneratedOnAdd();

                b.Property(sm => sm.Quantity).IsRequired();
                b.Property(sm => sm.MovementType).IsRequired();
                b.Property(sm => sm.CreatedAt).IsRequired();

                b.HasOne(sm => sm.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            });
        }
    }
}
