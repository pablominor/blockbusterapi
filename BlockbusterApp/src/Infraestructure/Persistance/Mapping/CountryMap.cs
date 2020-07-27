using BlockbusterApp.src.Domain.CountryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlockbusterApp.src.Infraestructure.Persistance.Mapping
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .Property(c => c.code)
                .HasColumnName("code")
                .HasColumnType("nvarchar(2)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CountryCode(v)
                )
                .IsRequired();
            builder
                .Property(c => c.tax)
                .HasColumnName("tax")
                .HasColumnType("decimal(10,2)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new CountryTax(v)
                )
                .IsRequired();           
        }
    }
}
