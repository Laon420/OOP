using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    internal class Program
    {
        public static void Main()
        {
            Console.Write("1 3 5 7 9 ");
            Console.WriteLine();
            for (int i = 1; i <= 10; i+=2)
                Console.Write(i + " ");
            Console.WriteLine();
            for (int i = 1; i <= 10; i++)
                if (i% 2 == 1)
                    Console.Write(i + " ");
            Console.WriteLine();
            int j = 0;
            while (j<10)
            {
                j++;
                if (j% 2 == 0)
                    continue;
                Console.Write(j + " ");

            }
            




        }
    }
}
