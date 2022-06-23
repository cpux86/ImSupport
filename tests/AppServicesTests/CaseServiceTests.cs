using System;
using System.Text;
using Domain.Models;
using Application;
using Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AppServicesTests
{
    public class CaseServiceTests
    {
        [Theory]
        [InlineData("�� ����������� ������", 1, 2,"�������� ����� ���", "������ �")]
        [InlineData("�� �������� ������ �� ���", 1, 2, "�������� ����� ���", "�������� �.")]
        public void AddCaseSuccess(string title, int clientOfficeId, int serviceOfficeId, string? description, string client)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
            .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
            .Options;
            CaseServices services = new CaseServices(new CaseContext(options));
            services.AddCase(title, clientOfficeId, serviceOfficeId, description, client);
        }

        [Theory]
        [InlineData("������ ����� �������", "90493479437")]
        public void AddTypeWorkSuccess(string title, string userId)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
                .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
                .Options;
            userId = $"{Guid.NewGuid()}";
            WorkService services = new WorkService(new CaseContext(options));
            services.AddType(title, userId);
        }

        [Theory]
        [InlineData(1)]
        public void RemoveWorkByIdSuccess(int id)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
                .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
                .Options;
            WorkService services = new WorkService(new CaseContext(options));
            services.RemoveById(id);
        }

        [Theory]
        [InlineData(1)]
        public void RemomeWorkAllSuccess(int id)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
                .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
                .Options;
            WorkService services = new WorkService(new CaseContext(options));
            services.RemoveAllByUserId();
        }
        [Theory]
        [InlineData(1,"������ ����������", "������� �.�")]
        [InlineData(2, "��������� ���������", "������� �.�")]
        public void CloseCase(int caseId, string workName, string caseManager)
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
                .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
                .Options;
            CaseServices services = new CaseServices(new CaseContext(options));
            services.CloseCase(caseId, workName,caseManager);
        }
        [Fact]
        public async void GetQuantityNewCases()
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
                .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
                .Options;
            CaseServices services = new CaseServices(new CaseContext(options));
            var allCase = await services.GetQuantityNewCasesAsync();
        }

        [Fact]
        public async void GetRangeCases()
        {
            var options = new DbContextOptionsBuilder<CaseContext>()
                .UseSqlite(@"DataSource=C:\C#\ImSupport\DB\ImSupport.db")
                .Options;
            CaseServices services = new CaseServices(new CaseContext(options));
            var c = await services.GetRangeCases(1,1);
        }
    }
}