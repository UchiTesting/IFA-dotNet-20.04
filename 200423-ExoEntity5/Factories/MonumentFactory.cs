using System;
using System.Collections.Generic;
using System.Text;

using _200423_ExoEntity5.Objects;
using _200423_ExoEntity5.Enums;

namespace _200423_ExoEntity5.Factories
{
	class MonumentFactory : AbstractFactory
	{
		private List<City> _cities;

		public MonumentFactory(List<City> cities, Random rng) : base(rng)
		{
			_cities = cities;
		}

		public override object Create()
		{
			return Create((MonumentNameEnum)_rng.Next(0, Enum.GetValues(typeof(MonumentNameEnum)).Length),
								 _cities[_rng.Next(0, _cities.Count)].Id
				 );
		}

		public object Create(MonumentNameEnum name, int id)
		{
			Monument mon = new Monument(_index++, name, id);

			DateTime date = Convert.ToDateTime("01/01/1970");
			while (date <= DateTime.Today)
			{
				mon.AddVisit(date, _rng.Next(0, 100000));
				date = date.AddDays(1);
			}
			return mon;
		}
	}
}
