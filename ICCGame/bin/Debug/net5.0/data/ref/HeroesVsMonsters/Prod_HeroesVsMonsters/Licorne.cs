using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    internal class Licorne : Monstre, IInventaire
    {
        public int Cuir { get ; set ; }
        public int Or { get ; set ; }

        public Licorne()
        {
            Cuir = De.LancerDe(1,7);
        }
    }
}
