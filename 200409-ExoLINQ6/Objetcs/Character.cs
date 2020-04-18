namespace ExoLINQ6.Objetcs
{
   public abstract class Character
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public int Atk { get; set; }
      public int HP { get; set; }
      public Weapon Weapon { get; set; }
      public int NbCombats { get; set; }

      protected Character(int id, string name, int atk, int hp, Weapon weapon)
      {
         Id = id;
         Name = name;
         Atk = atk;
         HP = hp;
         Weapon = weapon;
         NbCombats = 0;
      }
      public override string ToString()
      {
         return $"{Name} with ID {Id}";
      }
   }
}