using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Infraestructure.Persistance.Mapping;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Persistance.Context
{
    public class BlockbusterContext : DbContext
    {
        public BlockbusterContext(DbContextOptions opt) : base(opt) { }       

        public DbSet<User> User { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TokenMap());
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
