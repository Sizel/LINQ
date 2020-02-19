using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
	class Product
	{
		public string Name { get; set; }
		public int Calories { get; set; }
		public Product(string name, int calories)
		{
			Name = name;
			Calories = calories;
		}

		public override string ToString()
		{
			return $"Name: {Name}, Calories: {Calories}";
		}
	}
}
