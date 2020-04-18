using System;
using System.Collections.Generic;
using System.Linq;

namespace ExoLINQ9
{
	public static class Factories
	{
		static Random rnd = new Random();

		public static List<Country> CreateCountries()
		{
			List<Country> tmp = new List<Country>();
			string[] countries = new[] { "Australia", "Canada", "France", "Japan", "Poland", "Spain", "Ukraine", "USA" };
			for (int i = 0; i < countries.Length; i++)
			{
				tmp.Add(new Country(i, countries[i]));
			}

			return tmp;
		}

		public static List<City> CreateCities(List<Country> countries)
		{
			List<City> tmp = new List<City>();

			string[] cities = new[] { "Adelaide", "Canbera", "Epinal", "Greenwood", "Hrebinka", "Krakow", "Madrid", "Odessa", "Paris", "San Francisco", "Tokyo", "Vancouver", "Yokohama", "Zamora" };

			// 0 1 2 3 4 5 6 7
			tmp.Add(new City(0, cities[0], countries[0]));
			tmp.Add(new City(1, cities[1], countries[0]));
			tmp.Add(new City(2, cities[2], countries[2]));
			tmp.Add(new City(3, cities[3], countries[1]));
			tmp.Add(new City(4, cities[4], countries[6]));
			tmp.Add(new City(5, cities[5], countries[4]));
			tmp.Add(new City(6, cities[6], countries[5]));
			tmp.Add(new City(7, cities[7], countries[6]));
			tmp.Add(new City(8, cities[8], countries[2]));
			tmp.Add(new City(9, cities[9], countries[7]));
			tmp.Add(new City(10, cities[10], countries[3]));
			tmp.Add(new City(11, cities[11], countries[1]));
			tmp.Add(new City(12, cities[12], countries[3]));
			tmp.Add(new City(13, cities[13], countries[5]));

			return tmp;
		}

		public static List<Monument> CreateMonuments(List<City> cities)
		{
			List<Monument> tmp = new List<Monument>();

			int nbMonuments = rnd.Next(20, 50);

			for (int i = 0; i < nbMonuments; i++)
			{
				int randomCityId = rnd.Next(0, cities.Count);
				tmp.Add(new Monument(i, randomCityId, $"Monument {i}", CreateVisits()));
			}

			return tmp;
		}

		public static List<Product> CreateProducts(List<Monument> monuments)
		{
			List<Product> tmp = new List<Product>();
			int nbProducts = monuments.Count * 10;

			for (int i = 0; i < nbProducts; i++)
			{
				int randomMonumentId = rnd.Next(0, monuments.Count);
				tmp.Add(new Product(i, randomMonumentId, $"Product {i}", GenerateRandomFloat()));
			}

			return tmp;
		}

		public static List<Cart> CreateCarts(List<Product> availableProducts, List<Monument> availableMonuments)
		{
			List<Cart> tmp = new List<Cart>();
			int nbCarts = 100;

			for (int i = 0; i < nbCarts; i++)
			{
				int randomNbItems = rnd.Next(0, 20);
				int randomMonumentId = rnd.Next(0, availableMonuments.Count);
				tmp.Add(new Cart(i,CreateSubProductList(availableProducts,randomMonumentId, randomNbItems)));
			}

			return tmp;
		}

		private static List<Product> CreateSubProductList(List<Product> availableProducts, int monumentId, int nbProducts = 10)
		{
			List<Product> tmp = new List<Product>();

			var query = from item in availableProducts
							where item.MonumenId == monumentId
							select item;

			List<Product> queryList=query.ToList();
			

			for (int i =0; i < nbProducts; i++)
			{
				int randomItem = rnd.Next(0, queryList.Count);
				tmp.Add(queryList[randomItem]);
			}

			return tmp;
		}

		private static List<int> CreateVisits()
		{
			int nbVisits = 30;
			List<int> tmp = new List<int>();

			for (int i = 0; i < nbVisits; i++)
			{
				tmp.Add(rnd.Next(0, 100));
			}

			return tmp;
		}

		private static float GenerateRandomFloat(int min, int max)
		{
			return ((float)rnd.NextDouble() * max + min);
		}
		private static float GenerateRandomFloat(int max = 50)
		{
			return GenerateRandomFloat(0, max);
		}

	}
}