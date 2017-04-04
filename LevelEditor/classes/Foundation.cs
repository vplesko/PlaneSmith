using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Foundation
    {
        Form1 form;

        Dictionary dictionary;
        Level level;
        Plane plane;

        Generator generator;

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

            dictionary.Add(definition);

            // This way the image file is unlocked after loading
            using (Image tmp = new Bitmap(ImageFilePath))
            {
                definition.SetImage(new Bitmap(tmp), ImageFilePath);
            }

            form.onDictionaryChanged(dictionary.Count - 1);
        }

        public void AddObjTemporasToLevel()
        {
            if (plane.ObjTemporas != null)
            {
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

        public void DeleteObject(int index)
        {
            if (index < 0 || index >= level.Count) return;

            level.Delete(index);

            form.onLevelChanged(-1);
        }

        public void DeleteObjectAt(Point Pnt)
        {
            for (int i = level.Count - 1; i >= 0; --i)
            {
                Object obj = level[i];
                if (obj == null) continue;

                if (obj.GetDefinition() == null) continue;

                Image img = obj.GetDefinition().Image;
                if (img == null) continue;

                if (Pnt.X >= obj.Position.X && 
                    Pnt.X < obj.Position.X + img.Size.Width &&
                    Pnt.Y >= obj.Position.Y && 
                    Pnt.Y < obj.Position.Y + img.Size.Height)
                {
                    DeleteObject(i);
                    return;
                }
            }
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

        public string ExtractDictionaryPathFromLevelFile(string FilePath)
        {
            using (System.IO.StreamReader FS = new System.IO.StreamReader(FilePath))
            {
                string type = FS.ReadLine();

                if (string.Equals(type, Level.TypeToken))
                {
                    return FS.ReadLine();
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
