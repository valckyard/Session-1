using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
         //eg
        


            // question de nom
            Console.WriteLine("Quel est ton nom?");
            string nom = Console.ReadLine();
            Console.WriteLine("Quel est ton prenom?");
            string prenom = Console.ReadLine();

            //date de naissance et timespan
            Console.WriteLine("Quel est ta date de naissance?");
            var naissance = DateTime.Parse(Console.ReadLine());
            DateTime maintenant = DateTime.Now;

            // variable de 
            var DaysPerMonth = 30;
            var DaysPerYear = 365;
            var Days = (maintenant - naissance).Days;
            var Years = (Days / DaysPerYear);
            var Months = (Days / DaysPerMonth);


            Days -= (int)(Years * DaysPerYear);
            Days -= (int)(Months * DaysPerMonth);


            //Nombre 1 a 100 mais peut depasser 100
            int nombre;

            do
            {
                Console.WriteLine("Ecrit un nombre de 1 a 100!");


                nombre = int.Parse(Console.ReadLine());

                if (nombre > 100)
                {
                    Console.WriteLine("Ton nombre est trop grand!");
                }


                if (nombre < 1)
                {
                    Console.WriteLine("Ton nombre est trop petit!");
                }
            } while (nombre < 1 || nombre > 100); // || = ou bool While do a while (tant que le nombre est plus petit ou plus grand que 100
            bool vf = nombre > 50;

            //Final
            Console.WriteLine();
            Console.WriteLine("Bonjour {0} {1}!", prenom, nom);
            Console.WriteLine("Tu as {0} jours! ou {1} ans!", Days, Years);
            Console.WriteLine("Ton nombre {0} est superieur a 100? {1} ", nombre, vf);
            Console.WriteLine("{0} years, {1} months, {2} days", Years, Months, Days);
            Console.Read();

        }
    }
}
