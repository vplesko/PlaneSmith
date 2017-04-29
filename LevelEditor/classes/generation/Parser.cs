using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Parser
    {
        private Generator generator;

        private List<Statement> statements;

        private string codeOwner;

        public Parser(Generator Generator)
        {
            generator = Generator;
            statements = new List<Statement>();
        }

        public int Length
        {
            get { return statements.Count; }
        }

        public Statement this[int index]
        {
            get { return statements[index]; }
        }

        public string CodeOwner
        {
            get { return codeOwner; }
        }

        public void Parse(string Whole, string CodeOwner)
        {
            codeOwner = CodeOwner;

            statements.Clear();

            Stack<StmFech> fechStack = new Stack<StmFech>();

            int line = 1;
            int curr = 0;

            try
            {
                while (curr < Whole.Length)
                {
                    int indSegBeg = Whole.IndexOf(Code.SegmBeg, curr);
                    int indSegEnd = Whole.IndexOf(Code.SegmEnd, curr);

                    int indEol1 = Whole.IndexOf("\n", curr);
                    int indEol2 = Whole.IndexOf("\r\n", curr);

                    int min = indSegBeg;
                    if (min < 0 || (indSegEnd >= 0 && indSegEnd < min)) min = indSegEnd;
                    if (min < 0 || (indEol1 >= 0 && indEol1 < min)) min = indEol1;
                    if (min < 0 || (indEol2 >= 0 && indEol2 < min)) min = indEol2;

                    if (min < 0)
                    {
                        statements.Add(StatementFactory.CreateTerminal(statements.Count, Whole.Substring(curr)));
                        curr = Whole.Length;
                    }
                    else
                    {
                        if (curr < min)
                        {
                            statements.Add(StatementFactory.CreateTerminal(statements.Count, Whole.Substring(curr, min - curr)));
                            curr = min;
                        }

                        if (min == indSegBeg)
                        {
                            if (indSegEnd < 0) throw new ErrorCode("Unpaired statement start separator");
                            if (indSegBeg + 1 == indSegEnd) throw new ErrorCode("Empty statement");

                            string stmBody = Whole.Substring(indSegBeg + 1, indSegEnd - indSegBeg - 1);

                            Statement stm = StatementFactory.Create(statements.Count, stmBody);

                            if (stm is StmFech)
                            {
                                fechStack.Push(stm as StmFech);
                            }
                            else if (stm is StmEnd)
                            {
                                if (fechStack.Count == 0) throw new ErrorCode("No FECH statement to pair with");

                                StmFech fech = fechStack.Pop();
                                fech.End = stm.Index;
                                (stm as StmEnd).Start = fech.Index;
                            }

                            statements.Add(stm);

                            curr = indSegEnd + 1;
                            line += stmBody.Length - stmBody.Replace("\n", "").Length;
                        }
                        else if (min == indSegEnd)
                        {
                            throw new ErrorCode("Unpaired statement end separator");
                        }
                        else if (min == indEol1)
                        {
                            statements.Add(StatementFactory.CreateNewline(statements.Count));
                            curr += 1;
                            ++line;
                        }
                        else if (min == indEol2)
                        {
                            statements.Add(StatementFactory.CreateNewline(statements.Count));
                            curr += 2;
                            ++line;
                        }
                    }
                }
            }
            catch (ErrorCode err)
            {
                err.CodeOwner = CodeOwner;
                err.Line = line;
                throw err;
            }

            if (fechStack.Count > 0) throw new ErrorCode(codeOwner, -1, "Unclosed FECH statement(s)");
        }

        public void Parse(Code Code, string CodeOwner)
        {
            Parse(String.Join("", Code.LinesAsArray), CodeOwner);
        }

        public void SetSingleStatement(Statement Statement, string CodeOwner)
        {
            codeOwner = CodeOwner;

            statements.Clear();

            statements.Add(Statement);
        }
    }
}
