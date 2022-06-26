namespace DemineurICC
{
    internal class Affichage
    {
        public int Menu()
        {
            Console.SetCursorPosition(32, 0);
            Console.WriteLine(@" _____  ______ __  __ _____ _   _ ______ _    _ _____  ");
            Console.SetCursorPosition(32, 1);
            Console.WriteLine(@"|  __ \|  ____|  \/  |_   _| \ | |  ____| |  | |  __ \");
            Console.SetCursorPosition(32, 2);
            Console.WriteLine(@"| |  | | |__  | \  / | | | |  \| | |__  | |  | | |__) |");
            Console.SetCursorPosition(32, 3);
            Console.WriteLine(@"| |  | |  __| | |\/| | | | | . ` |  __| | |  | |  _  / ");
            Console.SetCursorPosition(32, 4);
            Console.WriteLine(@"| |__| | |____| |  | |_| |_| |\  | |____| |__| | | \ \ ");
            Console.SetCursorPosition(32, 5);
            Console.WriteLine(@"|_____/|______|_|  |_|_____|_| \_|______|\____/|_|  \_\");
            Console.SetCursorPosition(45, 8);
            Console.WriteLine("Selectionnez une difficulté :\n");
            Console.SetCursorPosition(17, 10);
            Console.WriteLine("FACILE");
            Console.SetCursorPosition(42, 10);
            Console.WriteLine("NORMAL");
            Console.SetCursorPosition(65, 10);
            Console.WriteLine("DIFFICILE");
            Console.SetCursorPosition(90, 10);
            Console.WriteLine("PERSONNALISE");
            return Selection();
        }
        public int Selection()
        {
            int choix = 0;
            Fleche(choix);
            ConsoleKeyInfo info;
            do
            {
                info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (choix != 0)
                        {
                            choix--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (choix != 3)
                        {
                            choix++;
                        }
                        break;
                    default:
                        break;
                }
                Fleche(choix);
            } while (info.Key != ConsoleKey.Enter);

                return choix;
        }

        public void Fleche(int choix)
        {
            Console.SetCursorPosition(0, 12);
            Console.Write("                                                                                                               ");
            Console.SetCursorPosition(0, 13);
            Console.Write("                                                                                                               ");
            Console.SetCursorPosition(0, 14);
            Console.Write("                                                                                                               ");
            Console.SetCursorPosition(0, 15);
            Console.Write("                                                                                                               ");
            Console.SetCursorPosition(17 + (choix * 25), 12);
            Console.Write("  █  ");
            Console.SetCursorPosition(17 + (choix * 25), 13);
            Console.Write(" ███ ");
            Console.SetCursorPosition(17 + (choix * 25), 14);
            Console.Write("█ █ █");
            Console.SetCursorPosition(17 + (choix * 25), 15);
            Console.Write("  █  ");
        }

    }
}
