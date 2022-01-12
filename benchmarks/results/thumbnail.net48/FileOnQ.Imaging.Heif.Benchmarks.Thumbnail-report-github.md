``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1415 (21H1/May2021Update)
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  Job-GHSIOX : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET Framework 4.8  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |     Mean |    Error |   StdDev | Allocated native memory | Native memory leak | Allocated |
|------------------- |---------:|---------:|---------:|------------------------:|-------------------:|----------:|
|    Thumbnail_Write | 34.15 ms | 0.432 ms | 0.383 ms |             5,123,909 B |              166 B |  74,504 B |
|  Thumbnail_ToArray | 33.40 ms | 0.237 ms | 0.211 ms |             5,123,865 B |              166 B |  74,504 B |
|   Thumbnail_ToSpan | 33.93 ms | 0.620 ms | 0.550 ms |             5,123,865 B |              166 B |         - |
| Thumbnail_ToStream | 33.91 ms | 0.263 ms | 0.233 ms |             5,123,865 B |              166 B | 140,816 B |
