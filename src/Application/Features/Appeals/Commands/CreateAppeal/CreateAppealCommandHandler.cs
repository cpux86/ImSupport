using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Appeals.Commands.CreateAppeal
{
    public class CreateAppealCommandHandler : IRequestHandler<CreateAppealCommand>
    {
        public Task<Unit> Handle(CreateAppealCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
