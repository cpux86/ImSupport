using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models
{
    public class Case
    {
        public enum Status : byte
        {
            /// <summary>
            /// Ожидание исполнения
            /// </summary>
            Waiting = 1,
            /// <summary>
            /// В работе
            /// </summary>
            Running = 2,
            /// <summary>
            /// Приостановлено
            /// </summary>
            Stopped = 3,
            /// <summary>
            /// Выполнено, завершено
            /// </summary>
            Done = 4,
            /// <summary>
            /// Отменено
            /// </summary>
            Cancelled = 5
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
        public int LocationId { get; private set; }
        public Office Office { get; private set; }
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

        public string ServiceCenter { get; set; }   

        private Case() { }
        public Case(string title, Office office, string client, DateTime dateTime)
        {
            Title = title;
            Office = office ?? throw new ArgumentNullException("не верный запрос!");
            Client = client;
            CaseStatusCode = (byte)Status.Waiting;
            CreatedDate = dateTime;
            ModifiedDate = dateTime;
            //Device = device;
            //DeviceId = deviceId;
            //LocationId = 1; //test
        }

        //public Case(string title, Device? device, Location location, string client, DateTime createdDate, DateTime modifiedDate)
        //{
        //    Title = title ?? throw new ArgumentNullException(nameof(title));
        //    Device = device;
        //    Location = location ?? throw new ArgumentNullException(nameof(location));
        //    Client = client ?? throw new ArgumentNullException(nameof(client));
        //    CreatedDate = createdDate;
        //    ModifiedDate = modifiedDate;
        //}

        public void CloseCase(string worksList, DateTime dateClosed, string caseManager)
        {
            this.CaseStatusCode = (byte)Status.Done;
            this.WorksList = worksList;
            this.ModifiedDate = dateClosed;
            this.CaseManager = caseManager;
        }
    }
}
