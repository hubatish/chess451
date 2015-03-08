using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Position p = new Position(8, 8);

            p.X = -1;
            Assert.AreEqual(p.X, -1);
            p.Y = -1;
            Assert.AreEqual(p.Y, -1);
        }
    }
}
