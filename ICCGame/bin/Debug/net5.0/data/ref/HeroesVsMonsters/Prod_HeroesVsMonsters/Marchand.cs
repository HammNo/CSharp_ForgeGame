using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    internal class Marchand : Personnage
    {
        public int Epee { get; set; }
        public int Armure { get; set; }

        public Marchand()
        {
            Epee = 1;
            Armure = 3;
        }

        public void AfficherMarchand()
        {
            Console.WriteLine("Que voulez vous acheter ?");
        }
    }
}
