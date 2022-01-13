``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  Job-EELGXR : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Runtime=.NET 6.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |     Mean |    Error |   StdDev | Allocated native memory | Native memory leak | Allocated |
|------------------- |---------:|---------:|---------:|------------------------:|-------------------:|----------:|
|    Thumbnail_Write | 48.18 ms | 0.541 ms | 0.506 ms |             5,124,409 B |                  - |     832 B |
|  Thumbnail_ToArray | 47.45 ms | 0.539 ms | 0.504 ms |             5,123,597 B |                  - |  66,888 B |
|   Thumbnail_ToSpan | 47.54 ms | 0.425 ms | 0.398 ms |             5,123,853 B |                  - |     600 B |
| Thumbnail_ToStream | 47.74 ms | 0.457 ms | 0.427 ms |             5,123,853 B |                  - |  66,952 B |
