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
                .HasColumnName("id")
                .HasColumnType("nvarchar(40)")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserId(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userEmail)
                .HasColumnName("email")
                .HasColumnType("nvarchar(60")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserEmail(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userHashedPassword)
                .HasColumnName("password")
                .HasColumnType("nvarchar(100")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserHashedPassword(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userFirstName)
                .HasColumnName("first_name")
                .HasColumnType("nvarchar(15")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserFirstName(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userLastName)
                .HasColumnName("last_name")
                .HasColumnType("nvarchar(30")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserLastName(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userRole)
                .HasColumnName("role")
                .HasColumnType("nvarchar(20")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserRole(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userCreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserCreatedAt(v)
                )
                .IsRequired();
            builder
                .Property(c => c.userUpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime2")
                .HasConversion(
                    v => v.GetValue(),
                    v => new UserUpdatedAt(v)
                )
                .IsRequired();
        }
    }
}
