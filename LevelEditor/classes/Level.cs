using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LevelEditor
{
    class Level : ICodeContainer
    {
        public static string TypeToken = "Level file";

        Foundation foundation;

        int lastId = 0;
        List<Object> list = new List<Object>();

        Code code;

        bool changed = false;

        string filePath = null;

        public Level(Foundation Foundation)
        {
            foundation = Foundation;

            code = new Code(this);
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

        public string FilePath
        {
            get { return filePath; }
        }

        public bool Changed
        {
            get { return changed; }
            set { changed = value; }
        }

        public Code GetCode()
        {
            return code;
        }

        public void OnCodeChanged(Code Code)
        {
            changed = true;
        }

        public void Add(Object O)
        {
            O.SetId(lastId++);
            list.Add(O);

            changed = true;
        }

        public bool MoveUp(int index)
        {
            if (index - 1 < 0 || index >= list.Count) return false;

            Object temp = list[index];
            list[index] = list[index - 1];
            list[index - 1] = temp;

            changed = true;

            return true;
        }

        public bool MoveDown(int index)
        {
            if (index < 0 || index + 1 >= list.Count) return false;

            Object temp = list[index];
            list[index] = list[index + 1];
            list[index + 1] = temp;

            changed = true;

            return true;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= list.Count) return;

            list.RemoveAt(index);

            changed = true;
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

            changed = true;
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

                string folder = Path.GetDirectoryName(FilePath);
                if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    folder += Path.DirectorySeparatorChar;
                Uri from = new Uri(folder);

                Uri to = new Uri(foundation.Dictionary.FilePath);

                FS.WriteLine(Uri.UnescapeDataString(from.MakeRelativeUri(to).ToString().Replace('/', Path.DirectorySeparatorChar)));

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
                throw new ErrorLoadLvl("File not found", FilePath);

            using (System.IO.StreamReader FS = new System.IO.StreamReader(FilePath))
            {
                list.Clear();

                string type = FS.ReadLine();
                if (!String.Equals(type, TypeToken))
                    throw new ErrorLoadLvl("Invalid file type", FilePath);

                FS.ReadLine();

                if (!code.Load(FS))
                    throw new ErrorLoadLvl("Could not parse level code", FilePath);

                int width, height;
                if (!Int32.TryParse(FS.ReadLine(), out width))
                    throw new ErrorLoadLvl("Grid cell width invalid", FilePath);
                if (!Int32.TryParse(FS.ReadLine(), out height))
                    throw new ErrorLoadLvl("Grid cell height invalid", FilePath);
                foundation.Plane.GridCellSize = new Size(width, height);

                bool grid;
                if (!Boolean.TryParse(FS.ReadLine(), out grid))
                    throw new ErrorLoadLvl("Show grid bool invalid", FilePath);
                foundation.Plane.IsDrawGrid = grid;
                if (!Boolean.TryParse(FS.ReadLine(), out grid))
                    throw new ErrorLoadLvl("Snap to grid bool invalid", FilePath);
                foundation.Plane.IsSnapGrid = grid;

                if (!Int32.TryParse(FS.ReadLine(), out lastId))
                    throw new ErrorLoadLvl("LastId data invalid", FilePath);

                int cnt;
                if (!Int32.TryParse(FS.ReadLine(), out cnt))
                    throw new ErrorLoadLvl("Count data invalid", FilePath);

                for (int i = 0; i < cnt; ++i)
                {
                    Object I = new Object(this);
                    if (!I.Load(FS))
                        throw new ErrorLoadLvl("Could not parse object " + i, FilePath);
                    list.Add(I);
                }
            }

            changed = false;
        }
    }
}
