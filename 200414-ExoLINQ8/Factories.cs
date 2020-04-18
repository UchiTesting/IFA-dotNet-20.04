using System;
using System.Collections.Generic;

namespace ExoLINQ8
{
   public static class Factories
   {
      static Random rnd = new Random();
      
      public static List<Product> CreateProducts(int nbProducts = 30)
      {
         List<Product> tmp = new List<Product>();
         
         for (int i = 0; i < nbProducts; i++)
         {
            tmp.Add(new Product(i,RandomString(),RandomFloat()));
         }

         return tmp;
      }

      public static List<Client> CreateClients(int nbClients=10)
      {
         List<Client> tmp = new List<Client>();
         
         for (int i = 0; i < nbClients; i++)
         {
            tmp.Add(new Client(i,RandomString(),RandomEmail(),RandomCity()));
         }

         return tmp;
      }

      public static List<Cart> CreateCarts(List<Product> products, List<Client> clients,int nbCarts=30)
      {
         List<Cart> tmp = new List<Cart>();

         for (int i = 0; i < nbCarts; i++)
         {
            tmp.Add(new Cart(i, rnd.Next(clients.Count), CreateCartEntries(products)));
         }

         return tmp;
      }

      public static CartEntry CreateCartEntry(List<Product> listOfAvailableProducts)
      {
         return new CartEntry(rnd.Next(listOfAvailableProducts.Count),rnd.Next(10));
      }

      private static List<CartEntry> CreateCartEntries(List<Product> products, int nbCartEntries=10)
      {
         List<CartEntry> tmp = new List<CartEntry>();

         for (int i = 0; i < nbCartEntries; i++)
         {
            tmp.Add(CreateCartEntry(products));
         }
         return tmp;
      }

      private static float RandomFloat(float max = 100.0f, float min = 0)
      {
         return ((float)rnd.NextDouble()) * max + min;
      }

      private static string RandomString()
      {
         List<string> products = new List<string>{"Computer","Xbox","PlayStation","Music Player","You Name It"};
         List<string> editions = new List<string>{"Black","White","Gamer","Truc","You Name It"};

         return $"{products[rnd.Next(products.Count)]} {editions[rnd.Next(editions.Count)]} {RandomFloat()}.{RandomFloat()}.{RandomFloat()}";
      }
      
      private static string RandomEmail()
      {
         List<string> names = new List<string>{"jack","john","Bethy","Cathy","You Name It"};
         List<string> domains = new List<string>{"Black","White","Gamer","Truc","You Name It"};

         return $"{names[rnd.Next(names.Count)]}{rnd.Next(20)}.{rnd.Next(20)}.{rnd.Next(20)}@{domains[rnd.Next(domains.Count)]}";
      }
      
      private static string RandomCity()
      {
         List<string> cities = new List<string>{"Metz","Osaka","Los Angeles","Krakow","You Name It"};

         return $"{cities[rnd.Next(cities.Count)]}";
      }
   }
}