using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours8
{
    class Program
    {
        static void Main(string[] args)
        {

            var z = 1234;
            var x = 8;
            var y = 6;
            var a = x + y;
            var nom = "Joe";
            /*
            Console.WriteLine("Bonjour, {0} y = {1}", nom, y); // old
            Console.WriteLine($"Bonjour, {nom} y= {y}");   // new runtime
            Console.WriteLine($"La valeur de Z est ! {z}");
            Console.WriteLine($"Bonjour, {nom.ToUpper()} Addition {a:C}"); //upper case // addition + Currency :C
            */
            int[] B = { 1, 2, 3, 4, 8, 16 };
            int somme = 0;
            foreach (int b in B)
            {
                Console.WriteLine(b);
                somme = somme + b;
            }
            //int c = 0;
            for (int c = 0; c < 10 ; x++) //int c = 0( une fois au debut) c<10 (condition de répétition) c = c+1 (fait apres chaque tour de boucle)

                     
            {
                Console.WriteLine(c);
            }
            //Console.WriteLine($" oh yea bouclé jusqua {c}");
            Console.WriteLine($"la soemme est {somme}.");

            // meme chose 
            for (int d = 0; d < 10; x++)
            {
                Console.WriteLine(d);
            }
            int e = 0;
            while (e < 10)
            {
                Console.WriteLine(e);
                x++;
            }            

            }
        }
    }
    /*
                      x=x+1 == x++
                      x=x+2 == x+=2
                      x*=3
                      x/=8
                      b|=k
                      b&
                      b^
                      */
