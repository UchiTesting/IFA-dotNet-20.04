namespace ExoLINQ9
{
	public class Country
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Country(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public override string ToString()
		{
			return $"ID: {Id}, Name: {Name}";
		}
	}
}