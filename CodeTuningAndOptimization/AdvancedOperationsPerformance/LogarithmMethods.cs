using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedOperationsPerformance
{
    public class LogarithmMethods
    {
        private static DateTime start;

        internal static void CalcLogarithmFloat(float startValue, float endValue, float step)
        {
            start = DateTime.Now;
            for (float i = startValue; i <= endValue; i = i + step, Math.Log(i)) { }
            Console.WriteLine(DateTime.Now - start);
        }

        internal static void CalcLogarithmDouble(double startValue, double endValue, double step)
        {
            start = DateTime.Now;
            for (double i = startValue; i <= endValue; i = i + step, Math.Log(i)) { }
            Console.WriteLine(DateTime.Now - start);
        }

        internal static void CalcLogarithmDecimal(decimal startValue, decimal endValue, decimal step)
        {
            start = DateTime.Now;
            for (decimal i = startValue; i <= endValue; i = i + step, Math.Log((double)i)) { }
            Console.WriteLine(DateTime.Now - start);
        }
    }
}
