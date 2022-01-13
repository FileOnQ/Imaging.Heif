``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5), VM=Hyper-V
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  Job-GHSIOX : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET Framework 4.8  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |     Mean |    Error |   StdDev |   Median | Allocated native memory | Native memory leak | Allocated |
|------------------- |---------:|---------:|---------:|---------:|------------------------:|-------------------:|----------:|
|    Thumbnail_Write | 59.36 ms | 1.167 ms | 1.091 ms | 59.51 ms |             5,123,891 B |                  - |  74,504 B |
|  Thumbnail_ToArray | 59.17 ms | 1.157 ms | 2.364 ms | 58.64 ms |             5,123,307 B |                  - |  74,504 B |
|   Thumbnail_ToSpan | 59.17 ms | 1.047 ms | 1.779 ms | 58.91 ms |             5,123,579 B |                  - |         - |
| Thumbnail_ToStream | 60.52 ms | 1.209 ms | 2.851 ms | 59.45 ms |             5,123,563 B |                  - | 140,816 B |
