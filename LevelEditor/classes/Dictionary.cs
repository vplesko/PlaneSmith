using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Dictionary
    {
        private List<Definition> list = new List<Definition>();

        public void Add(Definition T)
        {
            list.Add(T);
        }

        public Definition this[int index]
        {
            get { return list[index]; }
        }

        public int Count
        {
            get { return list.Count; }
        }
    }
}
