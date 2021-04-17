use payroll_service

create table Department
(
id int not null,
department varchar(40) not null,
name varchar(20) not null,
foreign key(id) references employee_payroll(id)
);

insert into Department values 
(1, 'TBD', 'Prashik'),
(2, 'TBD', 'Rani'),
(3, 'TBD', 'Sita'),
(4, 'Sales', 'Terissa'),
(5, 'Marketing', 'Terissa')

alter table employee_payroll
drop column department

ALTER TABLE [dbo].[employee_payroll] drop  CONSTRAINT [DF_Default_Object_Name]

ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Default_Object_Name]  DEFAULT ('TBD') FOR [department]
GO

create table Company
(
id int not null,
name varchar(20) not null,
salary money not null,
start date not null,
primary key (id),
foreign key(id) references employee_payroll(id)
)

insert into Company values
(1, 'Prashik', 100000, '2018-01-03'),
(2, 'Rani', 200000, '2019-02-23'),
(3, 'Sita', 10000, '2020-05-21'),
(4, 'Terissa', 6544643, '2021-01-12'),
(5, 'Terissa', 5656635, '2012-01-12')

alter table employee_payroll
drop column salary, start

create table payroll
(
	id int not null,
	[Deduction] [money] NULL,
	[Taxable_Pay] [money] NULL,
	[IncomeTax] [money] NULL,
	[NetPay] [money] NULL,
	foreign key(id) references employee_payroll(id)
)

insert into payroll values
(1, 0, 0, 0, 0),
(2, 0, 0, 0, 0),
(3, 0, 0, 0, 0),
(4, 519, 6395, 2156, 541653),
(5, 120, 2166, 7616, 416431)

alter table employee_payroll
drop column deduction, taxable_pay, incometax, netpay

select * from employee_payroll
select * from Department
select * from Company
select * from payroll