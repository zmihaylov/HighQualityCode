using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedOperationsPerformance
{
    public class SinusMethods
    {
        private static DateTime start;

        internal static void CalcSinusFloat(float startValue, float endValue, float step)
        {
            start = DateTime.Now;
            for (float i = startValue; i <= endValue; i = i + step, Math.Sin(i)) { }
            Console.WriteLine(DateTime.Now - start);
        }

        internal static void CalcSinusDouble(double startValue, double endValue, double step)
        {
            start = DateTime.Now;
            for (double i = startValue; i <= endValue; i = i + step, Math.Sin(i)) { }
            Console.WriteLine(DateTime.Now - start);
        }

        internal static void CalcSinusDecimal(decimal startValue, decimal endValue, decimal step)
        {
            start = DateTime.Now;
            for (decimal i = startValue; i <= endValue; i = i + step, Math.Sin((double)i)) { }
            Console.WriteLine(DateTime.Now - start);
        }
    }
}
