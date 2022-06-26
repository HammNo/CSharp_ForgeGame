using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public interface IXp
    {
            int Level { get; set; }
            int Experience { get; set; }
            void LevelUp();
    }
}
