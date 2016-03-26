**Performance tests

Compoaring Int.Parse and SmartInt.Parse.
SmartInt.Parse shows more than 4 times better performance.


```ini
BenchmarkDotNet=v0.9.1.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Core(TM) i7-3610QM CPU @ 2.30GHz, ProcessorCount=4
Frequency=2241298 ticks, Resolution=446.1700 ns
HostCLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]

```
                  Method |     Median |    StdDev |
------------------------ |----------- |---------- |
      Parse_Int_ps_Digit | 16.0447 ms | 0.1294 ms |
 Parse_SmartInt_ps_Digit |  3.0904 ms | 0.0373 ms |
      Parse_Int_ns_Digit | 16.7546 ms | 0.2413 ms |
 Parse_SmartInt_ns_Digit |  4.1857 ms | 0.1818 ms |
       Parse_Int_9_Digit | 16.1033 ms | 0.3239 ms |
  Parse_SmartInt_9_Digit |  3.4312 ms | 0.0584 ms |
      Parse_Int_9p_Digit | 15.9404 ms | 0.3320 ms |
 Parse_SmartInt_9p_Digit |  3.3714 ms | 0.2657 ms |
      Parse_Int_9n_Digit | 16.9156 ms | 0.9994 ms |
 Parse_SmartInt_9n_Digit |  3.2374 ms | 0.1291 ms |
       Parse_Int_8_Digit | 15.2415 ms | 0.7650 ms |
  Parse_SmartInt_8_Digit |  3.1400 ms | 0.0735 ms |
      Parse_Int_8p_Digit | 15.2498 ms | 0.2720 ms |
 Parse_SmartInt_8p_Digit |  3.1960 ms | 0.3934 ms |
      Parse_Int_8n_Digit | 15.7260 ms | 0.3031 ms |
 Parse_SmartInt_8n_Digit |  3.0148 ms | 0.0385 ms |


One digital values:

                  Method |      Median |     StdDev |
------------------------ |------------ |----------- |
       Parse_Int_1_Digit | 871.4395 ns | 26.4223 ns |
  Parse_SmartInt_1_Digit | 111.4159 ns |  8.1701 ns |
      Parse_Int_1p_Digit | 870.3970 ns | 12.2848 ns |
 Parse_SmartInt_1p_Digit | 155.0607 ns |  7.4938 ns |
      Parse_Int_1n_Digit | 928.7017 ns | 51.0293 ns |
 Parse_SmartInt_1n_Digit | 155.4004 ns |  9.6051 ns |

