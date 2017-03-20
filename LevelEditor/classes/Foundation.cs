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

        public void AddDefinition(string ImageFilePath)
        {
            Definition definition = new Definition(dictionary, "New Definition");

            dictionary.Add(definition);

            // This way the image file is unlocked after loading
            using (Image tmp = new Bitmap(ImageFilePath))
            {
                definition.SetImage(new Bitmap(tmp), ImageFilePath);
            }
        }

        public void AddInstAtCursorToLevel()
        {
            if (plane.InstAtCursor != null)
            {
                level.Add(plane.InstAtCursor);
                plane.RemakeInstAtCursor();
                form.onLevelChanged();
            }
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

            form.onLevelChanged();
        }
    }
}
