using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //UC2
            Salary.getAllData();

            //UC5
            Salary.ParticularRange();

            //UC6
            Salary.SumAvgMinMax();

            Console.ReadKey();
        }
    }
}
