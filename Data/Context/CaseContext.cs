//using AppCore.Modeles;
using AppCore.Interfaces;
using AppCore.Models;
using Data.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class CaseContext : DbContext, ICaseContext, ITypeOfWorkContext
    {

        public DbSet<Case>? Cases { get; set; }
        public DbSet<Device>? Devices { get; set; }
        public DbSet<Location>? Locations { get; set; }
        public DbSet<WorksList> WorksList { get; set ; }

        //public DbSet<CaseDescription>? CaseDescriptions { get; set; }   
        public CaseContext() {}
        public CaseContext(DbContextOptions options) : base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db");
                //optionsBuilder
                //    .UseNpgsql("Host=localhost;Port=5432;Database=zion;Username=cpux86;Password=1AC290066F");
            }

            //optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
            //Console.Clear();
            //optionsBuilder.LogTo(message => Console.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information);

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CaseConfiguration());
        }
    }
}
