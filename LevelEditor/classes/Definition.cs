using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LevelEditor
{
    class Definition
    {
        Form1 form;

        string name;
        Color col;
        int width, height;

        public Definition(string Name, Form1 Form)
        {
            form = Form;

            name = Name;
            col = Color.White;
            width = height = 32;
        }

        public string Name
        {
            get { return name; }
            set { name = value; form.renewBoxes(); }
        }

        public Color Color
        {
            get { return col; }
            set { col = value; form.redrawEdit(); }
        }

        public int Width
        {
            get { return width; }
            set { width = value; form.redrawEdit(); }
        }

        public int Height
        {
            get { return height; }
            set { height = value; form.redrawEdit(); }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
