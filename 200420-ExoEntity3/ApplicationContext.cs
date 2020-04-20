using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace _200420_ExoEntity3
{
	class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; }
	}
}
