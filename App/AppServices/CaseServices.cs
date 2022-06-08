using AppCore.Interfaces;
using AppCore.Models;

namespace AppServices
{
    public class CaseServices
    {
        private readonly IProblemContext _context;

        public CaseServices(IProblemContext context)
        {
            _context = context;
        }

        public async void AddCase(string title, string? description, string client, int? deviceId)
        {
            //CaseDescription caseDescription = new CaseDescription();
            //caseDescription.Description = description;

            var newCase = new Case(title, client, deviceId, DateTimeOffset.Now)
            {
                Description = description
            };

            _context.Cases?.Add(newCase);

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}