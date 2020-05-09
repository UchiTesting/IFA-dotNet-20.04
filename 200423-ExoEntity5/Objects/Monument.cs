using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using _200423_ExoEntity5.Enums;

namespace _200423_ExoEntity5.Objects
{
	public class Monument
	{

		public int Id { get; protected set; }
		public MonumentNameEnum Name { get; protected set; }
		public int IdCity { get; protected set; }
		public Dictionary<DateTime, int> Visits { get; private set; }

		public Monument(int id, MonumentNameEnum name, int idCity)
		{
			Id = id;
			Name = name;
			IdCity = idCity;
			Visits = new Dictionary<DateTime, int>();
		}

		public Monument() { }

		public void AddVisit(DateTime date, int nbVisitors)
		{
			if (Visits.ContainsKey(date))
			{
				Visits[date] += nbVisitors;
			}
			else
			{
				Visits.Add(date, nbVisitors);
			}
		}
	}
}
