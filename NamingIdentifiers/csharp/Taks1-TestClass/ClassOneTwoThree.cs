using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taks1_TestClass
{
    public class ClassOneTwoThree
    {
        private const int MaxCount = 6;

        public class ClassInClass
        {
            public void ValueAsString(bool value)
            {
                string valueAsString = value.ToString();
                Console.WriteLine(valueAsString);
            }
        }

        public static void Main(string[] args)
        {
            ClassInClass instance = new ClassInClass();
            instance.ValueAsString(true);
        }
    }
}
