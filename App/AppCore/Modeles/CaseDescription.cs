using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Modeles
{
    public class CaseDescription : BaseEntity
    {
        public int CaseId { get; set; } 
        public Case Case { get; set; }    
        public string Description { get; set; } = String.Empty;
    }
}
