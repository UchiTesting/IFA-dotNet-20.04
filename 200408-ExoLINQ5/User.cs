using System;
using System.Collections.Generic;
namespace ExoLINQ5
{
    public class User : Person
    {
        public List<Book> Books { get; set; }

        public User(int id, string firstName, string lastName) : base(id, firstName, lastName)
        {
            Books = new List<Book>();
        }

        public List<Book> GetBooksBorrowed()
        {
            return Books;
        }

        public void BorrowBook(ref Book b)
        {
            if (b.HasBeenBorrowed) return;
            
            b.Borrow();
            Books.Add(b);
        }

        public void ReturnBook(ref Book b)
        {
            if (!b.HasBeenBorrowed) return;
            
            b.Return();
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj.GetType() != typeof(User)) return false;

            User tmpUser = ((User) obj);

            if (tmpUser != null && (tmpUser.Id == Id && tmpUser.FirstName.Equals(FirstName) && tmpUser.LastName.Equals(LastName)))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} with ID:{Id}";
        }
    }
}