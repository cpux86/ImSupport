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
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// ID клиента
        /// </summary>
        public string ClientId { get; set; } = string.Empty;
        /// <summary>
        /// ID отдела клиента
        /// </summary>
        public int ClientDepartmentId { get; set; }
        /// <summary>
        /// ID кабинета клиента
        /// </summary>
        public int ClientOfficeId { get; set; }
        /// <summary>
        /// ID отдела адресата
        /// </summary>
        public int ServiceOfficeId { get; set; }
    }
}
