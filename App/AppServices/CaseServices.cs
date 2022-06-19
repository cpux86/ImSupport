using AppCore.Interfaces;
using AppCore.Models;

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
            //CaseDescription caseDescription = new CaseDescription();
            //caseDescription.Description = description;

            var newCase = new Case(title, client, deviceId, DateTimeOffset.Now)
            {
                Description = description
            };
            WorksList work = new WorksList("Замена термопасты", "10");
            newCase.WorksList = new List<WorksList> { work };
            _context.Cases?.Add(newCase);

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}