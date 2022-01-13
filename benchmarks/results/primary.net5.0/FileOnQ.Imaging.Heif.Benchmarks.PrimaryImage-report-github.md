``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  Job-SNCXBV : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT

Runtime=.NET 5.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|                Method |    Mean |    Error |   StdDev | Allocated native memory | Native memory leak |   Allocated |
|---------------------- |--------:|---------:|---------:|------------------------:|-------------------:|------------:|
|    PrimaryImage_Write | 2.906 s | 0.0174 s | 0.0145 s |           222,029,380 B |                  - |       256 B |
|  PrimaryImage_ToArray | 2.928 s | 0.0267 s | 0.0250 s |           222,028,824 B |                  - | 1,943,056 B |
|   PrimaryImage_ToSpan | 2.981 s | 0.0252 s | 0.0236 s |           222,028,216 B |                  - |        88 B |
| PrimaryImage_ToStream | 2.977 s | 0.0276 s | 0.0245 s |           222,028,888 B |                  - | 1,943,120 B |
