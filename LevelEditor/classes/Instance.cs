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
        int id;

        Level lvl;

        Definition def;
        Point loc;

        public Instance(Level Lvl)
        {
            lvl = Lvl;
            def = null;
            loc = new Point();
        }

        public Instance(Level Lvl, Definition Def)
        {
            lvl = Lvl;
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
            set
            {
                setLocation(value);
                // we get here by user changing an instance's coords
                lvl.getForm().RenewLevelBox();
                lvl.getForm().RedrawPlane(true);
            }
        }

        public void setId(int Id)
        {
            id = Id;
        }

        [Description("This is the ID by which this application manages this definition."),
        Category("General")]
        public int Id
        {
            get { return id; }
        }

        public void Draw(Graphics G)
        {
            if (def != null && def.Image != null) G.DrawImage(def.Image, Location);
        }

        public override string ToString()
        {
            return "[" + id + "] " + 
                (def != null ? def.Name : "??") + 
                " (" + loc.X + ", " + loc.Y + ")";
        }

        public void save(System.IO.StreamWriter FS)
        {
            FS.WriteLine("" + id);
            FS.WriteLine(def.Id);
            FS.WriteLine(loc.X);
            FS.WriteLine(loc.Y);
        }

        public bool load(System.IO.StreamReader FS, Dictionary Dict)
        {
            bool success = Int32.TryParse(FS.ReadLine(), out id);
            if (!success) return success;

            int defId;
            success = Int32.TryParse(FS.ReadLine(), out defId);
            if (!success) return success;
            def = Dict.Get(defId);
            if (def == null) return false;

            int x;
            success = Int32.TryParse(FS.ReadLine(), out x);
            if (!success) return success;
            loc.X = x;

            int y;
            success = Int32.TryParse(FS.ReadLine(), out y);
            if (!success) return success;
            loc.Y = y;

            return success;
        }
    }
}
