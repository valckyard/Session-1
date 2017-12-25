using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fizzbuzz
{
    class titsuifaweseaux
    {
        public static void calculeetappliquefizzication()
        {
            for (int y = 0; y < 10; y = ++y)
            {
                for (int x = 1; x <= 10; x = ++x)
               
            {
                    int z;
                    z = x + (y*10);
                if ((z % 3 == 0) & (z % 5 == 0))
                { Console.Write(" FizzBuzz |"); }
                else if ((z % 3 != 0) & (z % 5 == 0))
                { Console.Write(" Buzz |"); }
                else if ((z % 3 == 0) & (z % 5 != 0))
                { Console.Write(" Fizz |"); }
                else
                { Console.Write($" {z} |"); }

            }
                Console.WriteLine();

        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        titsuifaweseaux.calculeetappliquefizzication();
        Console.ReadLine();
    }
}
}
