using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOperationsPerformance
{
    public class SubstractMethods
    {
        private static DateTime start = DateTime.Now;

        public static void SubstractInt(int startValue, int endValue)
        {
            start = DateTime.Now;
            for (int i = startValue; i > endValue; i--) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void SubstractLong(long startValue, long endValue)
        {
            start = DateTime.Now;
            for (long i = startValue; i > endValue; i--) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void SubstractFloat(float startValue, float endValue)
        {
            start = DateTime.Now;
            for (float i = startValue; i > endValue; i--) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void SubstractDouble(double startValue, double endValue)
        {
            start = DateTime.Now;
            for (double i = startValue; i > endValue; i--) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void SubstractDecimal(decimal startValue, decimal endValue)
        {
            start = DateTime.Now;
            for (decimal i = startValue; i > endValue; i--) { }
            Console.WriteLine(DateTime.Now - start);
        }
    }
}
