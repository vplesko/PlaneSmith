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
            foundation.Form.onDictionaryChanged();
        }

        public Definition Get(int Id)
        {
            foreach (Definition D in list)
                if (D.Id == Id)
                    return D;

            return null;
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
            bool success;

            using (System.IO.StreamReader FS = new System.IO.StreamReader(FilePath))
            {
                list.Clear();

                string type = FS.ReadLine();
                if (!String.Equals(type, TypeToken)) return false;

                success = Int32.TryParse(FS.ReadLine(), out lastId);
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
            }

            if (success) foundation.Form.onDictionaryChanged();

            return success;
        }
    }
}
