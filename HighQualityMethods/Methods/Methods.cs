namespace Methods
{
    using System;

    public class Methods
    {
        private static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            if (sideA >= sideB + sideC || sideB >= sideA + sideC || sideC >= sideB + sideA)
            {
                throw new ArgumentException("Sides dont form a triangle.");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            return area;
        }

        private static string GetDigitName(sbyte digit)
        {
            if (digit < 0 || 10 < digit)
            {
                throw new ArgumentOutOfRangeException("Given input is not a valid digit!");
            }

            string result = "";

            switch (digit)
            {
                case 0: result = "zero"; break;
                case 1: result = "one"; break;
                case 2: result = "two"; break;
                case 3: result = "three"; break;
                case 4: result = "four"; break;
                case 5: result = "five"; break;
                case 6: result = "six"; break;
                case 7: result = "seven"; break;
                case 8: result = "eight"; break;
                case 9: result = "nine"; break;
            }

            return result;
        }

        private static int FindMaxElement(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Input array cannot be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Input array has no elements!");
            }

            int max = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }
            return max;
        }

        private static void PrintNumberAsFloat(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        private static void PrintNumberInPercents(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        private static void PrintNumberAlignedRight(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        private static void CheckIfPointsCoinside(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                throw new ArgumentException("Points coinside! A point cannot form a line!");
            }
        }

        private static bool CheckIfHorizontalLine(double x1, double y1, double x2, double y2)
        {
            CheckIfPointsCoinside(x1, y1, x2, y2);

            return y1 == y2;
        }

        private static bool CheckIfVerticalLine(double x1, double y1, double x2, double y2)
        {
            CheckIfPointsCoinside(x1, y1, x2, y2);

            return x1 == x2;
        }

        static double CalculateDistanceBetweenPoints(double x1, double y1, double x2, double y2)
        {
            CheckIfPointsCoinside(x1, y1, x2, y2);

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void Main()
        {
            try
            {
                Console.WriteLine(CalculateTriangleArea(3, 4, 5));

                Console.WriteLine(GetDigitName(5));

                Console.WriteLine(FindMaxElement(5, -1, 3, 2, 14, 2, 3));

                PrintNumberAsFloat(1.3);
                PrintNumberInPercents(0.75);
                PrintNumberAlignedRight(2.30);

                bool isHorizontal = CheckIfHorizontalLine(3, -1, 3, 2.5),
                     isVertical = CheckIfVerticalLine(3, -1, 3, 2.5);
                Console.WriteLine(CalculateDistanceBetweenPoints(3, -1, 3, 2.5));
                Console.WriteLine("Horizontal? " + isHorizontal);
                Console.WriteLine("Vertical? " + isVertical);

                Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
                peter.OtherInfo = "From Sofia, born at 03/17/1992"; ////if you comment this line you get an exception

                Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
                stella.OtherInfo = "From Vidin, gamer, high results, born at 11/03/1993"; ////if you comment this line you get an exception

                Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
