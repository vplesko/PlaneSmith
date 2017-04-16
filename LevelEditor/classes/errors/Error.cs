using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    abstract class Error : Exception
    {
        protected string str;

        public Error(string Str) : base()
        {
            str = Str;
        }

        public abstract String Description
        {
            get;
        }
    }
}
