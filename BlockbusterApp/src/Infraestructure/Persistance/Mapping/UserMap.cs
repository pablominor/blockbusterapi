using BlockbusterApp.src.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infraestructure.Persistance.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(c => c.userId)
                .HasColumnType("nvarchar(50")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserId(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userEmail)
                .HasColumnType("nvarchar(50")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserEmail(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userHashedPassword)
                .HasColumnType("nvarchar(50")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserHashedPassword(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userFirstName)
                .HasColumnType("nvarchar(50")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserFirstName(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userLastName)
                .HasColumnType("nvarchar(50")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserLastName(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userRole)
                .HasColumnType("nvarchar(50")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserRole(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userCreatedAt)
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserCreatedAt(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userUpdatedAt)
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserUpdatedAt(v)
                )
                .IsRequired();
        }
    }
}
