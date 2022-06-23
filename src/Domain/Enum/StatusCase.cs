using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
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
    public class StatusCase
    {
    }
}
