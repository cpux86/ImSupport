using Application;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppServicesTests
{
    public class CompanyServiceTests
    {
        [Theory]
        [InlineData("Мультифлекс")]
        public void AddCompany(string name)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
            .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
            .Options;
            CompanyService service = new CompanyService(new CaseContext(options));
            service.AddCompany(name);
        }

        [Theory]
        [InlineData(1, "Генеральный директор")]
        [InlineData(1, "Заместитель генерального директора")]
        [InlineData(1,"101")]
        [InlineData(1,"102")]
        [InlineData(1,"103")]
        public void AddOffice(int companyId,string name)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
            .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
            .Options;
            CompanyService service = new CompanyService(new CaseContext(options));
            service.AddOffice(companyId,name);

        }

        [Theory]
        [InlineData("Владимир","Каськов", "+79997961175", 1)]
        public void AddEmployee(string name, string surname, string phone, int companyId)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
            .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
            .Options;
            CompanyService service = new CompanyService(new CaseContext(options));
            service.AddEmployee(name, surname, phone, companyId);
        }
        [Fact]
        public void GetCompanyList()
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
            .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
            .Options;
            CompanyService service = new CompanyService(new CaseContext(options));
            var companyList = service.GetCompanyList();
        }


    }
}
