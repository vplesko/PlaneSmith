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

        Dictionary dictionary;

        string name;
        Image image;
        string imagePath;

        Code code, codeObjAuto;

        public Definition(Dictionary Dictionary)
        {
            dictionary = Dictionary;
            name = "";

            code = new Code();
            codeObjAuto = new Code();
        }

        public Definition(Dictionary Dict, string Name)
        {
            dictionary = Dict;
            name = Name;

            code = new Code();
            codeObjAuto = new Code();
        }

        [Description("The name by which this definition will be referenced in your code."), 
        Category("General")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                dictionary.Foundation.Form.onDictAndLevelChanged();
            }
        }

        [Description("This image presents the appearance of objects of this definition."),
        Category("General")]
        public Image Image
        {
            get { return image; }
        }

        public void SetImage(Image I, string Path)
        {
            image = I;
            imagePath = Path;
        }

        [Description("This is the path to the file from which the image was loaded."),
        Category("General")]
        public string ImagePath
        {
            get { return imagePath; }
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

        public Code GetCode()
        {
            return code;
        }

        public Code GetCodeObjAuto()
        {
            return codeObjAuto;
        }

        public override string ToString()
        {
            return Name;
        }

        public void Save(System.IO.StreamWriter FS)
        {
            FS.WriteLine("" + id);
            FS.WriteLine(name);
            FS.WriteLine(imagePath);

            code.Save(FS);
            codeObjAuto.Save(FS);
        }

        public bool Load(System.IO.StreamReader FS)
        {
            if (!Int32.TryParse(FS.ReadLine(), out id)) return false;

            name = FS.ReadLine();

            imagePath = FS.ReadLine();

            using (Image tmp = new Bitmap(imagePath))
            {
                image = new Bitmap(tmp);
            }

            if (!code.Load(FS)) return false;

            if (!codeObjAuto.Load(FS)) return false;

            return true;
        }
    }
}
