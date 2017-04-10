using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class IntPair
    {
        int x, y;

        public IntPair()
        {
            x = y = 0;
        }

        public IntPair(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
