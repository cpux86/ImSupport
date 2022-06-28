using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class EmployeeService
    {
        private readonly ICaseContext _context;

        public EmployeeService(ICaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async void AddEmployee(string name, string surname, string phone)
        {
            var user = new Employee(name, surname, phone);
            
            _context.Employees.Add(user);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
