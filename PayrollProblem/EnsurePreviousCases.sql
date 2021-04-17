use payroll_service

alter table Department
add dept_id int identity(1,1) primary key not null

alter table payroll
add payroll_id int identity(1,1) primary key not null

select * from ((employee_payroll inner join Department
on employee_payroll.id = Department.id)
inner join Company on employee_payroll.id = Company.id)
inner join payroll on payroll.id = employee_payroll.id


select Company.salary from ((employee_payroll inner join Department
on employee_payroll.id = Department.id)
inner join Company on employee_payroll.id = Company.id)
inner join payroll on payroll.id = employee_payroll.id
where start between '2019-01-01' and getdate()

select sum(Company.salary) as SalarySum from ((employee_payroll inner join Department
on employee_payroll.id = Department.id)
inner join Company on employee_payroll.id = Company.id)
inner join payroll on payroll.id = employee_payroll.id

select avg(Company.salary) as SalaryAverage from ((employee_payroll inner join Department
on employee_payroll.id = Department.id)
inner join Company on employee_payroll.id = Company.id)
inner join payroll on payroll.id = employee_payroll.id

select max(Company.salary) as SalaryMax from ((employee_payroll inner join Department
on employee_payroll.id = Department.id)
inner join Company on employee_payroll.id = Company.id)
inner join payroll on payroll.id = employee_payroll.id

select min(Company.salary) as SalaryMin from ((employee_payroll inner join Department
on employee_payroll.id = Department.id)
inner join Company on employee_payroll.id = Company.id)
inner join payroll on payroll.id = employee_payroll.id

select employee_payroll.gender, count(gender) as 'Count' from ((employee_payroll inner join Department
on employee_payroll.id = Department.id)
inner join Company on employee_payroll.id = Company.id)
inner join payroll on payroll.id = employee_payroll.id
group by gender

select employee_payroll.name, sum(Company.salary) as SalarySum from ((employee_payroll inner join Department
on employee_payroll.id = Department.id)
inner join Company on employee_payroll.id = Company.id)
inner join payroll on payroll.id = employee_payroll.id
group by employee_payroll.name

