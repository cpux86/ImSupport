using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
//#nullable disable
    public class Department : BaseEntity
    {
        /// <summary>
        /// Название отдела, подразделения компании
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Начальник отдела 
        /// </summary>
        public Employee HeadOfDepartment { get; private set; }
        /// <summary>
        /// Офисы и кабинеты отдела
        /// </summary>
        public IEnumerable<Office> Offices { get; private set; }

        /// <summary>
        /// Сотрудники отдела, офиса или кабинета компании
        /// </summary>
        public List<Employee> Employees { get; private set; } = new List<Employee>();
        /// <summary>
        /// Оборудование отдела, офиса и кабинета
        /// </summary>
        public List<Device>? Devices { get; private set; }
        /// <summary>
        /// Компания к которой принадлежит отдел
        /// </summary>
        public Company Company { get; private set; }
        public Department(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void AddEmployee(Employee employee) {
            // 
            bool isSet = Employees.Any(e => e.Phone == employee.Phone);
            if (isSet) throw new Exception("пользователь с таким номером существует");

            this.Employees.Add(employee);
        }

    }
}
