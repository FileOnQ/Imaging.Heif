``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5), VM=Hyper-V
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  Job-GHSIOX : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET Framework 4.8  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |     Mean |    Error |   StdDev | Allocated native memory | Native memory leak | Allocated |
|------------------- |---------:|---------:|---------:|------------------------:|-------------------:|----------:|
|    Thumbnail_Write | 60.80 ms | 1.188 ms | 2.658 ms |             5,124,251 B |              180 B |  74,504 B |
|  Thumbnail_ToArray | 60.41 ms | 1.086 ms | 1.592 ms |             5,123,923 B |              180 B |  74,504 B |
|   Thumbnail_ToSpan | 60.79 ms | 1.181 ms | 1.655 ms |             5,123,923 B |              180 B |         - |
| Thumbnail_ToStream | 58.00 ms | 1.130 ms | 1.429 ms |             5,123,923 B |              180 B | 140,816 B |
