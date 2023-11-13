using BenchmarkDotNet.Attributes;

namespace MergeLabs
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkCsvManager
    {
        //https://www.c-sharpcorner.com/article/performance-benchmarking-with-benchmarkdotnet/
        
        private List<object[]> Data = TestDataSet.GenerateBasicDataSet().ToList();

        [Benchmark]
        public void SimpleTransformCsv()
        {
            for (int i = 0; i < Data.Count; i++)
            {
                CsvManager.SimpleTransformCsv((string)Data[i][1]);
            }
        }

        [Benchmark]
        public void TransformCsv()
        {
            for (int i = 0; i < Data.Count; i++)
            {
                CsvManager.TransformCsv((string)Data[i][1]);
            }
        }
    }
}
