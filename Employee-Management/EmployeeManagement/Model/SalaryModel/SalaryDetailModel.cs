using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.SalaryModel
{
    class SalaryDetailModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public DateTime HireDay { get; set; }
        public int DepartmentNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string JobDescription { get; set; }
        public string ProfileImage { get; set; }

    }

}
