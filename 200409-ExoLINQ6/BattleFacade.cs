using System;
using System.Collections.Generic;
using System.Linq;
using ExoLINQ6.Abstractions;
using ExoLINQ6.Enums;
using ExoLINQ6.Objetcs;

namespace ExoLINQ6
{
   public class BattleFacade
   {
      public List<Hero> heroes { get; set; }
      public List<Monster> monsters { get; set; }
      public List<Combat> combats { get; set; }
      private Random rnd;


      public BattleFacade(List<Hero> heroes, List<Monster> monsters, List<Combat> combats)
      {
         this.heroes = heroes;
         this.monsters = monsters;
         this.combats = combats;
         rnd = new Random();
      }
      
      //ecrivez les requetes pour :
      // - touvez les dégas moyens
      public void DisplayAverageDamage()
      {
         var queryHeroDamage = ((int)(from cmb in combats select cmb.AverageHeroDamage()).Average());
         var queryMonsterDamage = ((int)(from cmb in combats select cmb.AverageMonsterDamage()).Average());
         var totalAverage = ((int)(queryHeroDamage + queryMonsterDamage) / 2);

         Console.WriteLine($"Average Damage: Hero {queryHeroDamage},Monster: {queryMonsterDamage},Total: {totalAverage}");
      }
      // - La race de monstre qui combat le plus
      public void DisplayMostlyFightingMonster()
      {
         var mostlyFightingMonster = (from c in combats
            from m in monsters
            where m.Id == c.IdMonster
            orderby m.NbCombats descending 
            select m).FirstOrDefault();
         
         Console.WriteLine(CharacterFightsToString(mostlyFightingMonster));
      }

      private string CharacterFightsToString(Character c)
      {
         return $"{c} with {c.NbCombats}";
      }
      
      // GAD => Greatest Average Damage
      
      // - l'arme qui fait les plus gros degats moyens
      public void DisplayWeaponWithGAD()
      {
         var allWeapons = RetrieveAllWeapons();

         var weapon = (from w in allWeapons
            orderby w.Atk
            select w).FirstOrDefault();
         Console.WriteLine($"Weapon with greatest damage is {weapon}");
      }

      private IEnumerable<Weapon> RetrieveAllWeapons()
      {
         var heroWeapons = from hero in heroes
            select hero.Weapon;

         var monsterWeapons = from monster in monsters
            select monster.Weapon;
         var allWeapons = heroWeapons.Union(monsterWeapons);
         return allWeapons;
      }

      // - L'element qui fait le plus de degats
      public void DisplayElementWithGAD()
      {
         var query = (from cmb in combats
            orderby cmb.ElementWithGreatestAverageDamage() descending
            select cmb.ElementWithGreatestAverageDamage()).FirstOrDefault();

         Console.WriteLine($"Element with greatest Average: {query}");
      }
      // - Le nom du hero qui fait le plus de degats
      public void DisplayHeroWithGAD()
      {
         // Retrieve 1st Hero
         var heroInfo = ((from cmb in combats orderby cmb.AverageHeroDamage() descending select new {cmb.IdHero, AverageHeroDamage = cmb.AverageHeroDamage()}).FirstOrDefault());
         Hero h = heroes[heroInfo.IdHero];

         Console.WriteLine($"Hero with greatest average damage: {h}. AVG DMG: {heroInfo.AverageHeroDamage}");
      }

      public void PerformExerciceRequirements()
      {
         Console.WriteLine("AVG DMG");
         DisplayAverageDamage();
         Console.WriteLine("Mostly Fighting Monster");
         DisplayMostlyFightingMonster();
         Console.WriteLine("Weapon GAD");
         DisplayWeaponWithGAD();
         Console.WriteLine("Elem GAD");
         DisplayElementWithGAD();
         Console.WriteLine("Hero GAD");
         DisplayHeroWithGAD();
      }

      public void DisplayAllWeapons()
      {
         var allWeapons = RetrieveAllWeapons();

         foreach (var weapon in allWeapons)
         {
            Console.WriteLine(weapon);
         }
      }
   }
}