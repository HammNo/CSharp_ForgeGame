using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HeroesVsMonsters
{
    public class AffichageMonstres
    {

        public static void AfficherMonstre(Monstre monstre) // static pour pouvoir l'appeler en faisant AffichageMonstres.AfficherMonstre(monstre); et pas devoir l'instancier
        {
            if (monstre is Dragonnet)
            {
                AfficherDrag();
            }
            if (monstre is Loup)
            {
                AfficherLoup();
            }
            if (monstre is Orc)
            {
                AfficherOrc();
            }
            if (monstre is Licorne)
            {
                AfficherLicorne();
            }
            if (monstre is Skeleton)
            {
                AfficherSekeleton();
            }
            if (monstre is Pampa)
            {
                AfficherPampa();
            }
        }

        public static void AfficherDrag()
        {
            string drag =
            @"
                                     ___====-_  _-====___
                               _--^^^#####//      \\#####^^^--_
                            _-^##########// (    ) \\##########^-_
                           -############//  |\^^/|  \\############-
                         _/############//   (@::@)   \\############\_
                        /#############((     \\//     ))#############\
                       -###############\\    (oo)    //###############-
                      -#################\\  / VV \  //#################-
                     -###################\\/      \//###################-
                    _#/|##########/\######(   /\   )######/\##########|\#_
                    |/ |#/\#/\#/\/  \#/\##\  |  |  /##/\#/  \/\#/\#/\#| \|
                    `  |/  V  V  `   V  \#\| |  | |/#/  V   '  V  V  \|  '
                       `   `  `      `   / | |  | | \   '      '  '   '
                                        (  | |  | |  )
                                       __\ | |  | | /__
                                      (vvv(VVV)(VVV)vvv)
                    ";
            Console.WriteLine(drag.Pastel(Color.Crimson));

        }

        public static void AfficherLoup()
        {
            string loup = @"
                                         .
                                        / V\
                                      / `  /
                                     <<   |
                                     /    |
                                   /      |
                                 /        |
                               /    \  \ /
                              (      ) | |
                      ________|   _/_  | |
                    <__________\______)\__) ";
            Console.WriteLine(loup.Pastel(Color.FromArgb(87, 123, 137)));
        }

        public static void AfficherOrc()
        {
            string orc = @"
                                _,.---''```````'-.
                            ,-'`                  `-._
                         ,-`                   __,-``,\
                        /             _       /,'  ,|/ \
                      ,'         ,''-<_`'.    |  ,' |   \
                     /          / _    `  `.  | / \ |\  |
                     |         (  |`'-,---, `'  \_|/ |  |
                     |         |`  \  \|  /  __,    _ \ |
                     |         |    `._\,'  '    ,-`_\ \|
                     |         |        ,----      /|   )
                     \         \       / --.      {/   /|
                      \         | |       `.\         / |
                       \        / `-.                 | /
                        `.     |     `-        _,--V`)\/        _,-
                          `,   |           /``V_,.--`  \.  _,-'`
                           /`--'`._        `-'`         )`'
                          /        `-.            _,.-'`
                                      `-.____,.-'`

                    ";
            Console.WriteLine(orc.Pastel(Color.FromArgb(90, 50, 10)));
        }

        public static void AfficherLicorne()
        {
            string licorne = @"
                              \
                               \
                                \\
                                 \\
                                  >\/7
                              _.-(6'  \
                             (=___._/` \
                                  )  \ |
                                 /   / |
                                /    > /
                               j    < _\
                           _.-' :      ``.
                           \ r=._\        `.
                          <`\\_  \         .`-.
                           \ r-7  `-. ._  ' .  `\
                            \`,      `-.`7  7)   )
                             \/         \|  \'  / `-._
                                        ||    .'
                                          \\  (
                                          >\  >
                                      ,.-' >.'
                                     <.'_.''
                                       <'
                             ";
            Console.WriteLine(licorne.Pastel(Color.FromArgb(222, 20, 174)));
        }

        public static void AfficherSekeleton()
        {
            string skel = @"
                         .            )        )
                                  (  (|              .
                              )   )\/ ( ( (
                      *  (   ((  /     ))\))  (  )    )
                    (     \   )\(          |  ))( )  (|
                    >)     ))/   |          )/  \((  ) \
                    (     (      .        -.     V )/   )(    (
                     \   /     .   \            .       \))   ))
                       )(      (  | |   )            .    (  /
                      )(    ,'))     \ /          \( `.    )
                      (\>  ,'/__      ))            __`.  /
                     ( \   | /  ___   ( \/     ___   \ | ( (
                      \.)  |/  /   \__      __/   \   \|  ))
                     .  \. |>  \      | __ |      /   <|  /
                          )/    \____/ :..: \____/     \ <
                   )   \ (|__  .      / ;: \          __| )  (
                  ((    )\)  ~--_     --  --      _--~    /  ))
                   \    (    |  ||               ||  |   (  /
                         \.  |  ||_             _||  |  /
                           > :  |  ~V+-I_I_I-+V~  |  : (.
                          (  \:  T\   _     _   /T  : ./
                           \  :    T^T T-+-T T^T    ;<
                            \..`_       -+-       _'  )
                               . `--=.._____..=--'. ./ 
                ";
            Console.WriteLine(skel.Pastel(Color.FromArgb(108, 105, 113)));
        }

        public static void AfficherPampa()
            {
                string pampa = @"
                           ''  .,.                          
                        .  .,:col:;.                        
                        .'.;k0KNX000o.                      
                          ,xKNK0NXkx0x'                     
                          :K00KOO0c.;0O,    'coxo.          
                          .xXx''okkkkOXOo::xO000Ox,         
                           .x0ocO0olOKOKXOdddccx0Ok,        
                       ..   .oKK0Kd.'xKOOK0o.  .cdo,        
                      ckkl.  ,dKKO0x..dK0OKXd.              
                      ;O0OxodkdxKXO0k:lKWX00Xx.             
                       ,k000Oxc':0X00XKO0XX00Xk'            
                        .cl:'.   ,OX00XK00KN00XO,           
                                  .xXK0XNXOKNKk00: .'cxko'  
                                  .;xOOOOKXOOkdxKKkOKXKK0c  
                                ,ok0OxkOkdl;..cO00KKKOxl,.  
                               ,0N00Kkl,..     :kOkd:.      
                               .oK00Xo.         ...         
                                 cKK0Kd.                    
                                  :0K0Kc                    
                                   :0Oo' 
                    ";
                Console.WriteLine(pampa.Pastel(Color.FromArgb(0, 130, 30)));
            }
        }
}
