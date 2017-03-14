using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LevelEditor
{
    class Content
    {
        List<Instance> list = new List<Instance>();

        public void Add(Instance I)
        {
            list.Add(I);
        }

        public Instance this[int index]
        {
            get { return list[index]; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public void Draw(Graphics G)
        {
            foreach (Instance I in list) I.Draw(G);
        }
    }
}
