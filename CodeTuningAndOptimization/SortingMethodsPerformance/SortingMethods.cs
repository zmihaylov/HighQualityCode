using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethodsPerformance
{
    public class SortingMethods
    {
        public static void InsertionSort<T>(T[] elements) where T : IComparable
        {
            T[] array = new T[elements.Length];
            elements.CopyTo(array, 0);

            for (int i = 1; i < array.Length - 1; i++)
            {
                T value = array[i];
                int j = i - 1;

                while (true)
                {
                    if (array[j].CompareTo(value) > 0)
                    {
                        array[j + 1] = array[j];
                        j = j - 1;
                        if (j < 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                array[j + 1] = value;
            }
        }

        public static void SelectionSort<T>(T[] elements) where T : IComparable
        {
            T[] array = new T[elements.Length];
            elements.CopyTo(array, 0);
            int i, j, min;
            T temp;

            for (i = 0; i < array.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[min]) < 0)
                    {
                        min = j;
                    }
                }
                temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }

        public static void Quicksort<T>(T[] elements, int left, int right) where T : IComparable
        {
            int i = left, j = right;
            T pivot = elements[(left + right) / 2];

            while (i<=j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }

        public static void ReverseSelectionSort<T>(T[] elements) where T : IComparable
        {
            T[] array = new T[elements.Length];
            elements.CopyTo(array, 0);
            int i, j, max;
            T temp;
            for (i = 0; i < array.Length - 1; i++)
            {
                max = i;
                for (j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[max]) > 0)
                    {
                        max = j;
                    }
                }
                temp = array[i];
                array[i] = array[max];
                array[max] = temp;
            }
        }
    }
}
