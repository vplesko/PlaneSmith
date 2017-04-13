using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ErrorText : Exception
    {
        public ErrorText(string Message)
            : base(Message)
        {
        }
    }
}
