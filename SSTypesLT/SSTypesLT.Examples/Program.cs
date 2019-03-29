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

namespace Examples
{
    using System;


    class Program
    {
        static void Main(string[] args)
        {
            SmartBoolExamples.Run1();


            double dd = SSTypes.SmartDouble.Parse("4897350");
            dd = dd / 0;
            bool bb = (new SSTypes.SmartDouble(dd)).isBad();
            bb = SSTypes.SmartDouble.Parse("4897350").isBad();


            SSTypes.SmartInt smi = 88;

            smi = null;


            // Uncomment example you want to run

            //CleanStringParse.RunTest(args);

            SmartIntExample.OperationsAdd();
            //SmartIntExample.ArraySize();

            //SmartIntExample.AssignmentByte();
            //SmartIntExample.AssignmentSingle();
            //SmartIntExample.AssignmentInt();
            //SmartIntExample.AssignmentLong();
            //SmartIntExample.AssignmentDouble();
            //SmartIntExample.AssignmentSmartDouble();
            //SmartIntExample.AssignmentDecimal();

            //SmartIntExample.IteratorIndexer();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
