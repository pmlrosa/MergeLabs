```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3570/22H2/2022Update)
Intel Core i7-5500U CPU 2.40GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET SDK 7.0.403
  [Host]     : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.13 (7.0.1323.51816), X64 RyuJIT AVX2


```
| Method             | Mean     | Error     | StdDev    | Rank | Gen0   | Allocated |
|------------------- |---------:|----------:|----------:|-----:|-------:|----------:|
| TransformCsv       | 1.151 μs | 0.0394 μs | 0.1136 μs |    1 | 1.0471 |   2.14 KB |
| SimpleTransformCsv | 6.303 μs | 0.2621 μs | 0.7519 μs |    2 | 0.9003 |   1.87 KB |
