using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200423_ExoEntity5.Objects
{
	public class Cart
	{
		public Cart(int id, DateTime date)
		{
			Id = id;
			DateBought = date;
			Products = new Dictionary<int, int>();
		}

		public Cart() { }

		public int Id { get; private set; }
		public Dictionary<int, int> Products { get; private set; }
		public float Amount { get; private set; }
		public DateTime DateBought { get; private set; }

		public void AddProduct(int id, int quantity, float unitPrice)
		{
			Amount += quantity * unitPrice;
			if (Products.ContainsKey(id))
			{
				Products[id] += quantity;
			}
			else
			{
				Products.Add(id, quantity);
			}
		}
	}
}
