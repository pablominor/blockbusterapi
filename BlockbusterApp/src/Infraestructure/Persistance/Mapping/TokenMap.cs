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
                .Property(c => c.tokenHash)
                .HasColumnName("hash")
                .HasColumnType("nvarchar(30)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenHash(v)
                )
                .IsRequired();
            builder
                .Property(c => c.tokenUserId)
                .HasColumnName("id_user")
                .HasColumnType("nvarchar(60")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenUserId(v)
                )
                .IsRequired();
            builder
                .Property(c => c.tokenCreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new TokenCreatedAt(v)
                )
                .IsRequired();
            builder
                .Property(c => c.tokenUpdatedAt)
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
