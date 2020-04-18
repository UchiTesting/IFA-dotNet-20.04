using System.Collections.Generic;

namespace ExoLINQ8
{
   public class Cart
   {
      public int Id { get; set; }
      public int ClientId { get; set; }
      public List<CartEntry> CartEntries { get; set; }

      public Cart(int id, int clientId, List<CartEntry> cartEntries)
      {
         Id = id;
         ClientId = clientId;
         CartEntries = cartEntries;
      }
   }
}