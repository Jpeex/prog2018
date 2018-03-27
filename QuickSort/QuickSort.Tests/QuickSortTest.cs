using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickSort.Tests
{
    [TestClass]
    public class QuickSortTest
    {
        [TestMethod]
        public void TestThreeElements()
        {
            var result = Program.Sort(3, 0, 100);
            var boolTemp = false;
            if ((result[0] < result[1]) & (result[1] < result[2]))
                boolTemp = true;
            Assert.AreEqual(true, boolTemp);
        }

        [TestMethod]
        public void TestHundredElements()
        {
            var result = Program.Sort(100, 3, 3);
            var boolTemp = false;
            if ((result[10] == result[50]) & (result[18] == result[95]))
                boolTemp = true;
            Assert.AreEqual(true, boolTemp);
        }

        [TestMethod]
        public void TestOneThousandElements()
        {
            var result = Program.Sort(1000, 0, 100);
            var boolTemp = false;
            if ((result[10] <= result[50]) && (result[18] <= result[95]) && (result[3] <= result[5]) && (result[9] <= result[81]) && (result[25] <= result[36]) && (result[13] <= result[44]) && (result[55] <= result[77]) && (result[0] <= result[1]) && (result[8] <= result[10]) && (result[56] <= result[85]))
                boolTemp = true;
            Assert.AreEqual(true, boolTemp);
        }

        [TestMethod]
        public void TestNullMassive()
        {
            var result = Program.Sort(0, 0, 0);

            Assert.AreEqual(0 , result.Length);
        }

        //[TestMethod]
        //public void TestMostElements()
        //{
        //    var result = Program.Sort(1500000000, 1, 100);
        //    var boolTemp = false;
        //    for (int i = 0; i < result.Length; i++)
        //        if (result[i] <= result[i + 1])
        //            boolTemp = true;
        //    Assert.AreEqual(true, boolTemp);
        //}
    }
}
