use Payroll_Service

alter table employee_payroll add gender char(1)

update employee_payroll set gender = 'F' where name = 'Rani' or name = 'Sita'

update employee_payroll set gender = 'M' where name = 'Prashik'