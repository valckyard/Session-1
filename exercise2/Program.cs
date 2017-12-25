using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 30);
            bool[] ta = { true, false };
            bool[] tb = { true, false };
            bool[] tc = { true, false };

            Console.WriteLine("     a\t    |    b\t      |  c\t   |  non a\t     | a et b\t    |  a ou b\t     |  a ou ex b\t| a bic c\t | a impl b");
            Console.WriteLine("---------------------------------------------------");
            foreach (bool a in ta)
            {
                foreach (bool b in tb)
                {
                    foreach (bool c in tc)
                    {
                        Console.WriteLine("{0}\t    |    {1}\t      |   {6}\t   | {2}\t     | {3}\t     | {4}\t     | {5}\t        | {6}\t         |{7}\t   ", a, b, !a, a & b, a | b, a ^ b, c, !(a ^ c), !a | b);

                        // Console.WriteLine("{0}\t    |    {1}\t", !(a ^ c), !a | b);

                    }
                }
            }
            /* MOYENNE
            int[] x = { 1, 5, 8, 9 };
            int somme = 0;
            foreach(int el in x)
                {
                somme = somme + el;
                }
            int moy = somme / x.Length;
            Console.WriteLine("Moyenne = {0}", moy);
            */
            // 3 eime partie
            /*
            {
                int[] t = { 1, 2 };
                bool existe = false;
                foreach (int x in t)
                {
                    if (x > 5)
                    {
                        existe = true;
              
                    }
                    if (x > 5)
                    {
                        existe = false;

                    }
                }
                Console.WriteLine("Ca existe tu? {0}", existe);
                */
            /* valeur plus haute que 8 dans l ensemble
            {
                int[] y = { 1, 8, 12 };
                bool valide = true;
                foreach (int w in y)
                {
                    if (w > 8)
                    {
                        valide = true;
                    }
                    if (w < 8)
                    {
                        valide = false;
                    }


                }
                Console.WriteLine("dans l ensemble il y a un chiffre plus grand que 8? {0}",valide);


             }
             */
            /*
           { 
               {
                   // AxB Produit Cartesien
               int[] A = { 1, 2, 4, 8 };
               int[] B = { 1, 2, 3, 4, 5 };
                   foreach (int a in A)
                   {
                   foreach (int b in B)
                       {
                       Console.WriteLine("({0},{1})", a, b);

                       }
                   }
                }
           }
           */
            // A U B union
            int[] A = { 1, 2, 4, 8 };
            int[] B = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Soit !");
            Console.WriteLine("Ensemble A = { 1, 2, 4, 8 }");
            Console.WriteLine("Ensemble B = { 1, 2, 3, 4, 5}");
            var union = new HashSet<int>(); // variable de type hashset int vide (ensemble de <int>)
                                            //defini les variables comme on aurait pu utiliser string float etc
            Console.WriteLine("A Union B");
            foreach (int a in A)
            {
                union.Add(a); // entre les valeurs de A dans union
            }
            foreach (int b in B)
            {
                union.Add(b); // entre les valeurs de B dans union
            }
            foreach (int x in union)            // pour toute les variables dans union
            {
                Console.WriteLine(x);   // ecrire tt les variable comprises dans union
            }

            // A intersect B
            var inter = new HashSet<int>();
            Console.WriteLine("intersect A & B");                // space entre union et interserct
            foreach (int b in B)
            {
                if (A.Contains(b))
                {
                    inter.Add(b);
                }
            }
            foreach (int y in inter)
            {
                Console.WriteLine(y);
            }
            // exclusion
            var excluab = new HashSet<int>();
            Console.WriteLine("Exclusion A - B");
            foreach(int a in A)
            {
                if (!B.Contains(a))
                {
                    excluab.Add(a);
                }
            }
            foreach (int z in excluab)
            {
                Console.WriteLine(z);
            }
            // exlusion B-A
            var excluba = new HashSet<int>();
            Console.WriteLine("Exclusion B - A");
            foreach (int b in B)
            {
                if (!A.Contains(b)) 
                {
                    excluba.Add(b);
                }
            }
            foreach(int z in excluba)
               {
                Console.WriteLine(z);
                }

            //Cardinalité .Size ou .Length
       }

    }
}
