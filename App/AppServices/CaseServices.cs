using AppCore.Interfaces;
using AppCore.Modeles;

namespace AppServices
{
    public class CaseServices
    {
        private readonly IProblemContext _context;

        public CaseServices(IProblemContext context)
        {
            _context = context;
        }

        public async void AddProblem(string title, string? description, string client, int? deviceId)
        {
            CaseDescription caseDescription = new CaseDescription();
            caseDescription.Description = description;

            Case problem = new Case(title, caseDescription, client, deviceId, DateTime.Now);

            _context.Cases?.Add(problem);

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}