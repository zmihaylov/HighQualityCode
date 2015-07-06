using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RefactorLoop
{
    class RefactorLoop
    {
        static void Main(string[] args)
        {
            int[] givenIntArray = new int[] { 3, 5, 7, 56, 34, 23, 30, 20, 90, 66, 34, 76, 9, 8, 666, 67, 45 };
            int searchValue = int.Parse(Console.ReadLine());

            bool isFound = false;

            for (int i = 0; i < givenIntArray.Length; i++)
            {
                if (i % 10 == 0)
                {
                    if (givenIntArray[i] == searchValue)
                    {
                        isFound = true;
                    }
                }

                Console.WriteLine(givenIntArray[i]);
            }

            // More code here
            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
