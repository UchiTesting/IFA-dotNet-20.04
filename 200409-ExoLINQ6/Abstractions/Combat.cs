using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ExoLINQ6.Enums;
using ExoLINQ6.Objetcs;

namespace ExoLINQ6.Abstractions
{
   public class Combat
   {
      public int IdHero { get; set; }
      public int IdMonster { get; set; }
      public List<Attack> HeroAttacks { get; set; }
      public List<Attack> MonsterAttacks { get; set; }
      public Character Winner { private get; set; }

      public Combat(int idHero, int idMonster, List<Attack> heroAttacks, List<Attack> monsterAttacks)
      {
         IdHero = idHero;
         IdMonster = idMonster;
         HeroAttacks = heroAttacks;
         MonsterAttacks = monsterAttacks;
         Winner = null;
      }

      public IEnumerable<Attack> UnifiedAttacks()
      {
         var heroAttacks = from h in HeroAttacks select h;
         var monsterAttacks = from m in MonsterAttacks select m;
         var unifiedAttacks = heroAttacks.Union(monsterAttacks);

         return unifiedAttacks;
      }

      public int AverageHeroDamage()
      {
         return ((int) (from atk in HeroAttacks select atk.Damage).Average());
      }

      public ElementsEnum ElementWithGreatestAverageDamage()
      {
         var avgElementDmg = (from atk in UnifiedAttacks()
               group atk by atk.Element
               into elementGroup
               select new {Element = elementGroup.Key, AvgAttack = ((int)elementGroup.Average(d => d.Damage))})
            .OrderByDescending(arg => arg.AvgAttack)
            .FirstOrDefault();

         ElementsEnum element = avgElementDmg.Element;
         int AvgDmg = avgElementDmg.AvgAttack;

         Console.WriteLine($"{element} {AvgDmg}");


         return element;
      }

      public int AverageMonsterDamage()
      {
         return ((int) (from atk in MonsterAttacks select atk.Damage).Average());
      }

      public int AvergageWeaponDamage()
      {
         return 0; // TODO
      }

      public int SumHeroDamage()
      {
         return ((int) (from dmg in HeroAttacks select dmg.Damage).Sum());
      }

      public int SumMonsterDamage()
      {
         return ((int) (from dmg in MonsterAttacks select dmg.Damage).Sum());
      }
   }
}