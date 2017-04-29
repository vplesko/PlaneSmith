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

        private Foundation foundation;

        private int lastId = 0;
        private List<Definition> list = new List<Definition>();

        private bool changed = false;

        private string filePath = null;

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

        public string FilePath
        {
            get { return filePath; }
        }

        public bool Changed
        {
            get { return changed; }
            set { changed = value; }
        }

        public void Add(Definition T)
        {
            T.SetId(lastId++);
            list.Add(T);

            changed = true;
        }

        public bool MoveUp(int index)
        {
            if (index - 1 < 0 || index >= list.Count) return false;

            Definition temp = list[index];
            list[index] = list[index - 1];
            list[index - 1] = temp;

            changed = true;

            return true;
        }

        public bool MoveDown(int index)
        {
            if (index < 0 || index + 1 >= list.Count) return false;

            Definition temp = list[index];
            list[index] = list[index + 1];
            list[index + 1] = temp;

            changed = true;

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

            changed = true;
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

            changed = false;

            return true;
        }

        public bool Save()
        {
            if (filePath == null || filePath.Length == 0) return false;
            else return Save(filePath);
        }

        public void Load(string FilePath)
        {
            filePath = FilePath;

            if (!File.Exists(filePath))
                throw new ErrorLoadDict("File not found", FilePath);

            using (System.IO.StreamReader FS = new System.IO.StreamReader(FilePath))
            {
                list.Clear();

                string type = FS.ReadLine();
                if (!String.Equals(type, TypeToken))
                    throw new ErrorLoadDict("Invalid file type", FilePath);

                if (!Int32.TryParse(FS.ReadLine(), out lastId))
                    throw new ErrorLoadDict("LastId data invalid", FilePath);

                int cnt;
                if (!Int32.TryParse(FS.ReadLine(), out cnt))
                    throw new ErrorLoadDict("Count data invalid", FilePath);

                for (int i = 0; i < cnt; ++i)
                {
                    Definition D = new Definition(this);
                    if (!D.Load(FS))
                        throw new ErrorLoadDict("Could not parse definition " + i, FilePath);
                    list.Add(D);
                }
            }

            changed = false;
        }
    }
}
