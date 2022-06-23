using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employee
    {
        public Guid Id { get; private set; }
        // <summary>
        /// Имя
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; private set; }      
        /// <summary>
        /// Номер мобильного телефона
        /// </summary>
        public string Phone { get; private set; }
        /// <summary>
        /// Номер рабочего телефона
        /// </summary>
        public string WorkPhone { get; private set; } = string.Empty;
        /// <summary>
        /// Место работы
        /// </summary>
        public Company Company { get; private set; }

        public Employee(string name, string surname, string phone)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }
    }
}
