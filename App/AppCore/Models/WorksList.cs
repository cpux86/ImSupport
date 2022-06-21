using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public class WorksList
    {
        public  int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        
        //public  List<Case> Cases { get; set; }

        public WorksList(string title, string userId)
        {
            Title = title;
            UserId = userId;
        }
    }
}
