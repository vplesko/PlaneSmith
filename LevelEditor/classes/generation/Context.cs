using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    abstract class Context
    {
        Generator generator;

        int lin = 0, col = 0;

        protected string[] lines;

        public Context(Generator Generator)
        {
            generator = Generator;
        }

        public Context(Generator Generator, string[] Lines)
        {
            generator = Generator;

            lines = new string[Lines.Length];
            Lines.CopyTo(lines, 0);
        }

        public Generator Generator
        {
            get { return generator; }
        }

        public virtual string Work()
        {
            if (lines == null || lin >= lines.Length)
            {
                Generator.Stack.Pop();
                return null;
            }

            if (col >= lines[lin].Length)
            {
                col = 0;
                ++lin;
                return null;
            }

            int ind0 = lines[lin].IndexOf("%<", col);
            int ind1 = ind0 >= 0 ? lines[lin].IndexOf(">%", ind0 + 2) : -1;

            if (ind0 < 0 || ind1 < 0)
            {
                string ret = lines[lin].Substring(col);
                col = 0;
                ++lin;
                return ret;
            }

            if (col < ind0)
            {
                string ret = lines[lin].Substring(col, ind0 - col);
                col = ind0;
                return ret;
            }

            col = ind1 + 2;

            string statement = lines[lin].Substring(ind0 + 2, ind1 - ind0 - 2);

            return Do(statement);
        }

        public abstract string Do(string Statement);
    }
}
