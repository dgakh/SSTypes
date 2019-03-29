/**********************************************************************************

Examples
https://github.com/dgakh/SSTypes
--------

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

using System;

namespace Examples
{
    class SmartBoolExamples
    {
        public static void Run1()
        {
            ArraySize();

            opCompatibility();

            // opIF();

            opNOT();
            opOR();
            opAND();
            opIMPL();
            opEXOR();
            opEQU();

            Console.ReadLine();
        }

        static void opCompatibility()
        {
            bool b1 = true;
            bool b2 = false;

            bool? bn1 = true;
            bool? bn2 = false;
            bool? bn3 = null;

            SmartBool sb11 = true;
            SmartBool sb12 = false;
            SmartBool sb13 = null;

            SmartBool sb21 = SmartBool.True;
            SmartBool sb22 = SmartBool.False;
            SmartBool sb23 = SmartBool.Unknown;

            SmartBool sb;

            sb = b1;
            sb = b2;

            sb = bn1;
            sb = bn2;
            sb = bn3;

            bool b;

            b = (bool)sb11;
            b = (bool)sb12;
            b = (bool)sb13;

            b = (bool)sb21;
            b = (bool)sb22;
            b = (bool)sb23;

            bool? bn;

            bn = sb11;
            bn = sb12;
            bn = sb13;

            bn = sb21;
            bn = sb22;
            bn = sb23;
        }

        static void ArraySize()
        {
            int objects_count = 1000;

            long memory1 = GC.GetTotalMemory(true);

            bool[] ai = new bool[objects_count];
            long memory2 = GC.GetTotalMemory(true);

            bool?[] ani = new bool?[objects_count];
            long memory3 = GC.GetTotalMemory(true);

            SmartBool[] asi = new SmartBool[objects_count];
            long memory4 = GC.GetTotalMemory(true);

            // Compiler can optimize and do not allocate arrays if they are not used
            // So we write their lengths

            Console.WriteLine("Array sizes {0}, {1}, {2}", ai.Length, ani.Length, asi.Length);
            Console.WriteLine("Memory for bool \t {0}", memory2 - memory1);
            Console.WriteLine("Memory for bool? \t {0}", memory3 - memory2);
            Console.WriteLine("Memory for SmartBool \t {0}", memory4 - memory3);
        }

        static void opIF()
        {
            bool? bn = null;
            bool b2 = (bool)bn;

            if ((bool)bn)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False or Unknown");
            }

            SmartBool sb = SmartBool.Unknown;
            // SmartBool sb = null;
            bool sb2 = (bool)sb;

            if (sb)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False or Unknown");
            }
        }

        static void opNOT()
        {
            bool?[] bl_vs = new bool?[] { true, null, false };
            SmartBool[] sm_bl_vs = new SmartBool[] { true, null, false };

            // Is equals to the following:
            // SmartBool[] sm_bl_vs = new SmartBool[] { SmartBool.True, SmartBool.Unknown, SmartBool.False };

            Console.WriteLine("Operation NOT (bool?)");
            Console.WriteLine("---");

            for (int i = 0; i < bl_vs.Length; i++)
            {
                Console.WriteLine("{0}\t{1}", (bl_vs[i]).Format(), (!bl_vs[i]).Format());
            }

            Console.WriteLine();

            Console.WriteLine("Operation NOT (SmartBool)");
            Console.WriteLine("---");

            for (int i = 0; i < sm_bl_vs.Length; i++)
            {
                Console.WriteLine("{0}\t{1}", (sm_bl_vs[i]).ToString(), (!sm_bl_vs[i]).ToString());
            }

            Console.WriteLine();
        }

        static void opOR()
        {
            bool?[] bl_vs = new bool?[] { true, null, false };
            SmartBool[] sm_bl_vs = new SmartBool[] { true, null, false };

            // Is equals to the following:
            // SmartBool[] sm_bl_vs = new SmartBool[] { SmartBool.True, SmartBool.Unknown, SmartBool.False };

            Console.WriteLine("Operation OR (bool?)");
            Console.WriteLine("---");

            Console.Write("  ");

            for (int i = 0; i < bl_vs.Length; i++)
                Console.Write("\t{0}", bl_vs[i].Format());

            Console.WriteLine();

            for (int j = 0; j < bl_vs.Length; j++)
            {
                Console.Write(bl_vs[j].Format());

                for (int i = 0; i < bl_vs.Length; i++)
                {
                    Console.Write("\t{0}", (bl_vs[j] | bl_vs[i]).Format());
                }

                Console.WriteLine();

            }

            Console.WriteLine();

            Console.WriteLine("Operation OR (SmartBool)");
            Console.WriteLine("---");

            Console.Write("  ");

            for (int i = 0; i < sm_bl_vs.Length; i++)
                Console.Write("\t{0}", sm_bl_vs[i].ToString());

            Console.WriteLine();

            for (int j = 0; j < sm_bl_vs.Length; j++)
            {
                Console.Write(sm_bl_vs[j].ToString());

                for (int i = 0; i < sm_bl_vs.Length; i++)
                {
                    Console.Write("\t{0}", (sm_bl_vs[j] | sm_bl_vs[i]).ToString());
                }

                Console.WriteLine();

            }

            Console.WriteLine();
        }

        static void opAND()
        {
            bool?[] bl_vs = new bool?[] { true, null, false };
            SmartBool[] sm_bl_vs = new SmartBool[] { true, null, false };

            // Is equals to the following:
            // SmartBool[] sm_bl_vs = new SmartBool[] { SmartBool.True, SmartBool.Unknown, SmartBool.False };

            Console.WriteLine("Operation AND (bool?)");
            Console.WriteLine("---");

            Console.Write("  ");

            for (int i = 0; i < bl_vs.Length; i++)
                Console.Write("\t{0}", bl_vs[i].Format());

            Console.WriteLine();

            for (int j = 0; j < bl_vs.Length; j++)
            {
                Console.Write(bl_vs[j].Format());

                for (int i = 0; i < bl_vs.Length; i++)
                {
                    Console.Write("\t{0}", (bl_vs[j] & bl_vs[i]).Format());
                }

                Console.WriteLine();

            }

            Console.WriteLine();

            Console.WriteLine("Operation AND (SmartBool)");
            Console.WriteLine("---");

            Console.Write("  ");

            for (int i = 0; i < sm_bl_vs.Length; i++)
                Console.Write("\t{0}", sm_bl_vs[i].ToString());

            Console.WriteLine();

            for (int j = 0; j < sm_bl_vs.Length; j++)
            {
                Console.Write(sm_bl_vs[j].ToString());

                for (int i = 0; i < sm_bl_vs.Length; i++)
                {
                    Console.Write("\t{0}", (sm_bl_vs[j] & sm_bl_vs[i]).ToString());
                }

                Console.WriteLine();

            }

            Console.WriteLine();
        }

        static void opIMPL()
        {
            bool?[] bl_vs = new bool?[] { true, null, false };
            SmartBool[] sm_bl_vs = new SmartBool[] { true, null, false };

            // Is equals to the following:
            // SmartBool[] sm_bl_vs = new SmartBool[] { SmartBool.True, SmartBool.Unknown, SmartBool.False };

            Console.WriteLine("Operation IMPL (bool?)");
            Console.WriteLine("---");

            Console.Write("  ");

            for (int i = 0; i < bl_vs.Length; i++)
                Console.Write("\t{0}", bl_vs[i].Format());

            Console.WriteLine();

            for (int j = 0; j < bl_vs.Length; j++)
            {
                Console.Write(bl_vs[j].Format());

                for (int i = 0; i < bl_vs.Length; i++)
                {
                    Console.Write("\t{0}", (bl_vs[j].Implies(bl_vs[i])).Format());
                }

                Console.WriteLine();

            }

            Console.WriteLine();

            Console.WriteLine("Operation IMPL (SmartBool)");
            Console.WriteLine("---");

            Console.Write("  ");

            for (int i = 0; i < sm_bl_vs.Length; i++)
                Console.Write("\t{0}", sm_bl_vs[i].ToString());

            Console.WriteLine();

            for (int j = 0; j < sm_bl_vs.Length; j++)
            {
                Console.Write(sm_bl_vs[j].ToString());

                for (int i = 0; i < sm_bl_vs.Length; i++)
                {
                    Console.Write("\t{0}", (sm_bl_vs[j].Implies(sm_bl_vs[i])).ToString());
                }

                Console.WriteLine();

            }

            Console.WriteLine();
        }

        static void opEXOR()
        {
            bool?[] bl_vs = new bool?[] { true, null, false };
            SmartBool[] sm_bl_vs = new SmartBool[] { true, null, false };

            // Is equals to the following:
            // SmartBool[] sm_bl_vs = new SmartBool[] { SmartBool.True, SmartBool.Unknown, SmartBool.False };

            Console.WriteLine("Operation EXOR (bool?)");
            Console.WriteLine("---");

            Console.Write("  ");

            for (int i = 0; i < bl_vs.Length; i++)
                Console.Write("\t{0}", bl_vs[i].Format());

            Console.WriteLine();

            for (int j = 0; j < bl_vs.Length; j++)
            {
                Console.Write(bl_vs[j].Format());

                for (int i = 0; i < bl_vs.Length; i++)
                {
                    Console.Write("\t{0}", (bl_vs[j] ^ (bl_vs[i])).Format());
                }

                Console.WriteLine();

            }

            Console.WriteLine();

            Console.WriteLine("Operation EXOR (SmartBool)");
            Console.WriteLine("---");

            Console.Write("  ");

            for (int i = 0; i < sm_bl_vs.Length; i++)
                Console.Write("\t{0}", sm_bl_vs[i].ToString());

            Console.WriteLine();

            for (int j = 0; j < sm_bl_vs.Length; j++)
            {
                Console.Write(sm_bl_vs[j].ToString());

                for (int i = 0; i < sm_bl_vs.Length; i++)
                {
                    Console.Write("\t{0}", (sm_bl_vs[j] ^ (sm_bl_vs[i])).ToString());
                }

                Console.WriteLine();

            }

            Console.WriteLine();
        }

        static void opEQU()
        {
            bool?[] bl_vs = new bool?[] { true, null, false };
            SmartBool[] sm_bl_vs = new SmartBool[] { true, null, false };

            // Is equals to the following:
            // SmartBool[] sm_bl_vs = new SmartBool[] { SmartBool.True, SmartBool.Unknown, SmartBool.False };

            Console.WriteLine("Operation == (bool?)");
            Console.WriteLine("---");

            Console.Write("  ");

            for (int i = 0; i < bl_vs.Length; i++)
                Console.Write("\t{0}", bl_vs[i].Format());

            Console.WriteLine();

            for (int j = 0; j < bl_vs.Length; j++)
            {
                Console.Write(bl_vs[j].Format());

                for (int i = 0; i < bl_vs.Length; i++)
                {
                    Console.Write("\t{0}", bl_vs[j].IsEquivalentTo(bl_vs[i]).Format());
                }

                Console.WriteLine();

            }

            Console.WriteLine();

            Console.WriteLine("Operation == (SmartBool)");
            Console.WriteLine("---");

            Console.Write("  ");

            for (int i = 0; i < sm_bl_vs.Length; i++)
                Console.Write("\t{0}", sm_bl_vs[i].ToString());

            Console.WriteLine();

            for (int j = 0; j < sm_bl_vs.Length; j++)
            {
                Console.Write(sm_bl_vs[j].ToString());

                for (int i = 0; i < sm_bl_vs.Length; i++)
                {
                    Console.Write("\t{0}", (sm_bl_vs[j] == sm_bl_vs[i]).ToString());
                }

                Console.WriteLine();

            }

            Console.WriteLine();
        }
    }
}
