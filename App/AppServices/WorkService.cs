using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppCore.Interfaces;
using AppCore.Models;

namespace AppServices
{
    public class WorkService
    {
        private readonly ITypeOfWorkContext _typeOfWorkContext;

        public WorkService(ITypeOfWorkContext typeOfWorkContext)
        {
            _typeOfWorkContext = typeOfWorkContext ?? throw new ArgumentNullException(nameof(typeOfWorkContext));
        }

        public async void AddType(string work, string userId)
        {
            WorksList type = new WorksList(work, userId);
            _typeOfWorkContext.WorksList.Add(type);
            await _typeOfWorkContext.SaveChangesAsync(CancellationToken.None);
        }

        public async void RemoveAllByUserId()
        {
            var work = await _typeOfWorkContext.WorksList
                .Where(e => e.Id > 0).ToListAsync(CancellationToken.None);
            _typeOfWorkContext.WorksList.RemoveRange(work);
            await _typeOfWorkContext.SaveChangesAsync(CancellationToken.None);
        }
        public async void RemoveById(int id)
        {
            var work = await _typeOfWorkContext.WorksList
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync() ?? throw new ArgumentNullException(nameof(id));
            _typeOfWorkContext.WorksList.Remove(work);
            await _typeOfWorkContext.SaveChangesAsync(CancellationToken.None);
        }
        
    }
}
