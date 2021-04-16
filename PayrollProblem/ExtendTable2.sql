use Payroll_Service

select * from employee_payroll

select * from employee_payroll_service

alter table employee_payroll add Deduction money

alter table employee_payroll add Taxable_Pay money

alter table employee_payroll add IncomeTax money

alter table employee_payroll add NetPay money

ALTER TABLE [dbo].[employee_payroll] add  CONSTRAINT [DF_Default_Object_Name1]  DEFAULT (0) FOR Deduction
GO

ALTER TABLE [dbo].[employee_payroll] ADD  CONSTRAINT [DF_Default_Object_Name2]  DEFAULT (0) FOR Taxable_Pay
GO

ALTER TABLE [dbo].[employee_payroll] ADD  CONSTRAINT [DF_Default_Object_Name3]  DEFAULT (0) FOR IncomeTax
GO

ALTER TABLE [dbo].[employee_payroll] ADD  CONSTRAINT [DF_Default_Object_Name4]  DEFAULT (0) FOR NetPay
GO