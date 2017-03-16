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
        Form1 form;

        string name;
        Image img;
        string imgPath;

        public Definition(string Name, Form1 Form)
        {
            form = Form;

            name = Name;
        }

        [Description("The name by which this definition will be referenced in your code."), 
        Category("General")]
        public string Name
        {
            get { return name; }
            set { name = value; form.RenewBoxes(); }
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

        public override string ToString()
        {
            return Name;
        }
    }
}
