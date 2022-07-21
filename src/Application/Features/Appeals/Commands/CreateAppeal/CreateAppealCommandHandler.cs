using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Appeals.Commands.CreateAppeal
{
    public class CreateAppealCommandHandler : IRequestHandler<CreateAppealCommand>
    {
        private readonly ICaseContext _context;

        public CreateAppealCommandHandler(ICaseContext caseContext)
        {
            _context = caseContext;
        }

        public async Task<Unit> Handle(CreateAppealCommand request, CancellationToken cancellationToken)
        {
            // получаем отдел клиента
            Department client = await _context.Departments
                .Where(o => o.Id == request.ClientOfficeId)
                .FirstOrDefaultAsync(CancellationToken.None) ?? throw new Exception("Bad request");
            // получаем отдел сервиса
            Department service = await _context.Departments
                .Where(o => o.Id == request.ServiceOfficeId)
                .FirstOrDefaultAsync(CancellationToken.None) ?? throw new Exception("Bad request");

            Case newCase = new Case(request.Title, client, service, request.ClientId, DateTime.Now)
            {
                Description = request.Description,
            };

            _context.Cases?.Add(newCase);

            await _context.SaveChangesAsync(CancellationToken.None);
            return Unit.Value;
        }
    }
}
