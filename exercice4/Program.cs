using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice4
{
    class Program
    {
        static void Main(string[] args)
        



        {
            bool replay = false; //Replay module start DO The CALC
            string yn;
            do
            {
                Console.Clear();
                Console.WriteLine("Bonjour bienvenue a mon calculateur !");
                Console.WriteLine("Veuillez entrer vos valeurs.");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                Console.WriteLine();
                float reponse;  // Defining what i want as a value at the start for my end switch
                {

                    float x;    // first number variable
                    float y;    // second number variable
                    Console.Write("Donnez moi votre premier chiffre!  : ");
                    while (float.TryParse(Console.ReadLine(), out x) == false) //Parsing readline to get a number if not it will ask again boolean wise
                        {
                            Console.WriteLine("DONNE MOE UN CHIFFRE OUSTI!");
                            Console.Write("Donnez moi votre premier chiffre!  : ");
                        }

                        bool op = false; // Boolean gateway of my asking calc type
                        string calc;     // initating my calc string for storing
                        do               // asking calc DO
                        {
                            Console.Write("Calcul desiré : ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("( +, -, *, / ou %) : ");
                            Console.ResetColor();
                            calc = Console.ReadLine();                  // Read what typed
                            foreach (string oper in new[] { "+", "-", "*", "/", "%" }) //create string oper as a new table of string var
                                op |= (oper == calc);                                  // op or equal oper == calc will go true
                            //if (oper == calc) // possible en ou boolean op |= (oper == calc);
                            if (op == false) // if its false it will go back asking
                                {
                                    Console.WriteLine("Entre le calcul desire pas autre chose !!!!!");
                                }
                        } while (!op); //gateway open or close for calc type

                    Console.Write("Donnez moi votre deuxieme chiffre! : ");
                    while (float.TryParse(Console.ReadLine(), out y) == false) // second number parsed as a number
                    {
                        Console.WriteLine("DONNE MOE UN CHIFFRE OUSTI!");
                        Console.Write("Donnez moi votre deuxieme chiffre! : ");
                    }
                        Console.Clear();   // return on values entered
                        Console.WriteLine($"Premier nombre  : | {x} |");
                        Console.WriteLine($"Calcul desire   : | {calc} |");
                        Console.WriteLine($"Deuxieme nombre : | {y} |");
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                        Console.Write($"Donc le calcul est : ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"[ {x} {calc} {y} ]");
                        Console.ResetColor();
                        Console.WriteLine();
                    switch (calc)   // calc switch for type and values
                    {
                        case "+":
                            reponse = x + y;
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"La reponse de : [ {x} {calc} {y} ] est :||| {reponse} |||");
                            break;
                        case "-":
                            reponse = x - y;
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"La reponse de : [ {x} {calc} {y} ] est :||| {reponse} |||");
                            break;
                        case "*":
                            reponse = x * y;
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"La reponse de : [ {x} {calc} {y} ] est :||| {reponse} |||");
                            break;
                        case "/":
                            reponse = x / y;
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"La reponse de : [ {x} {calc} {y} ] est :||| {reponse} |||");
                            break;
                        case "%":
                            reponse = x % y;
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"La reponse de : [ {x} {calc} {y} ] est :||| {reponse} |||");
                            break;
                    }
                }
                    Console.ResetColor();
                    Console.WriteLine("---------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.Write("Voulez vous faire un autre calcul? ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Oui");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ou ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Non");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ? : ");
                    yn = Console.ReadLine(); // replay asking
                if (yn.ToUpper() == "OUI")
                    {
                        replay = true;
                    }
                else
                    {
                        replay = false;
                    }
            } while (replay); // return to start
        }
    }
}
