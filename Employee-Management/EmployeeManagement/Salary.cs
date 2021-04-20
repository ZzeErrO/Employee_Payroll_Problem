using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model.SalaryModel;

namespace EmployeeManagement
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public static void getAllData()
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            try
            {
                using (SalaryConnection)
                {
                    string query = @"select * from employee";
                    SqlCommand command = new SqlCommand(query, SalaryConnection);
                    SalaryConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    SalaryDetailModel model = new SalaryDetailModel();
                    Console.WriteLine("----------TABLE FOR EMPLOYEE----------");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.EmployeeId = dr.GetInt32(0);
                            model.EmployeeName = dr.GetString(1);
                            model.Gender = dr.GetString(2);
                            model.Month = dr.GetDateTime(3);
                            model.DepartmentNumber = dr.GetInt32(4);
                            model.Email = dr.GetString(5);
                            model.BirthDay = dr.GetDateTime(6);
                            model.JobDescription = dr.GetString(7);
                            model.ProfileImage = dr.GetString(8);
                            Console.WriteLine(model.EmployeeId + " " + 
                                model.EmployeeName + " " 
                                + model.Gender + " " 
                                + model.Month + " "
                                + model.DepartmentNumber + " "
                                + model.Email + " "
                                + model.BirthDay + " "
                                + model.JobDescription + " "
                                + model.ProfileImage);

                        }
                    }
                    SalaryConnection.Close();
                    query = @"Select * from Salary";
                    SqlCommand command1 = new SqlCommand(query, SalaryConnection);
                    SalaryConnection.Open();
                    SqlDataReader dr1 = command1.ExecuteReader();
                    SalaryUpdateModel display = new SalaryUpdateModel();
                    Console.WriteLine("----------TABLE FOR SALARY----------");
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            display.SalaryId = dr1.GetInt32(0);
                            display.Month = dr1.GetString(1);
                            display.EmployeeSalary = dr1.GetDecimal(2);
                            display.EmployeeId = dr1.GetInt32(3);

                            Console.WriteLine(display.SalaryId + " " +
                                display.Month + " "
                                + display.EmployeeSalary + " "
                                + display.EmployeeId);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
        }

        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            int salary = 0;
            try
            {
                using (SalaryConnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary", SalaryConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpId", salaryUpdateModel.EmployeeId);
                    SalaryConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.EmployeeId = Convert.ToInt32(dr["EmpId"]);
                            displayModel.EmployeeName = dr["EName"].ToString();
                            displayModel.JobDescription = dr["JobDiscription"].ToString();
                            displayModel.EmployeeSalary = Convert.ToInt32(dr["EmpSal"]);
                            displayModel.Month = (DateTime)dr["SalaryMonth"];
                            //displayModel.SalaryId = Convert.ToInt32(dr["SalaryId"]);
                            Console.WriteLine(displayModel.EmployeeName + " " 
                                + displayModel.EmployeeSalary + " " 
                                + displayModel.Month);

                            Console.WriteLine("\n");
                            salary = displayModel.EmployeeSalary;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            return salary;
        }

    }

}
