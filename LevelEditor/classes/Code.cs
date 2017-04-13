using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LevelEditor
{
    class Code
    {
        List<string> lines = new List<string>();

        public List<string> Lines
        {
            get { return lines; }
        }

        public string[] LinesAsArray
        {
            get { return lines.ToArray(); }
        }

        public void CopyFrom(string[] Lines)
        {
            if (Lines == null) return;

            lines = new List<string>(Lines.Length);

            for (int i = 0; i < Lines.Length - 1; ++i)
            {
                lines.Add(Lines[i]);
                lines[i] += "\r\n";
            }
        }

        public void CopySplitLines(string Text)
        {
            lines = new List<string>();

            string[] array = Regex.Split(Text, "\r\n|\n");

            for (int i = 0; i < array.Length; ++i)
            {
                lines.Add(array[i]);
                if (i + 1 < array.Length) lines[i] += "\r\n";
            }
        }

        public void CopyFrom(Code C)
        {
            if (C == null || C.LinesAsArray == null)
            {
                lines = null;
                return;
            }

            lines = new List<string>(C.Lines.Count);
            foreach (string l in C.Lines)
                lines.Add(l);
        }

        public void Save(System.IO.StreamWriter FS)
        {
            if (lines == null || lines.Count == 0)
            {
                FS.WriteLine(0);
            }
            else
            {
                FS.WriteLine(lines.Count);
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
                lines = new List<string>(codeLen);
                for (int i = 0; i < codeLen; ++i)
                {
                    lines.Add(FS.ReadLine());
                    if (i + 1 < codeLen) lines[i] += "\r\n";
                }
            }

            return true;
        }
    }
}
