using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public class Office : BaseEntity
    {
        /// <summary>
        /// Название отдела, офиса или номер кабинета компании
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Сотрудники отдела, офиса или кабинета компании
        /// </summary>
        public List<Employee> Employees { get; private set; }
        /// <summary>
        /// Оборудование отдела, офиса и кабинета
        /// </summary>
        public List<Device> Devices { get; private set; } = new List<Device>();
        public Office(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void AddEmployee(Employee employee) {
            // 
            bool isSet = this.Employees.Any(e => e.Phone == employee.Phone);
            if (isSet) throw new Exception("пользователь с таким номером существует");

            this.Employees.Add(employee);
        }

    }
}
