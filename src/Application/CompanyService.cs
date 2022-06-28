using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Application
{
    public class CompanyService
    {
        private readonly ICaseContext _context;

        public CompanyService(ICaseContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Создать новую компанию
        /// </summary>
        /// <param name="name">Название компании</param>
        public async void AddCompany(string name)
        {
            Company newCompany = new Company(name);
            _context.Companys.Add(newCompany);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
        /// <summary>
        /// Добавить новый отдел в компанию
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="name">Название отдела</param>
        public async void AddOffice(int companyId, string name)
        {
            Company company = await _context.Companys.Where(x => x.Id == companyId)
                .FirstOrDefaultAsync(CancellationToken.None);
            Office newOffice = new Office(name);
            company.Offices.Add(newOffice);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
        /// <summary>
        /// Добавить сотрудника в компанию
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phone"></param>
        /// <param name="companyId"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public async void AddEmployee(string name, string surname, string phone, int companyId)
        {
            Company company = await _context.Companys
                .FirstOrDefaultAsync(c => c.Id == companyId) ?? throw new ArgumentNullException(nameof(company));
            var isSet = _context.Employees
                .Where(x => x.Company.Id == companyId && x.Phone == phone)
                .Any();
            if (isSet) throw new BadRequestException("Пользователь существует");
            Employee user = new Employee(name, surname, phone);
            company.Employees.Add(user);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public List<Company> GetCompanyList()
        {
            var res = _context.Companys.ToList();
            return res;
        }
    }
}
