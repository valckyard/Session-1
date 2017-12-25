using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours11note2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0;i<10;++i)
            {
                if (i == 3)
                {
                    continue; // continue apres verif
                }
                if (i == 5) 
                {
                    break;  // fini apres verif
             
                 }
                Console.WriteLine(i);
            }
        }
    }
}
