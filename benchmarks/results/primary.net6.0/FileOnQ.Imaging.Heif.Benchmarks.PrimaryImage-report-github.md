``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1415 (21H1/May2021Update)
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  Job-BOOZET : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT

Runtime=.NET 6.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|                Method |    Mean |    Error |   StdDev | Allocated native memory | Native memory leak |   Allocated |
|---------------------- |--------:|---------:|---------:|------------------------:|-------------------:|------------:|
|    PrimaryImage_Write | 1.635 s | 0.0043 s | 0.0036 s |           222,028,826 B |                  - |       848 B |
|  PrimaryImage_ToArray | 1.630 s | 0.0031 s | 0.0029 s |           222,028,298 B |                  - | 1,943,536 B |
|   PrimaryImage_ToSpan | 1.627 s | 0.0024 s | 0.0023 s |           222,028,442 B |                  - |       616 B |
| PrimaryImage_ToStream | 1.631 s | 0.0050 s | 0.0047 s |           222,027,978 B |                  - | 1,943,600 B |
