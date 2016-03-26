
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using SSTypes;
using System;

namespace PerformanceTest
{
    class SmartDoubleBM
    {
    }


    // Uncomment if wish to run specific platform
    //[BenchmarkTask(platform: BenchmarkPlatform.X86, jitVersion: BenchmarkJitVersion.LegacyJit)]
    //[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.LegacyJit)]
    //[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.RyuJit)]
    public class SmartDouble_Double_Parse
    {
        private const int N = 10000;
        private readonly string[] s_doubles;
        private readonly double[] d_doubles;
        private readonly double[] sd_doubles;

        public SmartDouble_Double_Parse()
        {
            s_doubles = new string[N];
            d_doubles = new double[N];
            sd_doubles = new double[N];

            Random rnd = new Random();

            for (int i = 0; i < N; i++)
                s_doubles[i] = rnd.Next(100000).ToString() + "." + rnd.Next(100000).ToString();
        }

        [Benchmark]
        public void Parse_Double()
        {
            for (int i = 0; i < N; i++)
                d_doubles[i] = double.Parse(s_doubles[i]);
        }

        [Benchmark]
        public void Parse_SmartDouble()
        {
            for (int i = 0; i < N; i++)
                sd_doubles[i] = SmartDouble.Parse(s_doubles[i]);
        }
    }

    // Uncomment if wish to run specific platform
    //[BenchmarkTask(platform: BenchmarkPlatform.X86, jitVersion: BenchmarkJitVersion.LegacyJit)]
    //[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.LegacyJit)]
    //[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.RyuJit)]
    public class SmartDouble_Double_ToString
    {
        private const int N = 10000;
        private readonly double[] doubles;
        private readonly string[] d_strings;
        private readonly string[] sd_strings;

        public SmartDouble_Double_ToString()
        {
            doubles = new double[N];
            d_strings = new string[N];
            sd_strings = new string[N];

            Random rnd = new Random();

            for (int i = 0; i < N; i++)
                doubles[i] = ((double)rnd.Next(100000) / (double)rnd.Next(100000));
        }

        [Benchmark]
        public void ToString_Double()
        {
            for (int i = 0; i < N; i++)
                d_strings[i] = doubles[i].ToString();
        }

        [Benchmark]
        public void ToString_SmartDouble()
        {
            for (int i = 0; i < N; i++)
                d_strings[i] = SmartDouble.ToStringValue(doubles[i]);
        }
    }

    // Uncomment if wish to run specific platform
    //[BenchmarkTask(platform: BenchmarkPlatform.X86, jitVersion: BenchmarkJitVersion.LegacyJit)]
    //[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.LegacyJit)]
    //[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.RyuJit)]
    public class SmartInt_Int_Parse
    {
        private const int N = 10000;
        private readonly string[] s_doubles;
        private readonly int[] d_doubles;
        private readonly int[] sd_doubles;

        public SmartInt_Int_Parse()
        {
            s_doubles = new string[N];
            d_doubles = new int[N];
            sd_doubles = new int[N];

            Random rnd = new Random();

            for (int i = 0; i < N; i++)
                s_doubles[i] = rnd.Next(1000000000).ToString();
        }

        [Benchmark]
        public void Parse_Double()
        {
            for (int i = 0; i < N; i++)
                d_doubles[i] = int.Parse(s_doubles[i]);
        }

        [Benchmark]
        public void Parse_SmartDouble()
        {
            for (int i = 0; i < N; i++)
                sd_doubles[i] = SmartInt.Parse(s_doubles[i]);
        }
    }

    // Uncomment if wish to run specific platform
    //[BenchmarkTask(platform: BenchmarkPlatform.X86, jitVersion: BenchmarkJitVersion.LegacyJit)]
    //[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.LegacyJit)]
    //[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.RyuJit)]
    public class SmartInt_Int_ToString
    {
        private const int N = 10000;
        private readonly int[] ints;
        private readonly string[] d_strings;
        private readonly string[] sd_strings;

        public SmartInt_Int_ToString()
        {
            ints = new int[N];
            d_strings = new string[N];
            sd_strings = new string[N];

            Random rnd = new Random();

            for (int i = 0; i < N; i++)
                ints[i] = rnd.Next(1000000000);
        }

        [Benchmark]
        public void ToString_Double()
        {
            for (int i = 0; i < N; i++)
                d_strings[i] = ints[i].ToString();
        }

        [Benchmark]
        public void ToString_SmartDouble()
        {
            for (int i = 0; i < N; i++)
                d_strings[i] = SmartInt.ToStringValue(ints[i]);
        }
    }


}
