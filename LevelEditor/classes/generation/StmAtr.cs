using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LevelEditor
{
    class StmAtr : Statement
    {
        private string context;
        private string attribute;

        public StmAtr(int Index, string Body)
            : base(Index, Body)
        {
            string cleaned = Regex.Replace(Body, @"\s+", "");

            int dot = cleaned.IndexOf('.');

            if (dot >= 0)
            {
                context = cleaned.Substring(0, dot).ToUpper();
                attribute = cleaned.Substring(dot + 1);
            }
            else
            {
                context = null;
                attribute = cleaned;
            }

            if (attribute.Length == 0) throw new ErrorCode("Attribute name missing");
            if (context != null && context.Length == 0) throw new ErrorCode("No context specified for attribute " + attribute);
        }

        public string Owner
        {
            get { return context; }
        }

        public string Attribute
        {
            get { return attribute; }
        }
    }
}
