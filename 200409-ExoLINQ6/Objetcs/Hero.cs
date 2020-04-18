using ExoLINQ6.Enums;

namespace ExoLINQ6.Objetcs
{
   public class Hero : Character
   {
      // Soit une liste de heros (id,nom,race,arme)
      public HeroRaceEnum Race { get; set; }

      public Hero(int id, string name, int atk, int hp, Weapon weapon, HeroRaceEnum race) : base(id, name, atk, hp, weapon)
      {
         Race = race;
      }

      public override string ToString()
      {
         return base.ToString();
      }
   }
}