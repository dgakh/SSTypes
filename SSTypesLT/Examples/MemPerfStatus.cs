/**********************************************************************************

Examples
--------

MemPerfStatus - Simple memory usage and performance measure class
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
    using System.Diagnostics;

    // Controls counters for memory usage and time
    struct MemPerfStatus
    {
        long memory;
        int[] gccounts;
        Stopwatch stopwatch;

        // Initiates the counters
        public MemPerfStatus(bool init)
        {
            memory = 0;
            gccounts = new int[GC.MaxGeneration + 1];
            stopwatch = Stopwatch.StartNew();
        }

        // Starts measurement
        public void Start()
        {
            memory = GC.GetTotalMemory(true);

            for (int i = 0; i <= GC.MaxGeneration; i++)
                gccounts[i] = GC.CollectionCount(i);

            stopwatch.Reset();
            stopwatch.Start();
        }

        // Stops measurements
        public void Stop()
        {
            stopwatch.Stop();
            memory = GC.GetTotalMemory(false) - memory;

            for (int i = 0; i <= GC.MaxGeneration; i++)
                gccounts[i] = GC.CollectionCount(i) - gccounts[i];
        }

        // Reports changes between Start and Stop
        // gccc: - Garbage collection counts by henerations
        // mem:  - Difference in memory allocated in bytes
        // time: - Nime perion in milliseconds
        public void Report(string Name)
        {
            Console.Write("{0} ", Name);
            Console.Write("gccc:");
            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                if (i != 0)
                    Console.Write(", ");

                Console.Write(gccounts[i].ToString());
            }

            Console.WriteLine("\t mem:{0} \t time:{1}", memory, stopwatch.ElapsedMilliseconds);
        }
    }

}
