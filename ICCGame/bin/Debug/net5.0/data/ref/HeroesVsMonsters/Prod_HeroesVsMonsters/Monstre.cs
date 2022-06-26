using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public class Monstre : Personnage
    {
        private int __montantxpPoint;

        public Monstre()
        {
            MontantXpPoints = De.LancerDe(1, 11);
        }

        public int MontantXpPoints
        {
            get { return __montantxpPoint; }
            set { __montantxpPoint = value; }
        }
    }
}
