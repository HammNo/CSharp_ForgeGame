using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public interface IInventaire // //interface qui va dire qu'on a un inventaire et il sera set dans la classe qui l'implémente
    {
        int Cuir { get; set; }
        int Or { get; set; }  
    }
}
