using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public abstract class Personnage // classe abstraite, elle contient tout ce qui est commun à tout les persos
    {

        private int _force;
        private int _end;
        private int _pv;
        private int _pvMax; // car on restaure tout ses pv après chaque combat, il faut les stocker quelque part



        // il faudra un bool pour en vie ou mort

        #region Ctor
        public Personnage()
        {
            For = De.RandomDe() + BonusFor; //initialise directement à le création de l'instance d'un personnage la force et endurance
            End = De.RandomDe() + BonusEnd;
            PvMax = End + De.Modificateur(End) + BonusPV; // les pv = endurance + le modificateur qui prends en paramètre l'endurance
            PV = PvMax;
        } 
        #endregion

        public int PvMax
        {
            get { return _pvMax; }
            set { _pvMax = value; }
        }

        public int PV
        {
            get { return _pv; }
            set { _pv = value; }
        }

        public int For
        {
            get { return _force; }
            set { _force = value; }
        }

        public int End
        {
            get { return _end; }
            set { _end = value; }
        }
        public int Frapper(Personnage personnage) // en paramètre celui qui va frapper
        {
            int frappe = De.LancerDe(1, 5) + De.Modificateur(For); // lancé de dè de 4 + modificateur avec en paramètre force
            Console.WriteLine($"{personnage.GetType().Name} va infliger {frappe} dégats");
            PV -= frappe;
            return PV;
        }

        public virtual int BonusEnd { get; } // bonus endurance et force à ajouter, ils sont redéfinis dans la classe enfant
        public virtual int BonusFor { get; }
        public virtual int BonusPV { get; } // bonus pv pour les héros

    }
}
