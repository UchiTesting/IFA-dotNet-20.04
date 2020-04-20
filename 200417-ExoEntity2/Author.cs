using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExoEntity2
{
	[Table("authors")]
	public class Author
	{
		[Column("id")]
		public int Id { get; set; }
		[Column("firstName")]
		public string FirstName { get; set; }
		[Column("lastName")]
		public string LastName { get; set; }

		public Author(int id, string firstName, string lastName)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
		}

		public Author() { }
	}
}