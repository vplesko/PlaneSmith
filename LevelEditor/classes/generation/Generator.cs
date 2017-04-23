using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Generator
    {
        public static string SegmBeg = "«";
        public static string SegmEnd = "»";

        public static string Keywords = "FECH OBJ DEF ATR";
        public static string FreqAtrs = "NL ID IMG_PATH IMG_NAME NAME CODE CODE_OBJ ID X Y";
        
        Foundation foundation;
        Stack stack;

        public Generator(Foundation Foundation)
        {
            foundation = Foundation;
            stack = new Stack(this);
        }

        public Foundation Foundation
        {
            get { return foundation; }
        }

        public Stack Stack
        {
            get { return stack; }
        }

        public void Generate(string FilePath)
        {
            using (System.IO.StreamWriter codeFile = new System.IO.StreamWriter(FilePath))
            {
                stack.Add(new ContextBase(this));

                while (!stack.Empty)
                {
                    string output = stack.Peek().Work();
                    if (output != null) codeFile.Write(output);
                }
            }

            stack.Clear();
        }
    }
}
