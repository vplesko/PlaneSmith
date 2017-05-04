using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Foundation
    {
        private Form1 form;

        private Dictionary dictionary;
        private Level level;
        private Plane plane;

        private Generator generator;

        public Foundation(Form1 Form)
        {
            form = Form;

            dictionary = new Dictionary(this);
            level = new Level(this);
            plane = new Plane(this);

            generator = new Generator(this);
        }

        public Form1 Form
        {
            get { return form; }
        }

        public Dictionary Dictionary
        {
            get { return dictionary; }
        }

        public Level Level
        {
            get { return level; }
        }

        public Plane Plane
        {
            get { return plane; }
        }

        public Generator Generator
        {
            get { return generator; }
        }

        public void AddDefinition(string Name, string ImageFilePath)
        {
            Definition definition = new Definition(dictionary, Name);
            definition.SetImage(ImageFilePath);
            dictionary.Add(definition);

            form.onDictionaryChanged(dictionary.Count - 1);
        }

        public void MoveObjTemporas(int X, int Y)
        {
            plane.MoveObjTemporas(plane.InverseTransform(X, Y));
        }

        public void AddObjTemporasToLevel()
        {
            if (plane.ObjTemporas != null)
            {
                //plane.ObjTemporas.Position = plane.InverseTransform(plane.ObjTemporas.Position);
                level.Add(plane.ObjTemporas);
                plane.RemakeObjTemporas();
                form.onLevelChanged(-1);
            }
        }

        public void MakeObjTemporas(Definition Definition)
        {
            plane.MakeObjTemporas(Definition);
            form.onPlaneChanged(false);
        }

        public void ForgetObjTemporas()
        {
            plane.ForgetObjTemporas();
            form.onPlaneChanged(true);
        }

        public void MoveObjUp(int index)
        {
            if (level.MoveUp(index))
                form.onLevelChanged(index - 1);
        }

        public void MoveObjDown(int index)
        {
            if (level.MoveDown(index))
                form.onLevelChanged(index + 1);
        }

        public void MoveDefUp(int index)
        {
            if (dictionary.MoveUp(index))
                form.onDictionaryChanged(index - 1);
        }

        public void MoveDefDown(int index)
        {
            if (dictionary.MoveDown(index))
                form.onDictionaryChanged(index + 1);
        }

        public bool ObjContains(Object Obj, Point Pnt)
        {
            return Obj.Contains(plane.InverseTransform(Pnt));
        }

        public bool ObjContains(int ObjIndex, Point Pnt)
        {
            return level[ObjIndex].Contains(plane.InverseTransform(Pnt));
        }

        public void DeleteDefinition(int index)
        {
            if (index < 0 || index >= dictionary.Count) return;

            level.DeleteUsingDefinition(dictionary[index]);

            if (plane.ObjTemporas.GetDefinition() == dictionary[index])
                ForgetObjTemporas();

            dictionary.Delete(index);

            form.onDictAndLevelChanged();
            form.onPlaneChanged(true);
        }

        public void DeleteObject(int index)
        {
            if (index < 0 || index >= level.Count) return;

            level.Delete(index);

            form.onLevelChanged(-1);
        }

        public void DeleteObjectAt(Point Pnt)
        {
            Point loc = plane.InverseTransform(Pnt);

            for (int i = level.Count - 1; i >= 0; --i)
            {
                Object obj = level[i];

                if (obj != null && obj.Contains(loc))
                {
                    DeleteObject(i);
                    return;
                }
            }
        }

        public List<int> GetIndexesOfObjsAt(Point Pnt)
        {
            Point loc = plane.InverseTransform(Pnt);
            List<int> list = new List<int>();

            for (int i = level.Count - 1; i >= 0; --i)
            {
                Object obj = level[i];

                if (obj != null && obj.Contains(loc))
                    list.Add(i);
            }

            return list;
        }

        public string ExtractDictionaryPathFromLevelFile(string FilePath)
        {
            if (!File.Exists(FilePath))
                throw new ErrorLoadLvl("File not found", FilePath);

            using (System.IO.StreamReader FS = new System.IO.StreamReader(FilePath))
            {
                string type = FS.ReadLine();

                if (string.Equals(type, Level.TypeToken))
                {
                    return Path.Combine(Path.GetDirectoryName(FilePath), FS.ReadLine());
                }
                else
                {
                    return null;
                }
            }
        }

        public void Reset()
        {
            dictionary = new Dictionary(this);
            level = new Level(this);
            plane = new Plane(this);

            form.onDictAndLevelChanged();
            form.onPlaneChanged(true);
        }

        public void ResetLevel()
        {
            level = new Level(this);
            plane = new Plane(this);

            form.onLevelChanged(-1);
        }
    }
}
