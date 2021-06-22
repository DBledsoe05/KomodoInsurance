using DeveloperPoco;
using DevTeamPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoUi
{
    class Program
    {
        static void Main(string[] args)
        {
            Developers denzel = new Developers("Denzel", "Bledsoe", 23432, true);
            ProgramUI program = new ProgramUI();
            program.Run();
        }
    }
}
