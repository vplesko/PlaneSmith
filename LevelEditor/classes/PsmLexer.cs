using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ScintillaNET;

namespace LevelEditor
{
    class PsmLexer
    {
        public static int StyleDefault = 0;
        public static int StyleKeyword = 1;
        public static int StyleFreqAtr = 2;
        public static int StyleSegment = 3;

        private enum State
        {
            DEFAULT,
            SEGMENT
        }

        private HashSet<string> keywords, freqAtrs;

        public void Style(Scintilla scintilla, int startPos, int endPos)
        {
            // @TODO@ it's assumed segment separators are single chars
            // @TODO@ nested segments?
            // @TODO@ multi-line segments?

            // Back up to the line start
            int line = scintilla.LineFromPosition(startPos);
            startPos = scintilla.Lines[line].Position;

            var length = 0;
            var state = State.DEFAULT;

            // Start styling
            scintilla.StartStyling(startPos);

            while (startPos < endPos)
            {
                char c = (char)scintilla.GetCharAt(startPos);

                bool goNext = true;

                switch (state)
                {
                    case State.DEFAULT:
                        if (c == Generator.SegmBeg[0])
                        {
                            scintilla.SetStyling(1, StyleSegment);
                            state = State.SEGMENT;
                        }
                        else
                        {
                            scintilla.SetStyling(1, StyleDefault);
                        }
                        break;

                    case State.SEGMENT:
                        if (c == Generator.SegmEnd[0])
                        {
                            ++length;
                            scintilla.SetStyling(length, StyleSegment);
                            length = 0;
                            state = State.DEFAULT;
                        }
                        else
                        {
                            ++length;
                        }
                        break;
                }

                if (goNext) ++startPos;
            }
        }

        public PsmLexer()
        {
            keywords = new HashSet<string>(Regex.Split(Generator.Keywords + ' ' + Generator.Keywords.ToLower() ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l)));
            freqAtrs = new HashSet<string>(Regex.Split(Generator.FreqAtrs + ' ' + Generator.FreqAtrs.ToLower() ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l)));
        }
    }
}
