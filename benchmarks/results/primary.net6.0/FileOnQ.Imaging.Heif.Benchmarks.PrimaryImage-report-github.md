``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  Job-AMEHTW : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Runtime=.NET 6.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|                Method |    Mean |    Error |   StdDev | Allocated native memory | Native memory leak |   Allocated |
|---------------------- |--------:|---------:|---------:|------------------------:|-------------------:|------------:|
|    PrimaryImage_Write | 2.869 s | 0.0189 s | 0.0167 s |           222,029,556 B |                  - |       848 B |
|  PrimaryImage_ToArray | 2.887 s | 0.0384 s | 0.0340 s |           222,028,872 B |                  - | 1,943,536 B |
|   PrimaryImage_ToSpan | 2.968 s | 0.0271 s | 0.0241 s |           222,029,080 B |                  - |       616 B |
| PrimaryImage_ToStream | 2.978 s | 0.0368 s | 0.0344 s |           222,028,952 B |                  - | 1,943,600 B |
