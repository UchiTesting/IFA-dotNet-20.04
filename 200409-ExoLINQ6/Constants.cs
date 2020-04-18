using System;
using ExoLINQ6.Enums;

namespace ExoLINQ6
{
   public static class Constants
   {
      public static readonly int ElementsEnumLength = Enum.GetValues(typeof(ElementsEnum)).Length;
      public static readonly int HeroRaceEnumLength = Enum.GetValues(typeof(HeroRaceEnum)).Length;
      public static readonly int MonsterRaceEnumLength = Enum.GetValues(typeof(MonsterRaceEnum)).Length;
      public static readonly int WeaponEnumLength = Enum.GetValues(typeof(WeaponEnum)).Length;
      public static Random rnd = new Random();
      
      public static int PickRandomIndex(int nbOfElements)
      {
         return rnd.Next(0, nbOfElements);
      }

   }
}