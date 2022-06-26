using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public class Guerrier : Hero
    {
        public override int BonusFor { get { return 2; } }
        public override int BonusEnd { get { return 1; } }         // bonus force et endurance a overide ici
    }
}
