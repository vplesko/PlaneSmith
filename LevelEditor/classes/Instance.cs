using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace LevelEditor
{
    class Instance
    {
        Form1 form;
        Definition def;
        Point loc;

        public Instance(Definition Def, Form1 Form)
        {
            form = Form;
            def = Def;
            loc = new Point();
        }

        public Definition GetDefinition()
        {
            return def;
        }

        public void setLocation(Point Loc)
        {
            loc.X = Loc.X;
            loc.Y = Loc.Y;
        }

        public void setLocation(int X, int Y)
        {
            loc.X = X;
            loc.Y = Y;
        }

        [Description("The coordinates of this instance on the plane."),
        Category("General")]
        public Point Location
        {
            get { return loc; }
            set { setLocation(value); form.renewContentBox(); form.redrawEdit(); }
        }

        public void Draw(Graphics G)
        {
            if (def.Image != null) G.DrawImage(def.Image, Location);
        }

        public override string ToString()
        {
            return def.Name + " (" + loc.X + ", " + loc.Y + ")";
        }
    }
}
