using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
	class Program
	{
		static Random rnd = new Random();
		static void Main(string[] args)
		{
			var products = new List<Product>();
			for (int i = 0; i < 20; i++)
			{
				products.Add(new Product($"Product { i }", rnd.Next(1, 10)));
			}

			PrintCollection(products);

			var result = from item in products
						 where item.Calories < 8 && item.Calories > 4
						 select item;

			PrintCollection(result);
			
			var result2 = products.Where(item => item.Calories < 8 && item.Calories > 4);

			PrintCollection(result2);

			var orderedProducts = products.Where(item => item.Calories > 4)
										  .OrderBy(item => item.Calories);
			
			PrintCollection(orderedProducts);

			var productsGroupedByCalories = products.GroupBy(product => product.Calories);
			foreach (var group in productsGroupedByCalories)
			{
				Console.WriteLine($"Calories: { group.Key }");
				foreach (var product in group)
				{
					Console.WriteLine(product);
				}
			}

			Console.WriteLine();
			
			Console.WriteLine($"Check if calories of all products are > 0: { products.All(product => product.Calories > 0) }");
			
			Console.WriteLine();

			Console.WriteLine($"Check if calories of all products == 5 { products.All(product => product.Calories == 5) }");

			Console.WriteLine();

			Console.WriteLine($"Check if calories of any product == 5: { products.Any(product => product.Calories == 5) }");
			
			Product newProduct = new Product("Product 0", 4);
			products[0] = newProduct;
			Console.WriteLine($"Check if products collection contains Product0 with 4 calories: { products.Contains(newProduct)}");

			int[] arr1 = new int[] { 1, 2, 3, 4 };
			int[] arr2 = new int[] { 2, 3, 4, 5 };

			PrintCollection(arr1);
			PrintCollection(arr2);

			var union = arr1.Union(arr2).ToArray();
			
			Console.WriteLine($"Union of arr1 and arr2:");
			PrintCollection(union);

			var intersect = arr1.Intersect(arr2).ToArray();

			Console.WriteLine($"Intersect of arr1 and arr2:");
			PrintCollection(intersect);

			var except = arr1.Except(arr2).ToArray();
			Console.WriteLine($"arr1 - arr2:");
			PrintCollection(except);

			var sumOfAllCalories = products.Sum(p => p.Calories);
			Console.WriteLine($"Sum of all calories: { sumOfAllCalories }");

			//var minCalories = products.Min(p => p.Calories);
			var minCaloriesProducts = products.Where(p => p.Calories == products.Min(p => p.Calories));
			Console.WriteLine("Min calories products: ");
			PrintCollection(minCaloriesProducts);

			var aggregate = arr1.Aggregate((x, y) => x + y);
			var sum = arr1.Sum();
			Console.WriteLine($"Aggregate = { aggregate }, Sum = { sum }");




			Console.WriteLine();
		}
		
		static void PrintCollection(IEnumerable collection)
		{
			foreach (var item in collection)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine();
		}

		static void PrintCollection(int[] arr)
		{
			foreach (var item in arr)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
		}
	}
}
