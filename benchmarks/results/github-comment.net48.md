## Benchmark Comparison - .NET Framework 4.8
Benchmarking comparison between this Pull Request and the comitted values at benchmarks/results 

thumbnail
\\\ini 
 summary:
worse: 4, geomean: 1.422
total diff: 4

| Slower                                                       | diff/base | Base Median (ns) | Diff Median (ns) | Modality|
| ------------------------------------------------------------ | ---------:| ----------------:| ----------------:| --------:|
| FileOnQ.Imaging.Heif.Benchmarks.Thumbnail.Thumbnail_ToArray  |      1.43 |      33421400.00 |      47766800.00 |         |
| FileOnQ.Imaging.Heif.Benchmarks.Thumbnail.Thumbnail_Write    |      1.43 |      34192300.00 |      48828200.00 |         |
| FileOnQ.Imaging.Heif.Benchmarks.Thumbnail.Thumbnail_ToSpan   |      1.42 |      33737350.00 |      47794200.00 |         |
| FileOnQ.Imaging.Heif.Benchmarks.Thumbnail.Thumbnail_ToStream |      1.41 |      33929000.00 |      47977900.00 |         |

No Faster results for the provided threshold = 10% and noise filter = 0.3ns.

No file given
 
 \\\

primary
\\\ini 
 summary:
worse: 4, geomean: 1.380
total diff: 4

| Slower                                                             | diff/base | Base Median (ns) | Diff Median (ns) | Modality|
| ------------------------------------------------------------------ | ---------:| ----------------:| ----------------:| --------:|
| FileOnQ.Imaging.Heif.Benchmarks.PrimaryImage.PrimaryImage_ToSpan   |      1.40 |    1626250700.00 |    2280420900.00 |         |
| FileOnQ.Imaging.Heif.Benchmarks.PrimaryImage.PrimaryImage_ToStream |      1.39 |    1631416100.00 |    2270355250.00 |         |
| FileOnQ.Imaging.Heif.Benchmarks.PrimaryImage.PrimaryImage_ToArray  |      1.38 |    1631128700.00 |    2244688500.00 |         |
| FileOnQ.Imaging.Heif.Benchmarks.PrimaryImage.PrimaryImage_Write    |      1.35 |    1635386400.00 |    2206250700.00 |         |

No Faster results for the provided threshold = 10% and noise filter = 0.3ns.

No file given
 
 \\\\r\n\r\n## Benchmark Results - .NET Framework 4.8
<details><summary>thumbnail</summary><p>

 \\\ ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5), VM=Hyper-V
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  Job-GHSIOX : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET Framework 4.8  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

\\\
|             Method |     Mean |    Error |   StdDev | Allocated native memory | Native memory leak | Allocated |
|------------------- |---------:|---------:|---------:|------------------------:|-------------------:|----------:|
|    Thumbnail_Write | 48.81 ms | 0.557 ms | 0.521 ms |             5,124,251 B |              180 B |  74,504 B |
|  Thumbnail_ToArray | 47.88 ms | 0.411 ms | 0.385 ms |             5,123,923 B |              180 B |  74,504 B |
|   Thumbnail_ToSpan | 47.71 ms | 0.353 ms | 0.331 ms |             5,123,939 B |              180 B |         - |
| Thumbnail_ToStream | 47.87 ms | 0.417 ms | 0.390 ms |             5,123,923 B |              180 B | 140,816 B |
 </p></details>
<details><summary>primary</summary><p>

 \\\ ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.17763.2366 (1809/October2018Update/Redstone5), VM=Hyper-V
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  Job-GHSIOX : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT

Runtime=.NET Framework 4.8  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

\\\
|                Method |    Mean |    Error |   StdDev | Allocated native memory | Native memory leak |   Allocated |
|---------------------- |--------:|---------:|---------:|------------------------:|-------------------:|------------:|
|    PrimaryImage_Write | 2.217 s | 0.0366 s | 0.0342 s |           222,029,254 B |              180 B | 1,951,112 B |
|  PrimaryImage_ToArray | 2.258 s | 0.0447 s | 0.0597 s |           222,029,198 B |              180 B | 1,951,112 B |
|   PrimaryImage_ToSpan | 2.282 s | 0.0449 s | 0.0551 s |           222,029,006 B |              180 B |           - |
| PrimaryImage_ToStream | 2.261 s | 0.0440 s | 0.0470 s |           222,029,166 B |              180 B | 3,894,032 B |
 </p></details>

