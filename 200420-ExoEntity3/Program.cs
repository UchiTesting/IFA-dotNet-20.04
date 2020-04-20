using System;
using System.Data.Entity;
using System.Linq;
using static Simple_IO.AskData;

namespace _200420_ExoEntity3
{
	class Program
	{
		static bool LoggedIn;
		static MyFile file;
		static void Main(string[] args)
		{
			LoggedIn = false;
			file = new MyFile();

			file.WriteFile("Test");

			file.ReadFile();

			Console.WriteLine("Entity3 : Login Access to File");

			char choice = '\0';

			do
			{
				Console.WriteLine((LoggedIn)? "Logged in successfully":"Not Logged in.");
				Console.WriteLine("Select an option: ");

				Console.WriteLine("0) Quit");
				Console.WriteLine("1) Enter login");
				Console.WriteLine("2) Add User");
				Console.WriteLine("3) Read File");

				choice = askChar("Choice: ");
				Console.WriteLine();

				switch (choice)
				{
					case '0': break;
					case '1':
						LoggedIn = ReadUser(askString("User name: "));
						break;
					case '2':
						AddUser(askString("New user name: "));
						break;
					case '3':
						ReadFile();
						break;
					default:
						Console.WriteLine("Not a valid option. Try again.");
						break;
				}

			} while (choice != '0');


		}

		static void ReadUsers()
		{
			ApplicationContext db = new ApplicationContext();

			var query = from u in db.Users
							select u;

		}

		static bool ReadUser(string userName)
		{
			ApplicationContext db = new ApplicationContext();

			var query = (from u in db.Users
							 where u.UserName == userName
							 select u).FirstOrDefault();

			if (query == null)
			{
				Console.WriteLine("User Not Found.");
				return false;
			}
			else
			{
				Console.WriteLine(query.UserName);
				return true;
			}
		}

		static void AddUser(string userName)
		{
			ApplicationContext db = new ApplicationContext();
			User user = new User { UserName = userName };
			db.Users.Add(user);
			db.SaveChanges();
		}

		static void ReadFile()
		{
			if (!LoggedIn)
			{
				Console.WriteLine("You must be logged in to read the file.");
				return;
			}
			else
			{
				Console.WriteLine(file.Content);
			}

		}
	}
}
