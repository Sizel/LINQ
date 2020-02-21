using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Assignment
{
	class Program
	{
		delegate bool PhonePredicate(Phone p);
		static void Main(string[] args)
		{
			PhonePredicate getByBrand;
			var phones = new List<Phone>
			{
				new Phone(Brands.Apple, 1000, new Screen (5, MatrixTypes.IpsLCD)),
				new Phone(Brands.Apple, 1100, new Screen (4, MatrixTypes.SuperAmoled)),
				new Phone(Brands.Samsung, 750, new Screen (6.5f, MatrixTypes.SuperAmoled)),
				new Phone(Brands.Samsung, 700, new Screen (4.5f, MatrixTypes.IpsLCD)),
				new Phone(Brands.Huawei, 400, new Screen (6, MatrixTypes.OpticAmoled))
			};

			getByBrand = isApple;
			var applePhones = getPhones(phones, getByBrand);

			Console.WriteLine("Only apple:");
			PrintCollection(applePhones);

			getByBrand = isSamsung;
			var samsungPhones = getPhones(phones, getByBrand);

			Console.WriteLine("Only samsung");
			PrintCollection(samsungPhones);

			PhonePredicate getByMatrixType = isSuperAmoled;
			var superAmoledPhones = getPhones(phones, getByMatrixType);

			Console.WriteLine("Only super amoled screens:");
			PrintCollection(superAmoledPhones);

			// Use of anonym0us functions
			var price = 1000;
			var expensivePhones = getPhones(phones, delegate (Phone p)
			{
				return p.Price >= price;
			});

			Console.WriteLine($"Price > { price }");
			PrintCollection(expensivePhones);

			// Use of lambdas
			var diagonal = 6;
			var largeScreenPhones = getPhones(phones, p => p.Screen.Diagonal >= 6);
			Console.WriteLine($"Diagonal > { diagonal }");
			PrintCollection(largeScreenPhones);

			// Use of extension method
			phones.OrderByPrice();
			Console.WriteLine("Phones ordered by price:");
			PrintCollection(phones);

			var x = phones.MyWhere(p => p.Price == 1100).ToList(); // does it make sense to make a list from list?
			PrintCollection(x);

			// Use of LINQ queries
			var s = phones.Where(p => p.Screen.Diagonal >= 6).Select(p => p.Price).ToList();
			var maxPrice = phones.Max(p => p.Price);
			var groupedByBrand = phones.GroupBy(p => p.Brand);
			foreach (var group in groupedByBrand)
			{
				//group = group.OrderByDescending(p => p.Price); How to order all the groups by price in desc order?
				PrintCollection(group);
			}
			phones = phones.OrderByDescending(p => p.Price).ToList();
			PrintCollection(phones);


		}

		static void PrintCollection(IEnumerable c)
		{
			foreach (var item in c)
			{
				Console.WriteLine($"{ item } ");
			}
			Console.WriteLine();
		}

		static List<Phone> getPhones(List<Phone> phones, PhonePredicate pred)
		{
			var newPhonesList = new List<Phone>();
			foreach (var phone in phones)
			{
				if (pred(phone))
				{
					newPhonesList.Add(phone);
				}
			}

			return newPhonesList;
		}

		static bool isApple(Phone phone)
		{
			return phone.Brand == Brands.Apple;
		}

		static bool isSamsung(Phone phone)
		{
			return phone.Brand == Brands.Samsung;
		}

		static bool isHuawei(Phone phone)
		{
			return phone.Brand == Brands.Huawei;
		}

		static bool isSuperAmoled(Phone phone)
		{
			return phone.Screen.MatrixType == MatrixTypes.SuperAmoled;
		}
	}
}
