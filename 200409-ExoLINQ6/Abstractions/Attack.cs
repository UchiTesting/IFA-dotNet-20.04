using ExoLINQ6.Enums;

namespace ExoLINQ6.Abstractions
{
   public class Attack
   {
      public int Damage { get; set; }
      public ElementsEnum Element { get; set; }

      public Attack(int damage, ElementsEnum element)
      {
         Damage = damage;
         Element = element;
      }
   }
}