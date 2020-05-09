using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _200423_ExoEntity5.Objects;
using _200423_ExoEntity5.Enums;
using _200423_ExoEntity5.Factories;

namespace _200423_ExoEntity5
{
	class Statistics
	{
		private Random _rng;
		public List<Monument> Monuments { get; private set; }
		public List<City> Cities { get; private set; }
		public List<Product> Products { get; private set; }
		public List<Cart> Carts { get; private set; }
		private ApplicationContext db;

		public Statistics()
		{
			_rng = new Random();
			db = new ApplicationContext();

			Monuments = db.Monuments.ToList();
			Cities = db.Cities.ToList();
			Products = db.Products.ToList();
			Carts = db.Carts.ToList();

		}

		public void GenerateData()
		{
			CityFactory villeFactory = new CityFactory(_rng);
			MonumentFactory monumentFactory = new MonumentFactory(Cities, _rng);
			ProductFactory produitFactory = new ProductFactory(Monuments, _rng);
			CartFactory panierFactory = new CartFactory(Products, Monuments, _rng);

			if (Cities.Count < 1)
			{
				foreach (CityNameEnum name in Enum.GetValues(typeof(CityNameEnum)))
				{
					db.Cities.Add((City)villeFactory.Create(name));
				}
				db.SaveChanges();
			}

			if (Monuments.Count < 1)
			{
				foreach (City ville in db.Cities)
				{
					foreach (MonumentNameEnum name in Enum.GetValues(typeof(MonumentNameEnum)))
					{
						db.Monuments.Add((Monument)monumentFactory.Create(name, ville.Id));
					}
				}
				db.SaveChanges();
			}

			if (Products.Count < 1)
			{
				foreach (Monument monument in Monuments)
				{
					foreach (ProductTypeEnum name in Enum.GetValues(typeof(ProductTypeEnum)))
					{
						db.Products.Add((Product)produitFactory.Create(name, monument));
					}
				}
				db.SaveChanges();
			}

			if (Carts.Count < 1)
			{
				for (int i = 0; i < _rng.Next(0, 10000); i++)
				{
					db.Carts.Add((Cart)panierFactory.Create());
				}
				db.SaveChanges();
			}

		}

		private DateTime RandomDate()
		{
			DateTime tmp = Da

			return DateTime.Now;
		}

		public double GetMoyeneVisite(string NomMonument, string NomVille)
		{
			Monument mon = getMonument(NomMonument, NomVille);
			return mon.Visits.Average(item => item.Value);

		}

		public double GetNbVisiteursBetween(string NomMonument, string NomVille, DateTime debut, DateTime fin)
		{
			Monument mon = getMonument(NomMonument, NomVille);
			return (from date in mon.Visits
					  where date.Key >= debut && date.Key <= fin
					  select date.Value).Sum();
		}

		public List<Monument> GetMonumentsFromPays(string name)
		{
			return (from mon in Monuments
					  join ville in db.Cities on mon.IdCity equals ville.Id
					  where ville.Country == name
					  select mon).ToList();
		}

		public List<IGrouping<City, Monument>> GetMonumentsGroupByVille()
		{
			return (from mon in Monuments
					  join ville in db.Cities on mon.IdCity equals ville.Id
					  group mon by ville).ToList();
		}

		public double PanierMoyen()
		{
			return (from pan in Carts
					  select pan.Amount).Average();
		}

		public double PrixMoyenProduit()
		{
			double panMoyen = PanierMoyen();
			double NbProduitsMoyens = (from pan in Carts
												from prod in pan.Products
												select prod.Value).Average();
			return panMoyen / NbProduitsMoyens;
		}

		public List<Cart> GetPaniersForDate(DateTime date, string ville)
		{
			CityNameEnum city = (CityNameEnum)Enum.Parse(typeof(CityNameEnum), ville);
			return (from pan in Carts
					  from prod in pan.Products.Keys
					  join produit in Products on prod equals produit.Id
					  join mon in Monuments on produit.IdMonument equals mon.Id
					  join vil in db.Cities on mon.IdCity equals vil.Id
					  where pan.DateBought == date && vil.Name == city
					  select pan).ToList();
		}

		private Monument getMonument(string NomMonument, string NomVille)
		{

			KeyValuePair<MonumentNameEnum, CityNameEnum> Pair = GetPairFor(NomMonument, NomVille);
			return (from mon in Monuments
					  join ville in db.Cities on mon.IdCity equals ville.Id
					  where mon.Name == Pair.Key && ville.Name == Pair.Value
					  select mon).First();
		}

		private KeyValuePair<MonumentNameEnum, CityNameEnum> GetPairFor(string NomMonument, string NomVille)
		{
			return new KeyValuePair<MonumentNameEnum, CityNameEnum>(
							(MonumentNameEnum)Enum.Parse(typeof(MonumentNameEnum), NomMonument),
							(CityNameEnum)Enum.Parse(typeof(CityNameEnum), NomVille));
		}
	}
}
