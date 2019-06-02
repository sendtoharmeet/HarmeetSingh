using BusinessApi;
using DataContract;
using NUnit.Framework;

namespace Tests
{
    public class DataProcessorTest
    {
        IDataProcessor _dataProcessor;

        [SetUp]
        public void Setup()
        {
            _dataProcessor = new DataProcessor(null);
        }

        [Test]
        public void ConversionPositivePassed()
        {
            Person inputData = new Person() { Name = "Test1", Amount = 123.456M };
            var outputData = _dataProcessor.ProcessPerson(inputData);
            Assert.AreEqual(outputData.AmountText, "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS");
        }

        [Test]
        public void ConversionMaxLimitTest()
        {
            Person inputData = new Person() { Name = "Test1", Amount = 999999999999999999M };
            var outputData = _dataProcessor.ProcessPerson(inputData);
            Assert.AreEqual(outputData.AmountText, "NINE HUNDRED AND NINETY-NINE QUADRILLION NINE HUNDRED AND NINETY-NINE TRILLION NINE HUNDRED AND NINETY-NINE BILLION NINE HUNDRED AND NINETY-NINE MILLION NINE HUNDRED AND NINETY-NINE THOUSAND NINE HUNDRED AND NINETY-NINE DOLLARS");
        }

        [Test]
        public void ConversionExceedsLimitTest()
        {
            Person inputData = new Person() { Name = "Test1", Amount = 99999999999999999999.456M };
            var outputData = _dataProcessor.ProcessPerson(inputData);
            Assert.AreEqual(outputData.AmountText, string.Empty);
        }
    }
}