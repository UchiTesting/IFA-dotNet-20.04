using System;
using System.Collections.Generic;
using ExoLINQ6.Abstractions;
using ExoLINQ6.Enums;
using ExoLINQ6.Objetcs;

namespace ExoLINQ6
{
   public class BattleFactory
   {
      private static Random rnd = Constants.rnd;

      public static List<Hero> CreateHeroes(int nbHeroes = 8)
      {
         List<Hero> heroes = new List<Hero>();

         for (int i = 0; i < nbHeroes; i++)
         {
            int randomAtk = rnd.Next(10, 50);
            int randomHp = rnd.Next(100, 500);
            Weapon w = CreateRandomWeapon();
            HeroRaceEnum randomRace = ((HeroRaceEnum) rnd.Next(0, Constants.HeroRaceEnumLength));
            heroes.Add(new Hero(i, $"Hero {i}", randomAtk, randomHp, w, randomRace));
         }

         return heroes;
      }

      public static void CreateHeroes(BattleFacade battleFacade, int nbHeroes = 8)
      {
         battleFacade.heroes = CreateHeroes(nbHeroes);
      }

      public static List<Monster> CreateMonsters(int nbMonsters = 8)
      {
         List<Monster> monsters = new List<Monster>();

         for (int i = 0; i < nbMonsters; i++)
         {
            int randomAtk = rnd.Next(10, 50);
            int randomHp = rnd.Next(100, 500);
            Weapon w = CreateRandomWeapon();
            MonsterRaceEnum randomRace = ((MonsterRaceEnum) rnd.Next(0, Constants.MonsterRaceEnumLength));
            monsters.Add(new Monster(i, $"Monster {i}", randomAtk, randomHp, w, randomRace));
         }

         return monsters;
      }

      public static void CreateMonsters(BattleFacade battleFacade, int nbMonsters = 8)
      {
         battleFacade.monsters = CreateMonsters(nbMonsters);
      }

      public static List<Combat> CreateCombats(List<Hero> heroes, List<Monster> monsters, int nbCombats = 20,
         int nbRounds = 10)
      {
         List<Combat> combats = new List<Combat>();

         for (int i = 0; i < nbCombats; i++)
         {
            int randomHeroId = Constants.PickRandomIndex(heroes.Count);
            int randomMonsterId = Constants.PickRandomIndex(monsters.Count);
            List<Attack> hAtks = BattleFactory.CreateRounds(nbRounds);
            List<Attack> mAtks = BattleFactory.CreateRounds(nbRounds);
            combats.Add(new Combat(randomHeroId, randomMonsterId, hAtks, mAtks));
         }

         return combats;
      }

      public static void CreateCombats(BattleFacade battleFacade, int nbCombats = 20, int nbRounds = 10)
      {
         if (battleFacade.heroes != null && battleFacade.monsters != null)
         {
            battleFacade.combats = CreateCombats(battleFacade.heroes, battleFacade.monsters, nbCombats, nbRounds);
         }
         else
         {
            throw new NullReferenceException($"Cannot initialize combats if the list of either heroes and/or monsters is not available.");
         }
      }

      public static List<Attack> CreateRounds(int nbRounds)
      {
         List<Attack> attacks = new List<Attack>();

         for (int i = 0; i < nbRounds; i++)
         {
            int randomDamage = rnd.Next(10, 50);
            ElementsEnum randomElement = ((ElementsEnum) rnd.Next(0, Constants.ElementsEnumLength));
            attacks.Add(new Attack(randomDamage, randomElement));
         }

         return attacks;
      }

      public static Weapon CreateRandomWeapon()
      {
         WeaponEnum randomWeaponType = ((WeaponEnum) Constants.PickRandomIndex(Constants.WeaponEnumLength));
         ElementsEnum randomElement = ((ElementsEnum)Constants.PickRandomIndex(Constants.ElementsEnumLength));
         List<string> WeaponNames = new List<string>{"Killer","Destroyer","Terror","Avenger","You Name It"};
         int randomNameIdx = Constants.PickRandomIndex(WeaponNames.Count);
         string weaponName = $"{WeaponNames[randomNameIdx]} of {randomElement.ToString()}";
         int randomAtk = rnd.Next(10, 50);
         
         return new Weapon(randomWeaponType, randomElement,weaponName,randomAtk);
         
         
      }
   }
}