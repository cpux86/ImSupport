using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface ITypeOfWorkContext
    {
        public DbSet<WorksList> WorksList { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
