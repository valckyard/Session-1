using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cours15app
{
    class Program
    {
        static void Main(string[] args)

        {
            int nbElemintab = 500;
            int[] tableau = CreerTableau(nbElemintab);
            MelangerTableau(tableau);
            AfficherTableau(tableau,nbElemintab);
            TrierTableau(tableau);
            AfficherTableau(tableau, nbElemintab);
            Console.ReadLine();
        }
        static bool TableauEstTrie(int[] tab)
        {
            int val = int.MinValue; // minvalie valeur la plus basse
            foreach (int item in tab)
            {
                if (item < val)
                    return false;
                val = item;
            }
            return true;
        }
        static int[] CreerTableau(int nbelEment)
        {

            int[] tab = new int[nbelEment];
            Random numbers = new Random();
            for (int i = 0; i < nbelEment; i++)
            {
                tab[i] = i+1;
            }
            return tab;
        }


        static void AfficherTableau(int[] tab, int nbelem)
        {
            List<string> TxtElm = new List<string>();

            /*
            TxtElm.Add(elem.ToString());
            string txtTab = string.Join(",", TxtElm);
            Console.WriteLine($"Tableau {{{txtTab}}}");
            or
            */
            Console.Write("Tableau : [");
            foreach (int elem in tab)
            {
                Console.Write(elem);
                if (elem == tab[nbelem-1])
                {
                   
                }
                else
                {
                 Console.Write(",");
                }

            }
            Console.WriteLine("}");

        }


        static void TrierTableau(int[] tab)
        {
            //   Array.Sort(tab);
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = i + 1; j < tab.Length; j++)
                {
                    if (tab[i] > tab[j])
                    {
                        tab[i] = tab[i] + tab[j];
                        tab[j] = tab[i] - tab[j];
                        tab[i] = tab[i] - tab[j];
                    }
                    else if (tab[i] < tab[j])
                    {

                    }
                }
            }
        }
    
    static void Swap(ref int a, ref int b)
    {
        if (a < b)
        {
            int temp = a; // powa swap
            a = b;
            b = temp;
            // a^=b b^=a a^=b
        }
    }
    static void MelangerTableau(int[] tab)
    {
        var rand = new Random();
        for (int i = 0; i < tab.Length; i++)
        {
            int j = rand.Next() % tab.Length;
            Swap(ref tab[i], ref tab[j]);
        }
    }
}
}

