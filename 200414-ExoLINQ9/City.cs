using System.Runtime;

namespace ExoLINQ9
{
	public class City
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Country Country { get; set; }

		public City(int id, string name, Country country)
		{
			Id = id;
			Name = name;
			Country = country;
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, CTR: {Country}";
		}
	}


}