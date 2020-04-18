using ExoLINQ6.Enums;

namespace ExoLINQ6.Objetcs
{
   public class Monster : Character
   {
      // Soit une liste de monstres (nom,id,race,points d'attaques,points de vie)
      public MonsterRaceEnum Race { get; set; }

      public Monster(int id, string name, int atk, int hp, Weapon weapon, MonsterRaceEnum race) : base(id, name, atk, hp, weapon)
      {
         Race = race;
      }

      public override string ToString()
      {
         return base.ToString();
      }
   }
}