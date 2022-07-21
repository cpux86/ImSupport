using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppServicesTests.Common
{
    public class CaseContextFactory : ICaseContext
    {
        public DbSet<Case> Cases { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<WorksList> WorksList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static CaseContext Create()
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
           //.UseNpgsql("Host=localhost;Port=5432;Database=zion;Username=cpux86;Password=1AC290066F")
           .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
           .Options;
            return new CaseContext(options);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
