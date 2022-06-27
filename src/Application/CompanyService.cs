using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CompanyService
    {
        private readonly ICaseContext _context;

        public CompanyService(ICaseContext context)
        {
            _context = context;
        }
        public async void AddCompany(string name)
        {
            Company newCompany = new Company(name);
            _context.Companys.Add(newCompany);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async void AddOffice(int companyId, string name)
        {
            Company company = await _context.Companys.Where(x => x.Id == companyId).FirstOrDefaultAsync(CancellationToken.None);
            Office newOffice = new Office(name);
            company.Offices.Add(newOffice);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async void AddEmployee(string name, string surname, string phone, int companyId)
        {
            Company company = await _context.Companys.FirstOrDefaultAsync(c => c.Id == companyId) ?? throw new ArgumentNullException(nameof(company));
            
            Employee user = new Employee(name, surname, phone);
            company.Employees.Add(user);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
