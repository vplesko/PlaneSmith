using System;
using System.Collections.Generic;
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
                string defImgPath = def.ImagePath;

                int indexS = defImgPath.LastIndexOf('/');
                int indexB = defImgPath.LastIndexOf('\\');
                int index = indexS > indexB ? indexS : indexB;

                if (index < 0) return "";
                else return defImgPath.Substring(0, index);
            }
            else if (string.Compare(Statement, "IMG_NAME", true) == 0)
            {
                string defImgPath = def.ImagePath;

                int indexS = defImgPath.LastIndexOf('/');
                int indexB = defImgPath.LastIndexOf('\\');
                int index = indexS > indexB ? indexS : indexB;

                if (index < 0) return defImgPath;
                else return defImgPath.Substring(index + 1);
            }
            else
            {
                return null;
            }
        }
    }
}
