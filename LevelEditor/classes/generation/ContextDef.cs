using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ContextDef : Context
    {
        private Definition def;

        public ContextDef(Generator Generator, Definition Def)
            : base(Generator)
        {
            def = Def;
        }

        public override string Do(Statement Statement)
        {
            if (Statement is StmAtr)
            {
                StmAtr stmAtr = Statement as StmAtr;

                if (stmAtr.Owner != null && 
                    !"DEF".Equals(stmAtr.Owner.ToUpper()))
                {
                    throw new ErrorCode(def.ToStringVerbose(), -1, "Invalid attribute owner: " + stmAtr.Owner);
                }

                string attr = stmAtr.Attribute;

                if (string.Compare(attr, "ID", true) == 0)
                {
                    return "" + def.Id;
                }
                else if (string.Compare(attr, "NAME", true) == 0)
                {
                    return def.Name;
                }
                else if (string.Compare(attr, "IMG_PATH", true) == 0)
                {
                    return Path.GetDirectoryName(def.ImagePath);
                }
                else if (string.Compare(attr, "IMG_NAME", true) == 0)
                {
                    return Path.GetFileName(def.ImagePath);
                }
                else if (string.Compare(attr, "CODE", true) == 0)
                {
                    ContextDef contextDef = new ContextDef(generator, def);
                    contextDef.SetParser(generator.GetParsed(def.GetCode()));
                    contextDef.Parent = this;

                    generator.Stack.Add(contextDef);

                    return null;
                }
                else if (string.Compare(attr, "AUTO_CODE", true) == 0)
                {
                    ContextDef contextDef = new ContextDef(generator, def);
                    contextDef.SetParser(generator.GetParsed(def.GetCodeObjAuto()));
                    contextDef.Parent = this;

                    generator.Stack.Add(contextDef);

                    return null;
                }
                else
                {
                    throw new ErrorCode(def.ToStringVerbose(), -1, "Invalid attribute name: " + stmAtr.Attribute);
                }
            }
            else
            {
                return base.Do(Statement);
            }
        }

        public override List<Context> GatherContexts(string context)
        {
            if ("OBJ".Equals(context))
            {
                List<Context> list = new List<Context>(generator.Foundation.Level.Count);

                for (int i = 0; i < generator.Foundation.Level.Count; ++i)
                {
                    Object obj = generator.Foundation.Level[i];

                    if (obj.GetDefinition() == def)
                    {
                        ContextObj contextObj = new ContextObj(generator, obj);
                        list.Add(contextObj);
                    }
                }

                return list;
            }

            return base.GatherContexts(context);
        }
    }
}
