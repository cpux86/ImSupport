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
    public class EmployeeServiceTests
    {
        [Theory]
        [InlineData("Владимир","Каськов", "+79997961175")]
        public void AddEmployee(string name, string surname, string phone)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
            .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
            .Options;
            EmployeeService services = new EmployeeService(new CaseContext(options));
            services.AddEmployee(name, surname, phone);
        }
    }
}
