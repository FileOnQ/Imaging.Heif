``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1165 (21H1/May2021Update)
AMD Ryzen 9 3950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=6.0.100-preview.6.21355.2
  [Host] : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT

Runtime=.NET Framework 4.8  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|          Method | Mean | Error |
|---------------- |-----:|------:|
| Thumbnail_Write |   NA |    NA |

Benchmarks with issues:
  Thumbnail.Thumbnail_Write: Job-GHTVJT(Runtime=.NET Framework 4.8, InvocationCount=1, LaunchCount=1, UnrollFactor=1)
