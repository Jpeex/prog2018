using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickSort.Tests
{
    [TestClass]
   public class QuickSortTest
   {
        [TestMethod]
        public void TestThreeMassive()
        {
            int[] wtfMassive = new int[3];
            var array = new Random();
            var boolElement = false;

            for (int i = 0; i< 3; i++)
                wtfMassive[i] = array.Next();
           Program.QuickSort(wtfMassive);
            
            if (wtfMassive[0] <= wtfMassive[1] && wtfMassive[1] <= wtfMassive[2])
                boolElement = true;
            Assert.AreEqual(true, boolElement);
        }

        [TestMethod]
        public void TestHundredMassive()
        {
            int[] wtfMassive = new int[100];
            var boolElement = false;

            for (int i = 0; i< wtfMassive.Length; i++)
                wtfMassive[i] = 1;

            Program.QuickSort(wtfMassive);
            for (int i = 0; i< wtfMassive.Length - 1; i++)
            {
               if (wtfMassive[i] > wtfMassive[i + 1])
                {
                    boolElement = true;
                    break;
                }
            }
            Assert.AreEqual(false, boolElement);
        }

        [TestMethod]
        public void TestOneThousandMassive()
        {
            var array = new Random();
            int size = 1000;
            int[] wtfMassive = new int[size];
            var boolElement = false;

            for (int i = 0; i<size; i++)
                wtfMassive[i] = array.Next();

            Program.QuickSort(wtfMassive);
            for (int i = 0; i< 10; i++)
            {
                int j = array.Next(0, 998);
                if (wtfMassive[j] > wtfMassive[j + 1])
                {
                    boolElement = true;
                    break;
                }
            }
            Assert.AreEqual(false, boolElement);
        }

        [TestMethod]
        public void TestEmptyMassive()
        {
            int[] wtfMassive = new int[0];
            var boolElement = false;
            Program.QuickSort(wtfMassive);

            if (wtfMassive.Length == 0)
                boolElement = true;

            Assert.AreEqual(true, boolElement);
        }

        [TestMethod]
        public void TestHugeMassive()
        {
            var array = new Random();
           int size = 1500000000;
            int[] wtfMassive = new int[size];
            var boolElement = false;

            for (int i = 0; i<size; i++)
                wtfMassive[i] = array.Next();
            Program.QuickSort(wtfMassive);

            for (int i = 0; i< 10; i++)
            {
                int j = array.Next(0, 1500000000 - 2);
               if (wtfMassive[j] > wtfMassive[j + 1])
                {
                    boolElement = true;
                    break;
                }
            }
            Assert.AreEqual(false, boolElement);
        }   
    }
}