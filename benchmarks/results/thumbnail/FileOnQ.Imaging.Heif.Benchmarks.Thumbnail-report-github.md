``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.17763.2114 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=5.0.400
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  Job-VLDWLB : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT

Runtime=.NET 5.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|          Method |     Mean |    Error |   StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated | Allocated native memory | Native memory leak |
|---------------- |---------:|---------:|---------:|------:|------:|------:|----------:|------------------------:|-------------------:|
| Thumbnail_Write | 60.91 ms | 1.208 ms | 2.269 ms |     - |     - |     - |     112 B |             4,937,059 B |          295,469 B |
