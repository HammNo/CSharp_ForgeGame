using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pastel;
using System.Drawing;

namespace Prod_HeroesVsMonsters
{
    public class Jeu // pour tout ce qui est lancement du jeu
    {
        public Hero Start()
        {
            Console.Title = "Hereos VS Monsters"; // change le titre dans la barre d'info de la console
            return RunMainMenu();
        }


        private Hero RunMainMenu() // privé, on ne peut l'utiliser que ici
        {
            string prompt = @"
              _    _                          __      _______   __  __                 _                
             | |  | |                         \ \    / / ____| |  \/  |               | |               
             | |__| | ___ _ __ ___  ___  ___   \ \  / / (___   | \  / | ___  _ __  ___| |_ ___ _ __ ___ 
             |  __  |/ _ \ '__/ _ \/ _ \/ __|   \ \/ / \___ \  | |\/| |/ _ \| '_ \/ __| __/ _ \ '__/ __|
             | |  | |  __/ | |  __/ (_) \__ \    \  /  ____) | | |  | | (_) | | | \__ \ ||  __/ |  \__ \
             |_|  |_|\___|_|  \___|\___/|___/     \/  |_____/  |_|  |_|\___/|_| |_|___/\__\___|_|  |___/

Que voulez vous faire ?
Utilisez les flêches directionnelles pour sélectionner";
            string[] options = { "Jouer", "Quitter" };
            Menu mainMenu = new Menu(prompt, options);
            int indexSelect = mainMenu.Run();

            switch (indexSelect)
            {
                case 0:
                    return ChoixHero();
                case 1:
                    QuitterJeu();
                    break;
            }
            return null;
        }

        private Hero ChoixHero() // choix du héro qui appelle le menu des choix
        {
            
            string prompt = "Quel Héro voulez vous jouer ? ";
            string[] options = { "Guerrier", "Pistosabreur", "Erudit", "Barde", "Invocateur" }; // liste d'options de mes héros
            Menu choixhero = new Menu(prompt, options);
            int choix = choixhero.Run();
            Console.Clear();
            Hero hero = null;
            switch (choix) // selon le choix utilisateur, crée un nouveau héro correspondant
            {
                case 0:
                    Console.WriteLine($"Vous avez choisi un Guerrier !\n".Pastel(Color.FromArgb(135, 250, 123)));
                    hero = new Guerrier();
                    break;
                case 1:
                    Console.WriteLine($"Vous avez choisi un Pistosabreur !\n".Pastel(Color.FromArgb(135, 250, 123)));
                    hero = new Pistosabreur();
                    break;
                case 2:
                    Console.WriteLine($"Vous avez choisi un Erudit !\n".Pastel(Color.FromArgb(135, 250, 123)));
                    hero = new Erudit();
                    break;
                case 3:
                    Console.WriteLine($"Vous avez choisi un Barde !\n".Pastel(Color.FromArgb(135, 250, 123)));
                    hero = new Barde();
                    break;
                case 4:
                    Console.WriteLine($"Vous avez choisi un Invocateur !\n".Pastel(Color.FromArgb(135, 250, 123)));
                    hero = new Invocateur();
                    break;
            }
            Console.ResetColor();
            return hero;
        }

        private void QuitterJeu()
        {
            Console.WriteLine("\nAppuyez sur une touche pour quitter");
            Console.ReadKey(true);
            Environment.Exit(0); // quitte le programme sans erreur
        }

        public void VoirMarchand()
        {
            string prompt = "Voulez vous aller voir le marchand ?";
            string[] options = { "Oui", "Non, continuer l'aventure" };
            Menu voirmarchand = new Menu(prompt, options);
            int choix = voirmarchand.Run();
            switch (choix)
            {
                case 1:
                    // renvoyer au menu du marchand
                    break;
                case 2:
                    return;
            }

        }
    }
}
