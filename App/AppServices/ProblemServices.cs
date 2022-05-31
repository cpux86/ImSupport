using AppCore.Interfaces;
using AppCore.Modeles;

namespace AppServices
{
    public class ProblemServices
    {
        private readonly IProblemContext _context;

        public ProblemServices(IProblemContext context)
        {
            _context = context;
        }

        public async void AddProblem(string title, string? description, string client, int? deviceId)
        {
            Problem problem = new Problem(title, description, client, deviceId, DateTime.Now);

            _context.Problems?.Add(problem);

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}