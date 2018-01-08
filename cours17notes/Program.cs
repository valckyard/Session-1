using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours17notes
{
    class Program
    {
        static bool TryParse(string s, out int val) // tryparse
        {
            try
            {
                val = int.Parse(s);
                return true;
            }
            catch
            {
                val = 0;
                return false;
            }
        }
        static int resultat = 0;
        static void Main(string[] args)
        {

            {
                int res;
                // modulo surtout pour nombres entiers
                // "Hello"[2] == l
                string s = "172";
                bool success = TryParse("suif", out res);

                Console.WriteLine($"{success},{res}");
                //int x = Convert.ToInt32(Console.ReadLine()); // conversion de whatever en int3
                //int.Parse(s);
                {

                    foreach (char c in s)
                    {
                        resultat *= 10;
                        switch (c)
                        {
                            case '0':
                                resultat += 0; break;
                            case '1': resultat += 1; break;
                            case '2': resultat += 2; break;
                            case '3': resultat += 3; break;
                            case '4': resultat += 4; break;
                            case '5': resultat += 5; break;
                            case '6': resultat += 6; break;
                            case '7': resultat += 7; break;
                            case '8': resultat += 8; break;
                            case '9': resultat += 9; break;
                        }
                        Console.WriteLine($"{resultat}");
                    }

                    int z;
                    if (int.TryParse((s), out z) == true) { Console.WriteLine($"{z} et {resultat}"); }
                }
            }
        }
    }
}