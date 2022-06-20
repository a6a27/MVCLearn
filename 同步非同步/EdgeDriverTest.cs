using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace 同步非同步
{
    [TestClass]
    public class EdgeDriverTest
    {
        [TestMethod()]
        public void AddTest()
        {
            int firstNumber = 1;
            int secondNumber = 2;
            int expected = 3;
            int actual;
            actual = Add(firstNumber, secondNumber);
            Assert.AreEqual(expected, actual);
        }

        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
