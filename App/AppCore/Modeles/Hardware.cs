using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Modeles
{
    public class Hardware : BaseEntity
    {
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
    }
}
