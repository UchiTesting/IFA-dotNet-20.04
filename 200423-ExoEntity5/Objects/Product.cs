using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _200423_ExoEntity5.Objects
{
	public class Product
	{
		public int Id { get; private set; }
		public int IdMonument { get; private set; }
		public string Name { get; private set; }
		public float Price { get; private set; }

		public Product(int id, int idMonument, string name, float price)
		{
			Id = id;
			IdMonument = idMonument;
			Name = name;
			Price = price;
		}

		public Product() { }
	}
}
