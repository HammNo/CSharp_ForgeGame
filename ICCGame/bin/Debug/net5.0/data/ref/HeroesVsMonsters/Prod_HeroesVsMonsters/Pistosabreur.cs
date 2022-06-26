using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public class Pistosabreur : Hero
    {
        public override int BonusEnd { get { return 2; } } // bonus endurence a overide ici
    }
}
