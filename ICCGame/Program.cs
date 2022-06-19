using System;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using Console = Colorful.Console;
using System.IO;

namespace ICCGame
{
    class Program
    {
        private static Color _bgColor = Color.FromArgb(255, 224, 150);
        private static void Start()
        {
            Console.SetWindowSize(150, 40);
            Console.BackgroundColor = _bgColor;
            Console.Clear();
            UIHelper.Instance.UIInit();
            MainMenu();
        }
        private static void MainMenu()
        {
            ConsoleKeyInfo info;
            bool run = true;
            while (run)
            {
                info = Console.ReadKey(true);
                Console.CursorVisible = false;
                switch (info.Key)
                {
                    case ConsoleKey.DownArrow:
                        UIHelper.Instance.SelectOptionMenu(Enums.MenuOptions.Down);
                        break;
                    case ConsoleKey.UpArrow:
                        UIHelper.Instance.SelectOptionMenu(Enums.MenuOptions.Up);
                        break;
                    case ConsoleKey.Enter:
                        LaunchGame();
                        break;
                    case ConsoleKey.Escape:
                        run = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private static void LaunchGame()
        {
            string path = "";
            switch (UIHelper.Instance.SelectedOption)
            {
                case 0:
                    path += "https://olivierbarbiaux.dev/memory/";
                    Process.Start("explorer", path);
                    break;
                case 1:
                    path += Directory.GetCurrentDirectory();
                    if (Directory.Exists("\\bin")) path += $"\\bin\\Debug\\net5.0";
                    path += $"\\Games\\HeroesVsMonsters\\Prod_HeroesVsMonsters\\bin\\Debug\\net5.0\\Prod_HeroesVsMonsters.exe";
                    Process.Start("explorer", path);
                    break;
                case 2:
                    path += Directory.GetCurrentDirectory();
                    if (Directory.Exists("\\bin")) path += $"\\bin\\Debug\\net5.0";
                    path += $"\\Games\\SuperRocket\\Rocket parcours.exe";
                    Process.Start("explorer", path);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}
