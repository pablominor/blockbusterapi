using BlockbusterApp.src.Domain.ProductAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlockbusterApp.src.Infraestructure.Persistance.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(c => c.id)
                .HasColumnName("id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new ProductId(v)
                )
                .IsRequired();
            builder
                .Property(c => c.name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(30)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new ProductName(v)
                )
                .IsRequired();
            builder
                .Property(c => c.description)
                .HasColumnName("description")
                .HasColumnType("nvarchar(1300)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new ProductDescription(v)
                )
                .IsRequired();
            builder
                .Property(c => c.price)
                .HasColumnName("price")
                .HasColumnType("decimal(10,2)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new ProductPrice(v)
                )
                .IsRequired();
            builder
                .Property(c => c.categoryId)
                .HasColumnName("category_id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new ProductCategoryId(v)
                )
                .IsRequired();
            builder
                .Property(c => c.createdAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new ProductCreatedAt(v)
                )
                .IsRequired();
            builder
                .Property(c => c.updatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new ProductUpdatedAt(v)
                )
                .IsRequired();
        }
    }
}
