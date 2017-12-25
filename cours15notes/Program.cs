using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours15notes
{
    class value
    {
        static public KeyValuePair<int, char> Decoder(int carte)
        {
            int val = (carte % 13) + 1;
            int suite = (carte / 12) - 1;
            char s = "CAPT"[suite];
            return new KeyValuePair<int, char>(val, s);
        }
        static public void swap(ref int a, ref int b)
        {
            if (a < b)
            {
                int temp = a; // powa swap
                a = b;
                b = temp;
                // a^=b; b^=a; a^=b;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*

 dom(add)=int x int = ZxZ
 codom(add)= int = Z
 dom(sub) = int x string
 codom(sub)= int union {planter}
 dom(fact)=int
 codom(fact) = int^n |n >= 0
             */


            int carte = 51;
            value.Decoder(carte);
            Console.WriteLine(carte);


            string joe;
            // tryparse
            int res;
            bool success;
            do
            {
                Console.WriteLine("nya");
                joe = Console.ReadLine();
                success = int.TryParse(joe, out res); // out defini que la varivable va changer //17 in out res
            } while (!success);
            /*
             * int res;
             *  success = int.TryParse(17, out res); // out defini que la varivable va changer //17 in out res
             *  string to int
             *  if res = 0;
             *  bla val parse valid ???
             *  */
            int x = 17;
            int y = 42;
            Console.WriteLine($"Original {x},{y}");
            if (x < y)
            {
                int temp = x; // powa swap
                x = y;
                y = temp;
            }
            Console.WriteLine($"Original SWAP {x},{y}");
            value.swap(ref x,ref y);
            Console.WriteLine($"Original SWAP BACK FUNC {x},{y}");
            Console.ReadLine();
        }
    }
}

