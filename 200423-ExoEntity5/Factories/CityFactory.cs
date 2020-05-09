using System;
using System.Collections.Generic;
using System.Text;
using _200423_ExoEntity5.Enums;
using _200423_ExoEntity5.Objects;

namespace _200423_ExoEntity5.Factories
{
class CityFactory : AbstractFactory
	{
		public CityFactory(Random rng) : base(rng)
		{
		}

		public override object Create()
		{
			return Create((CityNameEnum)_rng.Next(0, Enum.GetValues(typeof(CityNameEnum)).Length));
		}

		public object Create(CityNameEnum name)
		{
			return new City(_index++,
								 name,
								 "SomeCountry"
				 );
		}
	}
}
