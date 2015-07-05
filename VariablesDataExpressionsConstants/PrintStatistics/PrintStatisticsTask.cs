using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintStatistics
{
    class PrintStatisticsTask
    {
        static void Main(string[] args)
        {
            double[] testArray = new double[5] {2.123,123.123,12313,43,34};
            double max = FindMaxInArray(testArray);
            double min = FindMinInArray(testArray);
            double average = FindAverageInArray(testArray);
            PrintInformation(min, max, average);
        }

        public static double FindMaxInArray(double[] array)
        {
            double max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }

            return max;
        }

        private static double FindMinInArray(double[] array)
        {
            double min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
            }

            return min;
        }

        private static double FindAverageInArray(double[] array)
        {
            double sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum / array.Length;
        }

        private static void PrintInformation(double minElement, double maxElement, double averageOfElements)
        {
            Console.WriteLine("Max element: {0}; Min element: {1}; Average: {2}", maxElement, minElement, averageOfElements);
        }
    }
}
