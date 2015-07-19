using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedOperationsPerformance
{
    public class TestMethodsPerformance
    {
        static void Main()
        {
            Console.WriteLine("SQUARE:");
            SquareMethods.CalcSqrtFloat(1f, 10000f, 0.01f);
            SquareMethods.CalcSqrtDouble(1d, 10000d, 0.01d);
            SquareMethods.CalcSqrtDecimal(1m, 10000m, 0.01m);

            Console.WriteLine("\nLOGARITHMS:");
            LogarithmMethods.CalcLogarithmFloat(1f, 10000f, 0.01f);
            LogarithmMethods.CalcLogarithmDouble(1d, 10000d, 0.01d);
            LogarithmMethods.CalcLogarithmDecimal(1m, 10000m, 0.01m);

            Console.WriteLine("\nSINUS:");
            SinusMethods.CalcSinusFloat(1f, 10000f, 0.01f);
            SinusMethods.CalcSinusDouble(1d, 10000d, 0.01d);
            SinusMethods.CalcSinusDecimal(1m, 10000m, 0.01m);
        }
    }
}
