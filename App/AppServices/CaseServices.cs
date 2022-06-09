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
            TypeOfWork work = new TypeOfWork("Замена термопасты", "10");
            newCase.TypeOfWorks = new List<TypeOfWork> { work };
            _context.Cases?.Add(newCase);

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}