using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace ExoEntity1
{
	class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public User()
		{

		}
	}

	class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; }
	}
}
