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

        public Foundation(Form1 Form)
        {
            form = Form;

            dictionary = new Dictionary(this);
            level = new Level(this);

            plane = new Plane(this);
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

        public void AddInstAtCursorToLevel()
        {
            if (plane.InstAtCursor != null)
            {
                level.Add(plane.InstAtCursor);
                plane.RemakeInstAtCursor();
                form.onLevelChanged(-1);
            }
        }

        public void MoveInstUp(int index)
        {
            if (level.MoveUp(index))
                form.onLevelChanged(index - 1);
        }

        public void MoveInstDown(int index)
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

        public void DeleteInstance(int index)
        {
            if (index < 0 || index >= level.Count) return;

            level.Delete(index);

            form.onLevelChanged(-1);
        }

        public void DeleteInstanceAt(Point Pnt)
        {
            for (int i = level.Count - 1; i >= 0; --i)
            {
                Instance inst = level[i];
                if (inst == null) continue;

                if (inst.GetDefinition() == null) continue;

                Image img = inst.GetDefinition().Image;
                if (img == null) continue;

                if (Pnt.X >= inst.Location.X && 
                    Pnt.X < inst.Location.X + img.Size.Width &&
                    Pnt.Y >= inst.Location.Y && 
                    Pnt.Y < inst.Location.Y + img.Size.Height)
                {
                    DeleteInstance(i);
                    return;
                }
            }
        }

        public void DeleteDefinition(int index)
        {
            if (index < 0 || index >= dictionary.Count) return;

            level.DeleteUsingDefinition(dictionary[index]);

            if (plane.InstAtCursor.GetDefinition() == dictionary[index])
                plane.ForgetInstAtCursor();

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
