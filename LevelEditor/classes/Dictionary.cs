using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Dictionary
    {
        public static string TypeToken = "Dictionary file";

        Form1 form;

        int lastId = 0;
        List<Definition> list = new List<Definition>();

        public Dictionary(Form1 Form)
        {
            this.form = Form;
        }

        public void Add(Definition T)
        {
            T.SetId(lastId++);
            list.Add(T);
        }

        public Definition Get(int Id)
        {
            foreach (Definition D in list)
                if (D.Id == Id)
                    return D;

            return null;
        }

        public Definition this[int index]
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

        public void Save(System.IO.StreamWriter FS)
        {
            FS.WriteLine(TypeToken);

            FS.WriteLine("" + lastId);

            FS.WriteLine("" + list.Count);

            foreach (Definition D in list)
            {
                D.Save(FS);
            }
        }

        public bool Load(System.IO.StreamReader FS)
        {
            list.Clear();

            string type = FS.ReadLine();
            if (!String.Equals(type, TypeToken)) return false;

            bool success = Int32.TryParse(FS.ReadLine(), out lastId);
            if (!success) return success;

            int cnt;
            success = Int32.TryParse(FS.ReadLine(), out cnt);
            if (!success) return success;

            for (int i = 0; i < cnt; ++i)
            {
                Definition D = new Definition(this);
                success = D.Load(FS);
                if (!success) return success;
                list.Add(D);
            }

            return success;
        }
    }
}
