use employee

select * from employee
select * from salary

alter table employee
alter column HireDay Date null

alter table employee
alter column BirthDay Date null

select * from employee where DeptNo between 80  and 100

select sum(EmpSal) 'SumOfSalary' from employee as e inner join salary as s on e.EmpId = s.EmpId 

select avg(EmpSal) 'AverageOfSalary' from employee as e inner join salary as s on e.EmpId = s.EmpId 

select min(EmpSal) 'MinimuumOfSalary' from employee as e inner join salary as s on e.EmpId = s.EmpId 

select max(EmpSal) 'MaximuumOfSalary' from employee as e inner join salary as s on e.EmpId = s.EmpId 

select Gender, count(gender) 'CountByGender' from employee as e inner join salary as s on e.EmpId = s.EmpId group by gender
