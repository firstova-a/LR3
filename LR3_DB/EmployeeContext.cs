using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LR3_DB
{
	class EmployeeContext:DbContext
	{
		public DbSet<Filial> Filials { get; set; }
		public DbSet<Employee> Employees { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=LAPTOP-7VM5O03N\SQLEXPRESS;Database=LR3Db;Trusted_Connection=True;");
		}
	}
}
