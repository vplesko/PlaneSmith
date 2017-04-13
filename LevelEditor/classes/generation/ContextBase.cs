using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ContextBase : Context
    {
        public ContextBase(Generator Generator)
            : base(Generator)
        {
            string[] code = Generator.Foundation.Level.GetCode().LinesAsArray;
            if (code != null)
            {
                lines = new string[code.Length];
                code.CopyTo(lines, 0);
            }
        }

        public override string Do(string Statement)
        {
            if (string.Compare(Statement, "FECH(DEF)", true) == 0)
            {
                Generator.Stack.Add(new ContextFech(Generator, 0));
                return null;
            }
            else if (string.Compare(Statement, "FECH(OBJ)", true) == 0)
            {
                Generator.Stack.Add(new ContextFech(Generator, 1));
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
