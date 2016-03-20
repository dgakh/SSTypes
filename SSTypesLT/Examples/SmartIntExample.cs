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



    }


}
