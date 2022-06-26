namespace DemineurICC
{
    struct Case
    {
        private int contain;
        private bool isFlaged;
        private bool isReveal;

        public int Contain
        {
            get { return contain; }
            set { contain = value; }
        }
        public bool IsFlaged
        {
            get { return isFlaged; }
            set { isFlaged = value; }
        }
        public bool Isreveal
        {
            get { return isReveal; }
            set { isReveal = value; }
        }
    }
}


