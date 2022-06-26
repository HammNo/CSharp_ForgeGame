using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;


namespace ICCGame
{
    public class OptionMenuContainer : Container
    {
        private OptionMenuContainer _subContainer;
        private int _offset = 0;
        private bool _selected;
        private Task _blinkingArrow;
        private CancellationTokenSource _endBlinking;
        public OptionMenuContainer(int[] first_point, int height, int width, int offset) : base(first_point, height, width)
        {
            _offset = offset;
            _blinkingArrow = null;
            _subContainer = null;
            _selected = false;
        }
        public virtual void Clear()
        {
            lock (UIHelper.Instance)
            {
                Console.CursorVisible = false;
                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(FirstPoint[0] + _offset, FirstPoint[1] + i);
                    for (int j = 0; j < Width; j++)
                    {
                        Console.Write(" ");
                    }
                }
            }
        }
        public void PrintContent(List<string> toPrint)
        {
            Clear();
            lock (UIHelper.Instance)
            {
                Console.CursorVisible = false;
                int index = 0;
                foreach (string str in toPrint)
                {
                    int cpt = 0;
                    while (cpt < str.Length && cpt < Width)
                    {
                        Console.SetCursorPosition(FirstPoint[0] + _offset + cpt, FirstPoint[1] + index);
                        Console.Write(str[cpt]);
                        cpt++;
                    }
                    index++;
                }
                Console.ForegroundColor = Color.White;
            }
        }
        private async void ArrowBlink()
        {
            OptionMenuContainer cont = _subContainer;
            while (!_endBlinking.IsCancellationRequested)
            {
                await Task.Run(() =>
                {
                    List<string> arrow = new List<string>
                    {
                            "██   ██   ██   ",
                            " ██   ██   ██  ",
                            "  ██   ██   ██ ",
                            " ██   ██   ██  ",
                            "██   ██   ██   "
                    };
                    Console.ForegroundColor = Params.ArrowColor;
                    cont.PrintContent(arrow);
                    Console.ForegroundColor = Color.White;
                    Thread.Sleep(500);
                    if(!_endBlinking.IsCancellationRequested) cont.Clear();
                    Thread.Sleep(500);
                });
            }
        }
        public void OptionSelect()
        {
            if (_subContainer is null) _subContainer = new OptionMenuContainer(FirstPoint, Height, _offset, 0);
            if (_blinkingArrow is null)
            {
                _endBlinking = new CancellationTokenSource();
                _blinkingArrow = new Task(ArrowBlink, _endBlinking.Token);
            }
            if (_selected)
            {
                _endBlinking.Cancel(false);
                _subContainer.Clear();
            }
            else
            {
                if (_blinkingArrow.Status == TaskStatus.Running) return;
                else if (_blinkingArrow.Status == TaskStatus.RanToCompletion)
                {
                    _endBlinking = new CancellationTokenSource();
                    _blinkingArrow = new Task(ArrowBlink, _endBlinking.Token);
                }
                _blinkingArrow.Start();
            }
            _selected = !_selected;
        }
    }
}
