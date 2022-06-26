using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pastel;
using System.Drawing;
using System.Media;

namespace Prod_HeroesVsMonsters
{
    public class Menu // // contrôle de mes menus, pour pouvoir le réutiliser pour tout les menus avec choix
    {
        private int _indexselect; //selection de l'option
        private string[] _options; // la liste d'options, de choix possibles qui seront affichées dans le menu
        private string _prompt; //le texte à afficher avant le menu

        public int IndexSelect
        {
            get { return _indexselect; }
            set { _indexselect = value; }
        }
        public string[] Options
        {
            get { return _options; }
            set { _options = value; }
        }
        public string Prompt
        {
            get { return _prompt; }
            set { _prompt = value; }
        }

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            IndexSelect = 0;
        }

        private void MontrerOptions()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                if (i == IndexSelect) // pour changer la couleur en fonction de la sélection dans le menu
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"<< {currentOption} >>"); // afficher les options
            }
            Console.ResetColor();
        }

        internal int Run() 
        {
            ConsoleKey touchepressee; 
            do
            {
                Console.Clear(); // juste bouger le curseur et pas faire un clear console à chaque fois
                MontrerOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                touchepressee = keyInfo.Key;
                // selection dans le menu en fonction des touches pressées

                if (touchepressee == ConsoleKey.UpArrow)
                {
                    IndexSelect--;
                    if (IndexSelect == -1) // pour pas sortir de la liste d'options
                    {
                        IndexSelect = Options.Length - 1;
                    }
                }
                else if (touchepressee == ConsoleKey.DownArrow)
                {
                    IndexSelect++;
                    if (IndexSelect == Options.Length)
                    {
                        IndexSelect = 0;
                    }
                }
            }
            while (touchepressee != ConsoleKey.Enter);
            return IndexSelect;
        }
    }
}
