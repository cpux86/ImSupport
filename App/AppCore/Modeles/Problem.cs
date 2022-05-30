using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Modeles
{
    public class Problem : BaseEntity
    {
        private enum Status
        {
            Proccesing = 1,
            Running = 2,
            Stopped = 3,
            Success = 4
        }

        /// <summary>
        /// Описание неисправности
        /// </summary>
        public string Description { get; private set; } = String.Empty;
        public int StatusCode { get; private set; }
        /// <summary>
        /// Ответ для клиента
        /// </summary>
        public string Message { get; private set; } = String.Empty;
        /// <summary>
        /// Устройсво подлежащее обслуживанию или ремонту
        /// </summary>
        public int? DeviceId { get; private set; }

        /// <summary>
        /// Испольнитель(и)
        /// </summary>
        public string Executor { get; private set; } = String.Empty;
        /// <summary>
        /// Кто опубликовал задачу
        /// </summary>
        public string Client { get; private set; } = String.Empty;
        public DateTime CreatedDataTime { get; private set; }

        //public string ServiceCenter { get; set; }   

        private Problem() { }
        public Problem(string description, string client, DateTime dateTime, int? deviceId)
        {
            Description = description;
            Client = client;
            StatusCode = (int)Status.Proccesing;
            CreatedDataTime = dateTime;
            DeviceId = deviceId;
        }

    }
}
