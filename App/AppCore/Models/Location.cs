using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public class Location : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<Device> Devices { get; set; } = new List<Device>();
    }
}
