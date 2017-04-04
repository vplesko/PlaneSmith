using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Generator
    {
        Foundation foundation;
        Stack stack;

        System.IO.StreamWriter codeFile;

        public Generator(Foundation Foundation)
        {
            foundation = Foundation;
            stack = new Stack(this);

            codeFile = null;
        }

        public Foundation Foundation
        {
            get { return foundation; }
        }

        public Stack Stack
        {
            get { return stack; }
        }

        public System.IO.StreamWriter CodeFile
        {
            get { return codeFile; }
        }

        public string Generate(string FilePath)
        {
            using (codeFile = new System.IO.StreamWriter(FilePath))
            {
                stack.Add(new ContextBase(this));

                while (!stack.Empty)
                {
                    string output = stack.Peek().Work();
                    if (output != null) codeFile.Write(output);
                }
            }

            stack.Clear();
            codeFile = null;

            return null;
        }
    }
}
