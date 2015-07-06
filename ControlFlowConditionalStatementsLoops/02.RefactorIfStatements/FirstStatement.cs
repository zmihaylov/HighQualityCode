using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RefactorIfStatements
{
    public class FirstStatement
    {
        public static void CookPotato()
        {
            // doesn't compile if not instanced
            Potato potato = new Potato();

            if (potato != null)
            {
                if (potato.HasBeenPeeled && potato.IsFreesh)
                {
                    Cook(potato);
                }
            }
        }

        public static void Cook(Potato potato)
        {
            // ...
        }
    }
}
