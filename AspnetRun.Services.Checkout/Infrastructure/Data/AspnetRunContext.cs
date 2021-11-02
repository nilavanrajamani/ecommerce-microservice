using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AspnetRun.Services.Basket.Core.Entities;

namespace AspnetRun.Services.Basket.Infrastructure.Data
{
    public class AspnetRunContext : DbContext
    {
        public AspnetRunContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SetTableNamesAsSingle(builder);

            base.OnModelCreating(builder); // if we put this at top, it changes also identity table names so dont put this at top.
        }

        private static void SetTableNamesAsSingle(ModelBuilder builder)
        {
            // Use the entity name instead of the Context.DbSet<T> name
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
        }
    }
}
