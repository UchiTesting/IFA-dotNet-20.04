using System;
using System.Collections.Generic;
using System.Linq;
using _200423_ExoEntity5.Objects;

namespace _200423_ExoEntity5
{
	class Program
	{
		static Statistics stats;
		static void Main(string[] args)
		{
			Console.WriteLine("Monument App Entity Migrated.");

			Random rnd = new Random();

			stats = new Statistics();
			stats.GenerateData();
			Monument rndMonument = stats.Monuments[rnd.Next(0,stats.Monuments.Count)];
			City rndCity = stats.Cities.Find(c=> c.Id==rndMonument.IdCity);
			stats.GetMoyeneVisite(rndMonument.Name.ToString(),rndCity.Name.ToString());

		}

		static KeyValuePair<string, string> GetMonument()
		{
			Console.WriteLine("Liste des monuments par villes : ");

			List<IGrouping<City, Monument>> list = stats.GetMonumentsGroupByVille();
			foreach (IGrouping<City, Monument> item in list)
			{
				Console.WriteLine(item.Key);
				foreach (Monument monument in item)
				{
					Console.WriteLine(monument);
				}
			}
			string monumentName;
			string cityName;
			Console.WriteLine("Quelle ville ?");
			cityName = Console.ReadLine();

			Console.WriteLine("Quelle monument ?");
			monumentName = Console.ReadLine();

			return new KeyValuePair<string, string>(monumentName, cityName);
		}
	}
}