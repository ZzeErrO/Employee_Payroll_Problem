use Payroll_Service

select * from employee_payroll

select * from employee_payroll_service

alter table employee_payroll add phone_number int

alter table employee_payroll add  address varchar(40)

alter table employee_payroll add department varchar(40)

ALTER TABLE [dbo].[employee_payroll] ADD  CONSTRAINT [DF_Default_Object_Name]  DEFAULT ('TBD') FOR [department]
GO
