using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExoEntity2
{
	[Table("articles")]
	class Article
	{// titre / auteur / date / contenu
		[Column("id")]
		public int Id { get; set; }
		// Should use authorId as int
		public Author TheAuthor { get; set; }
		[Column("date")]
		public DateTime Date { get; set; }
		[Column("content")]
		public string Content { get; set; }

	}
}
