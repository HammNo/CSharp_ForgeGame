using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public static class Combat // tout mes affichages de persos et combats
    {
        public static Monstre RandomMonstre()
        {
            int alea = De.LancerDe(1, 16);
            switch (alea)
            {
                case 1:
                case 4:
                    return new Loup();
                case 3:
                case 6:
                    return new Licorne();
                case 8:
                case 2:
                    return new Orc();
                case 5:
                case 11:
                    return new Skeleton();
                case 15:
                case 10:
                case 7:
                    return new Pampa();
                default:
                    return new Dragonnet();
            }
        }
        public static void AfficherCombat(Hero hero, Monstre monstre)
        {
            int tour = 0; // pour avoir le nombre de tours
            while (hero.PV > 0 && monstre.PV > 0)
            {
                tour++; //incrémente le tour dès le début pour qu'il passe à 1 directement
                //Console.ReadKey(); //quand on appuie sur une touche
                Console.WriteLine($"Tour {tour}\n");
                Console.ForegroundColor = ConsoleColor.Green;
                monstre.Frapper(hero); // le héro frappe le monstre
                AfficherPV(hero, monstre);
                //Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Red;
                hero.Frapper(monstre); // le monstre frappe le héro
                AfficherPV(hero, monstre);
                Console.ResetColor();
                if (hero.PV <= 0 && monstre.PV > 0)
                {
                    Console.WriteLine($"{hero.GetType().Name} est mort !");
                    hero.Crier();
                    Console.WriteLine("----------------------");
                }
                else if (monstre.PV <= 0 && hero.PV > 0)
                {
                    HeroGagne(hero, monstre);
                    Console.ReadKey(); // pour pas passer au menu marchand sans voir les stats
                }
                else if (hero.PV <= 0 && monstre.PV <= 0)
                {
                    Console.WriteLine($"{hero.GetType().Name} et {monstre.GetType().Name} se sont entretués !");
                }
                Thread.Sleep(1000);
            }
        }
        public static void AfficherEtatHero(Hero hero)
        {
            Console.WriteLine(hero.GetType().Name);
            Console.WriteLine($"Force = {hero.For}");
            Console.WriteLine($"Endurance = {hero.End}");
            Console.WriteLine($"PV = {hero.PV}");
            Console.WriteLine($"Niveau = {hero.Level}");
            Console.WriteLine("----------------------");
        }
        public static void AfficherEtatEnnemi(Monstre monstre)
        {
            Console.WriteLine($"Le héro va affronter : {monstre.GetType().Name} ");
            AffichageMonstres.AfficherMonstre(monstre);
            Console.WriteLine($"\nForce = {monstre.For}");
            Console.WriteLine($"Endurance = {monstre.End}");
            Console.WriteLine($"PV = {monstre.PV}");
            if (monstre is IInventaire inventaire) // si il implémente IInventaire, alors il l'affiche
            {
                Console.WriteLine($"Inventaire {monstre.GetType().Name} : {inventaire.Or} or et {inventaire.Cuir} cuir");
            }
            Console.WriteLine("----------------------");
        }

        public static void AfficherPV(Hero h, Monstre m)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"pv {h.GetType().Name} : {h.PV} / {h.PvMax}");
            Console.WriteLine($"pv {m.GetType().Name} : {m.PV} / {m.PvMax}");
            Console.WriteLine("----------------------");
        }

        public static void HeroGagne(Hero hero, Monstre monstre)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{monstre.GetType().Name} est mort !");
            if (monstre is ICri c)
            {
                c.Crier();
            }
            Console.ResetColor();
            Console.WriteLine("----------------------");
            if (monstre is IInventaire inventaire)
            {
                hero.Cuir += inventaire.Cuir;
                hero.Or += inventaire.Or;
            }
            hero.PV = hero.PvMax;
            hero.GainXp(monstre.MontantXpPoints); // gain xp du héro = xp donné par le monstre
            Console.WriteLine($"Inventaire de {hero.GetType().Name} : {hero.Cuir} cuir et {hero.Or} or");
            Console.WriteLine($"Le {hero.GetType().Name} gagne {monstre.MontantXpPoints} points d'xp");
            Console.WriteLine("----------------------");
        }

        public static void Fin()
        {
            Console.WriteLine(@"
                    
                                   _____                         ____                 
                                  / ____|                       / __ \                
                                 | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ 
                                 | | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|
                                 | |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   
                                  \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|   
                    ".Pastel(Color.Crimson));
        }
    }
}