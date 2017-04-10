using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Code
    {
        string[] lines = null;

        public string[] Lines
        {
            get { return lines; }
        }

        public void CopyFrom(string[] Lines)
        {
            if (Lines == null) return;

            lines = new string[Lines.Length];
            Lines.CopyTo(lines, 0);

            for (int i = 0; i < lines.Length - 1; ++i)
                lines[i] += "\r\n";
        }

        public void CopyFrom(Code C)
        {
            if (C == null || C.Lines == null)
            {
                lines = null;
                return;
            }

            lines = new string[C.Lines.Length];
            for (int i = 0; i < lines.Length; ++i)
                lines[i] = C.Lines[i];
        }

        public void Save(System.IO.StreamWriter FS)
        {
            if (lines == null || lines.Length == 0)
            {
                FS.WriteLine(0);
            }
            else
            {
                FS.WriteLine(lines.Length);
                foreach (string line in lines) FS.Write(line);
                FS.WriteLine();
            }
        }

        public bool Load(System.IO.StreamReader FS)
        {
            int codeLen;
            if (!Int32.TryParse(FS.ReadLine(), out codeLen)) return false;

            if (codeLen == 0)
            {
                lines = null;
            }
            else
            {
                lines = new string[codeLen];
                for (int i = 0; i < codeLen; ++i)
                {
                    lines[i] = FS.ReadLine();
                    if (i + 1 < codeLen) lines[i] += "\r\n";
                }
            }

            return true;
        }
    }
}
