using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice3
{
    class Program
    {
        static void Main(string[] args)

        {
            bool replay = false; // creation variable replay
            string yn;
            do                   // "fait" le jeu
            {
                // variables du jeu
                int nb = (new Random()).Next() % 10; // reste de la division divise par 10 et garde le reste
                int essai = 0;
                Console.WriteLine("Devine le nombre, 0 a 9");
                bool trouve = false;
                int x;
                do
                {
                    essai++;                                                  //fait essai+1 pour commencer a essai 1 au lieu de 0
                    Console.Write($"Essai #{essai} : ");
                    while (int.TryParse(Console.ReadLine(), out x) == false) // sortir une valeur x true false x being an int so le texte va rretourner la valeur en dessous
                    {
                        Console.WriteLine("Un nombre gros epais");
                    }
                    //int x = int.Parse(Console.ReadLine()); // Prend la valeur en texte et la retourne en int

                    if (x > 9) //Si x > 9 on enleve un essai et on dit ca (essai est pour le garder au meme niveau since on en met +1 dans las base pour ne pas etre a 0 et modifier le nombre d essai
                    {
                        Console.WriteLine("Ton nombre est trop grand!");
                        --essai;
                    }


                    if (x < 0) //Si x < 0 on enleve un essai et on dit ca
                    {
                        Console.WriteLine("Ton nombre est trop petit!");
                        --essai;
                    }

                    if (x > nb)   // hot and cold avec la variable random nb
                    {
                        Console.WriteLine("Le nombre choisi est plus grand que le nombre recherché!");
                    }
                    if (x < nb)
                    {
                        Console.WriteLine("Le nombre choisi est plus petit que le nombre recherché!");
                    }

                    trouve = (x == nb);
                }
                while (!trouve); // ! non trouve
                if (essai < 5) // module de victoire  si les essai son plus bas que 5 good otherwise poche
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Tu a trouve le nombre {nb} en {essai} essai ! GOOOD STUFF!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Tu a trouve le nombre {nb} en {essai} essai ! T'ES BEN POCHE!");
                }

                Console.ForegroundColor = ConsoleColor.White;       // remet la couleur a nlanc
                Console.WriteLine();
                Console.WriteLine("Veux-tu jouer encore ? Oui ou Non?");   // module de replay V
                yn = Console.ReadLine();

                if (yn.ToUpper() == "OUI")
                {
                    replay = true;
                }
                // if (yn != "oui") essaye ca mais ca donne rien un else fait tres bien
                else
                {
                    replay = false;
                }

            } while (replay);
        }
    }
}
