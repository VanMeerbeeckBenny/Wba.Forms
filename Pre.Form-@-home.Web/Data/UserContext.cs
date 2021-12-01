using Microsoft.EntityFrameworkCore;
using Pre.Form___home.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pre.Form___home.Web.Data
{
    public class UserContext : DbContext
    {

        public DbSet<User>users { get; set; }
        public UserContext(DbContextOptions<UserContext> option):base(option)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging(); meer info welke key dat dat een error geeft
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<User>()
        //        .Property(u => u.Country)
        //        .HasMaxLength(150);
        //}
    }
}
