use Employee

select * from Employee
select * from Salary

insert into Employee values
('Terissa', 'F', '2021-5-18', 54, 'terissa@gmail.com', '1997-2-28', 'Sales', '.jpeg')

insert into Salary values
('May', 4500, 4)

create procedure [dbo].[spUpdateEmployeeSalary]
@id int,
@month varchar(20),
@salary int,
@EmpId int
as
BEGIN
--below line will cause transaction uncommitable if constraint violation occur
set XACT_ABORT on;
begin try
begin TRANSACTION;
update SALARY
set EMPSAL=@salary
where SALARYId=@id and SalaryMonth=@month and EmpId=@EmpId;
select e.EmpId,e.ENAME,e.JobDiscription,s.EMPSAL,s.SalaryMonth,s.SALARYId
from Employee e inner join SALARY s
ON e.EmpId=s.EmpId where s.SALARYId=@id;
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
select ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
IF(XACT_STATE())=-1
BEGIN
  PRINT N'The transaction is in an uncommitable state.'+'Rolling back transaction.'
  ROLLBACK TRANSACTION;
  END;

  IF(XACT_STATE())=1
  BEGIN
    PRINT 
	    N'The transaction is committable. '+'Committing transaction.'
       COMMIT TRANSACTION;
	END;
	END CATCH
END
GO


