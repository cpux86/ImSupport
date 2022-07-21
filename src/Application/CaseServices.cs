using Application.Exceptions;
using Domain.Enum;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Ardalis.Specification.EntityFrameworkCore;
using Application.Specifications;

namespace Application
{
    public class CaseServices
    {
        #region Fields
        private readonly ICaseContext _context;
        #endregion
        #region Ctor
        public CaseServices(ICaseContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods

        /// <summary>
        /// Добавить новое дело
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="clientOfficeId">ID отдела клиента</param>
        /// <param name="serviceOfficeId">ID отдела сервиса</param>
        /// <param name="description">Описание</param>
        /// <param name="userId">ID клиента</param>
        /// 
        public async void AddCase(string title, int clientOfficeId, int serviceOfficeId, string? description, string userId)
        {
            // получаем отдел клиента
            Department client = await _context.Departments
                .Where(o => o.Id == clientOfficeId)
                .FirstOrDefaultAsync(CancellationToken.None) ?? throw new Exception("Bad request");
            // получаем отдел сервиса
            Department service = await _context.Departments
                .Where(o => o.Id == serviceOfficeId)
                .FirstOrDefaultAsync(CancellationToken.None) ?? throw new Exception("Bad request");

            Case newCase = new Case(title, client, service, userId, DateTime.Now)
            {
                Description = description
            };

            _context.Cases?.Add(newCase);

            await _context.SaveChangesAsync(CancellationToken.None);
        }
        public async Task<Case> GetCaseById(int id)
        {
            var c = await _context.Cases
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync(CancellationToken.None)?? throw new Exception("case not fount");
            return c;
        }
        /// <summary>
        /// Получить количество новых дел
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetQuantityNewCasesAsync()
        {
            var count = await _context.Cases
                .CountAsync(c => c.CaseStatusCode == (byte)Status.Waiting);
            return count;
        }

        public async Task<List<Case>> GetRangeCases(int start = int.MinValue, int count = 30)
        {
            List<int> x = new List<int> { 1, 2, 3, 4, 5, 9, 12 };

            var cases = _context.Cases.Where(q => x.Contains(q.Id)).ToList();

            var caseList = await _context.Cases
                .OrderByDescending(date => date.CreatedDate)
                .Skip(start)
                .Take(count)
                .ToListAsync(CancellationToken.None);
            return caseList;

        }

        /// <summary>
        /// Получить список дел по номеру отдела
        /// </summary>
        /// <param name="officeId"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<Case>> GetCasesByOfficeId(int officeId, int start = 1, int count = 30)
        {
            var caseList = await _context.Cases
                .WithSpecification(new CaseListByOfficeIdSpec(officeId))
                .AsNoTracking()
                //.AsNoTrackingWithIdentityResolution()
                //.Where(c=>c.Service.Id == officeId)
                //.OrderByDescending(date => date.CreatedDate)
                //.Skip(start)
                //.Take(count)
                .ToListAsync(CancellationToken.None);
            return caseList;
        }    

        /// <summary>
        /// Закрыть дело
        /// </summary>
        /// <param name="caseId">ID дела</param>
        /// <param name="workName">Перечень проделанных работ</param>
        /// <param name="caseManager">Сотрудник закрывший дело</param>
        /// <exception cref="Exception"></exception>
        public async void CloseCase(int caseId, string workName, string caseManager)
        {
            //Guid[] employee;
            //List<Employee> employees = await _context.Employees.Where(e => employee.Contains(e.Id)).ToListAsync(CancellationToken.None);

            var c = await _context.Cases
                .Where(c => c.Id == caseId && c.CaseStatusCode != (byte)Status.Done)
                .FirstOrDefaultAsync(CancellationToken.None) ?? throw new ApiException("Не выполнено");
            c?.CloseCase(workName, DateTime.Now, caseManager);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        #endregion
    }
}