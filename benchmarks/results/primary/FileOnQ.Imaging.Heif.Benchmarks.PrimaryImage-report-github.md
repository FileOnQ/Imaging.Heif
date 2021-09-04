``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.17763.2114 (1809/October2018Update/Redstone5)
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=5.0.400
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  Job-DXULZI : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT

Runtime=.NET 5.0  InvocationCount=1  LaunchCount=1  
UnrollFactor=1  

```
|             Method |    Mean |    Error |   StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated | Allocated native memory | Native memory leak |
|------------------- |--------:|---------:|---------:|------:|------:|------:|----------:|------------------------:|-------------------:|
| PrimaryImage_Write | 2.947 s | 0.0303 s | 0.0268 s |     - |     - |     - |     128 B |           210,038,978 B |       18,048,557 B |
