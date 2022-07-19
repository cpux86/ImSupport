using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appeals.Commands.CreateAppeal
{
    public class CreateAppealCommand : IRequest
    {
        /// <summary>
        /// Заголовок заявки
        /// </summary>
        public string Title { get; set; }
    }
}
