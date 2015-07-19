namespace SimpleOperationsPerformance
{
    using System;

    public class AddMethods
    {
        private static DateTime start = DateTime.Now;

        public static void AddInt(int startValue, int endValue)
        {
            start = DateTime.Now;
            for (int i = startValue; i < endValue; i++) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void AddLong(long startValue, long endValue)
        {
            start = DateTime.Now;
            for (long i = startValue; i < endValue; i++) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void AddFloat(float startValue, float endValue)
        {
            start = DateTime.Now;
            for (float i = startValue; i < endValue; i++) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void AddDouble(double startValue, double endValue)
        {
            start = DateTime.Now;
            for (double i = startValue; i < endValue; i++) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void AddDecimal(decimal startValue, decimal endValue)
        {
            start = DateTime.Now;
            for (decimal i = startValue; i < endValue; i++) { }
            Console.WriteLine(DateTime.Now - start);
        }
    }
}
