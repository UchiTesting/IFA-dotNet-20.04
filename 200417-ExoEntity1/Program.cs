using System;
using System.Data.Entity;
using System.Linq;

namespace ExoEntity1
{
	class Program
	{
		static void Main(string[] args)
		{
			ReadUsers();
		}

		static void ReadUsers()
		{
			ApplicationContext db = new ApplicationContext();

			var query = from u in db.Users
							orderby u.Name
							select u;

		}

		static void AddUser(string userName)
		{
			ApplicationContext db = new ApplicationContext();
			User user = new User { Name = userName };
			db.Users.Add(user);
			db.SaveChanges();
			db.Dispose();
		}
	}
}
