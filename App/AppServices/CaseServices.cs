using AppCore.Interfaces;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppServices
{
    public class CaseServices
    {
        private readonly ICaseContext _context;

        public CaseServices(ICaseContext context)
        {
            _context = context;
        }
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
            Office client = await _context.Offices
                .Where(o => o.Id == clientOfficeId)
                .FirstOrDefaultAsync(CancellationToken.None) ?? throw new Exception("Bad request");
            // получаем отдел сервиса
            Office service = await _context.Offices
                .Where(o => o.Id == serviceOfficeId)
                .FirstOrDefaultAsync(CancellationToken.None) ?? throw new Exception("Bad request");

            Case newCase = new Case(title, client, service, userId, DateTime.Now)
            {
                Description = description
            };

            _context.Cases?.Add(newCase);

            await _context.SaveChangesAsync(CancellationToken.None);
        }
        /// <summary>
        /// Получить количество новых дел
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetQuantityNewCasesAsync()
        {
            var count = await _context.Cases
                .CountAsync(c => c.CaseStatusCode == (byte)Case.Status.Waiting);
            return count;
        }
       
        public async Task<List<Case>> GetRangeCases(int start= int.MinValue, int count=30)
        {
            var caseList = await _context.Cases
                .OrderByDescending(date=>date.CreatedDate)
                .Skip(start)
                .Take(count)
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
        public async void CloseCase(int caseId ,string workName, string caseManager)
        {
            var c = await _context.Cases
                .Where(c => c.Id == caseId && c.CaseStatusCode != (byte)Case.Status.Done)
                .FirstOrDefaultAsync(CancellationToken.None) ?? throw new Exception("bad request");
            c?.CloseCase(workName,DateTime.Now, caseManager);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}