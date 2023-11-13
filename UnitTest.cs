using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeLabs
{
    [TestClass]
    public class UnitTest
    {
        //To fix the error of "The entry point of the program is global code"
        //https://andrewlock.net/fixing-the-error-program-has-more-than-one-entry-point-defined-for-console-apps-containing-xunit-tests/
        
        public required TestContext TestContext { get; init; }

        [TestMethod]
        [DynamicData(nameof(TestDataSet.GenerateBasicDataSet), typeof(TestDataSet), DynamicDataSourceType.Method)]
        public void TestSimpleTransformCsvMethod(string display_name, string input, string expected)
        {
            TestContext.WriteLine($" > {display_name}");
            string results = CsvManager.SimpleTransformCsv(input);
            Assert.AreEqual(expected, results);
        }

        [TestMethod]
        [DynamicData(nameof(TestDataSet.GenerateBasicDataSet), typeof(TestDataSet), DynamicDataSourceType.Method)]
        public void TestTransformCsvMethod(string display_name, string input, string expected)
        {
            TestContext.WriteLine($" > {display_name}");
            string results = CsvManager.TransformCsv(input);
            Assert.AreEqual(expected, results);
        }
    }
}