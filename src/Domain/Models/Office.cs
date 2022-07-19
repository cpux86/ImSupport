using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
//#nullable disable
    public class Office : BaseEntity
    {
        /// <summary>
        /// Название или номер кабинета-офиса
        /// </summary>
        public string Name { get; private set; } = string.Empty;
        /// <summary>
        /// Отдел к которому относится офис-кабинет
        /// </summary>
        public Department? Department { get; private set; }
        public Company Company { get; private set; }
    }
}
