using AppServices;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AppServicesTests
{
    public class ProblemServiceTests
    {
        [Theory]
        [InlineData("Не иправность камеры", "работает через раз", "Леднев И")]
        public void AddProblemSuccess(string title, string description, string surnameAndInitials)
        {
            var options = new DbContextOptionsBuilder<ProblemContext>()
            .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
            .Options;
            ProblemServices services = new ProblemServices(new ProblemContext(options));
            services.AddProblem(title, description, surnameAndInitials, 1);
        }
    }
}