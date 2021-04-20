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
        //UC1
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        //UC2
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
                            model.HireDay = dr.GetDateTime(3);
                            model.DepartmentNumber = dr.GetInt32(4);
                            model.Email = dr.GetString(5);
                            model.BirthDay = dr.GetDateTime(6);
                            model.JobDescription = dr.GetString(7);
                            model.ProfileImage = dr.GetString(8);
                            Console.WriteLine(model.EmployeeId + " " + 
                                model.EmployeeName + " " 
                                + model.Gender + " " 
                                + model.HireDay + " "
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

        //UC3 and UC4
        public decimal UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            decimal salary = 0;
            try
            {
                using (SalaryConnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SalaryUpdateModel display = new SalaryUpdateModel();
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
                            display.EmployeeSalary = Convert.ToInt32(dr["EmpSal"]);
                            //displayModel.HireDay = Convert.ToDateTime(dr["SalaryMonth"]);
                            //displayModel.HireDay = DateTime.ParseExact(dr["SalaryMonth"], "dd/MM/yyyy", null);
                            //displayModel.HireDay = dr.GetDateTime(3);
                           // displayModel.HireDay = dr.GetDateTime(3).ToString();
                           // displayModel.HireDay = 
                            display.SalaryId = Convert.ToInt32(dr["SalaryId"]);

                            Console.WriteLine(displayModel.EmployeeName + " " 
                                + display.EmployeeSalary + " " 
                                + display.SalaryId);

                            Console.WriteLine("\n");
                            salary = display.EmployeeSalary;
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

        //UC5
        public static void ParticularRange()
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            try
            {
                using (SalaryConnection)
                {
                    string query = @"select * from employee where DeptNo between 80  and 100";
                    SqlCommand command = new SqlCommand(query, SalaryConnection);
                    SalaryConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    SalaryDetailModel model = new SalaryDetailModel();
                    Console.WriteLine("----------TABLE FOR EMPLOYEE WITH A SPECIFIC DEPARTMENTNUMBER RANGE----------");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.EmployeeId = dr.GetInt32(0);
                            model.EmployeeName = dr.GetString(1);
                            model.Gender = dr.GetString(2);
                            model.HireDay = dr.GetDateTime(3);
                            model.DepartmentNumber = dr.GetInt32(4);
                            model.Email = dr.GetString(5);
                            model.BirthDay = dr.GetDateTime(6);
                            model.JobDescription = dr.GetString(7);
                            model.ProfileImage = dr.GetString(8);
                            Console.WriteLine(model.EmployeeId + " " +
                                model.EmployeeName + " "
                                + model.Gender + " "
                                + model.HireDay + " "
                                + model.DepartmentNumber + " "
                                + model.Email + " "
                                + model.BirthDay + " "
                                + model.JobDescription + " "
                                + model.ProfileImage);

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

        //UC6
        public static void SumAvgMinMax()
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            try
            {
                using (SalaryConnection)
                {
                    string query = @"select sum(EmpSal) 'SumOfSalary' from employee as e inner join salary as s on e.EmpId = s.EmpId ";
                    SqlCommand command = new SqlCommand(query, SalaryConnection);
                    SalaryConnection.Open();
                    string sum = command.ExecuteScalar().ToString();
                    Console.WriteLine("\nSUM OF SALARY : " + sum);

                    string query1 = @"select avg(EmpSal) 'AverageOfSalary' from employee as e inner join salary as s on e.EmpId = s.EmpId ";
                    SqlCommand command1 = new SqlCommand(query1, SalaryConnection);
                    string avg = command1.ExecuteScalar().ToString();
                    Console.WriteLine("AVERAGE OF SALARY : " + avg);

                    string query2 = @"select min(EmpSal) 'MinimuumOfSalary' from employee as e inner join salary as s on e.EmpId = s.EmpId ";
                    SqlCommand command2 = new SqlCommand(query2, SalaryConnection);
                    string min = command2.ExecuteScalar().ToString();
                    Console.WriteLine("MINIMUM OF SALARY : " + min);

                    string query3 = @"select max(EmpSal) 'MaximuumOfSalary' from employee as e inner join salary as s on e.EmpId = s.EmpId ";
                    SqlCommand command3 = new SqlCommand(query3, SalaryConnection);
                    string max = command3.ExecuteScalar().ToString();
                    Console.WriteLine("MAXIMUM OF SALARY : " + max);

                    string query4 = @"select Gender, count(gender) 'CountByGender' from employee as e inner join salary as s on e.EmpId = s.EmpId group by gender ";
                    SqlCommand command4 = new SqlCommand(query4, SalaryConnection);
                    SqlDataReader dr = command4.ExecuteReader();
                    Console.WriteLine("----------TABLE FOR MALE AND FEMALE EMPLOYEE COUNT----------");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            char i = 'F';
                            if (i == Convert.ToChar(dr["Gender"]))
                            {
                                int Female = Convert.ToInt32(dr["CountByGender"]);
                                Console.WriteLine("Female : " + Female);
                            }
                            else
                            {
                                int Male = Convert.ToInt32(dr["CountByGender"]);
                                Console.WriteLine("Male : " + Male);
                            }

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

    }

}
