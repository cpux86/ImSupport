using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICaseContext
    {
        DbSet<Case> Cases { get; set; }
        DbSet<Device> Devices { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Company> Companys { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
