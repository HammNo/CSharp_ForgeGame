using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Console = Colorful.Console;

namespace ICCGame
{
    public abstract class Container
    {
        #region fields
        public Color ArrowColor = Color.FromArgb(184, 145, 140);
        private int[] _first_point;
        private int _height;
        private int _width;
        #endregion
        #region properties
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public int[] FirstPoint
        {
            get { return _first_point; }
            private set { _first_point = value; }
        }
        #endregion
        #region constructor
        public Container(int[] first_point, int height, int width)
        {
            FirstPoint = first_point;
            Height = height;
            Width = width;
        } 
        #endregion
    }
}
