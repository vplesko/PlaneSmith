using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ContextBase : Context
    {
        public ContextBase(Generator Generator)
            : base(Generator)
        {
            SetParser(Generator.GetParsed(generator.Foundation.Level.GetCode()));
        }

        public override List<Context> GatherContexts(string context)
        {
            context = context.ToUpper();

            if ("DEF".Equals(context))
            {
                List<Context> list = new List<Context>(generator.Foundation.Dictionary.Count);

                for (int i = 0; i < generator.Foundation.Dictionary.Count; ++i)
                {
                    ContextDef contextDef = new ContextDef(generator, generator.Foundation.Dictionary[i]);
                    list.Add(contextDef);
                }

                return list;
            }
            else if ("OBJ".Equals(context))
            {
                List<Context> list = new List<Context>(generator.Foundation.Level.Count);

                for (int i = 0; i < generator.Foundation.Level.Count; ++i)
                {
                    ContextObj contextObj = new ContextObj(generator, generator.Foundation.Level[i]);
                    list.Add(contextObj);
                }

                return list;
            }

            return base.GatherContexts(context);
        }
    }
}
