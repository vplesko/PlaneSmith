using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class ContextObj : Context
    {
        private Object obj;

        public ContextObj(Generator Generator, Object Obj)
            : base(Generator)
        {
            obj = Obj;
        }

        public override string Do(Statement Statement)
        {
            if (Statement is StmAtr)
            {
                StmAtr stmAtr = Statement as StmAtr;

                if (stmAtr.Owner != null && 
                    !"DEF".Equals(stmAtr.Owner.ToUpper()) && 
                    !"OBJ".Equals(stmAtr.Owner.ToUpper()))
                {
                    throw new ErrorCode(obj.ToStringVerbose(), -1, "Invalid attribute owner: " + stmAtr.Owner);
                }

                string attr = stmAtr.Attribute;

                if (stmAtr.Owner != null && "DEF".Equals(stmAtr.Owner.ToUpper()))
                {
                    StmAtr defAtr = new StmAtr(0, attr);

                    ContextDef defContext = new ContextDef(generator, obj.GetDefinition());
                    Parser defParser = new Parser(generator);
                    defParser.SetSingleStatement(defAtr, obj.GetDefinition().ToStringVerbose());
                    defContext.SetParser(defParser);

                    defContext.Parent = this;

                    generator.Stack.Add(defContext);

                    return null;
                }

                if (string.Compare(attr, "ID", true) == 0)
                {
                    return "" + obj.Id;
                }
                else if (string.Compare(attr, "X", true) == 0)
                {
                    return "" + obj.Position.X;
                }
                else if (string.Compare(attr, "Y", true) == 0)
                {
                    return "" + obj.Position.Y;
                }
                else if (string.Compare(attr, "CODE", true) == 0)
                {
                    ContextObj contextObj = new ContextObj(generator, obj);
                    contextObj.SetParser(generator.GetParsed(obj.GetCode()));
                    contextObj.Parent = this;

                    generator.Stack.Add(contextObj);

                    return null;
                }
                else
                {
                    throw new ErrorCode(obj.ToStringVerbose(), -1, "Invalid attribute name: " + stmAtr.Attribute);
                }
            }
            else
            {
                return base.Do(Statement);
            }
        }
    }
}
