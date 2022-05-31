using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            Done = 4
        }
        public int? NomberProblem { get; set; }  
        /// <summary>
        /// Заголовок заявки
        /// </summary>
        public string Title { get; set; } = string.Empty;
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
        public Device? Device { get; private set; }
        /// <summary>
        /// Место, участок или расположение устройства 
        /// </summary>
        public int? LocationId { get; private set; } 
        public Location? Location { get; private set; }
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
        public Problem(string title, string? description, string client, int? deviceId, DateTime dateTime)
        {
            Title = title;
            Description = description;
            Client = client;
            StatusCode = (int)Status.Proccesing;
            //CreatedDataTime = dateTime;
            DeviceId = deviceId;
            LocationId = 1;
        }

    }
}
