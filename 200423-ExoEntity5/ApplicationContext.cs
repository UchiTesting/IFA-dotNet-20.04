using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using _200423_ExoEntity5.Objects;

namespace _200423_ExoEntity5
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Monument> Monuments {get;set;}
		public DbSet<Cart> Carts {get;set;}
		public DbSet<Product> Products {get;set;}
		public DbSet<City> Cities {get;set;}

		public DbSet<CartProductAssociation> CartsProductsAssociation {get;set;}
	}
}
