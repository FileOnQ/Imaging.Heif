``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.17763.2114 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=5.0.400
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  Job-UAQZJA : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT

Runtime=.NET 5.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|                Method |    Mean |    Error |   StdDev | Gen 0 | Gen 1 | Gen 2 |   Allocated | Allocated native memory | Native memory leak |
|---------------------- |--------:|---------:|---------:|------:|------:|------:|------------:|------------------------:|-------------------:|
|    PrimaryImage_Write | 2.736 s | 0.0409 s | 0.0341 s |     - |     - |     - |       256 B |           222,029,948 B |                  - |
|  PrimaryImage_ToArray | 2.896 s | 0.0486 s | 0.0596 s |     - |     - |     - | 1,943,008 B |           222,029,376 B |                  - |
|   PrimaryImage_ToSpan | 2.775 s | 0.0372 s | 0.0310 s |     - |     - |     - |        88 B |           222,029,424 B |                  - |
| PrimaryImage_ToStream | 2.738 s | 0.0416 s | 0.0389 s |     - |     - |     - | 1,943,072 B |           222,029,552 B |                  - |
