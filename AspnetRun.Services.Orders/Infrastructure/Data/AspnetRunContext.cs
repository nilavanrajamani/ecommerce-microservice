using AspnetRun.Services.Orders.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetRun.Services.Orders.Infrastructure.Data
{
    public class AspnetRunContext : DbContext
    {
        public AspnetRunContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SetTableNamesAsSingle(builder);
            base.OnModelCreating(builder); // if we put this at top, it changes also identity table names so dont put this at top.            
            builder.Entity<Order>(ConfigureOrder);            
            builder.Entity<Product>(ConfigureProduct);            
        }

        private static void SetTableNamesAsSingle(ModelBuilder builder)
        {
            // Use the entity name instead of the Context.DbSet<T> name
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
        }

        private void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
            //// NOTE : This Owns methods provide to accept value object like Address
            //builder.OwnsOne(o => o.ShippingAddress);
            //builder.OwnsOne(o => o.BillingAddress);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            // check for conventions - http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx

            // add self reference table configuration
            // https://github.com/aspnet/EntityFrameworkCore/issues/10698 
            // https://stackoverflow.com/questions/27613117/introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths-s

            //builder
            //    .HasMany(p => p.ProductRelatedProducts)
            //    .WithOne(pr => pr.Product)
            //    .HasForeignKey(pr => pr.ProductId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
      
    }
}
