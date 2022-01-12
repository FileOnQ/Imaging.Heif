``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT
  Job-RCUIXA : .NET 5.0.8 (5.0.821.31504), X64 RyuJIT

Runtime=.NET 5.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|                Method |    Mean |    Error |   StdDev | Allocated native memory | Native memory leak |   Allocated |
|---------------------- |--------:|---------:|---------:|------------------------:|-------------------:|------------:|
|    PrimaryImage_Write | 2.277 s | 0.0441 s | 0.0413 s |           222,029,332 B |                  - |       256 B |
|  PrimaryImage_ToArray | 2.331 s | 0.0388 s | 0.0363 s |           222,028,840 B |                  - | 1,943,008 B |
|   PrimaryImage_ToSpan | 2.349 s | 0.0466 s | 0.0638 s |           222,028,744 B |                  - |        88 B |
| PrimaryImage_ToStream | 2.338 s | 0.0285 s | 0.0252 s |           222,028,968 B |                  - | 1,943,072 B |
