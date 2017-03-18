using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace LevelEditor
{
    class Definition
    {
        int id;

        Dictionary dict;

        string name;
        Image img;
        string imgPath;

        public Definition(Dictionary Dict)
        {
            dict = Dict;
            name = "";
        }

        public Definition(Dictionary Dict, string Name)
        {
            dict = Dict;
            name = Name;
        }

        [Description("The name by which this definition will be referenced in your code."), 
        Category("General")]
        public string Name
        {
            get { return name; }
            set { name = value; dict.getForm().RenewBoxes(); }
        }

        [Description("This image presents the appearance of instances of this definition."),
        Category("General")]
        public Image Image
        {
            get { return img; }
        }

        public void setImage(Image I, string Path)
        {
            img = I;
            imgPath = Path;
        }

        [Description("This is the path to the file from which the image was loaded."),
        Category("General")]
        public string ImagePath
        {
            get { return imgPath; }
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

        public override string ToString()
        {
            return Name;
        }

        public void save(System.IO.StreamWriter FS)
        {
            FS.WriteLine("" + id);
            FS.WriteLine(name);
            FS.WriteLine(imgPath);
        }

        public bool load(System.IO.StreamReader FS)
        {
            bool success = Int32.TryParse(FS.ReadLine(), out id);
            if (!success) return success;

            name = FS.ReadLine();
            imgPath = FS.ReadLine();
            img = new Bitmap(imgPath);

            return success;
        }
    }
}
