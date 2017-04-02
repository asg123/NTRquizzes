using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsgQuizzes
{
    /// <summary>
    /// HINT: Implement this methods to make all tests in QuizzesTest.cs pass
    /// </summary>
    public class Quizzes
    {
        public string ReverseString(string str)
        {
            char[] c = str.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

        public int[] GetSatisfyingNumbers(int limit, Func<int, bool> filter)
        {
            List<int> i = new List<int>();
            for (int j = 1; j <= limit; j++)
            {
                if (filter.Invoke(j))
                {
                    i.Add(j);
                }
            }
            return i.ToArray();
        }

        public int[] GetOddNumbers(int n)
        {
            // HINT: This method must be implemented with a call this.GetSatisfyingNumbers
            return GetSatisfyingNumbers(n, i => i % 2 != 0);
        }

        public int GetSecondGreatestNumber(int[] arr)
        {
            Array.Sort(arr);
            int len = arr.Length;
            return arr[len - 2];
        }

        public string FormatHex(byte r, byte g, byte b)
        {
            int red = r;
            int green = g;
            int blue = b;

            string theHexColor = red.ToString("X2") + green.ToString("X2") + blue.ToString("X2");
            return theHexColor;
        }

        public string[] OrderByAvgScoresDescending(IEnumerable<Exam> exams)
        {
            var student = exams.GroupBy(s => s.Student).Select(g => new
            {
                Average = g.Average(a => a.Score),
                Name = g.Key
            })
            .OrderByDescending(d => d.Average)
            .Select(s => s.Name).ToArray();
            return student;
        }

        public Exam GetExamFromString(string examStr)
        {
            Exam exam = JsonConvert.DeserializeObject<Exam>(examStr);
            return exam;
        }

        public string GenerateBoard(string strInput)
        {
            try
            {
                char[] inputChars = strInput.ToCharArray();
                string output = Environment.NewLine;
                int count = 1;
                foreach (var c in inputChars)
                {
                    if (c.Equals('x') || c.Equals('o') || c.Equals(' '))
                    {
                        if (count % 3 == 0)
                        {
                            output += " " + Char.ToUpper(c) + " " + Environment.NewLine;
                            output += "-----------" + Environment.NewLine;
                        }
                        else
                        {
                            output += " " + Char.ToUpper(c) + " " + "|";
                        }

                        count++;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                output = output.Remove(output.TrimEnd().LastIndexOf(Environment.NewLine));
                output += Environment.NewLine;
                return output;
            }
            catch (Exception e)
            {
                throw new ArgumentException();
            }

        }

        public string ParseBoard(string strInput)
        {
            int count = strInput.Count(f => f == '|');
            if (count != 6)
            {
                throw new ArgumentException();
            }
            strInput = strInput.Replace("/n", "");
            strInput = strInput.Replace("/r", "");
            strInput = strInput.Replace(Environment.NewLine, "");
            strInput = strInput.Replace("|", "");
            strInput = strInput.Replace("-", "");
            strInput = strInput.Replace("   ", " ");
            strInput = strInput.Replace(" X ", "x");
            strInput = strInput.Replace(" O ", "o");

            return strInput;
        }

        public int PostFixCalc(string s)
        {
            Stack<int> eval = new Stack<int>();

            try
            {
                s = ReplaceUnwantedStrings(s);
                string[] ans = s.Split(' ');
                for (int x = 0; x < ans.Length; x++)
                {
                    if ("*+%/-".Contains(ans[x]))
                    {
                        int temp1;
                        int temp2;

                        switch (ans[x])
                        {
                            case ("*"):
                                eval.Push(eval.Pop() * eval.Pop());
                                break;
                            case "-":
                                temp1 = eval.Pop();
                                temp2 = eval.Pop();
                                eval.Push(temp2 - temp1);
                                break;
                            case "%":
                                temp1 = eval.Pop();
                                temp2 = eval.Pop();
                                eval.Push(temp2 % temp1);
                                break;
                            case "+":
                                eval.Push(eval.Pop() + eval.Pop());
                                break;
                            case "/":
                                temp1 = eval.Pop();
                                temp2 = eval.Pop();
                                eval.Push(temp2 / temp1);
                                break;
                        }

                    }
                    else
                        eval.Push(Convert.ToInt32(ans[x]));
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException();
            }

            return eval.Pop();
        }

        private string ReplaceUnwantedStrings(string s)
        {
            s = s.Replace("ja", "");
            s = s.Replace("r", " ");
            return s;
        }
    }

    public class Exam
    {
        public string Student { get; set; }
        public decimal Score { get; set; }

        public Exam(string student, decimal score)
        {
            this.Student = student;
            this.Score = score;
        }
    }

}
