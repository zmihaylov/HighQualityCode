using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedOperationsPerformance
{
    public class SquareMethods
    {
        private static DateTime start;

        public static void CalcSqrtFloat(float startValue, float endValue, float step)
        {
            start = DateTime.Now;
            for (float i = startValue; i <= endValue; i = i + step, Math.Sqrt(i)) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void CalcSqrtDouble(double startValue, double endValue, double step)
        {
            start = DateTime.Now;
            for (double i = startValue; i <= endValue; i = i + step, Math.Sqrt(i)) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void CalcSqrtDecimal(decimal startValue, decimal endValue, decimal step)
        {
            start = DateTime.Now;
            for (decimal i = startValue; i <= endValue; i = i + step, Math.Sqrt((double)i)) { }
            Console.WriteLine(DateTime.Now - start);
        }
    }
}
