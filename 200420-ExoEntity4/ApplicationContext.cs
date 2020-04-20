using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace _200420_ExoEntity4
{
	class ApplicationContext : DbContext
	{
		public DbSet<Article> Articles { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
