``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5), VM=Hyper-V
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  Job-GHSIOX : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET Framework 4.8  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|                Method |    Mean |    Error |   StdDev | Allocated native memory | Native memory leak |   Allocated |
|---------------------- |--------:|---------:|---------:|------------------------:|-------------------:|------------:|
|    PrimaryImage_Write | 2.989 s | 0.0554 s | 0.0518 s |           222,028,750 B |                  - | 1,951,112 B |
|  PrimaryImage_ToArray | 2.767 s | 0.0547 s | 0.0671 s |           222,028,966 B |                  - | 1,951,112 B |
|   PrimaryImage_ToSpan | 2.828 s | 0.0560 s | 0.1118 s |           222,028,774 B |                  - |           - |
| PrimaryImage_ToStream | 2.774 s | 0.0483 s | 0.0517 s |           222,029,014 B |                  - | 3,894,032 B |
