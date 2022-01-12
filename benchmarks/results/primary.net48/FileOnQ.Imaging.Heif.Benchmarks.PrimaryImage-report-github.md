``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5), VM=Hyper-V
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  Job-GHSIOX : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET Framework 4.8  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|                Method |    Mean |    Error |   StdDev | Allocated native memory | Native memory leak |   Allocated |
|---------------------- |--------:|---------:|---------:|------------------------:|-------------------:|------------:|
|    PrimaryImage_Write | 2.141 s | 0.0131 s | 0.0123 s |           222,029,638 B |              180 B | 1,951,112 B |
|  PrimaryImage_ToArray | 2.144 s | 0.0081 s | 0.0063 s |           222,029,326 B |              180 B | 1,951,112 B |
|   PrimaryImage_ToSpan | 2.163 s | 0.0037 s | 0.0035 s |           222,029,358 B |              180 B |           - |
| PrimaryImage_ToStream | 2.270 s | 0.0350 s | 0.0327 s |           222,029,278 B |              180 B | 3,894,032 B |
