using System;
using System.Collections.Generic;
using System.Linq;

namespace ExoLINQ5
{
    public class Library
    {
        public List<User> Users { get; set; }
        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }

        public Library(List<User> users, List<Author> authors, List<Book> books)
        {
            Users = users;
            Authors = authors;
            Books = books;
        }

        public bool Login(User u)
        {
            if (Users.Exists(usr => usr.Equals(u)))
                return true;
            else
                return false;
        }

        public int NumberOfBooksBorrowedByUser(User u)
        {
            return Login(u) ? u.GetBooksBorrowed().Count() : 0;
        }

        public void DisplayBooksBorrowedByUser(User u)
        {
            u.GetBooksBorrowed().ForEach(Console.WriteLine);
        }

        public List<Book> BooksFromAuthor(Author a)
        {
            List<Book> temp = null;
            
            try
            {
                temp = Books.FindAll(b => b.Author.Equals(a));
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            finally
            {
                temp ??= new List<Book>();
            }

            return temp;
        }

        public void BorrowBook(ref Book b, ref User u, bool displayDisclaimer = false)
        {
            if (!Login(u) || u == null) return; // Guard clause
            
            u.BorrowBook(ref b);
        }

        public void DisplayAuthorCharts()
        {
            var query = from author in Authors
                orderby author.SumOfBorrows(this) descending 
                select author;

            Console.WriteLine("\nAuthors Chart\n========");
            foreach (var author in query)
            {
                Console.WriteLine($"{author} {author.SumOfBorrows(this)}");
            }

            Console.WriteLine();
        }

        public void DisplayAuthorsWithNoBook()
        {
            // TODO 
        }

        public void PerformBorrowing(int nbBorrows = 100)
        {
            Random rnd = new Random();
            
            for (int i = 0; i < nbBorrows; i++)
            {
                int rndUserId = PickRandomUserId(rnd);
                int rndBookId = PickRandomBookId(rnd);
                var book = Books[rndBookId];
                Users[rndUserId].BorrowBook(ref book);
                Users[rndUserId].ReturnBook(ref book);
            }
        }

        private int PickRandomBookId(Random r)
        {
            return r.Next(0, Books.Count);
        }

        private int PickRandomUserId(Random r)
        {
            return r.Next(0, Users.Count);
        }
    }
}