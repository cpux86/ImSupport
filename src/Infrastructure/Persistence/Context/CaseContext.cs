﻿//using Domain.Modeles;
using Domain.Interfaces;
using Domain.Models;
using Persistence.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class CaseContext : DbContext, ICaseContext, ITypeOfWorkContext
    {

        public DbSet<Case> Cases { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WorksList> WorksList { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companys { get; set; }

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
                //    .UseNpgsql("Host=localhost;Port=5432;Database=imSupport;Username=cpux86;Password=1AC290066F");
            }

            //optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
            //Console.Clear();
            optionsBuilder.LogTo(message => File.AppendAllText(".\\1.txt",message), Microsoft.Extensions.Logging.LogLevel.Information);

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CaseConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
        }
    }
}
