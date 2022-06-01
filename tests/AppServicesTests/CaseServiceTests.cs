using AppServices;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AppServicesTests
{
    public class CaseServiceTests
    {
        [Theory]
        [InlineData("Не иправность камеры", "работает через раз", "Леднев И")]
        [InlineData("Не работают камеры на УСК", "работает через раз", "Горбаток Е.")]
        public void AddCaseSuccess(string title, string? description, string client)
        {
            var options = new DbContextOptionsBuilder<ProblemContext>()
            .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
            .Options;
            CaseServices services = new CaseServices(new ProblemContext(options));
            services.AddProblem(title, description, client, 1);
        }
    }
}