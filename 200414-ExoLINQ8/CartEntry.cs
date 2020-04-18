namespace ExoLINQ8
{
   public struct CartEntry
   {
      public int ProductId { get; set; }
      public int Quantity { get; set; }

      public CartEntry(int productId, int quantity)
      {
         ProductId = productId;
         Quantity = quantity;
      }
   }
}