``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  Job-GUHUPJ : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Runtime=.NET 6.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|                Method |    Mean |    Error |   StdDev | Allocated native memory | Native memory leak |   Allocated |
|---------------------- |--------:|---------:|---------:|------------------------:|-------------------:|------------:|
|    PrimaryImage_Write | 2.593 s | 0.0349 s | 0.0326 s |           222,029,092 B |                  - |       848 B |
|  PrimaryImage_ToArray | 2.529 s | 0.0325 s | 0.0288 s |           222,028,696 B |                  - | 1,943,536 B |
|   PrimaryImage_ToSpan | 2.598 s | 0.0375 s | 0.0350 s |           222,028,488 B |                  - |       616 B |
| PrimaryImage_ToStream | 2.605 s | 0.0373 s | 0.0330 s |           222,028,552 B |                  - | 1,943,600 B |
