using System;
using System.Text;
using AppServices;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AppServicesTests
{
    public class CaseServiceTests
    {
        [Theory]
        [InlineData("Не исправность камеры", "работает через раз", "Леднев И")]
        [InlineData("Не работают камеры на УСК", "работает через раз", "Горбаток Е.")]
        public void AddCaseSuccess(string title, string? description, string client)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
            .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
            .Options;
            CaseServices services = new CaseServices(new CaseContext(options));
            services.AddCase(title, description, client, 1);
        }

        [Theory]
        [InlineData("Замена блока питания", "328d0eb0-cbc3-4116-a440-b8f91c8d782d")]
        public void AddTypeWorkSuccess(string title, string userId)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
                .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
                .Options;
            TypeWorkService services = new TypeWorkService(new CaseContext(options));
            services.AddType(title, userId);
        }
    }
}