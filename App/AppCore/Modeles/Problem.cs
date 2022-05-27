using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Modeles
{
    public class Problem : BaseEntity
    {
        /// <summary>
        /// Описание неисправности
        /// </summary>
        public string Description { get; set; }
        public int Status { get; set; }  

        /// <summary>
        /// Испольнитель(и)
        /// </summary>
        public string Executor { get; set; }
        /// <summary>
        /// Кто опубликовал задачу
        /// </summary>
        public string Author { get; set; } 
        //public string ServiceCenter { get; set; }   

        public void NewProblem(string description, string user)
        {
            Description = description;
            Status = 1;
            Author = user;
           
        }
    }
}
