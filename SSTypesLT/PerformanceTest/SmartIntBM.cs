
using BenchmarkDotNet.Attributes;

namespace PerformanceTest
{

    // Test Simple Operations SSTypes.SmartInt.Parse and System.Int32
    public class SmartIntBM_SimpleOperations
    {
        int cycles = 10000000;
        int count = 10;

        public SmartIntBM_SimpleOperations()
        {
        }

        [Benchmark]
        public SSTypes.SmartInt Additions_SmartInt()
        {
            SSTypes.SmartInt s = 0;
            SSTypes.SmartInt d = 7;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 0;
                d = 7;

                for (var i = 0; i < count; i++)
                    s += d;
            }

            return s;
        }

        [Benchmark]
        public System.Int32 Additions_Int()
        {
            System.Int32 s = 0;
            System.Int32 d = 7;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 0;
                d = 7;

                for (var i = 0; i < count; i++)
                    s += d;
            }

            return s;
        }


        [Benchmark]
        public SSTypes.SmartInt Substractions_SmartInt()
        {
            SSTypes.SmartInt s = 1000000;
            SSTypes.SmartInt d = 7;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 1000000;
                d = 7;

                for (var i = 0; i < count; i++)
                    s -= d;
            }

            return s;
        }

        [Benchmark]
        public System.Int32 Substractions_Int()
        {
            System.Int32 s = 1000000;
            System.Int32 d = 7;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 1000000;
                d = 7;

                for (var i = 0; i < count; i++)
                    s -= d;
            }

            return s;
        }

        [Benchmark]
        public SSTypes.SmartInt Multiplications_SmartInt()
        {
            SSTypes.SmartInt s = 1;
            SSTypes.SmartInt d = 3;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 1;
                d = 3;

                for (var i = 0; i < count; i++)
                    s *= d;
            }

            return s;
        }

        [Benchmark]
        public System.Int32 Multiplications_Int()
        {
            System.Int32 s = 1;
            System.Int32 d = 3;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 1;
                d = 3;

                for (var i = 0; i < count; i++)
                    s *= d;
            }

            return s;
        }

        [Benchmark]
        public SSTypes.SmartInt Divisions_SmartInt()
        {
            SSTypes.SmartInt s = int.MaxValue;
            SSTypes.SmartInt d = 3;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = int.MaxValue;
                d = 3;

                for (var i = 0; i < count; i++)
                    s /= d;
            }

            return s;
        }

        [Benchmark]
        public System.Int32 Divisions_Int()
        {
            System.Int32 s = int.MaxValue;
            System.Int32 d = 3;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = int.MaxValue;
                d = 3;

                for (var i = 0; i < count; i++)
                    s /= d;
            }

            return s;
        }

        [Benchmark]
        public SSTypes.SmartInt DivResiduals_SmartInt()
        {
            SSTypes.SmartInt s = int.MaxValue;
            SSTypes.SmartInt d = 3;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = int.MaxValue;
                d = 3;

                for (var i = 0; i < count; i++)
                    s %= d;
            }

            return s;
        }

        [Benchmark]
        public System.Int32 DivResiduals_Int()
        {
            System.Int32 s = int.MaxValue;
            System.Int32 d = 3;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = int.MaxValue;
                d = 3;

                for (var i = 0; i < count; i++)
                    s %= d;
            }

            return s;
        }

        [Benchmark]
        public SSTypes.SmartInt LogicAnds_SmartInt()
        {
            SSTypes.SmartInt s = 17;
            SSTypes.SmartInt d = 3;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 17;
                d = 3;

                for (var i = 0; i < count; i++)
                    s &= d;
            }

            return s;
        }

        [Benchmark]
        public System.Int32 LogicAnds_Int()
        {
            System.Int32 s = 17;
            System.Int32 d = 3;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 17;
                d = 3;

                for (var i = 0; i < count; i++)
                    s &= d;
            }

            return s;
        }

        [Benchmark]
        public SSTypes.SmartInt LogicOrs_SmartInt()
        {
            SSTypes.SmartInt s = 17;
            SSTypes.SmartInt d = 3;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 17;
                d = 3;

                for (var i = 0; i < count; i++)
                    s |= d;
            }

            return s;
        }

        [Benchmark]
        public System.Int32 LogicOrs_Int()
        {
            System.Int32 s = 17;
            System.Int32 d = 3;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 17;
                d = 3;

                for (var i = 0; i < count; i++)
                    s |= d;
            }

            return s;
        }

    }



    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: int.MinValue, int.MinValue + 1, int.MinValue + 2, ...
    public class SmartIntBM_Parse_IntSmartInt_ns_Digit
    {
        const int num_count = 100000;
        string[] sna;
        int[] ina;

        public SmartIntBM_Parse_IntSmartInt_ns_Digit()
        {
            ina = new int[num_count];
            sna = new string[num_count];

            for (var i = 0; i < sna.Length; i++)
                sna[i] = (int.MinValue + i).ToString();
        }

        [Benchmark]
        public void Parse_SmartInt_ns_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_ns_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }

    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: int.MaxValue, int.MaxValue - 1, int.MaxValue - 2, ...
    public class SmartIntBM_Parse_IntSmartInt_ps_Digit
    {
        const int num_count = 100000;
        string[] sna;
        int[] ina;

        public SmartIntBM_Parse_IntSmartInt_ps_Digit()
        {
            ina = new int[num_count];
            sna = new string[num_count];

            for (var i = 0; i < sna.Length; i++)
                sna[i] = (int.MaxValue - i).ToString();
        }

        [Benchmark]
        public void Parse_SmartInt_ps_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_ps_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }



    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
    public class SmartIntBM_Parse_IntSmartInt_1_Digit
    {
        string[] sna = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        int[] ina = new int[10];

        public SmartIntBM_Parse_IntSmartInt_1_Digit()
        {
        }

        [Benchmark]
        public void Parse_SmartInt_1_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_1_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }

    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: "-0", "-1", "-2", "-3", "-4", "-5", "-6", "-7", "-8", "-9"
    public class SmartIntBM_Parse_IntSmartInt_1n_Digit
    {
        string[] sna = new string[] { "-0", "-1", "-2", "-3", "-4", "-5", "-6", "-7", "-8", "-9" };
        int[] ina = new int[10];

        public SmartIntBM_Parse_IntSmartInt_1n_Digit()
        {
        }

        [Benchmark]
        public void Parse_SmartInt_1n_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_1n_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }

    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: "+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9"
    public class SmartIntBM_Parse_IntSmartInt_1p_Digit
    {
        string[] sna = new string[] { "+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9" };
        int[] ina = new int[10];

        public SmartIntBM_Parse_IntSmartInt_1p_Digit()
        {
        }

        [Benchmark]
        public void Parse_SmartInt_1p_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_1p_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }



    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: numbers containing 8 digits including leading zeros
    public class SmartIntBM_Parse_IntSmartInt_8_Digit
    {
        const int num_count = 100000;
        string[] sna;
        int[] ina;

        public SmartIntBM_Parse_IntSmartInt_8_Digit()
        {
            char[] chars = new char[8];
            System.Random rnd = new System.Random(150);

            ina = new int[num_count];
            sna = new string[num_count];

            for (var i = 0; i < sna.Length; i++)
            {
                for (var i2 = 0; i2 < 8; i2++)
                    chars[i2] = (char)('0' + rnd.Next(0, 10));

                sna[i] = new string(chars);
            }
        }

        [Benchmark]
        public void Parse_SmartInt_8_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_8_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }

    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: negative numbers started from '-' and containing 8 digits including leading zeros
    public class SmartIntBM_Parse_IntSmartInt_8n_Digit
    {
        const int num_count = 100000;
        string[] sna;
        int[] ina;

        public SmartIntBM_Parse_IntSmartInt_8n_Digit()
        {
            char[] chars = new char[9];
            System.Random rnd = new System.Random(150);

            ina = new int[num_count];
            sna = new string[num_count];

            chars[0] = '-';

            for (var i = 0; i < sna.Length; i++)
            {
                for (var i2 = 1; i2 <= 8; i2++)
                    chars[i2] = (char)('0' + rnd.Next(0, 10));

                sna[i] = new string(chars);
            }
        }

        [Benchmark]
        public void Parse_SmartInt_8n_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_8n_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }

    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: positive numbers started from '+' and containing 8 digits including leading zeros
    public class SmartIntBM_Parse_IntSmartInt_8p_Digit
    {
        const int num_count = 100000;
        string[] sna;
        int[] ina;

        public SmartIntBM_Parse_IntSmartInt_8p_Digit()
        {
            char[] chars = new char[9];
            System.Random rnd = new System.Random(150);

            ina = new int[num_count];
            sna = new string[num_count];

            chars[0] = '+';

            for (var i = 0; i < sna.Length; i++)
            {
                for (var i2 = 1; i2 <= 8; i2++)
                    chars[i2] = (char)('0' + rnd.Next(0, 10));

                sna[i] = new string(chars);
            }
        }

        [Benchmark]
        public void Parse_SmartInt_8p_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_8p_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }



    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: numbers containing 9 digits including leading zeros
    public class SmartIntBM_Parse_IntSmartInt_9_Digit
    {
        const int num_count = 100000;
        string[] sna;
        int[] ina;

        public SmartIntBM_Parse_IntSmartInt_9_Digit()
        {
            char[] chars = new char[9];
            System.Random rnd = new System.Random(150);

            ina = new int[num_count];
            sna = new string[num_count];

            for (var i = 0; i < sna.Length; i++)
            {
                for (var i2 = 0; i2 < 9; i2++)
                    chars[i2] = (char)('0' + rnd.Next(0, 10));

                sna[i] = new string(chars);
            }
        }

        [Benchmark]
        public void Parse_SmartInt_9_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_9_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }

    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: negative numbers started from '-' and containing 9 digits including leading zeros
    public class SmartIntBM_Parse_IntSmartInt_9n_Digit
    {
        const int num_count = 100000;
        string[] sna;
        int[] ina;

        public SmartIntBM_Parse_IntSmartInt_9n_Digit()
        {
            char[] chars = new char[10];
            System.Random rnd = new System.Random(150);

            ina = new int[num_count];
            sna = new string[num_count];

            chars[0] = '-';

            for (var i = 0; i < sna.Length; i++)
            {
                for (var i2 = 1; i2 <= 9; i2++)
                    chars[i2] = (char)('0' + rnd.Next(0, 10));

                sna[i] = new string(chars);
            }
        }

        [Benchmark]
        public void Parse_SmartInt_9n_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_9n_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }

    // Test SSTypes.SmartInt.Parse and System.Int32.Parse
    // DataSet: positive numbers started from '+' and containing 9 digits including leading zeros
    public class SmartIntBM_Parse_IntSmartInt_9p_Digit
    {
        const int num_count = 100000;
        string[] sna;
        int[] ina;

        public SmartIntBM_Parse_IntSmartInt_9p_Digit()
        {
            char[] chars = new char[10];
            System.Random rnd = new System.Random(150);

            ina = new int[num_count];
            sna = new string[num_count];

            chars[0] = '+';

            for (var i = 0; i < sna.Length; i++)
            {
                for (var i2 = 1; i2 <= 9; i2++)
                    chars[i2] = (char)('0' + rnd.Next(0, 10));

                sna[i] = new string(chars);
            }
        }

        [Benchmark]
        public void Parse_SmartInt_9p_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = SSTypes.SmartInt.Parse(sna[i]);
        }

        [Benchmark]
        public void Parse_Int_9p_Digit()
        {
            for (var i = 0; i < sna.Length; i++)
                ina[i] = System.Int32.Parse(sna[i]);
        }
    }

}
