using BlockbusterApp.src.Domain.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlockbusterApp.src.Infraestructure.Persistance.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .Property(c => c.id)
                .HasColumnName("id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CategoryId(v)
                )
                .IsRequired();
            builder
                .Property(c => c.name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(30)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CategoryName(v)
                )
                .IsRequired();            
            builder
                .Property(c => c.createdAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CategoryCreatedAt(v)
                )
                .IsRequired();
            builder
                .Property(c => c.updatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CategoryUpdatedAt(v)
                )
                .IsRequired();
        }
    }
}
