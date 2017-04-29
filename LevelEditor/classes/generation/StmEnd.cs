using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class StmEnd : Statement
    {
        private int start;

        public StmEnd(int Index, string Str)
            : base(Index, Str)
        {
            start = -1;
        }

        public static bool IsThisYou(string str, string cln)
        {
            return "END".Equals(cln);
        }

        public int Start
        {
            get { return start; }
            set { start = value; }
        }
    }
}
