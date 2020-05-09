using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _200423_ExoEntity5.Enums;

namespace _200423_ExoEntity5.Objects
{
	public class City
	{
		public City(int id, CityNameEnum name, string country)
		{
			Id = id;
			Name = name;
			Country = country;
		}

		public City() { }

		public int Id { get; private set; }
		public CityNameEnum Name { get; private set; }
		public string Country { get; private set; }

	}
}
