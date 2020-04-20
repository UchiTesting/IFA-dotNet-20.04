using System;
using System.Linq;
using static Simple_IO.AskData;

namespace _200420_ExoEntity4
{
	class Program
	{
		static bool LoggedIn;
		static bool AdminUser;
		static void Main(string[] args)
		{
			LoggedIn = false;
			AdminUser = false;

			Console.WriteLine("Exo Entity 4: Login Users");

			char choice = '\0';



			do
			{
				//Console.Clear();
				Console.WriteLine($"Log Status: {LoggedIn}, Admin Status: {AdminUser}");

				Console.WriteLine("Select an option: ");
				Console.WriteLine("0) Quit");
				Console.WriteLine("1) Log in");
				Console.WriteLine("2) AddUser");
				Console.WriteLine("3) Change user rights");
				Console.WriteLine("4) Add article");
				Console.WriteLine("5) Modify article");

				choice = askChar("Choice: ");
				Console.WriteLine();
				switch (choice)
				{
					default: Console.WriteLine("Not a valid option. Try again."); Console.ReadKey(); break;
					case '0': break;
					case '1': LoggedIn = ReadUser(askString("User name: ")); break;
					case '2': AddUser(); break;
					case '3': ChangeUserRights(); break;
					case '4': AddArticle(); break;
					case '5': ModifyArticle(); break;
				}
			} while (choice != '0');

		}

		static bool ReadUser(string userName)
		{
			ApplicationContext db = new ApplicationContext();

			var query = (from u in db.Users
							 where u.UserName == userName
							 select u).FirstOrDefault();

			if (query == null) return false;
			else
			{
				if (query.IsAdmin) AdminUser = true; else AdminUser = false;
				return true;
			}
		}

		static void AddUser()
		{
			string userName = "";
			string password = "";
			bool isAdmin = false;
			char isAdminChar = 'n';
			string validChars = "ynYN";
			do { userName = askString("Username: "); Console.WriteLine(); } while (userName.Equals(""));
			do { userName = askString("Password: "); if (userName.Length < 8) Console.WriteLine("Password must be at least 8 characters."); Console.WriteLine(); } while (userName.Equals("") && userName.Length < 8);
			do { isAdminChar = askChar("Is the user an admin (y/N): "); if (Char.IsLetter(isAdminChar)) isAdminChar = Char.ToLower(isAdminChar); Console.WriteLine($"isadminchar => {isAdminChar}"); } while (!validChars.Contains(isAdminChar));

			isAdmin = (isAdminChar == 'y') ? true : false;

			User user = new User { UserName = userName, Password = password, IsAdmin = isAdmin };

			ApplicationContext db = new ApplicationContext();

			db.Users.Add(user);
			db.SaveChanges();
		}

		static void ChangeUserRights()
		{
			throw new NotImplementedException("You muppet did not implement that one yet."); // TODO
		}

		static void AddArticle()
		{
			throw new NotImplementedException("You muppet did not implement that one yet."); // TODO
		}
		static void ModifyArticle()
		{
			throw new NotImplementedException("You muppet did not implement that one yet."); // TODO
		}
	}
}
