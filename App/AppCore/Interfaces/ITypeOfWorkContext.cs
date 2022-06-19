using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Interfaces
{
    public interface ITypeOfWorkContext
    {
        public DbSet<WorksList> WorksList { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
