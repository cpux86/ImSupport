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
            //var type = await _typeOfWorkContext.TypeOfWorks.Where(t => t.Title == work).FirstOrDefaultAsync();
            TypeOfWork type = new TypeOfWork(work, userId);
            _typeOfWorkContext.TypeOfWorks.Add(type);
            await _typeOfWorkContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
