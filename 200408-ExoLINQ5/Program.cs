using System;

namespace ExoLINQ5
{
    class Program
    {
        private static Library _library;
        
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ 5\n========");
            /*
            #### Exo 5
            Faire une facade bibliotheque pour :
            - demander les noms des livres emprunté par un utlisateur
            - Emprunter un livre
              -  pas impruntable 2 fois 
              -  Si on a deja un emprun on peut pas en prendre un autre
             */

            _library = new LibraryFactory().CreateLibrary();


            User impossibleUser = new User(-1,"John","Doe");
            TestLogin(impossibleUser);
            TestLogin(_library.Users[0]);

            Console.WriteLine("\nBorrowing 1000 books...");
            _library.PerformBorrowing(1000);

            Console.WriteLine($"\nBooks borrowed by {_library.Users[0]}\n========");
            _library.DisplayBooksBorrowedByUser(_library.Users[0]);

            Console.WriteLine($"\nListing books from {_library.Authors[0]}\n========");
            _library.BooksFromAuthor(_library.Authors[0]);
            
            _library.DisplayAuthorCharts();
            
            _library.DisplayAuthorsWithNoBook(); // TODO Implement this method
            
            TestConcurrentBorrowing(_library.Books[0], _library.Users[0]);
        }

        static void TestLogin(User u)
        {
            bool userExists = _library.Users.Exists(usr => usr.Equals(u));
            if (_library.Login(u))
            {
                Console.WriteLine($"User logged in. "+(userExists ? "Per design":"It should not be")+".");
            }
            else
            {
                Console.WriteLine("User did not login. "+(userExists ? "It should have done.":"Per design")+".");
            }
        }

        static void TestConcurrentBorrowing(Book b, User u)
        {
            bool userExists = _library.Users.Exists(usr => usr.Equals(u));
            bool bookExists = _library.Books.Exists(bk => bk.Equals(b));

            if (!userExists || !bookExists) return; // Guard clause
            
            _library.BorrowBook(ref b, ref u, true);
            _library.BorrowBook(ref b, ref u, true);
        }
    }
}