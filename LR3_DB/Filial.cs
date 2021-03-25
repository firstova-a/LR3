using System;
using System.Collections.Generic;
using System.Text;

namespace LR3_DB
{
	class Filial
	{
		public int Id { get; set; }
		public string Address { get; set; }

		public string Name { get; set; }
		public List<Employee> Employees { get; set; }
	}
}
