using System;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartIntExample.AssignmentByte();
            SmartIntExample.AssignmentSingle();
            SmartIntExample.AssignmentInt();
            SmartIntExample.AssignmentLong();
            SmartIntExample.AssignmentDouble();
            SmartIntExample.AssignmentSmartDouble();
            SmartIntExample.AssignmentDecimal();

            SmartIntExample.IteratorIndexer();

            Console.ReadLine();
        }
    }
}
