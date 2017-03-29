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

        string[] code;

        public Definition(Dictionary Dictionary)
        {
            dictionary = Dictionary;
            name = "";
        }

        public Definition(Dictionary Dict, string Name)
        {
            dictionary = Dict;
            name = Name;
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

        [Description("This image presents the appearance of instances of this definition."),
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

        public void CopyAsCode(string[] Code)
        {
            code = new string[Code.Length];
            Code.CopyTo(code, 0);
        }

        public void RecopyCode()
        {
            if (code == null) return;

            string[] temp = code;
            CopyAsCode(temp);
        }

        public string[] GetCode()
        {
            return code;
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

            if (code == null || code.Length == 0)
            {
                FS.WriteLine(0);
            }
            else
            {
                FS.WriteLine(code.Length);
                foreach (string line in code) FS.WriteLine(line);
            }
        }

        public bool Load(System.IO.StreamReader FS)
        {
            bool success = Int32.TryParse(FS.ReadLine(), out id);
            if (!success) return success;

            name = FS.ReadLine();

            imagePath = FS.ReadLine();

            using (Image tmp = new Bitmap(imagePath))
            {
                image = new Bitmap(tmp);
            }

            int codeLen;
            success = Int32.TryParse(FS.ReadLine(), out codeLen);
            if (!success) return success;
            if (codeLen == 0)
            {
                code = null;
            }
            else
            {
                code = new string[codeLen];
                for (int i = 0; i < codeLen; ++i)
                {
                    code[i] = FS.ReadLine();
                    if (i + 1 < codeLen) code[i] += "\r\n";
                }
            }

            return success;
        }
    }
}
