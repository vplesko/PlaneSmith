using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class StmNewline : Statement
    {
        public StmNewline(int Index) : base(Index, Environment.NewLine)
        {
        }

        public static bool IsThisYou(string str, string cln)
        {
            return "NL".Equals(cln);
        }
    }
}
