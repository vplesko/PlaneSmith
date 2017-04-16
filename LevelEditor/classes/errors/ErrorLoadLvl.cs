using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ErrorLoadLvl : ErrorLoad
    {
        public ErrorLoadLvl(string Str, string File) : base(Str, File)
        {

        }

        public override string Description
        {
            get
            {
                return "Error loading level file " + file + ": " + str;
            }
        }
    }
}
