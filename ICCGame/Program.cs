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
            UIHelper.Instance.UIInit();
            MainMenu();
        }
        private static void MainMenu()
        {
            ConsoleKeyInfo info;
            bool run = true;
            while (true)
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
            switch (UIHelper.Instance.SelectedOption)
            {
                case 0:
                    Board.Instance.LaunchGame(0);
                    break;
                case 1:
                    Board.Instance.LaunchGame(1);
                    break;
                case 2:
                    Board.Instance.LaunchGame(2);
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}
