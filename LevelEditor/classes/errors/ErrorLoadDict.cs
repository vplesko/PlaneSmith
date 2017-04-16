using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ErrorLoadDict : ErrorLoad
    {
        public ErrorLoadDict(string Str, string File) : base(Str, File)
        {

        }

        public override string Description
        {
            get
            {
                return "Error loading dictionary file " + file + ": " + str;
            }
        }
    }
}
