namespace DemineurICC
{
    struct Grille
    {
        private Case[,] grilleJeu;
        private int nbCasesRestantes;
        private int posX, posY;
        private int nbLignes, nbColonnes;
        public Grille(int nbColonne, int nbLigne)
        {
            grilleJeu = new Case[nbColonne, nbLigne];
            for (int colonne = 0; colonne < nbColonne; colonne++)
            {
                for (int ligne = 0; ligne < nbLigne; ligne++)
                {
                    grilleJeu[colonne, ligne] = new Case();
                }
            }
            nbCasesRestantes = nbColonne * nbLigne;
            posY = 0;
            posX = 0;
            nbColonnes = nbColonne;
            nbLignes = nbLigne;
        }
        public int NbCasesRestantes
        {
            get { return nbCasesRestantes; }
        }
        public void RemplirGrille(int nbBombes)
        {
            nbCasesRestantes -= nbBombes;
            int cptBombes = 0;
            Random rand = new Random();
            while (cptBombes < nbBombes)
            {
                int xX = rand.Next(0, nbColonnes);
                int yY = rand.Next(0, nbLignes);
                if (grilleJeu[xX, yY].Contain == 0)
                {
                    grilleJeu[xX, yY].Contain = 9;
                    cptBombes++;
                }
            }
            for (int xX = 0; xX < nbColonnes; xX++)
            {
                for (int yY = 0; yY < nbLignes; yY++)
                {
                    if (grilleJeu[xX, yY].Contain != 9) grilleJeu[xX, yY].Contain = (countBombProximity(xX, yY));
                }
            }
            #region AfficheBomb
            //for (int yY = 0; yY < nbLignes; yY++)
            //{
            //    Console.SetCursorPosition(nbColonnes * 4 + 2, yY + 1);
            //    for (int xX = 0; xX < nbColonnes; xX++)
            //    {
            //        Console.Write(grilleJeu[xX, yY].Contain);
            //    }
            //    Console.Write(" \n");
            //}
            #endregion
        }
        public int countBombProximity(int xX, int yY)
        {
            int cptProxi = 0;

            if (xX - 1 >= 0 && yY - 1 >= 0 && grilleJeu[xX - 1, yY - 1].Contain == 9) cptProxi++;
            if (xX - 1 >= 0 && yY >= 0 && grilleJeu[xX - 1, yY].Contain == 9) cptProxi++;
            if (xX - 1 >= 0 && yY + 1 < nbLignes && grilleJeu[xX - 1, yY + 1].Contain == 9) cptProxi++;
            if (xX >= 0 && yY - 1 >= 0 && grilleJeu[xX, yY - 1].Contain == 9) cptProxi++;
            if (xX >= 0 && yY + 1 < nbLignes && grilleJeu[xX, yY + 1].Contain == 9) cptProxi++;
            if (xX + 1 < nbColonnes && yY - 1 >= 0 && grilleJeu[xX + 1, yY - 1].Contain == 9) cptProxi++;
            if (xX + 1 < nbColonnes && yY >= 0 && grilleJeu[xX + 1, yY].Contain == 9) cptProxi++;
            if (xX + 1 < nbColonnes && yY + 1 < nbLignes && grilleJeu[xX + 1, yY + 1].Contain == 9) cptProxi++;
            return cptProxi;
        }
        public void AfficheGrille()
        {
            Console.SetCursorPosition(0, 1);
            for (int y = 0; y <= nbLignes * 2; y++)
            {
                if (y == 0)
                {
                    for (int x = 0; x < nbColonnes; x++)
                    {
                        if (x == 0)
                        {
                            Console.Write("╔═══");
                        }
                        else if (x != nbColonnes - 1)
                        {
                            Console.Write("╦═══");
                        }
                        else
                        {
                            Console.Write("╦═══╗\n");
                        }
                    }
                }
                else if (y == nbLignes * 2)
                {
                    for (int x = 0; x < nbColonnes; x++)
                    {
                        if (x == 0)
                        {
                            Console.Write("╚═══");
                        }
                        else if (x != nbColonnes - 1)
                        {
                            Console.Write("╩═══");
                        }
                        else
                        {
                            Console.Write("╩═══╝\n");
                        }
                    }
                }
                else if (y % 2 == 1)
                {
                    int x = 1;
                    while (x < nbColonnes)
                    {
                        Console.Write("║ ? ");
                        x++;
                    }
                    Console.Write("║ ? ║\n");
                }
                else
                {
                    for (int x = 0; x < nbColonnes; x++)
                    {
                        if (x == 0)
                        {
                            Console.Write("╠═══");
                        }
                        else if (x != nbColonnes - 1)
                        {
                            Console.Write("╬═══");
                        }
                        else
                        {
                            Console.Write("╬═══╣\n");
                        }
                    }
                }
            }
        }
        public bool InputJoueur()
        {
            ConsoleKeyInfo info;
            do
            {
                info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (posY != 0)
                        {
                            posY--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (posY != nbLignes - 1)
                        {
                            posY++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (posX != 0)
                        {
                            posX--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (posX != nbColonnes - 1)
                        {
                            posX++;
                        }
                        break;
                    case ConsoleKey.F:
                        if (grilleJeu[posX, posY].Isreveal == false)
                        {
                            if (grilleJeu[posX, posY].IsFlaged == false)
                            {
                                grilleJeu[posX, posY].IsFlaged = true;
                                Console.SetCursorPosition(1 + posX * 4, 2 + posY * 2);
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(" ? ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                grilleJeu[posX, posY].IsFlaged = false;
                                Console.SetCursorPosition(1 + posX * 4, 2 + posY * 2);
                                Console.Write(" ? ");
                            }
                        }
                        else
                        {
                            if(grilleJeu[posX, posY].Contain != 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                            }
                            Console.SetCursorPosition(1 + posX * 4, 2 + posY * 2);
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        break;
                    default:
                        if (grilleJeu[posX, posY].Contain != 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        Console.SetCursorPosition(1 + posX * 4, 2 + posY * 2);
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                }
                Console.SetCursorPosition(1 + posX * 4, 2 + posY * 2);
            } while (info.Key != ConsoleKey.Enter);
            return Reveal();
        }
        public bool Reveal()
        {
            Console.SetCursorPosition(1 + posX * 4, 2 + posY * 2);
            if (grilleJeu[posX, posY].IsFlaged == true || grilleJeu[posX, posY].Isreveal)
            {
                return true;
            }
            else if (grilleJeu[posX, posY].Contain == 9)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" X ");
                Console.BackgroundColor = ConsoleColor.Black;
                return false;
            }
            else if (grilleJeu[posX, posY].Contain != 0)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" " + grilleJeu[posX, posY].Contain + " ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                nbCasesRestantes--;
                grilleJeu[posX, posY].Isreveal = true;
            }
            else
            {
                grilleJeu[posX, posY].Isreveal = true;
                Console.Write("   ");
                nbCasesRestantes--;
                Cascade(posX, posY);
            }
            return true;
        }
        public void Cascade(int xX, int yY)
        {
            AroundCascade(xX - 1, yY - 1);
            AroundCascade(xX - 1, yY);
            AroundCascade(xX - 1, yY + 1);
            AroundCascade(xX, yY - 1);
            AroundCascade(xX, yY + 1);
            AroundCascade(xX + 1, yY - 1);
            AroundCascade(xX + 1, yY);
            AroundCascade(xX + 1, yY + 1);
        }
        public void AroundCascade(int xX, int yY)
        {
            if (xX >= 0 && xX < nbColonnes && yY >= 0 && yY < nbLignes && grilleJeu[xX, yY].Isreveal == false)
            {
                Console.SetCursorPosition(1 + xX * 4, 2 + yY * 2);
                grilleJeu[xX, yY].Isreveal = true;
                nbCasesRestantes--;
                if (grilleJeu[xX, yY].Contain == 0)
                {
                    Console.Write("   ");
                    Cascade(xX, yY);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" " + grilleJeu[xX, yY].Contain + " ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
