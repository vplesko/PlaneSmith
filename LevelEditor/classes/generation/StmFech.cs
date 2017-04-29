using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LevelEditor
{
    class StmFech : Statement
    {
        private string context;
        private string split;

        private int end;

        public StmFech(int Index, string Str)
            : base(Index, Str)
        {
            end = -1;

            int dot0 = Str.IndexOf('.');

            if (dot0 < 0) throw new ErrorCode("Context in FECH not specified");

            int dot1 = Str.IndexOf('.', dot0 + 1);

            if (dot1 < 0)
            {
                context = Str.Substring(dot0 + 1);
                context = Regex.Replace(context, @"\s+", "").ToUpper();

                split = null;
            }
            else
            {
                if (dot0 + 1 == dot1) throw new ErrorCode("Context in FECH is empty");

                context = Str.Substring(dot0 + 1, dot1 - dot0 - 1);
                context = Regex.Replace(context, @"\s+", "").ToUpper();

                split = Str.Substring(dot1 + 1);
            }
        }

        public static bool IsThisYou(string str, string cln)
        {
            return cln.IndexOf("FECH") == 0;
        }

        public string Context
        {
            get { return context; }
        }

        public string Split
        {
            get { return split; }
        }

        public int End
        {
            get { return end; }
            set { end = value; }
        }
    }
}
