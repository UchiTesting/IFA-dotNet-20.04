using System;
using System.Collections.Generic;
using ExoLINQ6.Abstractions;
using ExoLINQ6.Objetcs;

namespace ExoLINQ6
{
   
   /*
   #### Exo 6
   Soit une liste de monstres (nom,id,race,points d'attaques,points de vie)
   Soit une liste de heros (id,nom,race,arme)
   Soit une liste de combat(idhero,idmonstre,list de {val degas,elements} hero,list de {val degas,elements} monstre,victoire hero ou monstre)

   ecrivez les requetes pour :
   - touvez les dégas moyens
   - La race de monstre qui combat le plus
   - l'arme qui fait les plus gros degas moyens
   - L'element qui fait le plus de degas
   - Le nom du hero qui fait le plus de degas
    */
   class Program
   {
      private static BattleFacade _battleFacade;
      static void Main(string[] args)
      {
         Console.WriteLine("Combats");
         List<Hero> heroes = BattleFactory.CreateHeroes();
         List<Monster> monsters = BattleFactory.CreateMonsters();
         List<Combat> combats = BattleFactory.CreateCombats(heroes,monsters);

         _battleFacade = new BattleFacade(heroes,monsters,combats);
         
         _battleFacade.PerformExerciceRequirements();
         
         // _battleFacade.DisplayAllWeapons();
      }
   }
}