using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOperationsPerformance
{
    public class DivideMethods
    {
        private static DateTime start = DateTime.Now;

        public static void DivideInt(int startValue, int endValue, int step)
        {
            start = DateTime.Now;
            for (int i = startValue; i >= endValue; i = i / step) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void DivideLong(long startValue, long endValue, long step)
        {
            start = DateTime.Now;
            for (long i = startValue; i >= endValue; i = i / step) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void DivideFloat(float startValue, float endValue, float step)
        {
            start = DateTime.Now;
            for (float i = startValue; i >= endValue; i = i / step) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void DivideDouble(double startValue, double endValue, double step)
        {
            start = DateTime.Now;
            for (double i = startValue; i >= endValue; i = i / step) { }
            Console.WriteLine(DateTime.Now - start);
        }

        public static void DivideDecimal(decimal startValue, decimal endValue, decimal step)
        {
            start = DateTime.Now;
            for (decimal i = startValue; i >= endValue; i = i / step) { }
            Console.WriteLine(DateTime.Now - start);
        }
    }
}
