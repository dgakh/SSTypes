using SSTypes;
using System;

namespace Examples
{
    public static class SmartIntExample
    {

        /// <summary>
        /// Parse and error control of SmartInt and System.Int32.
        /// No error, no exception.
        /// </summary>
        public static void Parse1Ok()
        {
            try
            {
                SmartInt i = SmartInt.Parse("  593  ");
                Console.Write("SmartInt:");
                Console.Write(i.ToString());  // Use i.ToString() instead of single i to avoid implicit conversion to int
                Console.Write("  IsBad:");
                Console.WriteLine(i.isBad());

                System.Int32 i2 = System.Int32.Parse("  593  ");
                Console.Write("System.Int32:");
                Console.WriteLine(i2);
            }
            catch(Exception ex)
            {
                Console.Write("Exception:");
                Console.Write(ex.Message);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Parse and error control of SmartInt and System.Int32.
        /// SmartInt takes SmartInt.BadValue value.
        /// System.Int32.Parse throws exception.
        /// </summary>
        public static void Parse1Error()
        {
            try
            {
                SmartInt i = SmartInt.Parse("abc");
                Console.Write("SmartInt:");
                Console.Write(i.ToString());  // Use i.ToString() instead of single i to avoid implicit conversion to int
                Console.Write("  IsBad:");
                Console.WriteLine(i.isBad());

                System.Int32 i2 = System.Int32.Parse("abc");
                Console.Write("System.Int32:");
                Console.WriteLine(i2);
            }
            catch (Exception ex)
            {
                Console.Write("Exception:");
                Console.Write(ex.Message);
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Implicit conversion between SmartInt and System.Byte.
        /// </summary>
        public static void AssignmentByte()
        {
            try
            {
                SmartInt v1 = 7;
                System.Byte v2 = 5;

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = (System.Byte)v1;  // Explicit conversion 

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = 4;
                v1 = v2;  // Implicit conversion

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);
            }
            catch (Exception ex)
            {
                Console.Write("Exception:");
                Console.Write(ex.Message);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Implicit conversion between SmartInt and System.Int16.
        /// </summary>
        public static void AssignmentSingle()
        {
            try
            {
                SmartInt v1 = 7;
                System.Int16 v2 = 5;

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = (System.Int16)v1;  // Explicit conversion 

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = 4;
                v1 = v2;  // Implicit conversion

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);
            }
            catch (Exception ex)
            {
                Console.Write("Exception:");
                Console.Write(ex.Message);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Implicit conversion between SmartInt and System.Int32.
        /// </summary>
        public static void AssignmentInt()
        {
            try
            {
                SmartInt v1 = 7;
                System.Int32 v2 = 5;

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = v1;  // Implicit conversion 

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = 4;
                v1 = v2;  // Implicit conversion

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);
            }
            catch (Exception ex)
            {
                Console.Write("Exception:");
                Console.Write(ex.Message);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Implicit conversion between SmartInt and System.Int64.
        /// </summary>
        public static void AssignmentLong()
        {
            try
            {
                SmartInt v1 = 7;
                System.Int64 v2 = 5;

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = v1;  // Implicit conversion 

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = 4;
                v1 = (SmartInt)v2;  // Only explicit conversion allowed

                Console.Write(v1.ToString()); // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);
            }
            catch (Exception ex)
            {
                Console.Write("Exception:");
                Console.Write(ex.Message);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Implicit conversion between SmartInt and System.Double.
        /// </summary>
        public static void AssignmentDouble()
        {
            try
            {
                SmartInt v1 = 7;
                System.Double v2 = 5;

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = v1;  // Implicit conversion 

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = 4;
                v1 = (SmartInt)v2;  // Only explicit conversion allowed

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);
            }
            catch (Exception ex)
            {
                Console.Write("Exception:");
                Console.Write(ex.Message);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Implicit conversion between SmartInt and System.Double.
        /// </summary>
        public static void AssignmentSmartDouble()
        {
            try
            {
                SmartInt v1 = 7;
                System.Double v2 = 5;

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = v1;  // Implicit conversion 

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = 4;
                v1 = (SmartInt)v2;  // Only explicit conversion allowed

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);
            }
            catch (Exception ex)
            {
                Console.Write("Exception:");
                Console.Write(ex.Message);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Implicit conversion between SmartInt and System.Decimal.
        /// </summary>
        public static void AssignmentDecimal()
        {
            try
            {
                SmartInt v1 = 7;
                System.Decimal v2 = 5;

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = v1;  // Implicit conversion 

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);

                v2 = 4;
                v1 = (SmartInt)v2;  // Only explicit conversion allowed

                Console.Write(v1.ToString());  // Use v1.ToString() instead of single v1 to avoid implicit conversion to int
                Console.Write(", ");
                Console.WriteLine(v2);
            }
            catch (Exception ex)
            {
                Console.Write("Exception:");
                Console.Write(ex.Message);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Use SmartInt in for cycle and as indexer in place where System.Int32 is used.
        /// </summary>
        public static void IteratorIndexer()
        {
            try
            {
                String shello = "Hello !";
                Char[] chello = { 'H', 'e', 'l', 'l', 'o', ' ', '!' };

                for(SmartInt i = 0; i < shello.Length; i++)
                    Console.Write(shello[i]);

                Console.WriteLine();

                for (SmartInt i = 0; i < chello.Length; i++)
                    Console.Write(chello[i]);

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.Write("Exception:");
                Console.Write(ex.Message);
                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Compare sizes of arrays of int, int?s and SmartInt
        /// </summary>
        public static void ArraySize()
        {
            int objects_count = 1000;

            long memory1 = GC.GetTotalMemory(true);
            int[] ai = new int[objects_count];
            long memory2 = GC.GetTotalMemory(true);
            int?[] ani = new int?[objects_count];
            long memory3 = GC.GetTotalMemory(true);
            SmartInt[] asi = new SmartInt[objects_count];
            long memory4 = GC.GetTotalMemory(true);

            // Compiler can optimize and do not allocate arrays if they are not used
            // So we write their lengths
            Console.WriteLine("Array sizes {0}, {1}, {2}", ai.Length, ani.Length, asi.Length);
            Console.WriteLine("Memory for int \t {0}", memory2 - memory1);
            Console.WriteLine("Memory for int? \t {0}", memory3 - memory2);
            Console.WriteLine("Memory for SmartInt \t {0}", memory4 - memory3);
        }

        /// <summary>
        /// Compare times of addition of int, int?s and SmartInt
        /// </summary>
        public static void OperationsAdd()
        {
            MemPerfStatus mps_Int = new MemPerfStatus(true);
            MemPerfStatus mps_IntN = new MemPerfStatus(true);
            MemPerfStatus mps_SmartInt = new MemPerfStatus(true);

            SmartIntBM_SimpleOperations tt = new SmartIntBM_SimpleOperations();

            // Warmup
            tt.Additions_Int();

            mps_Int.Start();

            for (var i = 0; i < 10; i++)
                tt.Additions_Int();

            mps_Int.Stop();

            // Warmup
            tt.Additions_IntN();

            mps_IntN.Start();

            for (var i = 0; i < 10; i++)
                tt.Additions_IntN();

            mps_IntN.Stop();


            // Warmup
            tt.Additions_SmartInt();

            mps_SmartInt.Start();

            for (var i = 0; i < 10; i++)
                tt.Additions_SmartInt();

            mps_SmartInt.Stop();

            mps_Int.Report("Int     ");
            mps_Int.Report("Int?    ");
            mps_SmartInt.Report("SmartInt");
        }


    }

    public class SmartIntBM_SimpleOperations
    {
        int cycles = 10000000;
        int count = 10;

        public SmartIntBM_SimpleOperations()
        {
        }

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

        public System.Int32? Additions_IntN()
        {
            System.Int32? s = 0;
            System.Int32? d = 7;

            for (var cc = 0; cc < cycles; cc++)
            {
                s = 0;
                d = 7;

                for (var i = 0; i < count; i++)
                    s += d;
            }

            return s;
        }

    }


}
