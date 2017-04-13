using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ContextObj : Context
    {
        Object obj;

        public ContextObj(Generator Generator, Object Obj)
            : base(Generator)
        {
            obj = Obj;

            string[] code = Obj.GetCode().LinesAsArray;
            if (code != null)
            {
                lines = new string[code.Length];
                code.CopyTo(lines, 0);
            }
        }

        public override string Do(string Statement)
        {
            if (string.Compare(Statement, "ID", true) == 0)
            {
                return "" + obj.Id;
            }
            else if (string.Compare(Statement, "X", true) == 0)
            {
                return "" + obj.Position.X;
            }
            else if (string.Compare(Statement, "Y", true) == 0)
            {
                return "" + obj.Position.Y;
            }
            else if (Statement.IndexOf("DEF.") == 0)
            {
                ContextDef cDef = new ContextDef(Generator, obj.GetDefinition());
                return cDef.Do(Statement.Substring("DEF.".Length));
            }
            else
            {
                return null;
            }
        }
    }
}
