using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public class Dragonnet : Monstre, IInventaire, ICri
    {
        public override int BonusEnd { get { return 1; } }
        public int Or { get; set; }
        public int Cuir { get; set; }

        public Dragonnet()
        {
            Or = De.LancerDe(1, 5);
            Cuir = De.LancerDe(1, 7);  
        }

        public void Crier()
        {
            Console.WriteLine("Grahhhhhhh");
        }
    }
}
