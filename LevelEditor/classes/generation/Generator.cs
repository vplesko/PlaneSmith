using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Generator
    {
        private Foundation foundation;

        private Stack stack;
        private Dictionary<Code, Parser> parsers;

        public Generator(Foundation Foundation)
        {
            foundation = Foundation;

            stack = new Stack(this);
            parsers = new Dictionary<Code, Parser>();
        }

        public Foundation Foundation
        {
            get { return foundation; }
        }

        public Stack Stack
        {
            get { return stack; }
        }

        public Context CurrentContext
        {
            get { return stack.Empty ? null : stack.Peek(); }
        }

        public Parser GetParsed(Code Code)
        {
            return parsers[Code];
        }

        public void Generate(string FilePath)
        {
            parsers.Clear();
            stack.Clear();

            Parser parser = new Parser(this);
            parser.Parse(foundation.Level.GetCode(), "Level");
            parsers.Add(foundation.Level.GetCode(), parser);

            for (int i = 0; i < foundation.Dictionary.Count; ++i)
            {
                Definition def = foundation.Dictionary[i];

                parser = new Parser(this);
                parser.Parse(def.GetCode(), def.ToStringVerbose());
                parsers.Add(def.GetCode(), parser);

                parser = new Parser(this);
                parser.Parse(def.GetCodeObjAuto(), def.ToString() + " (Def.'s obj code)");
                parsers.Add(def.GetCodeObjAuto(), parser);
            }

            for (int i = 0; i < foundation.Level.Count; ++i)
            {
                Object obj = foundation.Level[i];
                parser = new Parser(this);
                parser.Parse(obj.GetCode(), obj.ToStringVerbose());
                parsers.Add(obj.GetCode(), parser);
            }

            using (System.IO.StreamWriter codeFile = new System.IO.StreamWriter(FilePath))
            {
                stack.Add(new ContextBase(this));

                while (!stack.Empty)
                {
                    string output = stack.Peek().Work();
                    if (output != null) codeFile.Write(output);
                }
            }

            parsers.Clear();
            stack.Clear();
        }
    }
}
