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
        List<Object> list = new List<Object>();

        Code code;

        string filePath = null;

        public Level(Foundation Foundation)
        {
            foundation = Foundation;

            code = new Code();
        }

        public Foundation Foundation
        {
            get { return foundation; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public Object this[int index]
        {
            get { return list[index]; }
        }

        public string GetFilePath()
        {
            return filePath;
        }

        public Code GetCode()
        {
            return code;
        }

        public void Add(Object O)
        {
            O.SetId(lastId++);
            list.Add(O);
        }

        public bool MoveUp(int index)
        {
            if (index - 1 < 0 || index >= list.Count) return false;

            Object temp = list[index];
            list[index] = list[index - 1];
            list[index - 1] = temp;

            return true;
        }

        public bool MoveDown(int index)
        {
            if (index < 0 || index + 1 >= list.Count) return false;

            Object temp = list[index];
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
            foreach (Object O in list) O.Draw(G);
        }

        public bool Save(string FilePath)
        {
            filePath = FilePath;

            using (System.IO.StreamWriter FS = new System.IO.StreamWriter(FilePath))
            {
                FS.WriteLine(TypeToken);

                FS.WriteLine(foundation.Dictionary.GetFilePath());

                code.Save(FS);

                FS.WriteLine("" + foundation.Plane.GridCellSize.Width);
                FS.WriteLine("" + foundation.Plane.GridCellSize.Height);
                FS.WriteLine("" + foundation.Plane.IsDrawGrid);
                FS.WriteLine("" + foundation.Plane.IsSnapGrid);

                FS.WriteLine("" + lastId);

                FS.WriteLine("" + list.Count);

                foreach (Object I in list)
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

            using (System.IO.StreamReader FS = new System.IO.StreamReader(FilePath))
            {
                list.Clear();

                string type = FS.ReadLine();
                if (!String.Equals(type, TypeToken)) return false;

                FS.ReadLine();

                if (!code.Load(FS)) return false;

                int width, height;
                if (!Int32.TryParse(FS.ReadLine(), out width)) return false;
                if (!Int32.TryParse(FS.ReadLine(), out height)) return false;
                foundation.Plane.GridCellSize = new Size(width, height);

                bool grid;
                if (!Boolean.TryParse(FS.ReadLine(), out grid)) return false;
                foundation.Plane.IsDrawGrid = grid;
                if (!Boolean.TryParse(FS.ReadLine(), out grid)) return false;
                foundation.Plane.IsSnapGrid = grid;

                if (!Int32.TryParse(FS.ReadLine(), out lastId)) return false;

                int cnt;
                if (!Int32.TryParse(FS.ReadLine(), out cnt)) return false;

                for (int i = 0; i < cnt; ++i)
                {
                    Object I = new Object(this);
                    if (!I.Load(FS)) return false;
                    list.Add(I);
                }
            }

            return true;
        }
    }
}
