``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  Job-BSEFYJ : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Runtime=.NET 6.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |     Mean |    Error |   StdDev |   Median | Allocated native memory | Native memory leak | Allocated |
|------------------- |---------:|---------:|---------:|---------:|------------------------:|-------------------:|----------:|
|    Thumbnail_Write | 46.47 ms | 0.924 ms | 2.300 ms | 47.67 ms |             5,124,153 B |                  - |     832 B |
|  Thumbnail_ToArray | 47.60 ms | 0.388 ms | 0.363 ms | 47.55 ms |             5,123,917 B |               64 B |  66,888 B |
|   Thumbnail_ToSpan | 45.27 ms | 0.902 ms | 2.229 ms | 46.29 ms |             5,123,869 B |                  - |     600 B |
| Thumbnail_ToStream | 45.89 ms | 0.917 ms | 1.994 ms | 46.44 ms |             5,123,869 B |                  - |  66,952 B |
