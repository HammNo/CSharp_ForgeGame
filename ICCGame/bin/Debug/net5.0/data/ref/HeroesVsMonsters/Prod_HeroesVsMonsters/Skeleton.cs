using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    internal class Skeleton : Monstre, IInventaire
    {
        public override int BonusFor { get { return 1; } }
        public override int BonusEnd { get { return 1; } }
        public int Cuir { get; set; }
        public int Or { get; set; }

        public Skeleton()
        {
            Or = De.LancerDe(1, 5);
        }
    }
}
