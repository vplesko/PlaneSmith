using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ContextDef : Context
    {
        Definition def;

        public ContextDef(Generator Generator, Definition Def)
            : base(Generator)
        {
            def = Def;

            string[] code = Def.GetCode().LinesAsArray;
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
                return "" + def.Id;
            }
            else if (string.Compare(Statement, "NAME", true) == 0)
            {
                return def.Name;
            }
            else if (string.Compare(Statement, "IMG_PATH", true) == 0)
            {
                return Path.GetFileName(def.ImagePath);
            }
            else if (string.Compare(Statement, "IMG_NAME", true) == 0)
            {
                return Path.GetDirectoryName(def.ImagePath);
            }
            else
            {
                return null;
            }
        }
    }
}
