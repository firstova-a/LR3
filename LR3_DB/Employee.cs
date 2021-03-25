using System;
using System.Collections.Generic;
using System.Text;

namespace LR3_DB
{
	class Employee
	{
		public int Id { get; set; }
		public string FIO { get; set; }

		public string Position { get; set; }

		//1 - ставка, 2 - почасовая оплата
		public int AccrualType { get; set; }

		public int Hours { get; set; }
		public int SalaryPerHour { get; set; }
		public int Salary { get; set; }
		public List<Filial> Filials { get; set; }
	}
}
