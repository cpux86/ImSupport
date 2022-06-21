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

        public async void AddCase(string title, string? description, string client, int? deviceId)
        {
            var newCase = new Case(title, client, deviceId, DateTimeOffset.Now)
            {
                Description = description
            };

            _context.Cases?.Add(newCase);

            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async void CloseCase(int caseId ,string workName, string caseManager)
        {
            var c = await _context.Cases
                .Where(c => c.Id == caseId && c.CaseStatusCode != (byte)Case.Status.Done)
                .FirstOrDefaultAsync(CancellationToken.None) ?? throw new Exception("bad request");
            c?.CloseCase(workName,DateTimeOffset.Now, caseManager);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}