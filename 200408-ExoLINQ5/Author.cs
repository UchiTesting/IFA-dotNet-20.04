using System;
using System.Linq;

namespace ExoLINQ5
{
    public class Author : Person
    {
        private DateTime DateOfBirth { get; set; }

        public Author(int id, string firstName, string lastName, DateTime dateOfBirth) : base(id, firstName, lastName)
        {
            DateOfBirth = dateOfBirth;
        }

        public int SumOfBorrows(Library l)
        {
            return l.Books.FindAll(b => b.Author.Equals(this)).Sum(b =>b.NbBorrows);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} born {DateOfBirth.ToString("yyyy'/'MM'/'dd")}";
        }
    }
}