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
        [InlineData("�� ����������� ������", "�������� ����� ���", "������ �")]
        [InlineData("�� �������� ������ �� ���", "�������� ����� ���", "�������� �.")]
        public void AddCaseSuccess(string title, string? description, string client)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
            .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
            .Options;
            CaseServices services = new CaseServices(new CaseContext(options));
            services.AddCase(title, description, client, 1);
        }

        [Theory]
        [InlineData("������ ����� �������", "328d0eb0-cbc3-4116-a440-b8f91c8d782d")]
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