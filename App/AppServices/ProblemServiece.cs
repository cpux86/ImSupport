using AppCore.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class ProblemServiece
    {
        public void NewProblem( string description)
        {
            Problem  problem = new Problem();
            problem.StatusCode = (int)StatusCode.New;
            problem.Description = description;
        }
    }
}
