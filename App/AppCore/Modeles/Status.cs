using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Modeles
{
    public class Status
    {
        // не отработаная
        // в работе
        // приостановленна
        // отклонена
        //public enum StatusCode
        //{
        //    New = 1,
        //    Stopped = 2,
        //}
        public int StatusCode { get; set; }
        public string? Description { get; set; }

        public void New(string message = "не отработано")
        {
            StatusCode = 1;
            Description = "не отработана";
        }
        
        public void Runnig()
        {
            StatusCode = 2;
            Description = "в работе";
        }
        /// <summary>
        /// приостановлено
        /// </summary>
        public void Stopped(string message = "приостановленно")
        {
            StatusCode = 3;
            Description = message;
        }
        /// <summary>
        /// отклонено
        /// </summary>
        public void Rejectd(string message = "отклонено")
        {
            StatusCode = 4;
            Description = message;
        }

    }
}
