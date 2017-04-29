using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Stack
    {
        private Generator generator;

        private LinkedList<Context> list;

        public Stack(Generator Generator)
        {
            generator = Generator;

            list = new LinkedList<Context>();
        }

        public Generator Generator
        {
            get { return generator; }
        }

        public void Add(Context Context)
        {
            list.AddLast(Context);
        }

        public Context Peek()
        {
            return list.Last.Value;
        }

        public Context Pop()
        {
            Context C = Peek();
            list.RemoveLast();
            return C;
        }

        public bool Empty
        {
            get { return list.Count == 0; }
        }

        public void Clear()
        {
            list.Clear();
        }
    }
}
