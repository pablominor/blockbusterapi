using BlockbusterApp.src.Domain.TokenAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Persistance.Mapping
{
    public class TokenMap : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder
                .Property(c => c.hash)
                .HasColumnName("hash")
                .HasColumnType("text")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenHash(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userId)
                .HasColumnName("id_user")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenUserId(v)
                )
                .IsRequired();
            builder
                .Property(c => c.createdAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenCreatedAt(v)
                )
                .IsRequired();
            builder
                .Property(c => c.updatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenUpdatedAt(v)
                )
                .IsRequired();
        }
    }
}
