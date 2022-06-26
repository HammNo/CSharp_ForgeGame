using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public static class De
    {
        static Random rand = new();
        
        public static int RandomDe() //méthode
        {

            List<int> listDe = new List<int>(); // Liste pour garder en mémoire les 4 lancers de dès et pouvoir les comparer
            for (int i = 0; i < 4; i++)
            {
                int rndDe = LancerDe(1, 7); // aléatoire de nombres entre 1 et 6, dè 6 faces
                listDe.Add(rndDe); // Ajout de chaque nombre random à la liste
            }
            int nbMin = listDe.Min(); //trouver le plus petit nombre dans la liste
            //Console.WriteLine($"nombre min {nbMin}");
            listDe.Remove(nbMin); // effacer le nombre minimum de la liste
            int total = listDe.Sum();

            return total;
        }

        public static int Modificateur(int n) // le modificateur basé sur une caractéristique ici n, sera définie dans la classe
        {
            int modif = 0;
            if (n < 5)
            {
                modif -= 1;
            }
            else if (n < 10)
            {
                modif += 0;
            }
            else if (n < 15)
            {
                modif += 1;
            }
            else
            {
                modif += 2;
            }
            return modif;
        }
        public static int LancerDe(int min, int max)
        {
            int de = rand.Next(min, max);
            return de;
        }
    }
}
