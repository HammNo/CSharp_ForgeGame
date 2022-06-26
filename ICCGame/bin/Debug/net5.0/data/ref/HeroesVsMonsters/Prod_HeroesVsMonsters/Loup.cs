using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    internal class Loup : Monstre, IInventaire, ICri
    {
        public int Cuir { get; set; }
        public int Or { get; set; }

        public Loup()
        {
            Cuir = De.LancerDe(1,7);
            Or = 0;
        }

        public void Crier()
        {
            Console.WriteLine("Aouuuuuhhhhhh");
        }
    }
}
