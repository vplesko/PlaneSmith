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

        Foundation foundation;

        int lastId = 0;
        List<Instance> list = new List<Instance>();

        string[] code;

        string filePath = null;

        public Level(Foundation Foundation)
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

        public Instance this[int index]
        {
            get { return list[index]; }
        }

        public string GetFilePath()
        {
            return filePath;
        }

        public void CopyAsCode(string[] Code)
        {
            if (Code == null)
            {
                code = null;
                return;
            }

            code = new string[Code.Length];
            Code.CopyTo(code, 0);
        }

        public void RecopyCode()
        {
            string[] temp = code;
            CopyAsCode(temp);
        }

        public string[] GetCode()
        {
            return code;
        }

        public void Add(Instance I)
        {
            I.SetId(lastId++);
            list.Add(I);
        }

        public bool MoveUp(int index)
        {
            if (index - 1 < 0 || index >= list.Count) return false;

            Instance temp = list[index];
            list[index] = list[index - 1];
            list[index - 1] = temp;

            return true;
        }

        public bool MoveDown(int index)
        {
            if (index < 0 || index + 1 >= list.Count) return false;

            Instance temp = list[index];
            list[index] = list[index + 1];
            list[index + 1] = temp;

            return true;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= list.Count) return;

            list.RemoveAt(index);
        }

        public void DeleteUsingDefinition(Definition Def)
        {
            int i = 0;
            for (int j = 0; j < list.Count; ++j)
            {
                if (list[j].GetDefinition() != Def)
                    list[i] = list[j];

                if (list[i].GetDefinition() != Def)
                    ++i;
            }

            if (i < list.Count)
            {
                list.RemoveRange(i, list.Count - i);
            }
        }

        public void Draw(Graphics G)
        {
            foreach (Instance I in list) I.Draw(G);
        }

        public bool Save(string FilePath)
        {
            filePath = FilePath;

            using (System.IO.StreamWriter FS = new System.IO.StreamWriter(FilePath))
            {
                FS.WriteLine(TypeToken);

                FS.WriteLine(foundation.Dictionary.GetFilePath());

                if (code == null || code.Length == 0)
                {
                    FS.WriteLine(0);
                }
                else
                {
                    FS.WriteLine(code.Length);
                    foreach (string line in code) FS.WriteLine(line);
                }

                FS.WriteLine("" + foundation.Plane.GridCellSize.Width);
                FS.WriteLine("" + foundation.Plane.GridCellSize.Height);
                FS.WriteLine("" + foundation.Plane.IsDrawGrid);
                FS.WriteLine("" + foundation.Plane.IsSnapGrid);

                FS.WriteLine("" + lastId);

                FS.WriteLine("" + list.Count);

                foreach (Instance I in list)
                {
                    I.Save(FS);
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

                FS.ReadLine();

                int codeLen;
                success = Int32.TryParse(FS.ReadLine(), out codeLen);
                if (!success) return success;
                if (codeLen == 0)
                {
                    code = null;
                }
                else
                {
                    code = new string[codeLen];
                    for (int i = 0; i < codeLen; ++i)
                    {
                        code[i] = FS.ReadLine();
                        if (i + 1 < codeLen) code[i] += "\r\n";
                    }
                }

                int width, height;
                success = Int32.TryParse(FS.ReadLine(), out width);
                if (!success) return success;
                success = Int32.TryParse(FS.ReadLine(), out height);
                if (!success) return success;
                foundation.Plane.GridCellSize = new Size(width, height);

                bool grid;
                success = Boolean.TryParse(FS.ReadLine(), out grid);
                if (!success) return success;
                foundation.Plane.IsDrawGrid = grid;
                success = Boolean.TryParse(FS.ReadLine(), out grid);
                if (!success) return success;
                foundation.Plane.IsSnapGrid = grid;

                success = Int32.TryParse(FS.ReadLine(), out lastId);
                if (!success) return success;

                int cnt;
                success = Int32.TryParse(FS.ReadLine(), out cnt);
                if (!success) return success;

                for (int i = 0; i < cnt; ++i)
                {
                    Instance I = new Instance(this);
                    success = I.Load(FS, foundation.Dictionary);
                    if (!success) return success;
                    list.Add(I);
                }
            }

            return success;
        }
    }
}
