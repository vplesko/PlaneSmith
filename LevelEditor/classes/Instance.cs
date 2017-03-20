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

        Level level;

        Definition definition;
        Point location;

        public Instance(Level Lvl)
        {
            level = Lvl;
            definition = null;
            location = new Point();
        }

        public Instance(Level Lvl, Definition Def)
        {
            level = Lvl;
            definition = Def;
            location = new Point();
        }

        public Definition GetDefinition()
        {
            return definition;
        }

        public void SetLocation(Point Loc)
        {
            location.X = Loc.X;
            location.Y = Loc.Y;
        }

        [Description("The coordinates of this instance on the plane."),
        Category("General")]
        public Point Location
        {
            get { return location; }
            set
            {
                SetLocation(value);
                level.Foundation.Form.onInstanceLocationChanged(this);
            }
        }

        public void SetId(int Id)
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
            if (definition != null && definition.Image != null) G.DrawImage(definition.Image, Location);
        }

        public override string ToString()
        {
            return "[" + id + "] " + 
                (definition != null ? definition.Name : "??") + 
                " (" + location.X + ", " + location.Y + ")";
        }

        public void Save(System.IO.StreamWriter FS)
        {
            FS.WriteLine("" + id);
            FS.WriteLine(definition.Id);
            FS.WriteLine(location.X);
            FS.WriteLine(location.Y);
        }

        public bool Load(System.IO.StreamReader FS, Dictionary Dict)
        {
            bool success = Int32.TryParse(FS.ReadLine(), out id);
            if (!success) return success;

            int defId;
            success = Int32.TryParse(FS.ReadLine(), out defId);
            if (!success) return success;
            definition = Dict.Get(defId);
            if (definition == null) return false;

            int x;
            success = Int32.TryParse(FS.ReadLine(), out x);
            if (!success) return success;
            location.X = x;

            int y;
            success = Int32.TryParse(FS.ReadLine(), out y);
            if (!success) return success;
            location.Y = y;

            return success;
        }
    }
}
