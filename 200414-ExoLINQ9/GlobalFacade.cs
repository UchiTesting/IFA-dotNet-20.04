using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExoLINQ9
{
	class GlobalFacade
	{
		private List<Country> _countries;
		private List<City> _cities;
		private List<Monument> _monuments;
		private List<Product> _products;
		private List<Cart> _carts;

		public GlobalFacade(List<Country> countries, List<City> cities, List<Monument> monuments, List<Product> availableProducts, List<Cart> cart)
		{
			_countries = countries; _cities = cities; _monuments = monuments; _products = availableProducts; _carts = cart;
		}

		//- Calculer la moyenne de visite pour un monument.
		public void PrintMeanVisitsForMonument(int monumentId) {
			var query = (from item in _monuments
							 select item.nbVisitors);

			query.ToList().ForEach(i => Console.WriteLine($"element {i}"));

			//Console.WriteLine($"Printing {query}");
		}
		//- Calcule le nombre de visiteur entre 2 dates
		public void PrintNumberOfVisitsInDateRange(int minDate, int maxDate) { }
		//- Trouvez tous les monuments pour un pays
		public void PrintMonumentsFromCountry(int countryId) { }
		public void PrintMonumentsOrderedByCity() {
			var query = from item in _monuments
							orderby item.CityId
							select item;

			query.ToList<Monument>().ForEach(m => Console.WriteLine(m));
		}
		//- Calculez le panier moyen
		public void PrintMeanCartPrice() {
			var query = (from item in _carts
							 select item.Total).Average();

			Console.WriteLine($"Average cart amount: {query.ToString()}");
		}
		//- Calculez le prix moyen d'un produit acheté
		public void PrintMeanProductPrice() {
			var query = (from item in _carts
							 select item.Products.Average(i=>i.Price));//.Average(); // exception No element

			query.ToList().ForEach(i => Console.WriteLine($"FLOAT {i}"));

			//Console.WriteLine($"Average product price: {query.ToList()[0]}");
		}
		//- Trouvez tous les achats pour une une ville et une date donnée
		public void PrintAllOrdersForCityAndDate(int cityId, int date) { }
	}
}
