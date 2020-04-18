using System;
using System.Collections.Generic;

namespace ExoLINQ5
{
   public class LibraryFactory
   {
      List<User> users;
      List<Author> authors;
      List<Book> books;
      private Random rnd;
      private Library library;

      public LibraryFactory(List<User> users, List<Author> authors, List<Book> books)
      {
         this.users = users;
         this.authors = authors;
         this.books = books;
         library = new Library(users,authors,books);
         rnd = new Random();
      }

      public LibraryFactory()
      {
         users = new List<User>();
         authors = new List<Author>();
         books = new List<Book>();
         
         rnd = new Random();
      }

      private void UpdateLibrary()
      {
         library = new Library(users,authors,books);
      }
      
      public Library CreateLibrary()
      {
         CreateUsers(rnd.Next(1,30));
         CreateAuthors(rnd.Next(5,10));
         CreateBooks(rnd.Next(5,50));
         UpdateLibrary();

         return library;
      }

      private void CreateUsers(int nbUsers)
      {
         for (int i = 0; i < nbUsers; i++)
         {
            users.Add(new User(i, $"FirstName {i}", $"Last Name {i}"));
         }
      }

      private void CreateAuthors(int nbAuthors)
      {
         for (int i = 0; i < nbAuthors; i++)
         {
            authors.Add(new Author(i,$"First Name {i}",$"LastName {i}",GenerateRandomDate()));
         }
      }

      private DateTime GenerateRandomDate()
      {
         int year = rnd.Next(1500, DateTime.Now.Year);
         int month = rnd.Next(1, 12+1);
         int day = rnd.Next(1, 28+1); // TODO: I don't want to bother with 29 30 31 of feb for now.
         DateTime dt = new DateTime(year,month,day);

         return dt;
      }

      private void CreateBooks(int nbBooks)
      {
         for (int i = 0; i < nbBooks; i++)
         {
            books.Add(new Book(i,$"Title {i}",GenRandomAuthor(),GenRandomNbPage(),GenerateRandomDate()));
         }
      }

      private Author GenRandomAuthor()
      {
         return authors[rnd.Next(0, authors.Count)];
      }
      private int GenRandomNbPage(int maxPages = 500)
      {
         return rnd.Next(1, maxPages);
      }
   }
}