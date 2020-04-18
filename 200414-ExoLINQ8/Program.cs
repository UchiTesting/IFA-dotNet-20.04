using System;
using System.Collections.Generic;
using System.Linq;

namespace ExoLINQ8
{
   class Program
   {
      static List<Product> products = Factories.CreateProducts();
      static List<Client> clients = Factories.CreateClients();
      static List<Cart> carts = Factories.CreateCarts(products, clients);

      static void Main(string[] args)
      {
         Console.WriteLine("Hello World!");


         SelectClientsWhoBoughtAProductGroupedByProduct();
         ComputeAverageCartAmount();
         CityThatOrdersTheMost();
      }
      /*==============================================================================================================*/
      private static void SelectClientsWhoBoughtAProductGroupedByProduct()
      {
         // var query = from item in carts
         //    from client in clients
         //    where client.Id == item.ClientId
         //    group item.CartEntries.ProductId
         //    select item;
            Console.WriteLine($"Clients who bought a product:");
      }
      private static void ComputeAverageCartAmount()
      {
         throw new NotImplementedException();
      }
      private static void CityThatOrdersTheMost()
      {
         throw new NotImplementedException();
      }
      /*==============================================================================================================*/
   }

/*#### Exo 8
   Simulation d'un site d'achat
   client(id nom email ville)
   panier(id produit quantité)
   produit(id nom prix)

   Selectionez tous les clients qui ont acheté un produit groupé par produit
   Calculez le montant moyen du panier
   Calculez la ville qui commande le plus*/
}