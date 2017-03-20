﻿using System;
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

        public void Add(Instance I)
        {
            I.SetId(lastId++);
            list.Add(I);
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

            if (success) foundation.Form.onLevelChanged();

            return success;
        }
    }
}
