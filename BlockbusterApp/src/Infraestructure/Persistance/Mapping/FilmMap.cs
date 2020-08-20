using BlockbusterApp.src.Domain.FilmAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlockbusterApp.src.Infraestructure.Persistance.Mapping
{
    public class FilmMap : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder
                .Property(c => c.id)
                .HasColumnName("id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmId(v)
                )
                .IsRequired();
            builder
                .Property(c => c.name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(30)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmName(v)
                )
                .IsRequired();
            builder
                .Property(c => c.description)
                .HasColumnName("description")
                .HasColumnType("nvarchar(1300)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmDescription(v)
                )
                .IsRequired();
            builder
                .Property(c => c.price)
                .HasColumnName("price")
                .HasColumnType("decimal(10,2)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmPrice(v)
                )
                .IsRequired();
            builder
                .Property(c => c.categoryId)
                .HasColumnName("category_id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmCategoryId(v)
                )
                .IsRequired();
            builder
                .Property(c => c.createdAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmCreatedAt(v)
                )
                .IsRequired();
            builder
                .Property(c => c.updatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new FilmUpdatedAt(v)
                )
                .IsRequired();
        }
    }
}
