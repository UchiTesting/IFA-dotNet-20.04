﻿namespace ExoLINQ8
{
   public class Product
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public float Price { get; set; }

      public Product(int id, string name, float price)
      {
         Id = id;
         Name = name;
         Price = price;
      }
   }
}