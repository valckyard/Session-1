using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours14app
{
    class Program
    {
        static void Main(string[] args)
        {
            int nb1 = demandernombre("enter 1",1,10);
           int nb2 = demandernombre("enter 2",1,10);
            Console.WriteLine(nb1 + nb2);
            Console.ReadLine();
        }
        static bool DansPlageValeur(int nombre, int min, int max)
        {
            return nombre >= min && nombre >= max;
        }
        static int demandernombre(string msg, int min, int max)
        {
            for (; ; )
            {
                Console.WriteLine(msg);
                string txt = Console.ReadLine();
                int result;
                bool success = int.TryParse(txt, out result);
                if (success && DansPlageValeur(result, min, max))
                return result;
            
                }
        }
        
    }
}
