using System;
using System.Collections.Generic;
using System.Linq;

namespace LR3_DB
{
	class Program
	{
		static void Main(string[] args)
		{
			EmployeeContext context = new EmployeeContext();
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			Filial filial1 = new Filial()
			{
				Name = "Северный",
				Address = "ул.Южнопортовая, дом 31"
			};
			context.Filials.Add(filial1);
			Filial filial2 = new Filial()
			{
				Name = "Южный",
				Address = "ул.Ленина, дом 27"
			};
			context.Filials.Add(filial2);

			List<Filial> North = new List<Filial>() { filial1 };
			List<Filial> South = new List<Filial>() { filial2 };
			List<Filial> Both = new List<Filial>() { filial1, filial2 };

			context.Employees.Add(new Employee()
			{
				FIO = "Даниил Даниилович Двойнов",
				Position = "Уборщик",
				Filials = Both,
				AccrualType = 2,
				Hours = 24,
				SalaryPerHour = 200
			}); ;
			context.Employees.Add(new Employee()
			{
				FIO = "Игнатий Варфаломеевич Петров",
				Position = "Аналитик",
				Filials = South,
				AccrualType = 1,
				Salary = 50000
			});
			context.Employees.Add(new Employee()
			{
				FIO = "Генадий Петрович Сидоров",
				Position = "Генеральный",
				Filials = Both,
				AccrualType = 1,
				Salary = 30000
			});
			context.Employees.Add(new Employee()
			{
				FIO = "Иван Иванович Иванов",
				Position = "Главный специалист",
				Filials = North,
				AccrualType = 1,
				Salary = 55000
			});
			context.Employees.Add(new Employee()
			{
				FIO = "Артемий Вахтангович Орматян",
				Position = "Системный администратор",
				Filials = South,
				AccrualType = 2,
				Hours = 20,
				SalaryPerHour = 1200
			});

			context.SaveChanges();

			Console.WriteLine("Люди с зарплатой от 22 до 35 тысяч");
			IQueryable<Employee> employees = from emp in context.Employees
											 where (emp.Salary >= 22000 && emp.Salary <= 35000)
												|| (emp.SalaryPerHour*emp.Hours >= 22000 && emp.Salary <= 35000)
											 select emp;
			List<Employee> listEmpl = employees.ToList();
			foreach (Employee empl in employees)
			{
				Console.WriteLine($"{empl.FIO}");
			}

			Console.WriteLine("\nЛюди, работающие в филиале 1 (Северный)");
			IQueryable<Employee> employees2 = from emp in context.Employees
											 where emp.Filials.Contains(filial1)
											 select emp;
			List<Employee> listEmpl2 = employees2.ToList();
			foreach (Employee empl in employees2)
			{
				Console.WriteLine($"{empl.FIO}");
			}

			Console.WriteLine("\nЛюди, с почасовой зарплатой");
			IQueryable<Employee> employees3 = from emp in context.Employees
											  where emp.AccrualType == 2
											  select emp;
			List<Employee> listEmpl3 = employees3.ToList();
			foreach (Employee empl in employees3)
			{
				Console.WriteLine($"{empl.FIO}");
			}


			context.Dispose();
		}
	}
}
