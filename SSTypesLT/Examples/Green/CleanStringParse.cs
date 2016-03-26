/**********************************************************************************

Examples / Green Programming
----------------------------
Example of three types of string parsing
Parse_Classic - produces garbage;
Parse_Substring - produces smaller ammount of garbage;
Parse_SmartDouble - cleanest and quickest, produces garbage.

Requirements:
- Reference to System.Drawing is need to provide PointF structure;
- Reference to SSTypesLT is need to provide SmartDouble structure;

SSTypesLT can be installed from NuGet by running the following
command in Package Manager Console:
PM> Install-Package SSTypesLT.dll

Compile and run in Release mode to get rigth measurements.

Links:
SSTypesLT NuGet package:
https://www.nuget.org/packages/SSTypesLT

SSTypesLT on GitHub:
https://github.com/dgakh/SSTypes

Article "Clean String Parsing – the Step to the Green Programming":
http://www.codeproject.com/Articles/1087346/Clean-String-Parsing-the-Step-to-the-Green-Program

-----------------------------------------------------------------------------------

The MIT License (MIT)

Copyright (c) 2016 Dmitriy Gakh ( dmgakh@gmail.com ).

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

**********************************************************************************/

namespace Examples
{
    using System;
    using System.Drawing;
    using System.Text;

    public static class CleanStringParse
    {
        private static Random rnd = new Random();

        public static void RunTest(string[] args)
        {
            // Default number of generated figures
            int figures_count = 100000;

            // Number of vertexes in each figure
            int points_count = 5;

            // Try to get number of generated figures from command line arguments
            if (args.Length > 0)
                figures_count = int.Parse(args[0]);

            // Allocate memory for test data
            PointF[][] figures_p = new PointF[figures_count][];
            string[] figures_s = new string[figures_count];
            char[][] figures_sa = new char[figures_count][];

            // Initialise test data
            for (int i = 0; i < figures_count; i++)
            {
                figures_p[i] = new PointF[points_count];
                figures_s[i] = ToString(GenerateRandom(points_count));
                figures_sa[i] = figures_s[i].ToCharArray();
            }

            // Initialise counters
            MemPerfStatus mps_Classic = new MemPerfStatus(true);
            MemPerfStatus mps_Substring = new MemPerfStatus(true);
            MemPerfStatus mps_SmartDouble = new MemPerfStatus(true);

            // Warming up
            Parse_Classic(figures_s[0], figures_p[0]);
            Parse_Substring(figures_s[0], figures_p[0]);
            Parse_SmartDouble(figures_s[0], figures_p[0]);

            // Testing Parse_Classic
            mps_Classic.Start();

            for (int i = 0; i < figures_count; i++)
                Parse_Classic(figures_s[i], figures_p[i]);

            mps_Classic.Stop();

            // Testing Parse_Substring
            mps_Substring.Start();

            for (int i = 0; i < figures_count; i++)
                Parse_Substring(figures_s[i], figures_p[i]);

            mps_Substring.Stop();

            // Testing Parse_SmartDouble
            mps_SmartDouble.Start();

            for (int i = 0; i < figures_count; i++)
                Parse_SmartDouble(figures_s[i], figures_p[i]);

            mps_SmartDouble.Stop();

            // Reporting - Garbage Collection Count, Memory Usage, Time period
            Console.WriteLine("Figures:{0}", figures_count);
            Console.WriteLine("Points:{0}", points_count);
            mps_Classic.Report("Classic    ");
            mps_Substring.Report("Substring  ");
            mps_SmartDouble.Report("SmartDouble");

            // Console.ReadKey();
        }

        // Generates multilines with given number of vertexes
        private static PointF[] GenerateRandom(int points)
        {
            PointF[] figure = new PointF[points];
            for (int i = 0; i < figure.Length; i++)
                figure[i] = new PointF((float)rnd.Next() / rnd.Next(), (float)rnd.Next() / rnd.Next());

            return figure;
        }

        // Encodes multilines to strings
        private static string ToString(PointF[] figure)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('(');

            for (int i = 0; i < figure.Length; i++)
            {
                sb.Append(figure[i].X.ToString());
                sb.Append(',');
                sb.Append(figure[i].Y.ToString());
                sb.Append(' ');
            }

            sb.Append(')');
            return sb.ToString();
        }

        // Classic method of parsing
        // String.Split produces garbage
        // The most simple source code
        private static void Parse_Classic(string text, PointF[] figure)
        {
            string[] numbers = text.Split(new char[] { ' ', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int points = figure.Length / 2;

            for (int i = 0; i < points; i++)
                figure[i] = new PointF((float)double.Parse(numbers[i * 2]), (float)double.Parse(numbers[i * 2 + 1]));
        }

        // Method of parsing without String.Split
        // String.Substring produces less garbage comparing to method with String.Split
        // The source code becomes more complex
        private static void Parse_Substring(string text, PointF[] figure)
        {
            int x_start = -1, x_len = -1, y_start = -1, y_len = -1;
            int points = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == '(')
                    continue;

                if ((c == ' ') || (c == ')'))
                {
                    if ((x_start != -1) && (y_start != -1))
                    {
                        figure[points] = new PointF(
                            (float)Convert.ToDouble(text.Substring(x_start, x_len)),
                            (float)Convert.ToDouble(text.Substring(y_start, y_len))
                            );

                        x_start = -1; x_len = -1; y_start = -1; y_len = -1;
                        points++;
                    }

                    continue;
                }

                if (c == ',')
                { y_start = i + 1; y_len = 1; continue; }

                if (y_start != -1)
                { y_len++; continue; }

                if (x_start != -1)
                { x_len++; continue; }
                else
                { x_start = i; x_len = 1; continue; }
            }
        }

        // Method of parsing without String.Split nor String.Substring.
        // The method does not produce garbage.
        // The method is almost 3 times faster than Parse_Classic and Parse_Substring.
        private static void Parse_SmartDouble(string text, PointF[] figure)
        {
            int x_start = -1, x_len = -1, y_start = -1, y_len = -1;
            int points = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == '(')
                    continue;

                if ((c == ' ') || (c == ')'))
                {
                    if ((x_start != -1) && (y_start != -1))
                    {
                        // Install SSTypesLT.dll as is described above
                        figure[points] = new PointF(
                            (float)SSTypes.SmartDouble.Parse(text, x_start, x_start + x_len - 1),
                            (float)SSTypes.SmartDouble.Parse(text, y_start, y_start + y_len - 1)
                            );

                        x_start = -1; x_len = -1; y_start = -1; y_len = -1;
                        points++;
                    }

                    continue;
                }

                if (c == ',')
                { y_start = i + 1; y_len = 1; continue; }

                if (y_start != -1)
                { y_len++; continue; }

                if (x_start != -1)
                { x_len++; continue; }
                else
                { x_start = i; x_len = 1; continue; }
            }
        }
    }

}
