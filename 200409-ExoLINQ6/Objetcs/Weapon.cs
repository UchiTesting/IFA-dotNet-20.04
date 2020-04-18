using ExoLINQ6.Enums;

namespace ExoLINQ6.Objetcs
{
   public class Weapon
   {
      public WeaponEnum WeaponType { get; set; }
      public ElementsEnum Element { get; set; }
      public string Name { get; set; }
      public int Atk { get; set; }

      public Weapon(WeaponEnum weaponType, ElementsEnum element, string name, int atk)
      {
         WeaponType = weaponType;
         Element = element;
         Name = name;
         Atk = atk;
      }

      public override string ToString()
      {
         return $"{Name} with ATK: {Atk}";
      }
   }
}