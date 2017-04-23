using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ErrorCode : Error
    {
        protected int line;
        protected string desc;

        public ErrorCode(int Line, string Desc) : base(Desc)
        {
            line = Line;
            desc = Desc;
        }

        public override string Description
        {
            get
            {
                return "Error at line " + line + ": " + desc;
            }
        }
    }
}
