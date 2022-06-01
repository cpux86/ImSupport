using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Modeles
{
    public class Device : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public Location? Location { get; set; }
        public string? Description { get; set; }
        public List<Case>? Problem { get; set; }
    }
}
