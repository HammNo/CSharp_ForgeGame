using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ICCGame
{
    public class Board
    {
        private static Board _instance;
        private List<Action> _actions_list;
        public static Board Instance
        {
            get { return _instance ?? (_instance = new Board()); }
        }
        public Board()
        {
            _actions_list = new List<Action>();
        }
        private void GMemory()
        {
            string path = "https://olivierbarbiaux.dev/memory/";
            Process.Start("explorer", path);
        }
        private void GHeroesVsMonsters()
        {
            string path = Directory.GetCurrentDirectory();
            if (Directory.Exists("\\bin")) path += $"\\bin\\Debug\\net5.0";
            path += $"\\data\\ref\\HeroesVsMonsters\\Prod_HeroesVsMonsters\\bin\\Debug\\net5.0\\Prod_HeroesVsMonsters.exe";
            Process.Start("explorer", path);
        }
        private void GDemin()
        {
            string path = Directory.GetCurrentDirectory();
            if (Directory.Exists("\\bin")) path += $"\\bin\\Debug\\net5.0";
            path += $"\\data\\ref\\Demineur\\DemineurICC\\bin\\Debug\\net6.0\\DemineurICC.exe";
            Process.Start("explorer", path);
        }
        private void GSecret()
        {
            string path = Directory.GetCurrentDirectory();
            if (Directory.Exists("\\bin")) path += $"\\bin\\Debug\\net5.0";
            path += $"\\data\\ref\\SuperRocket\\Rocket parcours.exe";
            Process.Start("explorer", path);
        }
        private void GPoke()
        {
            string path = "https://olivierbarbiaux.dev/pokemon/";
            Process.Start("explorer", path);
        }
        private void ReadPasswords()
        {
            _actions_list = new List<Action>();
            string path = "";
            if (Directory.Exists("\\bin")) path += $"\\bin\\Debug\\net5.0";
            path += @"pwd.txt";
            StreamReader sr = null;
            if (File.Exists(path))
            {
                sr = File.OpenText(path);
                string line = "";
                do
                {
                    line = sr.ReadLine();
                    int code = 0;
                    if (int.TryParse(line, out code))
                    {
                        if (code == XCode(Params.CodeG1)) _actions_list.Add(GMemory);
                        else if (code == XCode(Params.CodeG2)) _actions_list.Add(GHeroesVsMonsters);
                        else if (code == XCode(Params.CodeG3)) _actions_list.Add(GSecret);
                        else if (code == XCode(Params.CodeG4)) _actions_list.Add(GDemin);
                        else if (code == XCode(Params.CodeG5)) _actions_list.Add(GPoke);
                    }
                } while (line != null && _actions_list.Count < 4);
                sr.Dispose();
                sr.Close();
            }
        }
        private int XCode(int nbr)
        {
            int count = 0;
            int prem = 0;
            for (int j = 0; count < nbr; j++)
            {
                int i = 2;
                while ((i <= (j / 2)) && (j % i != 0)) i++;
                if (i == (j / 2) + 1)
                {
                    count++;
                    prem = j;
                }
            }
            return prem;
        }
        public void LaunchGame(int option)
        {
            ReadPasswords();
            if(option < _actions_list.Count)
            {
                if (_actions_list[option] != null) _actions_list[option].Invoke();
            }
        }
    }
}
