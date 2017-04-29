using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    abstract class Statement
    {
        protected int index;
        protected string body;

        public Statement(int Index, string Body)
        {
            index = Index;
            body = Body;
        }

        public int Index
        {
            get { return index; }
        }

        public string Body
        {
            get { return body; }
        }
    }
}
