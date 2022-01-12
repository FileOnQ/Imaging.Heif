``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1415 (21H1/May2021Update)
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  Job-KXHYYP : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT

Runtime=.NET 6.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |     Mean |    Error |   StdDev | Allocated native memory | Native memory leak | Allocated |
|------------------- |---------:|---------:|---------:|------------------------:|-------------------:|----------:|
|    Thumbnail_Write | 33.66 ms | 0.288 ms | 0.269 ms |             5,124,079 B |                  - |     832 B |
|  Thumbnail_ToArray | 33.74 ms | 0.358 ms | 0.317 ms |             5,123,551 B |                  - |  66,888 B |
|   Thumbnail_ToSpan | 33.61 ms | 0.451 ms | 0.400 ms |             5,123,583 B |               32 B |     600 B |
| Thumbnail_ToStream | 33.48 ms | 0.480 ms | 0.449 ms |             5,123,583 B |               32 B |  66,952 B |
