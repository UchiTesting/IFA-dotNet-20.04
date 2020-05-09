using System;
using System.Collections.Generic;
using System.Text;
using _200423_ExoEntity5.Objects;
using System.Linq;

namespace _200423_ExoEntity5.Factories
{
	public class CartFactory : AbstractFactory
	{
		private List<Product> _products;
		private List<Monument> _monuments;

		public CartFactory(List<Product> products, List<Monument> monuments, Random rng) : base(rng)
		{
			_products = products;
			_monuments = monuments;
		}

		public override object Create()
		{
			DateTime debut = Convert.ToDateTime("01/01/1970");
			int nbDaysSince = (DateTime.Now - debut).Days;
			Cart cart = new Cart(_index++, debut.AddDays(_rng.Next(0, nbDaysSince)));
			Monument monument = _monuments[_rng.Next(0, _monuments.Count)];

			List<Product> products = _products.Where(prod => prod.IdMonument == monument.Id).ToList();
			Console.WriteLine($"Products of this monument: ");
			products.ForEach(Console.WriteLine);

			for (int i = 0; i < _rng.Next(0, 10); i++)
			{
				Product prod = products[_rng.Next(0, products.Count)];
				cart.AddProduct(prod.Id,
										  _rng.Next(0, 5),
										  prod.Price
										  );
			}
			return cart;
		}

	}
}
