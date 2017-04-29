using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LevelEditor
{
    class StatementFactory
    {
        private StatementFactory()
        {
        }

        public static Statement Create(int Index, string Str)
        {
            string cln = Regex.Replace(Str, @"\s+", "").ToUpper();

            if (StmFech.IsThisYou(Str, cln)) return new StmFech(Index, Str);
            if (StmEnd.IsThisYou(Str, cln)) return new StmEnd(Index, Str);
            if (StmNewline.IsThisYou(Str, cln)) return new StmNewline(Index);

            return new StmAtr(Index, Str);
        }

        public static Statement CreateTerminal(int Index, string Str)
        {
            return new StmTerminal(Index, Str);
        }

        public static Statement CreateNewline(int Index)
        {
            return new StmNewline(Index);
        }
    }
}
