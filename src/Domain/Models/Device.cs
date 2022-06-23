using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Device : BaseEntity
    {
        public string Name { get; private set; }
        public Office Office { get; set; }
        public string? Description { get; private set; }
        public List<Case>? Cases { get; private set; }
        private Device() {}
        public Device(string name, Office office, string? description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Office = office;
            Description = description;
        }


    }
}
