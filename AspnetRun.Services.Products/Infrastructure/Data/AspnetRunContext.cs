using AspnetRun.Services.Products.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetRun.Services.Products.Infrastructure.Data
{
    public class AspnetRunContext : DbContext
    {
        public AspnetRunContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCompare> ProductCompares { get; set; }
        public DbSet<ProductList> ProductLists { get; set; }
        public DbSet<ProductRelatedProduct> ProductRelatedProducts { get; set; }
        public DbSet<ProductWishlist> ProductWishlists { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetTableNameAsSinge(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(ConfigureProduct);
            modelBuilder.Entity<ProductWishlist>(ConfigureProductWishlist);
            modelBuilder.Entity<ProductCompare>(ConfigureProductCompare);
            modelBuilder.Entity<ProductList>(ConfigureProductList);
            modelBuilder.Entity<ProductRelatedProduct>(ConfigureProductRelatedProduct);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            // check for conventions - http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx

            // add self reference table configuration
            // https://github.com/aspnet/EntityFrameworkCore/issues/10698 
            // https://stackoverflow.com/questions/27613117/introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths-s

            builder
                .HasMany(p => p.ProductRelatedProducts)
                .WithOne(pr => pr.Product)
                .HasForeignKey(pr => pr.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetTableNameAsSinge(ModelBuilder modelBuilder)
        {
            // Use the entity name instead of the Context.DbSet<T> name
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
        }

        private void ConfigureProductWishlist(EntityTypeBuilder<ProductWishlist> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.WishlistId });
        }

        private void ConfigureProductCompare(EntityTypeBuilder<ProductCompare> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.CompareId });
        }

        private void ConfigureProductList(EntityTypeBuilder<ProductList> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.ListId });
        }

        private void ConfigureProductRelatedProduct(EntityTypeBuilder<ProductRelatedProduct> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.RelatedProductId });
        }
    }
}
