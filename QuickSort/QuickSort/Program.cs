using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class Program
    {
        public static void QuickSort(int[] array, int start, int end)
        {
            if ((start == end) | (array.Length == 0)) return;
            int memory = start;
            var turn = array[end];
            for (int i = start; i<end; i++)
            {
                if (array[i] < turn)
                {
                    Change(array, i, memory);
                    memory++;
                }
            }
            Change(array, memory, end);
            if (memory > start) QuickSort(array, start, memory - 1);
            if (memory < end) QuickSort(array, memory + 1, end);
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public static void Change(int[] array, int i, int j)
        {
            int variable;
            variable = array[i];
            array[i] = array[j];
            array[j] = variable;
        }

        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
} 