namespace DemineurICC
{
    class Program
    {
        static void Main(string[] args)
        {
            Affichage affichage = new Affichage();
            Grille jeu;
            int choix = affichage.Menu();
            switch (choix)
            {
                case 0:
                    jeu = new Grille(10, 10);
                    jeu.RemplirGrille(10);
                    break;
                case 1:
                    jeu = new Grille(20, 10);
                    jeu.RemplirGrille(25);
                    break;
                case 2:
                    jeu = new Grille(25, 15);
                    jeu.RemplirGrille(50);
                    break;
                case 3:
                    Console.SetCursorPosition(20, 17);
                    Console.Write("Combien de Colonnes ? : ");
                    int colonne = DemandeColonne();
                    Console.SetCursorPosition(20, 19);
                    Console.Write("Combien de lignes ? : ");
                    int ligne = DemandeLigne();
                    Console.SetCursorPosition(20, 21);
                    Console.Write("Combien de Bombes ? : ");
                    int nbBombes = DemandeBombe(ligne, colonne);
                    jeu = new Grille(colonne, ligne);
                    jeu.RemplirGrille(nbBombes);
                    break;
                default:
                    jeu = new Grille(10, 10);
                    jeu.RemplirGrille(1);
                    break;
            }
            Console.Clear();
            Console.WriteLine("Bienvenue sur Démineur ! Révélez toutes les cases vide pour gagner ! utilisez la touche F pour marquer une case !");
            jeu.AfficheGrille();
            Console.SetCursorPosition(1, 2);
            bool gagner = true;
            while (jeu.NbCasesRestantes > 0 && gagner == true)
            {
                gagner = jeu.InputJoueur();
            }
            Console.SetCursorPosition(0, 22);
            if (gagner)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(48, 14);
                Console.Write("                         ");
                Console.SetCursorPosition(48, 15);
                Console.Write("  Bravo vous avez gagné  ");
                Console.SetCursorPosition(48, 16);
                Console.Write("                         ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(48, 14);
                Console.Write("                         ");
                Console.SetCursorPosition(48, 15);
                Console.Write(" Dommage vous avez perdu ");
                Console.SetCursorPosition(48, 16);
                Console.Write("                         ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadLine();
        }
        private static int DemandeBombe(int ligne, int colonne)
        {
            int nbBombes;
            bool isTrue;
            do
            {
                isTrue = true;
                while (!int.TryParse(Console.ReadLine(), out nbBombes))
                {
                    Console.SetCursorPosition(20, 22);
                    Console.Write("                                                                                  ");
                    Console.SetCursorPosition(20, 22);
                    Console.Write("Vous devez absolument entrez un nombre ! Réessayer");
                    Console.SetCursorPosition(42, 21);
                    Console.Write("                                     ");
                    Console.SetCursorPosition(42, 21);
                }
                if (nbBombes <= 0)
                {
                    Console.SetCursorPosition(20, 22);
                    Console.Write("                                                                                  ");
                    Console.SetCursorPosition(20, 22);
                    Console.Write("Le nombre de bombes ne peut pas être inférieur à 1 ! Réessayer");
                    Console.SetCursorPosition(42, 21);
                    Console.Write("                                     ");
                    Console.SetCursorPosition(42, 21);
                    isTrue = false;
                }
                else if (nbBombes > ligne * colonne - 1)
                {
                    Console.SetCursorPosition(20, 22);
                    Console.Write("                                                                                  ");
                    Console.SetCursorPosition(20, 22);
                    Console.Write("Le nombre de bombes ne peut pas être égale ou supérieur à " + ligne * colonne + " ! Réessayer");
                    Console.SetCursorPosition(42, 21);
                    Console.Write("                                     ");
                    Console.SetCursorPosition(42, 21);
                    isTrue = false;
                }
            } while (!isTrue);
            return nbBombes;
        }
        private static int DemandeColonne()
        {
            int colonne;
            bool isTrue;
            do
            {
                isTrue = true;
                while (!int.TryParse(Console.ReadLine(), out colonne))
                {
                    Console.SetCursorPosition(20, 18);
                    Console.Write("                                                                                  ");
                    Console.SetCursorPosition(20, 18);
                    Console.Write("Vous devez absolument entrez un nombre ! Réessayer");
                    Console.SetCursorPosition(44, 17);
                    Console.Write("                                     ");
                    Console.SetCursorPosition(44, 17);
                }
                if (colonne <= 1)
                {
                    Console.SetCursorPosition(20, 18);
                    Console.Write("                                                                                  ");
                    Console.SetCursorPosition(20, 18);
                    Console.Write("Le nombre de colonnes ne peut pas être inférieur à 2 ! Réessayer");
                    Console.SetCursorPosition(44, 17);
                    Console.Write("                                     ");
                    Console.SetCursorPosition(44, 17);
                    isTrue = false;
                }
                else if (colonne > 50)
                {
                    Console.SetCursorPosition(20, 18);
                    Console.Write("                                                                                  ");
                    Console.SetCursorPosition(20, 18);
                    Console.Write("Le nombre de colonnes ne peut pas être supérieur à 50 ! Réessayer");
                    Console.SetCursorPosition(44, 17);
                    Console.Write("                                     ");
                    Console.SetCursorPosition(44, 17);
                    isTrue = false;
                }
            } while (!isTrue);
            return colonne;
        }
        private static int DemandeLigne()
        {
            int ligne;
            bool isTrue;
            do
            {
                isTrue = true;
                while (!int.TryParse(Console.ReadLine(), out ligne))
                {
                    Console.SetCursorPosition(20, 20);
                    Console.Write("                                                                                  ");
                    Console.SetCursorPosition(20, 20);
                    Console.Write("Vous devez absolument entrez un nombre ! Réessayer");
                    Console.SetCursorPosition(42, 19);
                    Console.Write("                                     ");
                    Console.SetCursorPosition(42, 19);
                }
                if (ligne <= 1)
                {
                    Console.SetCursorPosition(20, 20);
                    Console.Write("                                                                                  ");
                    Console.SetCursorPosition(20, 20);
                    Console.Write("Le nombre de lignes ne peut pas être inférieur à 2 ! Réessayer");
                    Console.SetCursorPosition(42, 19);
                    Console.Write("                                     ");
                    Console.SetCursorPosition(42, 19);
                    isTrue = false;
                }
                else if (ligne > 50)
                {
                    Console.SetCursorPosition(20, 20);
                    Console.Write("                                                                                  ");
                    Console.SetCursorPosition(20, 20);
                    Console.Write("Le nombre de lignes ne peut pas être supérieur à 50 ! Réessayer");
                    Console.SetCursorPosition(42, 19);
                    Console.Write("                                     ");
                    Console.SetCursorPosition(42, 19);
                    isTrue = false;
                }
            } while (!isTrue);
            return ligne;
        }
    }
}
