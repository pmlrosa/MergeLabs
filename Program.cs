// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using MergeLabs;


List<object[]> data = TestDataSet.GenerateBasicDataSet().ToList();

Console.WriteLine($"Simple Csv transformation{Environment.NewLine}");
for (int i = 0; i < data.Count; i++)
{
    Console.WriteLine($"{data[i][0]}");
    Console.WriteLine(CsvManager.SimpleTransformCsv((string)data[i][1]));
    Console.WriteLine("");
}

Console.WriteLine("=========");
Console.WriteLine("=========");
Console.WriteLine($"{Environment.NewLine}Csv transformation{Environment.NewLine}");
for (int i = 0; i < data.Count; i++)
{
    Console.WriteLine($"{data[i][0]}");
    Console.WriteLine(CsvManager.TransformCsv((string)data[i][1]));
    Console.WriteLine("");
}

ManualConfig manualConfig = DefaultConfig.Instance.WithArtifactsPath($"{Environment.CurrentDirectory}\\BenchmarkResults");
BenchmarkRunner.Run<BenchmarkCsvManager>(manualConfig);
