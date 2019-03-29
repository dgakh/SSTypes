
using BenchmarkDotNet.Attributes;
using SSTypes;

namespace PerformanceTest
{
    class SmartBool_BM
    {
        private const int N = 10000;

        private bool[] bba1;
        private bool?[] bna1;
        private SmartBool[] bsa1;

        private bool[] bba2;
        private bool?[] bna2;
        private SmartBool[] bsa2;

        private bool[] bba3;
        private bool?[] bna3;
        private SmartBool[] bsa3;

        private bool[] bba_input1;
        private bool?[] bna_input1;
        private SmartBool[] bsa_input1;

        public SmartBool_BM()
        {
            bba1 = new bool[N];
            bna1 = new bool?[N];
            bsa1 = new SmartBool[N];

            bba2 = new bool[N];
            bna2 = new bool?[N];
            bsa2 = new SmartBool[N];

            bba3 = new bool[N];
            bna3 = new bool?[N];
            bsa3 = new SmartBool[N];

            bba_input1 = new bool[N];
            bna_input1 = new bool?[N];
            bsa_input1 = new SmartBool[N];

            SmartRandom rnd = new SmartRandom();

            for (int i = 0; i < N; i++)
            {
                bba1[i] = rnd.NextBool();
            }

            rnd.ReSeed();

            for (int i = 0; i < N; i++)
            {
                bna1[i] = rnd.NextNullableBool();
            }

            rnd.ReSeed();

            for (int i = 0; i < N; i++)
            {
                bsa1[i] = rnd.NextSmartBool();
            }

            rnd = new SmartRandom();

            for (int i = 0; i < N; i++)
            {
                bba2[i] = rnd.NextBool();
            }

            rnd.ReSeed();

            for (int i = 0; i < N; i++)
            {
                bna2[i] = rnd.NextNullableBool();
            }

            rnd.ReSeed();

            for (int i = 0; i < N; i++)
            {
                bsa2[i] = rnd.NextSmartBool();
            }
        }

        [Benchmark]
        public bool[] TRUE_Bool()
        {
            for (int i = 0; i < N; i++)
            {
                if (bba1[i])
                {
                    bba_input1[i] = true;
                }
            }

            return bba_input1;
        }

        [Benchmark]
        public bool[] TRUE_NullableBool()
        {
            for (int i = 0; i < N; i++)
            {
                if (bna1[i].HasValue && (bool)bna1[i])
                {
                    bba_input1[i] = true;
                }
            }

            return bba_input1;
        }

        [Benchmark]
        public bool[] TRUE_SmartBool()
        {
            for (int i = 0; i < N; i++)
            {
                if (bsa1[i])
                {
                    bba_input1[i] = true;
                }
            }

            return bba_input1;
        }

        [Benchmark]
        public bool[] FALSE_Bool()
        {
            for (int i = 0; i < N; i++)
            {
                if (!bba1[i])
                {
                    bba_input1[i] = true;
                }
            }

            return bba_input1;
        }

        [Benchmark]
        public bool[] FALSE_NullableBool()
        {
            for (int i = 0; i < N; i++)
            {
                if (bna1[i].HasValue && (!(bool)bna1[i]))
                {
                    bba_input1[i] = true;
                }
            }

            return bba_input1;
        }

        [Benchmark]
        public bool[] FALSE_SmartBool()
        {
            for (int i = 0; i < N; i++)
            {
                if (!bsa1[i])
                {
                    bba_input1[i] = true;
                }
            }

            return bba_input1;
        }

        [Benchmark]
        public bool?[] Assignment_Bool2NullableBool()
        {
            for (int i = 0; i < N; i++)
            {
                bna_input1[i] = bba1[i];
            }

            return bna_input1;
        }

        [Benchmark]
        public SmartBool[] Assignment_Bool2SmartBool()
        {
            for (int i = 0; i < N; i++)
            {
                bsa_input1[i] = bba1[i];
            }

            return bsa_input1;
        }

        [Benchmark]
        public bool[] Assignment_Bool2Bool()
        {
            for (int i = 0; i < N; i++)
            {
                bba_input1[i] = bba1[i];
            }

            return bba_input1;
        }

        [Benchmark]
        public bool?[] Assignment_NullableBool2NullableBool()
        {
            for (int i = 0; i < N; i++)
            {
                bna_input1[i] = bna1[i];
            }

            return bna_input1;
        }

        [Benchmark]
        public SmartBool[] Assignment_SmartBool2SmartBool()
        {
            for (int i = 0; i < N; i++)
            {
                bsa_input1[i] = bsa1[i];
            }

            return bsa_input1;
        }

        [Benchmark]
        public bool?[] NOT_Bool2Bool()
        {
            for (int i = 0; i < N; i++)
            {
                bba_input1[i] = !bba1[i];
            }

            return bna_input1;
        }

        [Benchmark]
        public bool?[] NOT_NullableBool2NullableBool()
        {
            for (int i = 0; i < N; i++)
            {
                bna_input1[i] = !bna1[i];
            }

            return bna_input1;
        }

        [Benchmark]
        public SmartBool[] NOT_SmartBool2SmartBool()
        {
            for (int i = 0; i < N; i++)
            {
                bsa_input1[i] = !bsa1[i];
            }

            return bsa_input1;
        }

        [Benchmark]
        public bool[] OR_Bool2Bool()
        {
            for (int i = 0; i < N; i++)
            {
                bba_input1[i] = bba1[i] | bba2[i];
            }

            return bba_input1;
        }

        [Benchmark]
        public bool?[] OR_NullableBool2NullableBool()
        {
            for (int i = 0; i < N; i++)
            {
                bna_input1[i] = bna1[i] | bna2[i];
            }

            return bna_input1;
        }

        [Benchmark]
        public SmartBool[] OR_SmartBool2SmartBool()
        {
            for (int i = 0; i < N; i++)
            {
                bsa_input1[i] = bsa1[i] | bsa2[i];
            }

            return bsa_input1;
        }

        [Benchmark]
        public bool[] AND_Bool2Bool()
        {
            for (int i = 0; i < N; i++)
            {
                bba_input1[i] = bba1[i] & bba2[i];
            }

            return bba_input1;
        }

        [Benchmark]
        public bool?[] AND_NullableBool2NullableBool()
        {
            for (int i = 0; i < N; i++)
            {
                bna_input1[i] = bna1[i] & bna2[i];
            }

            return bna_input1;
        }

        [Benchmark]
        public SmartBool[] AND_SmartBool2SmartBool()
        {
            for (int i = 0; i < N; i++)
            {
                bsa_input1[i] = bsa1[i] & bsa2[i];
            }

            return bsa_input1;
        }

        [Benchmark]
        public bool[] EQ_Bool2Bool()
        {
            for (int i = 0; i < N; i++)
            {
                bba_input1[i] = bba1[i] == bba2[i];
            }

            return bba_input1;
        }

        [Benchmark]
        public bool?[] EQ_NullableBool2NullableBool()
        {
            for (int i = 0; i < N; i++)
            {
                bna_input1[i] = bna1[i] == bna2[i];
            }

            return bna_input1;
        }

        [Benchmark]
        public SmartBool[] EQ_SmartBool2SmartBool()
        {
            for (int i = 0; i < N; i++)
            {
                bsa_input1[i] = bsa1[i] == bsa2[i];
            }

            return bsa_input1;
        }

        [Benchmark]
        public bool[] NEQ_Bool2Bool()
        {
            for (int i = 0; i < N; i++)
            {
                bba_input1[i] = bba1[i] == bba2[i];
            }

            return bba_input1;
        }

        [Benchmark]
        public bool?[] NEQ_NullableBool2NullableBool()
        {
            for (int i = 0; i < N; i++)
            {
                bna_input1[i] = bna1[i] == bna2[i];
            }

            return bna_input1;
        }

        [Benchmark]
        public SmartBool[] NEQ_SmartBool2SmartBool()
        {
            for (int i = 0; i < N; i++)
            {
                bsa_input1[i] = bsa1[i] == bsa2[i];
            }

            return bsa_input1;
        }
    }

}

