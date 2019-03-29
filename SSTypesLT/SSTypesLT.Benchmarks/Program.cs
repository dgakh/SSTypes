
using BenchmarkDotNet.Running;
using System;

namespace PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SmartBool_BM>();

            //BenchmarkRunner.Run<SmartIntBM_SimpleOperations>();
            //BenchmarkRunner.Run<SmartDoubleBM_SimpleOperations>();

            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_ns_Digit>();
            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_ps_Digit>();

            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_1_Digit>();
            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_1n_Digit>();
            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_1p_Digit>();

            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_8_Digit>();
            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_8n_Digit>();
            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_8p_Digit>();

            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_9_Digit>();
            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_9n_Digit>();
            //BenchmarkRunner.Run<SmartIntBM_Parse_IntSmartInt_9p_Digit>();

            //BenchmarkRunner.Run<SmartDouble_Double_Parse>();
            //new BenchmarkRunner().RunCompetition(new SmartDouble_Double_Parse());
            //new BenchmarkRunner().RunCompetition(new SmartDouble_Double_ToString());
            //new BenchmarkRunner().RunCompetition(new SmartInt_Int_Parse());
            //new BenchmarkRunner().RunCompetition(new SmartInt_Int_ToString());

            //Console.ReadKey();
        }
    }

}
