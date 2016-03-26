**Simple Smart Types** is a library enriching functionality of native types

**Links:**
[NuGet](https://www.nuget.org/packages/SSTypesLT.dll)
[PerfDotNet](https://github.com/PerfDotNet)


**Summary**

* Contains SmartInt and SmartDouble types enriching native .NET types Int32 and Double
* Fast string parsing
* Special ToString and ToStringBuilder methods
* Supports constant BadValue for all types
* Fully compatible with native types Int32 and Double
* Almost fully compatible with nullable types Int32? and Double?
* Universal, save, and easy to use

## Content

* [SSTypesLT](#sstypeslt)
* [Performance](#performance)
* [Durability](#durability)
* [Practical Implementation](#practical-implementation)
* [Acknowledgments](#acknowledgments)

## SSTypesLT

SSTypesLT is C# solution with tests and examples.

[Documentation](https://github.com/dgakh/SSTypes/tree/master/SSTypesLT/Docs)

## Performance

The significant performance gain was achieved for string parse operations. ToString methods still require optimization.

Performance was measured by PerfDotNet. See [PerfDotNet](https://github.com/PerfDotNet) for details.

### Test environment for the tests performed
```ini
BenchmarkDotNet=v0.9.1.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Core(TM) i7-3610QM CPU @ 2.30GHz, ProcessorCount=4
Frequency=2241298 ticks, Resolution=446.1700 ns
HostCLR=MS.NET 4.0.30319.42000, Arch=64-bit RELEASE [RyuJIT]

```

### String Parse for Double and SmartDouble

            Method |        Median |     StdDev |
------------------ |-------------- |----------- |
      Parse_Double | 2,233.6640 us | 37.0084 us |
 Parse_SmartDouble |   576.6582 us |  9.8574 us |


### String Parse for 9-digit Int32 and SmartInt numbers

                 Method |     Median |    StdDev |
----------------------- |----------- |---------- |
      Parse_Int_9_Digit | 16.3008 ms | 0.2596 ms |
 Parse_SmartInt_9_Digit |  3.4532 ms | 0.0471 ms |



## Durability

Durability is assured by unit tests included into solution.


## Practical Implementation

The solution has been successfully used in [GoMap.Az](http://gomap.az) project. Data workflow load includes about 10 billions string-to-double parsing operations per day.


## Acknowledgments

Thanks to the following people for their contributions:

[AndreyAkinshin] (https://github.com/AndreyAkinshin) for his advices regarding performance tests.

[Samir Salimkhanov] () for his advices regarding unit tests.

