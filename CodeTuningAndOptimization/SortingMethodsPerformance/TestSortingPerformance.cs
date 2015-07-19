using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethodsPerformance
{
    public class TestSortingPerformance
    {
        private const int ARRAYS_LENGTH = 200;
        private const double DOUBLE_NUMBERS_MULTIPLIER = 0.3333d;
        private static Random generator = new Random();
        private static Stopwatch stopwatch = new Stopwatch();

        public static void Main(string[] args)
        {
            int[] testIntegers = new int[ARRAYS_LENGTH]; ;
            double[] testDoubles = new double[ARRAYS_LENGTH]; ;
            string[] testStrings = new string[ARRAYS_LENGTH];
            Console.WriteLine("Test InsertionSort with int, double and string!");
            GenerateArrays(testIntegers, testDoubles, testStrings);
            stopwatch.Start();
            SortingMethods.InsertionSort(testIntegers);
            GetStopwatchTime();
            SortingMethods.InsertionSort(testDoubles);
            GetStopwatchTime();
            SortingMethods.InsertionSort(testStrings);
            GetStopwatchTime();

            Console.WriteLine("Test SelectionSort with int, double and string!");
            GenerateArrays(testIntegers, testDoubles, testStrings);
            ResetStopwatch(); // watch must be resetted after arrays are generated
            SortingMethods.SelectionSort(testIntegers);
            GetStopwatchTime();
            SortingMethods.SelectionSort(testDoubles);
            GetStopwatchTime();
            SortingMethods.SelectionSort(testStrings);
            GetStopwatchTime();

            Console.WriteLine("Test QuickSort with int, double and string!");
            GenerateArrays(testIntegers, testDoubles, testStrings);
            ResetStopwatch(); // watch must be resetted after arrays are generated
            SortingMethods.Quicksort(testIntegers, 0, testIntegers.Length - 1);
            GetStopwatchTime();
            SortingMethods.Quicksort(testDoubles, 0, testDoubles.Length - 1);
            GetStopwatchTime();
            SortingMethods.Quicksort(testStrings, 0, testStrings.Length - 1);
            GetStopwatchTime();

            Console.WriteLine("Test SelectionSort with sorted values int, double and string!");
            GenerateArrays(testIntegers, testDoubles, testStrings);
            SortingMethods.SelectionSort(testIntegers);
            SortingMethods.SelectionSort(testDoubles);
            SortingMethods.SelectionSort(testStrings);
            ResetStopwatch(); // watch must be resetted after arrays are generated
            SortingMethods.Quicksort(testIntegers, 0, testIntegers.Length - 1);
            GetStopwatchTime();
            SortingMethods.Quicksort(testDoubles, 0, testDoubles.Length - 1);
            GetStopwatchTime();
            SortingMethods.Quicksort(testStrings, 0, testStrings.Length - 1);
            GetStopwatchTime();

            Console.WriteLine("Test SelectionSort with values sorted in reversed order int, double and string!");
            GenerateArrays(testIntegers, testDoubles, testStrings);
            SortingMethods.ReverseSelectionSort(testIntegers);
            SortingMethods.ReverseSelectionSort(testDoubles);
            SortingMethods.ReverseSelectionSort(testStrings);
            ResetStopwatch(); // watch must be resetted after arrays are generated
            SortingMethods.Quicksort(testIntegers, 0, testIntegers.Length - 1);
            GetStopwatchTime();
            SortingMethods.Quicksort(testDoubles, 0, testDoubles.Length - 1);
            GetStopwatchTime();
            SortingMethods.Quicksort(testStrings, 0, testStrings.Length - 1);
            GetStopwatchTime();
            stopwatch.Stop();
        }

        private static void GenerateArrays(int[] integers, double[] doubles, string[] strings)
        {
            GenerateIntArray(integers);
            GenerateDoubleArray(doubles);
            GenerateStringArray(strings);
        }

        private static int[] GenerateIntArray(int[] numbers)
        {
            for (int i = 0; i < ARRAYS_LENGTH; i++)
            {
                int generatedNumber = generator.Next(ARRAYS_LENGTH);
                numbers[i] = generatedNumber;
            }

            return numbers;
        }

        private static double[] GenerateDoubleArray(double[] numbers)
        {
            for (int i = 0; i < ARRAYS_LENGTH; i++)
            {
                double generatedNumber = generator.Next(ARRAYS_LENGTH) * DOUBLE_NUMBERS_MULTIPLIER;
                numbers[i] = generatedNumber;
            }

            return numbers;
        }

        private static string[] GenerateStringArray(string[] stringArray)
        {
            for (int i = 0; i < ARRAYS_LENGTH; i++)
            {
                string generatedString = string.Empty;
                int charsCount = generator.Next(10);
                for (int j = 0; j < charsCount; j++)
                {
                    generatedString += (char)generator.Next(65, 122);
                }

                stringArray[i] = generatedString;
            }

            return stringArray;
        }

        private static void GetStopwatchTime()
        {
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Reset();
            stopwatch.Start();
        }

        private static void ResetStopwatch()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }
    }
}
