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
    public class TypeWorkService
    {
        private readonly ITypeOfWorkContext _typeOfWorkContext;

        public TypeWorkService(ITypeOfWorkContext typeOfWorkContext)
        {
            _typeOfWorkContext = typeOfWorkContext ?? throw new ArgumentNullException(nameof(typeOfWorkContext));
        }

        public async void AddType(string work, string userId)
        {
            TypeOfWork type = new TypeOfWork(work, userId);
            _typeOfWorkContext.TypeOfWorks.Add(type);
            await _typeOfWorkContext.SaveChangesAsync(CancellationToken.None);
        }

        public async void RemoveAllByUserId()
        {
            var work = await _typeOfWorkContext.TypeOfWorks
                .Where(e => e.Id > 0).ToListAsync(CancellationToken.None);
            _typeOfWorkContext.TypeOfWorks.RemoveRange(work);
            await _typeOfWorkContext.SaveChangesAsync(CancellationToken.None);
        }
        public async void RemoveById(int id)
        {
            var work = await _typeOfWorkContext.TypeOfWorks
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync() ?? throw new ArgumentNullException(nameof(id));
            _typeOfWorkContext.TypeOfWorks.Remove(work);
            await _typeOfWorkContext.SaveChangesAsync(CancellationToken.None);
        }
        
    }
}
