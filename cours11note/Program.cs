using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace cours11note
{
    class Program
    {
        static void Main(string[] args)

        {/*
            var sw = new StreamWriter(@"C:\Projects\Premiers.txt");  // \t espace tab \n jsais pas
            for (int y = 2; y < 1000000; ++y)
            {
                bool premier = true;                         //
                for  (int x = 2; x <=Math.Sqrt(y);++x) // plus vite 
                    //(int x = 2; x < y; ++x)plus lent                 /// add one a x tant quil est plus bas que mon nombre pour le diviser par modulo
                {                                               ///
                    if (y % x == 0)                         /// valeur de division pour la verité
                        premier = false;                        ///
                }                                               ///Module nombre premiers
                if (premier == true)                        ///
                {                                               ///
                 sw.WriteLine(y);                        //
                }                                                   //
                /* Liste de nombre premier de 2  a 1 000 0000
                 * x+1  divisible only par 1 ou lui meme
                
            }sw.Dispose(); // memory tampon write if too short
        }*/
         /*{
             var sw = new StreamWriter(@"C:\Projects\Premiers2.txt");  // \t espace tab \n jsais pas
             for (int y = 2; y < 1000000; ++y)
             {
                 bool premier = true;
                 int sqrty = (int)Math.Sqrt(y); // defini racine carré de y sont >= racine carré est la portée
                 for (int x = 2; x <= sqrty; ++x)
                 {
                     if (y % x == 0)
                     {
                         premier = false;
                     }
                 }
                      if (premier == true)                        ///
                     {                                               ///
                         sw.WriteLine(y);                        //
                     }
             }
             sw.Dispose();*/ // memory tampon write if too short
            { //new strategy au lieu de charcher chaque premier barrer les pas premiers
                var sw = new StreamWriter(@"C:\Projects\Premiers 1 milliard.txt");  // \t espace tab \n jsais pas
                bool[] nb = new bool[1000000000]; // 1 mil de valeurs fausse
                nb[0] = true;
                nb[1] = true;// exclus
                var r2 = (int)Math.Sqrt(nb.Length);
                for (int x = 2; x <= r2; ++x)
                {
                    for (int y = x * 2; y < nb.Length; y += x) //  y = y+x
                    {
                        nb[y] = true;
                    }
                }
                for (int i = 2; i < nb.Length; ++i) // hors de la boucle pour le restant qui est encore faux pour le write
                {
                    if (nb[i] == false)
                    {
                        sw.WriteLine(i);
                    }
                }
                sw.Dispose();
            }

        }

    }
}

