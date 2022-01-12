``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1415 (21H1/May2021Update)
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  Job-CIJBHG : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT

Runtime=.NET 5.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |     Mean |    Error |   StdDev | Allocated native memory | Native memory leak | Allocated |
|------------------- |---------:|---------:|---------:|------------------------:|-------------------:|----------:|
|    Thumbnail_Write | 33.89 ms | 0.232 ms | 0.217 ms |             5,124,079 B |                  - |     288 B |
|  Thumbnail_ToArray | 33.37 ms | 0.314 ms | 0.279 ms |             5,123,551 B |                  - |  66,408 B |
|   Thumbnail_ToSpan | 33.66 ms | 0.272 ms | 0.241 ms |             5,123,551 B |                  - |     120 B |
| Thumbnail_ToStream | 33.61 ms | 0.320 ms | 0.284 ms |             5,123,551 B |                  - |  66,472 B |
