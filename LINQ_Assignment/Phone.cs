using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Assignment
{
	public class Phone
	{
		public Brands Brand { get; set; }
		public int Price { get; set; }
		public Screen Screen { get; set; }

		public Phone(Brands _brand, int _price, Screen _screen)
		{
			Brand = _brand;
			Price = _price;
			Screen = _screen;
		}

		public override string ToString()
		{
			return $"Brand: { Brand }, Price: { Price }, Screen: { Screen.ToString() }";
		}
	}
}
