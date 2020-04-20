using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace ExoEntity2
{
	class ApplicationContext : DbContext
	{
		public DbSet<Article> Articles { get; set; }
		public DbSet<Author> Authors { get; set; }

	}
}
