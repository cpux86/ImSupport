using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;
using Domain.Exceptions;

namespace Domain.Models
{
    public class Case
    {
        /// <summary>
        /// Номер заявки или дела
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Заголовок заявки
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Описание неисправности
        /// </summary>
        public string? Description { get; set; }
        public byte CaseStatusCode { get; private set; }

        /// <summary>
        /// Перечень проделанных работ
        /// </summary>
        //public  List<WorksList> WorksList { get; set; }
        public string? WorksList { get; set; } = string.Empty;
        /// <summary>
        /// Устройство подлежащее обслуживанию или ремонту
        /// </summary>
        public int? DeviceId { get; private set; }
        public Device? Device { get; private set; }
        /// <summary>
        /// местоположение обслуживаемого объекта 
        /// </summary>
        public int ClientOfficeId { get; private set; }
        public Office ClientOffice { get; private set; }
        /// <summary>
        /// Исполнитель(и)
        /// </summary>
        public string Master { get; private set; } = string.Empty;
        /// <summary>
        /// Заказчик 
        /// </summary>
        public string Client { get; private set; } = string.Empty;
        /// <summary>
        /// Кто закрыл
        /// </summary>
        public string? CaseManager { get; set; } = string.Empty;
        public DateTime CreatedDate { get; private set; }
        public  DateTime ModifiedDate  { get; set; }

        public Office Service { get; set; }   

        private Case() { }
        public Case(string title, Office clientOffice, Office service, string client, DateTime dateTime)
        {
            Title = title;
            ClientOffice = clientOffice ?? throw new BadRequestException("Bad Request");
            Client = client;
            Service = service;
            CaseStatusCode = (byte)Status.Waiting;
            CreatedDate = dateTime;
            ModifiedDate = dateTime;
            
        }

        public void CloseCase(string worksList, DateTime dateClosed, string caseManager)
        {
            this.CaseStatusCode = (byte)Status.Done;
            this.WorksList = worksList;
            this.ModifiedDate = dateClosed;
            this.CaseManager = caseManager;
        }
    }
}
