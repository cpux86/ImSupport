using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models
{
    public class Case
    {
        public enum Status : byte
        {
            Proccesing = 1,
            Running = 2,
            Stopped = 3,
            Done = 4
        }
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
        public int? LocationId { get; private set; }
        public Location? Location { get; private set; }
        /// <summary>
        /// Исполнитель(и)
        /// </summary>
        public string Master { get; private set; } = string.Empty;
        /// <summary>
        /// Заказчик 
        /// </summary>
        public string Client { get; private set; } = string.Empty;

        /// <summary>
        /// кто закрыл
        /// </summary>
        public string? CaseManager { get; set; } = string.Empty;
        public DateTimeOffset CreatedDate { get; private set; }
        public  DateTimeOffset ModifiedDate  { get; set; }

        //public string ServiceCenter { get; set; }   

        private Case() { }
        public Case(
            string title,
            string client,
            int? deviceId,
            DateTimeOffset dateTime
            )
        {
            Title = title;
            Client = client;
            CaseStatusCode = (byte)Status.Proccesing;
            CreatedDate = dateTime;
            ModifiedDate = dateTime;
            DeviceId = deviceId;
            LocationId = 1; //test
        }

        public void CloseCase(string worksList, DateTimeOffset dateClosed, string caseManager)
        {
            this.CaseStatusCode = (byte)Status.Done;
            this.WorksList = worksList;
            this.ModifiedDate = dateClosed;
            this.CaseManager = caseManager;
        }
    }
}
