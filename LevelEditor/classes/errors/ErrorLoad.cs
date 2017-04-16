using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    abstract class ErrorLoad : Error
    {
        protected string file;

        public ErrorLoad(string Str, string File) : base(Str)
        {
            file = File;
        }
    }
}
