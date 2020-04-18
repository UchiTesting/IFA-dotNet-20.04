using System.Collections.Generic;

namespace ExoLINQ9
{
	public class Monument
	{
		public int Id { get; set; }
		public int CityId { get; set; }
		public string Name { get; set; }
		public List<int> nbVisitors { get; set; }  // Refactor to List<Visit> later if needs be

		public Monument(int id, int cityId, string name)
		{
			Id = id;
			CityId = cityId;
			Name = name;
			nbVisitors = new List<int>();
		}

		public Monument(int id, int cityId, string name, List<int> visits) : this(id, cityId, name)
		{
			nbVisitors = visits;
		}

		public void SetVisits(List<int> visits) => nbVisitors = visits;

		public override string ToString()
		{
			return $"Id: {Id},CityId: {CityId},Name: {Name}";
		}

	}
}