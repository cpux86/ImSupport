using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public class TypeOfWork
    {
        public  int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        
        public  List<Case> Cases { get; set; }

        public TypeOfWork(string title, string userId)
        {
            Title = title;
            UserId = userId;
        }
    }
}
