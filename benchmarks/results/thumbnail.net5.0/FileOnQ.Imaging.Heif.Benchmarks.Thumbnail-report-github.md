``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  Job-AGFPST : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT

Runtime=.NET 5.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |     Mean |    Error |   StdDev | Allocated native memory | Native memory leak | Allocated |
|------------------- |---------:|---------:|---------:|------------------------:|-------------------:|----------:|
|    Thumbnail_Write | 59.29 ms | 1.184 ms | 1.912 ms |             5,124,425 B |                  - |     288 B |
|  Thumbnail_ToArray | 58.66 ms | 1.163 ms | 1.339 ms |             5,123,869 B |                  - |  66,408 B |
|   Thumbnail_ToSpan | 58.68 ms | 1.150 ms | 1.889 ms |             5,123,597 B |                  - |     120 B |
| Thumbnail_ToStream | 57.98 ms | 1.150 ms | 1.370 ms |             5,123,853 B |                  - |  66,472 B |
