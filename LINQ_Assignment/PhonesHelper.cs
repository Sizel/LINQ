using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LINQ_Assignment
{
	public static class PhonesHelper
	{
		public static void OrderByPrice(this List<Phone> phones)
		{
			PriceComparer priceComparer = new PriceComparer();
			phones.Sort(priceComparer);
		}

		public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Predicate<TSource> pred)
		{
			List<TSource> list = new List<TSource>();
			foreach (var item in source)
			{
				if (pred(item))
				{
					list.Add(item);
				}
			}

			return list;
		}
	}

	class PriceComparer : IComparer<Phone>
	{
		public int Compare([AllowNull] Phone x, [AllowNull] Phone y)
		{
			return x.Price - y.Price;
		}
	}
}
