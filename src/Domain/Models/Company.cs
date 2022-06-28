using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Company : BaseEntity
    {
        /// <summary>
        /// Название компании
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// ИНН компании
        /// </summary>
        public string? INN { get; private set; }
        /// <summary>
        /// Сотрудники компании
        /// </summary>
        public List<Employee> Employees { get; private set; } = new List<Employee>();
        /// <summary>
        /// Отделы, офисы, кабинеты компании
        /// </summary>
        public List<Office> Offices { get; private set; } = new List<Office>();

        public Company(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }     
    }
}
