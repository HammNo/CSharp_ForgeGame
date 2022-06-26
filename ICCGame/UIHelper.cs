using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using System.Diagnostics;
using System.IO;

namespace ICCGame
{
    public class UIHelper
    {
        private static UIHelper _instance = null;
        private List<string> _title = new List<string>
        {
            " ▄▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄   ▄▄       ▄▄   ▄▄▄▄▄▄▄▄▄▄▄ ",
            "▐░░░░░░░░░░░▌ ▐░░░░░░░░░░░▌ ▐░░░░░░░░░░░▌ ▐░░░░░░░░░░░▌ ▐░░░░░░░░░░░▌ ▐░░░░░░░░░░░▌ ▐░░░░░░░░░░░▌ ▐░░▌     ▐░░▌ ▐░░░░░░░░░░░▌",
            "▐░█▀▀▀▀▀▀▀▀▀  ▐░█▀▀▀▀▀▀▀█░▌ ▐░█▀▀▀▀▀▀▀█░▌ ▐░█▀▀▀▀▀▀▀▀▀  ▐░█▀▀▀▀▀▀▀▀▀  ▐░█▀▀▀▀▀▀▀▀▀  ▐░█▀▀▀▀▀▀▀█░▌ ▐░▌░▌   ▐░▐░▌ ▐░█▀▀▀▀▀▀▀▀▀ ",
            "▐░▌           ▐░▌       ▐░▌ ▐░▌       ▐░▌ ▐░▌           ▐░▌           ▐░▌           ▐░▌       ▐░▌ ▐░▌▐░▌ ▐░▌▐░▌ ▐░▌          ",
            "▐░█▄▄▄▄▄▄▄▄▄  ▐░▌       ▐░▌ ▐░█▄▄▄▄▄▄▄█░▌ ▐░▌ ▄▄▄▄▄▄▄▄  ▐░█▄▄▄▄▄▄▄▄▄  ▐░▌ ▄▄▄▄▄▄▄▄  ▐░█▄▄▄▄▄▄▄█░▌ ▐░▌ ▐░▐░▌ ▐░▌ ▐░█▄▄▄▄▄▄▄▄▄ ",
            "▐░░░░░░░░░░░▌ ▐░▌       ▐░▌ ▐░░░░░░░░░░░▌ ▐░▌▐░░░░░░░░▌ ▐░░░░░░░░░░░▌ ▐░▌▐░░░░░░░░▌ ▐░░░░░░░░░░░▌ ▐░▌  ▐░▌  ▐░▌ ▐░░░░░░░░░░░▌",
            "▐░█▀▀▀▀▀▀▀▀▀  ▐░▌       ▐░▌ ▐░█▀▀▀▀█░█▀▀  ▐░▌ ▀▀▀▀▀▀█░▌ ▐░█▀▀▀▀▀▀▀▀▀  ▐░▌ ▀▀▀▀▀▀█░▌ ▐░█▀▀▀▀▀▀▀█░▌ ▐░▌   ▀   ▐░▌ ▐░█▀▀▀▀▀▀▀▀▀ ",
            "▐░▌           ▐░▌       ▐░▌ ▐░▌     ▐░▌   ▐░▌       ▐░▌ ▐░▌           ▐░▌       ▐░▌ ▐░▌       ▐░▌ ▐░▌       ▐░▌ ▐░▌          ",
            "▐░▌           ▐░█▄▄▄▄▄▄▄█░▌ ▐░▌      ▐░▌  ▐░█▄▄▄▄▄▄▄█░▌ ▐░█▄▄▄▄▄▄▄▄▄  ▐░█▄▄▄▄▄▄▄█░▌ ▐░▌       ▐░▌ ▐░▌       ▐░▌ ▐░█▄▄▄▄▄▄▄▄▄ ",
            "▐░▌           ▐░░░░░░░░░░░▌ ▐░▌       ▐░▌ ▐░░░░░░░░░░░▌ ▐░░░░░░░░░░░▌ ▐░░░░░░░░░░░▌ ▐░▌       ▐░▌ ▐░▌       ▐░▌ ▐░░░░░░░░░░░▌",
            " ▀             ▀▀▀▀▀▀▀▀▀▀▀   ▀         ▀   ▀▀▀▀▀▀▀▀▀▀▀   ▀▀▀▀▀▀▀▀▀▀▀   ▀▀▀▀▀▀▀▀▀▀▀   ▀         ▀   ▀         ▀   ▀▀▀▀▀▀▀▀▀▀▀ "
        };
        private List<string> _optionMenu1 = new List<string>
        {
            "     ██ ███████ ██    ██         ██ ",
            "     ██ ██      ██    ██        ███ ",
            "     ██ █████   ██    ██         ██ ",
            "██   ██ ██      ██    ██         ██ ",
            " █████  ███████  ██████          ██ "
        };
        private List<string> _optionMenu2 = new List<string>
        {
            "     ██ ███████ ██    ██     ██████  ",
            "     ██ ██      ██    ██          ██ ",
            "     ██ █████   ██    ██      █████  ",
            "██   ██ ██      ██    ██     ██      ",
            " █████  ███████  ██████      ███████ "
        };
        private List<string> _optionMenu3 = new List<string>
        {
            "     ██ ███████ ██    ██     ██████  ",
            "     ██ ██      ██    ██          ██ ",
            "     ██ █████   ██    ██      █████  ",
            "██   ██ ██      ██    ██          ██ ",
            " █████  ███████  ██████      ██████  "
        };
        private OptionMenuContainer[] _optionMenu_tab;
        private int _selectedOption;
        public int X { get; set; }
        public int Y { get; set; }
        public int SelectedOption
        {
            get { return _selectedOption; }
        }
        public OptionMenuContainer[] OptionMenuTab
        {
            get { return _optionMenu_tab; }
        }

        public static UIHelper Instance
        {
            get { return _instance ?? (_instance = new UIHelper()); }
        }
        private UIHelper()
        {
            X = 0;
            Y = 0;
            _optionMenu_tab = new OptionMenuContainer[3];
            _selectedOption = 0;
        }
        public void UIInit()
        {
            X = Console.WindowWidth / 2 - 60;
            Console.Title = "ForgeGame";
            PrintOptionMenu(0);
            X += 25;
            PrintOptionMenu(1);
            PrintOptionMenu(2);
            PrintOptionMenu(3);
            OptionMenuTab[0].OptionSelect();
        }
        private void PrintTitle()
        {
            List<string> toPrint = _title;
            Console.ForegroundColor = Params.TitleColor;
            foreach (string line in toPrint)
            {
                Console.SetCursorPosition(X, ++Y);
                Console.Write(line);
            }
            Console.ForegroundColor = Color.White;
            Y += 4;
        }
        private void PrintOption(int option, List<string> toPrint)
        {
            if (_optionMenu_tab[option - 1] is null)
            {
                int[] first_point = new int[2] { X, Y };
                _optionMenu_tab[option - 1] = new OptionMenuContainer(first_point, toPrint.Count, toPrint[0].Length, 20);
            }
            else _optionMenu_tab[option - 1].Clear();
            Console.ForegroundColor = Params.OptionColor;
            _optionMenu_tab[option - 1].PrintContent(toPrint);
            Console.ForegroundColor = Color.White;
            Y += _optionMenu_tab[option - 1].Height + 1;
        }
        public void PrintOptionMenu(int option)
        {
            if (option == 0) PrintTitle();
            else
            {
                List<string> toPrint = null;
                switch (option)
                {
                    case 1:
                        toPrint = _optionMenu1;
                        break;
                    case 2:
                        toPrint = _optionMenu2;
                        break;
                    case 3:
                        toPrint = _optionMenu3;
                        break;
                }
                PrintOption(option, toPrint);
            }
        }
        public void SelectOptionMenu(Enums.MenuOptions option)
        {
            int move = (option == Enums.MenuOptions.Up) ? -1 : 1;
            int tab_index = _selectedOption + move;
            if(tab_index >= 0 && tab_index < _optionMenu_tab.Length)
            {    
                _optionMenu_tab[_selectedOption].OptionSelect();
                _optionMenu_tab[tab_index].OptionSelect();
                _selectedOption = tab_index;
            }
        }
    }
}
