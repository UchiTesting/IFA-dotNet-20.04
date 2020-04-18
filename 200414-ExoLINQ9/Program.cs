using System;
using System.Collections.Generic;

namespace ExoLINQ9
{
	class Program
	{
		private static List<Country> _countries;
		private static List<City> _cities;
		private static List<Monument> _monuments;
		private static List<Product> _products;
		private static List<Cart> _carts;
		static void Main(string[] args)
		{
			/*
			 * #### Exo 9

Ecrivez les requetes pour:
- Calculer la moyenne de visite pour un monument.
- Calcule le nombre de visiteur entre 2 dates
- Trouvez tous les monuments pour un pays
- Ordoner les momuments en les classant par ville
- Calculez le panier moyen
- Calculez le prix moyen d'un produit acheté
- Trouvez tous les achats pour une une ville et une date donnée
			 */

			_countries = Factories.CreateCountries();
			_cities = Factories.CreateCities(_countries);
			_monuments = Factories.CreateMonuments(_cities);
			_products = Factories.CreateProducts(_monuments);
			_carts = Factories.CreateCarts(_products, _monuments);

			PrintLists(false);

			GlobalFacade globalFacade = new GlobalFacade(_countries, _cities, _monuments, _products, _carts);

			globalFacade.PrintMonumentsOrderedByCity();
			globalFacade.PrintMeanCartPrice();
			globalFacade.PrintMeanProductPrice();

		}

		static void PrintLists(bool active = true)
		{
			if (active)
			{
				Console.WriteLine($"{Environment.NewLine}-=< Carts >=-");
				_carts.ForEach(c => Console.WriteLine(c));
				Console.WriteLine($"{Environment.NewLine}-=< Cities >=-");
				_cities.ForEach(c => Console.WriteLine(c));
				Console.WriteLine($"{Environment.NewLine}-=< Countries >=-");
				_countries.ForEach(c => Console.WriteLine(c));
				Console.WriteLine($"{Environment.NewLine}-=< Monuments >=-");
				_monuments.ForEach(m => Console.WriteLine(m));
				Console.WriteLine($"{Environment.NewLine}-=< Products >=-");
				_products.ForEach(p => Console.WriteLine(p)); 
			}
		}
	}
}