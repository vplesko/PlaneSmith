using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Dictionary
    {
        public static string TypeToken = "Dictionary file";

        Foundation foundation;

        int lastId = 0;
        List<Definition> list = new List<Definition>();

        string filePath = null;

        public Dictionary(Foundation Foundation)
        {
            foundation = Foundation;
        }

        public Foundation Foundation
        {
            get { return foundation; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public Definition this[int index]
        {
            get { return list[index]; }
        }

        public string GetFilePath()
        {
            return filePath;
        }

        public void Add(Definition T)
        {
            T.SetId(lastId++);
            list.Add(T);
        }

        public bool MoveUp(int index)
        {
            if (index - 1 < 0 || index >= list.Count) return false;

            Definition temp = list[index];
            list[index] = list[index - 1];
            list[index - 1] = temp;

            return true;
        }

        public bool MoveDown(int index)
        {
            if (index < 0 || index + 1 >= list.Count) return false;

            Definition temp = list[index];
            list[index] = list[index + 1];
            list[index + 1] = temp;

            return true;
        }

        public Definition Get(int Id)
        {
            foreach (Definition D in list)
                if (D.Id == Id)
                    return D;

            return null;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= list.Count) return;

            list.RemoveAt(index);
        }

        public bool Save(string FilePath)
        {
            filePath = FilePath;

            using (System.IO.StreamWriter FS = new System.IO.StreamWriter(FilePath))
            {
                FS.WriteLine(TypeToken);

                FS.WriteLine("" + lastId);

                FS.WriteLine("" + list.Count);

                foreach (Definition D in list)
                {
                    D.Save(FS);
                }
            }

            return true;
        }

        public bool Save()
        {
            if (filePath == null || filePath.Length == 0) return false;
            else return Save(filePath);
        }

        public bool Load(string FilePath)
        {
            filePath = FilePath;

            if (!File.Exists(filePath)) return false;

            using (System.IO.StreamReader FS = new System.IO.StreamReader(FilePath))
            {
                list.Clear();

                string type = FS.ReadLine();
                if (!String.Equals(type, TypeToken)) return false;

                if (!Int32.TryParse(FS.ReadLine(), out lastId)) return false;

                int cnt;
                if (!Int32.TryParse(FS.ReadLine(), out cnt)) return false;

                for (int i = 0; i < cnt; ++i)
                {
                    Definition D = new Definition(this);
                    if (!D.Load(FS)) return false;
                    list.Add(D);
                }
            }

            return true;
        }
    }
}
