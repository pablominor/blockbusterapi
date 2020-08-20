using BlockbusterApp.src.Domain.CategoryAggregate;
using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infraestructure.Persistance.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BlockbusterApp.src.Shared.Infraestructure.Persistance.Context
{
    public class BlockbusterContext : DbContext
    {
        public BlockbusterContext(DbContextOptions opt) : base(opt) { }       

        public DbSet<User> User { get; set; }
        public DbSet<Token> Token { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TokenMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
