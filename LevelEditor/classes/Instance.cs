using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LevelEditor
{
    class Instance
    {
        Form1 form;
        Definition def;
        int x, y;

        public Instance(Definition Def, Form1 Form)
        {
            form = Form;
            def = Def;
        }

        public Definition GetDefinition()
        {
            return def;
        }

        public void setLoc(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public int X
        {
            get { return x; }
            set { x = value; form.renewContentBox(); form.redrawEdit(); }
        }

        public int Y
        {
            get { return y; }
            set { y = value; form.renewContentBox(); form.redrawEdit(); }
        }

        public void Draw(Graphics G)
        {
            G.FillRectangle(new SolidBrush(def.Color), X, Y, def.Width, def.Height);
        }

        public void DrawTransp(Graphics G)
        {
            G.FillRectangle(new SolidBrush(Color.FromArgb(200, def.Color)), X, Y, def.Width, def.Height);
        }

        public override string ToString()
        {
            return def.Name + " (" + X + ", " + Y + ")";
        }
    }
}
