``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1165 (21H1/May2021Update)
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.6.21355.2
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  Job-YMIZFC : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT

Runtime=.NET 5.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |    Mean |    Error |   StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated | Allocated native memory | Native memory leak |
|------------------- |--------:|---------:|---------:|------:|------:|------:|----------:|------------------------:|-------------------:|
| PrimaryImage_Write | 1.665 s | 0.0083 s | 0.0078 s |     - |     - |     - |      80 B |           210,038,234 B |       18,048,557 B |
