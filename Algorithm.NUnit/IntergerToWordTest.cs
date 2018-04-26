using NUnit.Framework;
using System;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class IntergerToWordTest
    {
        [TestCase(0, "Zero")]
        [TestCase(2, "Two")]
        [TestCase(10, "Ten")]
        [TestCase(19, "Nineteen")]
        [TestCase(20, "Twenty")]
        [TestCase(23, "Twenty Three")]
        [TestCase(70, "Seventy")]
        [TestCase(73, "Seventy Three")]
        [TestCase(99, "Ninty Nine")]
        [TestCase(100, "One Hundred")]
        [TestCase(101, "One Hundred One")]
        [TestCase(111, "One Hundred Eleven")]
        [TestCase(120, "One Hundred Twenty")]
        [TestCase(137, "One Hundred Thirty Seven")]
        [TestCase(999, "Nine Hundred Ninety Nine")]
        public void IntergerToWordTestConvertHundreds(int num, string expected)
        {
            // Arrange
            var itw = new Algorithm.MicrosoftProblems.IntegerToWord();
                                  
            // Act
            var result = itw.ConvertHundreds(num);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(0, "Zero")]
        [TestCase(2, "Two")]
        [TestCase(10, "Ten")]
        [TestCase(19, "Nineteen")]
        [TestCase(20, "Twenty")]
        [TestCase(23, "Twenty Three")]
        [TestCase(70, "Seventy")]
        [TestCase(73, "Seventy Three")]
        [TestCase(99, "Ninety Nine")]
        [TestCase(100, "One Hundred")]
        [TestCase(101, "One Hundred One")]
        [TestCase(111, "One Hundred Eleven")]
        [TestCase(120, "One Hundred Twenty")]
        [TestCase(137, "One Hundred Thirty Seven")]
        [TestCase(999, "Nine Hundred Ninety Nine")]
        [TestCase(1000, "One Thousand")]
        [TestCase(1001, "One Thousand One")]
        [TestCase(1010, "One Thousand Ten")]
        [TestCase(1016, "One Thousand Sixteen")]
        [TestCase(1200, "One Thousand Two Hundred")]
        [TestCase(1320, "One Thousand Three Hundred Twenty")]
        [TestCase(1328, "One Thousand Three Hundred Twenty Eight")]
        [TestCase(10000, "Ten Thousand")]
        [TestCase(10001, "Ten Thousand One")]
        [TestCase(10011, "Ten Thousand Eleven")]
        [TestCase(10020, "Ten Thousand Twenty")]
        [TestCase(10049, "Ten Thousand Forty Nine")]
        [TestCase(10100, "Ten Thousand One Hundred")]
        [TestCase(10101, "Ten Thousand One Hundred One")]
        [TestCase(10151, "Ten Thousand One Hundred Fifty One")]
        [TestCase(14567, "Fourteen Thousand Five Hundred Sixty Seven")]
        [TestCase(145678, "One Hundred Forty Five Thousand Six Hundred Seventy Eight")]
        [TestCase(9000000, "Nine Million")]
        [TestCase(9145678, "Nine Million One Hundred Forty Five Thousand Six Hundred Seventy Eight")]
        [TestCase(29145678, "Twenty Nine Million One Hundred Forty Five Thousand Six Hundred Seventy Eight")]
        [TestCase(729145678, "Seven Hundred Twenty Nine Million One Hundred Forty Five Thousand Six Hundred Seventy Eight")]
        [TestCase(1000000000, "One Billion")]
        [TestCase(1729145678, "One Billion Seven Hundred Twenty Nine Million One Hundred Forty Five Thousand Six Hundred Seventy Eight")]
        [TestCase(int.MaxValue, "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred Forty Seven")]
        public void IntergerToWordTestConvert(int num, string expected)
        {
            // Arrange
            var itw = new Algorithm.MicrosoftProblems.IntegerToWord();

            // Act
            var result = itw.Convert(num);

            // Assert
            Assert.AreEqual(expected, result);
        }    
    }
}
