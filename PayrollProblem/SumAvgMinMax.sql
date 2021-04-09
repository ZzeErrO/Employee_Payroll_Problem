use Payroll_Service

select sum(salary) from employee_payroll

select avg(salary) from employee_payroll

select min(salary) from employee_payroll

select max(salary) from employee_payroll

select gender,sum(salary) from employee_payroll group by gender

select gender,avg(salary) from employee_payroll group by gender

select gender,min(salary) from employee_payroll group by gender

select gender,max(salary) from employee_payroll group by gender

select gender,avg(salary) as 'Average Salary' from employee_payroll group by gender