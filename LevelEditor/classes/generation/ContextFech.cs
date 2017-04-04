using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ContextFech : Context
    {
        Context[] list;
        int curr;

        public ContextFech(Generator Generator, int Type)
            : base(Generator)
        {
            if (Type == 0)
            {
                list = new Context[Generator.Foundation.Dictionary.Count];

                for (int i = 0; i < list.Length; ++i)
                    list[i] = new ContextDef(Generator, Generator.Foundation.Dictionary[i]);
            }
            else
            {
                list = new Context[Generator.Foundation.Level.Count];

                for (int i = 0; i < list.Length; ++i)
                    list[i] = new ContextObj(Generator, Generator.Foundation.Level[i]);
            }

            curr = 0;
        }

        public override string Work()
        {
            if (curr < list.Length)
            {
                Generator.Stack.Add(list[curr]);
                ++curr;
                return null;
            }

            Generator.Stack.Pop();
            return null;
        }

        public override string Do(string Statement)
        {
            return null;
        }
    }
}
