using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor.classes
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

            dictionary = new Dictionary(Form);
            level = new Level(Form);

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
    }
}
