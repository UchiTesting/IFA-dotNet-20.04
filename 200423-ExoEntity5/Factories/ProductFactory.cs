using System;
using System.Collections.Generic;
using System.Text;
using _200423_ExoEntity5.Objects;
using _200423_ExoEntity5.Enums;

namespace _200423_ExoEntity5.Factories
{
	public class ProductFactory : AbstractFactory
	{
		private List<Monument> _monuments;

		public ProductFactory(List<Monument> monuments, Random rng) : base(rng)
		{
			_monuments = monuments;
		}

		public override object Create()
		{
			Monument mon = _monuments[_rng.Next(0, _monuments.Count)];
			ProductTypeEnum name = (ProductTypeEnum)_rng.Next(0, Enum.GetValues(typeof(ProductTypeEnum)).Length);
			return Create(name, mon);
		}

		public object Create(ProductTypeEnum name, Monument monument)
		{
			return new Product(_index++,
										monument.Id,
									  name + " de " + monument.Name,
									  (float)_rng.Next(0, 50)
				 );
		}
	}
}
