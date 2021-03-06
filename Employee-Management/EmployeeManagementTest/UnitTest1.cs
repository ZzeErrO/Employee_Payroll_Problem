using System;
using EmployeeManagement;
using EmployeeManagement.Model.SalaryModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagementTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDataAbleToUpdateSalaryDetails()
        {
            Salary salary = new Salary();
            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {
                SalaryId = 3,
                Month = "May",
                EmployeeSalary = 3000000.0M,
                EmployeeId = 4
            };

            decimal EmpSalary = salary.UpdateEmployeeSalary(updateModel);

            Assert.AreEqual(updateModel.EmployeeSalary, EmpSalary);
        }
    }


}
