namespace ExoLINQ8
{
   public class Client
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
      public string City { get; set; }

      public Client(int id, string name, string email, string city)
      {
         Id = id;
         Name = name;
         Email = email;
         City = city;
      }
      
      
   }
}