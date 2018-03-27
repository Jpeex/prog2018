using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class Program
    {
        static void Main()
        {
            Sort(2, 0, 100);
        }
        public static long[] Sort(long length, int x, int y)
        {
            long[] array = new long[length];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(x, y);
            Array.Sort(array);
            return (array);
        } 
    }
}
