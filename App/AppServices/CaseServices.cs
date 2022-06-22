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
        /// <param name="description">Описание</param>
        /// <param name="client">Клиент</param>
        /// <param name="deviceId"></param>
        public async void AddCase(string title, string? description, string client, int? deviceId)
        {
            var newCase = new Case(title, client, deviceId, DateTime.Now)
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