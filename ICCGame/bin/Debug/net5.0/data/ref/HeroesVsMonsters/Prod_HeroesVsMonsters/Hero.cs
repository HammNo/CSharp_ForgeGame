using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public class Hero : Personnage, IInventaire, ICri, IXp
    {
        public int Or { get; set; }
        public int Cuir { get; set; }

        public int Level { get; set; }
        public int Experience { get; set; }
        public override int BonusPV => De.LancerDe(2,6); // calcul du bonus pv des héros

        public Hero()
        {
            Or = 0;
            Cuir = 0;
            Level = 1;
            Experience = 0;
        }

        public void Crier()
        {
            Console.WriteLine("AAAAaaaAAAaaargHHhhhhh");
        }

        public void GainXp(int xpGain)
        {
            Experience += xpGain;
            Console.WriteLine($"Points d'experience = { Experience }");
            if (Experience >= (Level * 10))
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Level += 1;
            Experience = 0 + (Experience % Level); // reste d'xp pour le prochain niveau
            //For++;
            //PvMax++;
            //End++;
            Console.WriteLine($"Félicitations, votre héros passe niveau : {Level}");
            //Console.WriteLine($"Force : {For}");
            //Console.WriteLine($"Pv : {PvMax}");
            //Console.WriteLine($"Endurance: {End}");

        }
    }
}
