using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Core;

namespace StringCalculator.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEmptyOrOneNumber()
        {
            Assert.AreEqual(0, Calculator.Add(""));
            Assert.AreEqual(0, Calculator.Add(String.Empty));
            Assert.AreEqual(0, Calculator.Add("     "));
            Assert.AreEqual(4, Calculator.Add("4"));
            Assert.AreEqual(4, Calculator.Add(" 4     "));
            Assert.AreEqual(444, Calculator.Add("444"));
            try
            {
                Assert.AreEqual(444, Calculator.Add("-15"));
            }
            catch (Exception ex)
            {
                new AssertFailedException(ex.Message, ex);
            }
        }


        [TestMethod]
        public void TestTwoNumbersOrMore()
        {

            Assert.AreEqual<int>(4, Calculator.Add("2,2"));
            Assert.AreEqual<int>(4, Calculator.Add("2\n2"));
            Assert.AreEqual<int>(6, Calculator.Add("2\n2,2"));
            Assert.AreEqual<int>(24, Calculator.Add("12,12"));
            Assert.AreEqual<int>(36, Calculator.Add("12,12,12 "));
            Assert.AreEqual<int>(48, Calculator.Add(" 12,12,12\n12 "));

        }

        [TestMethod]
        public void TestWithCustomDelimeters()
        {
            Assert.AreEqual<int>(4, Calculator.Add("//;\n2;2"));
            Assert.AreEqual<int>(6, Calculator.Add("//;\n2;2\n2")); // 3x2

            Assert.AreEqual<int>(6, Calculator.Add("//#\n2#2#2")); //3x3

            Assert.AreEqual<int>(54, Calculator.Add("//#\n1#1#2#3#5#8#13#21")); //Fibonacci
        }

        [TestMethod]
        public void TestWithNegatives()
        {

            Assert.AreEqual<int>(400, Calculator.Add("//;\n+200;+200"));
            try
            {
                Assert.AreEqual<int>(4, Calculator.Add("//;\n-2;2;-5;-67;-2345;9;10"));
            }
            catch (Exception ex)
            {
                throw new AssertFailedException(ex.Message, ex);
            }
 
        }
    }
}
