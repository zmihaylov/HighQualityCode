using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOperationsPerformance
{
    public class TestMethodsPerformance
    {
        public static void Main()
        {
            Console.WriteLine("ADD:");
            AddMethods.AddInt(1, 500000);
            AddMethods.AddLong(1L, 500000L);
            AddMethods.AddFloat(1f, 500000f);
            AddMethods.AddDouble(1d, 500000d);
            AddMethods.AddDecimal(1m, 500000m);

            Console.WriteLine("\nSUBSTRACT:");
            SubstractMethods.SubstractInt(500000, 1);
            SubstractMethods.SubstractLong(500000L, 1L);
            SubstractMethods.SubstractFloat(500000f, 1f);
            SubstractMethods.SubstractDouble(500000d, 1d);
            SubstractMethods.SubstractDecimal(500000m, 1m);

            Console.WriteLine("\nMULTIPLY");
            MultiplyMethods.MultiplyInt(1, 500000, 2);
            MultiplyMethods.MultiplyLong(1L, 500000L, 2L);
            MultiplyMethods.MultiplyFloat(1f, 500000f, 2f);
            MultiplyMethods.MultiplyDouble(1d, 500000d, 2d);
            MultiplyMethods.MultiplyDecimal(1m, 500000m, 2m);

            Console.WriteLine("\nDIVIDE");
            DivideMethods.DivideInt(500000, 1, 2);
            DivideMethods.DivideLong(500000L, 1L, 2L);
            DivideMethods.DivideFloat(500000f, 1f, 2f);
            DivideMethods.DivideDouble(500000d, 1d, 2d);
            DivideMethods.DivideDecimal(500000m, 1m, 2m);
        }
    }
}
