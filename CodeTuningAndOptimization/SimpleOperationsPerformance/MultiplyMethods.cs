using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOperationsPerformance
{
    public class MultiplyMethods
    {
        private static DateTime start = DateTime.Now;

        public static void MultiplyInt(int startValue, int endValue, int step)
        {
            start = DateTime.Now;
            for (int i = startValue; i <= endValue; i = i * step) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void MultiplyLong(long startValue, long endValue, long step)
        {
            start = DateTime.Now;
            for (long i = startValue; i <= endValue; i = i * step) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void MultiplyFloat(float startValue, float endValue, float step)
        {
            start = DateTime.Now;
            for (float i = startValue; i <= endValue; i = i * step) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void MultiplyDouble(double startValue, double endValue, double step)
        {
            start = DateTime.Now;
            for (double i = startValue; i <= endValue; i = i * step) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void MultiplyDecimal(decimal startValue, decimal endValue, decimal step)
        {
            start = DateTime.Now;
            for (decimal i = startValue; i <= endValue; i = i * step) { }
            Console.WriteLine(DateTime.Now - start);
        }
    }
}
