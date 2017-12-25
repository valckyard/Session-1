using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours6app
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             //app qui marque le nom
            Console.WriteLine("Cossin Magique quel est son nom?");
            string nom = Console.ReadLine();
            Console.WriteLine("{0}! quel cossin merveilleux", nom);
            Console.Read();
            */
            {
                /*
                int x = int.Parse("17");    // Changer un nombre "17" en texte em nombre int
                Console.WriteLine(x + 1);
                Console.Read();
                string t = Console.ReadLine();
                string v = 
                */
                {
                    /*
                    Console.WriteLine("How many brothers do you have ?");
                    float bro = float.Parse(Console.ReadLine());
                    Console.WriteLine("How many sisters do you have ?");
                    float sis = float.Parse(Console.ReadLine());
                    float tot = bro + sis;    // entier
                    float div = bro / sis;  // virgule flotante Math.Div(sis,bro)
                    Console.WriteLine("You have {0} Brothers, {1} Sisters , so you have {2} Siblings", bro, sis, tot);
                    Console.WriteLine("You have {0} Brothers, {1} Sisters , so you have {2} Siblings", bro, sis, div);
                    Console.Read();
                    */
                    {
                        /*
                        int -> int.Parse entier
                        float.Parse float les decimales
                        bool.Parse("true") parse un true false
                        DateTime.Parse("2017-10-13 22:17");
                        Math en c# <  > <= >= == !=(negal pas)
                        +   -   *   / modulo
                        int x = 5;
                        int y = 10;
                        bool z = x > y; vrai
                        bool w = x != 5;    faux
                          16%5 = 1
                         */

                        Console.WriteLine("Ecrit la date de naissance de ton singe!");
                        var nais = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Quand est mort ton singe? si il est toujours en vie appuie sur ENTER");
                        string mort = Console.ReadLine(); // prend la variable mort
                        DateTime maintenant = DateTime.Now; // prend le temps ici
                        if (mort.Length > 0)
                            {
                                maintenant = DateTime.Parse(mort);
                            }
                        TimeSpan delta = maintenant - nais; // 80 jours
                        Console.WriteLine("Ton singe a vecu de {0} - {1} donc il a {2} jours.",nais,maintenant,delta.Days);
                        Console.Read();
                    }
                }
            }

        }
    }
}
