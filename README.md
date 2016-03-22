**Simple Smart Types** is a library enriching functionality of native types

**Links:**
[NuGet](https://www.nuget.org/packages/SSTypesLT.dll)

**Summary**

* Contains SmartInt and SmartDouble types enriching native types int and double
* Quick string parsing
* Special ToString and ToStringBuilder methods
* Supports constant BadValue for all types
* Fully compatible with native types

## Content

* [SSTypesLT](#sstypeslt)
* [Performance](#performance)
* [Durability](#durability)
* [Practical Implementation](#practical-implementation)

## SSTypesLT

SSTypesLT is C# solution with tests and examples.


## Performance

The significant performance gain was achieved for string parse operations. ToString methods still require optimization.

Performance was measured by PerfDotNet. See [PerfDotNet](https://github.com/PerfDotNet) for details.

### Test environment for the tests performed

BenchmarkDotNet=v0.7.7.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Core(TM) i7-3610QM CPU @ 2.30GHz, ProcessorCount=4
Host CLR=MS.NET 4.0.30319.42000, Arch=64-bit  [RyuJIT]


### String Parse for Double and SmartDouble

            Method |   AvrTime |   StdDev |    op/s |
------------------ |---------- |--------- |-------- |
      Parse_Double |   2.12 ms | 12.63 us |  472.15 |
 Parse_SmartDouble | 548.47 us |  3.87 us | 1823.27 |


### ToString for Double and SmartDouble

               Method | AvrTime |    StdDev |   op/s |
--------------------- |-------- |---------- |------- |
      ToString_Double | 6.69 ms | 121.04 us | 149.46 |
 ToString_SmartDouble | 7.52 ms | 244.79 us | 132.97 |


### String Parse for Int32 and SmartInt

         Method |   AvrTime |   StdDev |    op/s |
--------------- |---------- |--------- |-------- |
      Parse_Int |   1.60 ms | 48.71 us |  625.87 |
 Parse_SmartInt | 302.99 us |  2.81 us | 3300.49 |


### ToString for Int32 and SmartInt

            Method |   AvrTime |   StdDev |    op/s |
------------------ |---------- |--------- |-------- |
      ToString_Int | 952.83 us |  7.31 us | 1049.51 |
 ToString_SmartInt |   1.46 ms | 13.58 us |  684.06 |


## Durability

Durability is assured by unit tests included into solution.


## Practical Implementation

The solution has been successfully used in [GoMap.Az](http://gomap.az) project. Data workflow load includes about 10 billions string-to-double parsing operations per day.
