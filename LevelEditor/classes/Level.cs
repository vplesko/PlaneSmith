using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LevelEditor
{
    class Level
    {
        public static string TypeToken = "Level file";

        Form1 form;

        int lastId = 0;
        List<Instance> list = new List<Instance>();

        public Level(Form1 Form)
        {
            this.form = Form;
        }

        public void Add(Instance I)
        {
            I.SetId(lastId++);
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

        public Form1 GetForm()
        {
            return form;
        }

        public void Draw(Graphics G)
        {
            foreach (Instance I in list) I.Draw(G);
        }

        public void Save(System.IO.StreamWriter FS, string FileDictionary)
        {
            FS.WriteLine(TypeToken);

            FS.WriteLine(FileDictionary);

            FS.WriteLine("" + lastId);

            FS.WriteLine("" + list.Count);

            foreach (Instance I in list)
            {
                I.Save(FS);
            }
        }

        public bool Load(System.IO.StreamReader FS, Dictionary Dict)
        {
            list.Clear();

            string type = FS.ReadLine();
            if (!String.Equals(type, TypeToken)) return false;

            FS.ReadLine();

            bool success = Int32.TryParse(FS.ReadLine(), out lastId);
            if (!success) return success;

            int cnt;
            success = Int32.TryParse(FS.ReadLine(), out cnt);
            if (!success) return success;

            for (int i = 0; i < cnt; ++i)
            {
                Instance I = new Instance(this);
                success = I.Load(FS, Dict);
                if (!success) return success;
                list.Add(I);
            }

            return success;
        }
    }
}
