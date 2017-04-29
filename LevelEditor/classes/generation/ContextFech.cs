using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ContextFech : Context
    {
        private StmFech stmFech;

        private List<Context> list;
        private int currContext;

        public ContextFech(Generator Generator, Parser Parser, StmFech Stm)
            : base(Generator)
        {
            stmFech = Stm;

            if (stmFech != null) SetParser(Parser, Stm.Index, Stm.End);
            else parser = Parser;

            list = null;
        }

        public override string Work()
        {
            if (parser == null || stmFech == null)
            {
                Generator.Stack.Pop();
                return null;
            }

            if (list == null)
            {
                list = GatherContexts(stmFech.Context);

                foreach (Context context in list)
                {
                    context.SetParser(parser, fromStm + 1, toStm - 1);
                    context.Parent = this;
                }

                currContext = 0;

                return null;
            }

            if (currContext < list.Count)
            {
                Generator.Stack.Add(list[currContext]);
                ++currContext;

                // return mid-context split terminal if this is not the first context
                // this WILL be written before Generator goes into the next context
                if (currContext > 1) return stmFech.Split;
                else return null;
            }

            Generator.Stack.Pop();
            return null;
        }
    }
}
