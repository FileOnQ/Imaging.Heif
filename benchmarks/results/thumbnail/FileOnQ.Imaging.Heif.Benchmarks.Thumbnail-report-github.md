``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.17763.2114 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=5.0.400
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  Job-FJVQTT : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT

Runtime=.NET 5.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |     Mean |    Error |   StdDev |   Median | Gen 0 | Gen 1 | Gen 2 | Allocated | Allocated native memory | Native memory leak |
|------------------- |---------:|---------:|---------:|---------:|------:|------:|------:|----------:|------------------------:|-------------------:|
|    Thumbnail_Write | 52.41 ms | 1.036 ms | 2.746 ms | 52.50 ms |     - |     - |     - |     288 B |             5,125,137 B |                  - |
|  Thumbnail_ToArray | 48.68 ms | 1.194 ms | 3.503 ms | 47.95 ms |     - |     - |     - |  66,408 B |             5,124,581 B |                  - |
|   Thumbnail_ToSpan | 50.10 ms | 1.206 ms | 3.555 ms | 49.83 ms |     - |     - |     - |     120 B |             5,124,581 B |                  - |
| Thumbnail_ToStream | 48.84 ms | 1.220 ms | 3.577 ms | 47.63 ms |     - |     - |     - |  66,472 B |             5,124,581 B |                  - |
