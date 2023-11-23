using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;

namespace CalculatorTests
{
    [TestClass]
    public class EvaluateTests
    {
        [TestMethod]
        public void Test1()
        {
            var expr = "(1 + 6) * 2;";
            Assert.AreEqual(14, Calculator.Evaluate(expr));
        }

        [TestMethod]
        public void Test2()
        {
            var expr = "1 + 3;";
            Assert.AreEqual(4, Calculator.Evaluate(expr));
        }

        [TestMethod]
        public void Test3()
        {
            var expr = "1 + 7 + 2 + 3 * 8 * (1 + 3);";
            Assert.AreEqual(106, Calculator.Evaluate(expr));
        }

        [TestMethod]
        public void Test4()
        {
            var expr = "(5 + 5) * (2 + 3);";
            Assert.AreEqual(50, Calculator.Evaluate(expr));
        }

        [TestMethod]
        public void Test5()
        {
            var expr = "2 * 3;";
            Assert.AreEqual(6, Calculator.Evaluate(expr));
        }

        [TestMethod]
        public void Test6()
        {
            var expr = "2 * 3 + 2;";
            Assert.AreEqual(8, Calculator.Evaluate(expr));
        }

        [TestMethod]
        public void Test7()
        {
            var expr = "2 * 3 * 5;";
            Assert.AreEqual(30, Calculator.Evaluate(expr));
        }

        [TestMethod]
        public void Test8()
        {
            var expr = "10 + 2 * 5;";
            Assert.AreEqual(20, Calculator.Evaluate(expr));
        }
        
        [TestMethod]
        public void Test9()
        {
            var expr = "(9 + (7 + (98 + 3) * 23)) * 2;";
            Assert.AreEqual(4678, Calculator.Evaluate(expr));
        }
    }
}