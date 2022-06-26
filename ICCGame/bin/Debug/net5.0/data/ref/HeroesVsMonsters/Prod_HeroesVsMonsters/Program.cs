using Pastel;
using System;
using System.Drawing;

namespace Prod_HeroesVsMonsters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jeu jeu = new Jeu();
            Hero hero = jeu.Start();
            Combat.AfficherEtatHero(hero);
            while (hero.PV > 0)
            {
                Console.WriteLine($"{"Le héro va affronter un nouveau monstre !".Pastel(Color.White).PastelBg("#FF013A")}");
                Console.WriteLine();
                Monstre monstre = Combat.RandomMonstre();
                Combat.AfficherEtatEnnemi(monstre);
                Console.ReadLine();
                Combat.AfficherCombat(hero, monstre);
                //jeu.VoirMarchand();

                if (hero.PV <= 0 && monstre.PV > 0)
                {
                    Console.ReadKey();
                    Console.Clear();
                    Combat.Fin();
                }
            }
            Console.ReadLine();
        }
    }
}
