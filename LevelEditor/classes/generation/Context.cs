using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    abstract class Context
    {
        protected Generator generator;

        protected Context parent = null;

        protected int fromStm, toStm, currStm;
        protected Parser parser = null;

        public Context(Generator Generator)
        {
            generator = Generator;
        }

        public Generator Generator
        {
            get { return generator; }
        }

        public Context Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public void SetParser(Parser Parser)
        {
            parser = Parser;
            fromStm = 0;
            toStm = parser.Length - 1;
            currStm = fromStm;
        }

        public void SetParser(Parser Parser, int FromStm, int ToStm)
        {
            parser = Parser;
            fromStm = FromStm;
            toStm = ToStm;
            currStm = fromStm;
        }

        public int CurrStm
        {
            get { return currStm; }
            set { currStm = value; }
        }

        public virtual string Work()
        {
            if (parser == null || currStm > toStm)
            {
                generator.Stack.Pop();
                return null;
            }

            Statement statement = parser[currStm];
            ++currStm;

            return Do(statement);
        }

        public virtual List<Context> GatherContexts(string context)
        {
            if (parent == null) throw new ErrorCode("Fech context" + " from " + parser.CodeOwner + " is invalid: " + context);

            return parent.GatherContexts(context);
        }

        public virtual string Do(Statement Statement)
        {
            if (Statement is StmTerminal)
            {
                return Statement.Body;
            }
            else if (Statement is StmNewline)
            {
                return Environment.NewLine;
            }
            else if (Statement is StmFech)
            {
                --currStm;

                ContextFech fech = new ContextFech(generator, parser, Statement as StmFech);
                fech.Parent = this;
                generator.Stack.Add(fech);

                currStm = (Statement as StmFech).End + 1;

                return null;
            }

            if (parent == null) throw new ErrorCode("Statement" + " from " + parser.CodeOwner + " couldn't be processed: " + Code.SegmBeg + Statement + Code.SegmEnd);

            return parent.Do(Statement);
        }
    }
}
