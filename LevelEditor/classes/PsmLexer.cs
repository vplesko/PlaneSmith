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
            // TODO it's assumed segment separators are single chars

            // Back up to the line start
            int line = scintilla.LineFromPosition(startPos);
            startPos = scintilla.Lines[line].Position;

            int length = 0;
            State state = State.DEFAULT;

            if (line > 0)
            {
                int prevLine = line - 1;
                int startPosPrevLine = scintilla.Lines[prevLine].Position;
                int endPosPrevLine = startPosPrevLine + scintilla.Lines[prevLine].Length - 1;
                
                if (scintilla.GetStyleAt(endPosPrevLine) == StyleSegment &&
                    (char)scintilla.GetCharAt(endPosPrevLine) != Code.SegmEnd[0])
                {
                    state = State.SEGMENT;
                }
            }

            // Start styling
            scintilla.StartStyling(startPos);

            while (startPos < endPos)
            {
                char c = (char)scintilla.GetCharAt(startPos);

                bool goNext = true;

                switch (state)
                {
                    case State.DEFAULT:
                        if (c == Code.SegmBeg[0])
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
                        if (c == Code.SegmEnd[0])
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

            if (length > 0 && state == State.SEGMENT)
            {
                scintilla.SetStyling(length, StyleSegment);
            }
        }

        public PsmLexer()
        {
            keywords = new HashSet<string>(Regex.Split(Code.Keywords + ' ' + Code.Keywords.ToLower() ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l)));
            freqAtrs = new HashSet<string>(Regex.Split(Code.FreqAtrs + ' ' + Code.FreqAtrs.ToLower() ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l)));
        }
    }
}
