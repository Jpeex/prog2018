using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTableTests
{

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void ThreeElements()
        {
            var wtf = new HashTable.HashTable(3);

            wtf.PutPair("1", "Один");
            wtf.PutPair("2", "Два");
            wtf.PutPair("3", "Три");

            Assert.AreEqual(wtf.GetValueByKey("1"), "Один");
            Assert.AreEqual(wtf.GetValueByKey("2"), "Два");
            Assert.AreEqual(wtf.GetValueByKey("3"), "Три");
        }

        [TestMethod]
        public void TwoElements()
        {
            var wtf = new HashTable.HashTable(3);

            wtf.PutPair("1", "Один");
            wtf.PutPair("1", "Два");

            Assert.AreEqual(wtf.GetValueByKey("1"), "Два");
        }

        [TestMethod]
        public void BigElements()
        {
            var wtf = new HashTable.HashTable(10000);

            for (int i = 0; i < 10000; i++)
            {
                wtf.PutPair(i, i + "Один");
            }

            Assert.AreEqual(wtf.GetValueByKey(1), "1Один");
        }

        [TestMethod]
        public void DifficultTest()
        {
            var wtf = new HashTable.HashTable(11000);

            for (int i = 0; i < 10000; i++)
            {
                wtf.PutPair(i, i + "Один");
            }

            for (int i = 10000; i < 11000; i++)
            {
                Assert.AreEqual(wtf.GetValueByKey(i), null);
            }
        }
    }
}