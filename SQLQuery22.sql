use LR3Db
GO

select emp.FIO
from Employees emp
where (Salary >= 22000 and Salary <= 35000) 
	or (SalaryPerHour*Hours >= 22000 and SalaryPerHour*Hours <= 35000)

select emp.FIO
from Employees emp
inner join EmployeeFilial on EmployeeFilial.EmployeesId = emp.Id
inner join Filials on Filials.Id = EmployeeFilial.FilialsId
where Filials.Name = 'Северный'

select emp.FIO
from Employees emp
where emp.AccrualType = 2