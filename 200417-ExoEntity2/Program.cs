using System;
using System.Collections.Generic;

namespace ExoEntity2
{
	/*
	 * Faire un programme qui permet de sauver des articles
	 * Article : titre / auteur / date / contenu
	 * Vous devez demander soi :
	 * - d'afficher un ou tous les articles
	 * - d'ajouter un article
	 * 
	 */
	class Program
	{
		static void Main(string[] args)
		{
			CreateContent(false);
		}

		static void DisplayAnArticle(int articleId)
		{
			ApplicationContext db = new ApplicationContext();
		}
		static void DisplayAllArticles() { }

		static void CreateContent(bool active = true)
		{

			if (active)
			{
				Random rnd = new Random();

				int nbAuthors = 5;

				for (int i = 0; i < nbAuthors; i++)
				{
					string fName = $"firstName {i}";
					string lName = $"lastName {i}";
					AddAuthor(fName, lName);
				}

				int nbArticles = 10;

				for (int i = 0; i < nbArticles; i++)
				{
					AddArticle(rnd.Next(0, nbAuthors), DateTime.Now, $"Article {i}");
				}
			}
		}
		static void AddAuthor(string firstName, string lastName)
		{
			ApplicationContext db = new ApplicationContext();
			Author author = new Author { FirstName = firstName, LastName = lastName };
			db.Authors.Add(author);
			db.SaveChanges();
			db.Dispose();
		}

		static void AddArticle(Author author, DateTime date, string content)
		{
			ApplicationContext db = new ApplicationContext();
			Article article = new Article { TheAuthor = author, Date = date, Content = content };

			db.Articles.Add(article);
			db.SaveChanges();
			db.Dispose();
		}

	}
}
}
