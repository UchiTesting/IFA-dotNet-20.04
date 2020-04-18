using System.Collections.Generic;

namespace ExoLINQ9
{
	public class Cart
	{
		// Un panier est composé d'un id,d'une liste de produit,d'un total
		public int Id { get; set; }
		public List<Product> Products { get; set; }

		public float Total
		{
			get
			{
				float sum = 0;
				Products.ForEach(p => sum += p.Price);
				return sum;
			}
		}

		public Cart(int id, List<Product> products)
		{
			Id = id;
			Products = products;
		}

		public override string ToString()
		{
			return $"Cart Id: {Id} containing {Products.Count} items.";
		}
	}
}