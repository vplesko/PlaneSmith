using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ErrorCode : Error
    {
        protected string codeOwner;
        protected int line;

        public ErrorCode(string Str) : base(Str)
        {
            codeOwner = null;
            line = -1;
        }

        public ErrorCode(string CodeOwner, int Line, string Str)
            : base(Str)
        {
            codeOwner = CodeOwner;
            line = Line;
        }

        public override string Description
        {
            get
            {
                return "Error" +
                    (codeOwner != null ? " in code for " + codeOwner : "") +
                    (line >= 0 ? " at line " + line : "") +
                    ": " + str;
            }
        }

        public string CodeOwner
        {
            get { return codeOwner; }
            set { codeOwner = value; }
        }

        public int Line
        {
            get { return line; }
            set { line = value; }
        }
    }
}
