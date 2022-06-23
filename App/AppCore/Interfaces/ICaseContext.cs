using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface ICaseContext
    {
        DbSet<Case> Cases { get; set; }
        DbSet<Device> Devices { get; set; }
        DbSet<Location> Locations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
