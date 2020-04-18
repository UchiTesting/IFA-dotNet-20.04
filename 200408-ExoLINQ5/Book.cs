using System;

namespace ExoLINQ5
{
    public class Book
    {
         public int Id { get; set; }
         public string Title { get; set; }
         public Author Author { get; set; } // Specific focus on the author ID
         public int NbPages { get; set; }
         public DateTime ReleaseDate { get; set; }
         public bool HasBeenBorrowed { get; set; }
         public int NbBorrows { get; set; }

        public Book(int id, string title, Author author, int nbPages, DateTime releaseDate, bool hasBeenBorrowed = false, int nbBorrows = 0)
        {
            Id = id;
            Title = title;
            Author = author;
            NbPages = nbPages;
            ReleaseDate = releaseDate;
            HasBeenBorrowed = hasBeenBorrowed;
            NbBorrows = nbBorrows;
        }

        public void Borrow()
        {
            if (HasBeenBorrowed) return;

            HasBeenBorrowed = true;
            NbBorrows++;
        }

        public void Return()
        {
            if (!HasBeenBorrowed) return;

            HasBeenBorrowed = false;
        }

        public override string ToString()
        {
            return $"{Title} by {Author.FirstName} {Author.LastName}";
        }
    }
}