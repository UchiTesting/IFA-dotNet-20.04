namespace ExoLINQ9
{
	public class Product
	{
		public int Id { get; set; }
		public int MonumenId { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }

		public Product(int id, int monumenId, string name, float price)
		{
			Id = id;
			MonumenId = monumenId;
			Name = name;
			Price = price;
		}

		public override string ToString()
		{
			return $"ID: {Id}, MonID: {MonumenId}, Name: {Name}, Price {Price}";
		}
	}
}