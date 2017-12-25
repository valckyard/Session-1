using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Sapinage1
{
}
class Program
{
    static Random rand = new Random();
    static void ShowTree()
    {
                        ////////////////////Tree Creation////////////////

        Console.BackgroundColor = ConsoleColor.White;
        int DecSpace = 50;//the number of spaces top row then decrease
        int Troncspace = 8; // trunk stars width
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        for (int i = 1; i <= 22; i++)
        {
            for (int j = 1; j < DecSpace; j++)// white space til decspace than decrease it right
            {
                Console.Write(" ");
            }

            DecSpace = DecSpace - 1; // decrease spacing for next row
            for (int t = 1; t < i * 2; t++) // stars ~~~~~
            {
                Console.Write("*");
            }
            for (int j = 1; j < DecSpace; j++)// white space til decspace than decrease it left
            {
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        for (int i = 1; i < 9; i++)
        {
            for (int j = 1; j < 47; j++) // white side trunk right
            {
                Console.Write(" ");
            }
            for (int t = 1; t < Troncspace; t++) // trunk bars
            {
                Console.Write("|");
            }
            for (int j = 1; j < 46; j++)//white side trunk left
            {
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
    static void SetCursorStar()
    {
        int MaxTop = 21;
        int Middle = 49;
        int RandHeight = rand.Next(0, 22);
        int VarHeight = MaxTop - RandHeight;
        int i = 0;
        int VarMidRangeMin = 0;
        int VarMidRangeMax = 0;
        int HeightRand = RandHeight;
        while (i < HeightRand)
        {
            VarMidRangeMin += -1;
            VarMidRangeMax += 1;
            ++i;
        }
        var DaStar = rand.Next(VarMidRangeMin, VarMidRangeMax + 1);
        Console.SetCursorPosition((Middle + DaStar), Console.CursorTop = HeightRand);//+(Middle+DaStar)
    }
    static void SetCursorsave(int nbLights, ref List<int> HList, ref List<int> WList)
    {
        int j = 0;
        while (j < nbLights)
        {
            int MaxTop = 21;
            int Middle = 49;
            int RandHeight = rand.Next(0, 22);
            int VarHeight = MaxTop - RandHeight;
            int i = 0;
            int VarMidRangeMin = 0;
            int VarMidRangeMax = 0;
            int HeightRand = RandHeight;
            while (i < HeightRand)
            {
                VarMidRangeMin += -1;
                VarMidRangeMax += 1;
                ++i;
            }
            var DaStar = rand.Next(VarMidRangeMin, VarMidRangeMax + 1);
            int Widthrand = Middle + DaStar;
            HList.Add(HeightRand);
            WList.Add(Widthrand);
            ++j;
        }

    }
    static void Color()
    {
        int colorrand = rand.Next(0, 8);

        switch (colorrand)
        {
            case 0:
                Console.
            ForegroundColor = ConsoleColor.Red;
                Console.Write("0");
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("&");
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("!");
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("$");
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("*");
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("*");
                break;
            case 6:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("~");
                break;
            case 7:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("#");
                break;
        }
    }
    static void Main(string[] args)
    {
        string Choix;
        bool Vf = false;
        do//Choice between Flashing ot Random
        {
            Console.WriteLine("Quel sapin voulez-vous? (C)lignotant ou (R)andomLight?");
            Choix = Console.ReadLine();
            foreach (string RC in new[] { "C", "R" }) // Verif tab
                Vf |= (Choix.ToUpper() == RC.ToUpper()); //R or C == true ?
            if (Vf == false) // Not ... 
            {
                Console.WriteLine("Serieux marquez pas autre chose ca marche pas...");
                Console.WriteLine();
            }
        } while (!Vf);

        ///////// Starting Values ///////////
        int LightNum;
        int SleepC;
        int SleepR;
        List<int> SapinHeight;
        List<int> SapinWidth;
        SapinHeight = new List<int>();
        SapinWidth = new List<int>();
         
        /////// Switch for Tree Types/////////
        switch (Choix.ToUpper())
        {
            case "C":
                int x; // temp value for questions


                       ////////// NB of Light Question//////////
                do
                {
                    Console.WriteLine("Nombre de lumieres?(1-1275)");
                    while (int.TryParse(Console.ReadLine(), out x) == false) ;

                    LightNum = x;
                } while (LightNum > 1276 ^ LightNum <1);


                       ///////Speed of Flashing Lights /////////
                do
                {
                    Console.WriteLine("Vitesse ?(Je conseille 25 a 75.. have fun tbh lol)");
                    while (int.TryParse(Console.ReadLine(), out x) == false) ;

                    SleepC = x;
                } while (SleepC < 1);

                Console.CursorVisible = false; // invis cursor
                SetCursorsave(LightNum, ref SapinHeight, ref SapinWidth);

                
                
                
                
                        ///////////////Begin////////////////////
                Console.Clear();
                ShowTree();
                while (true) // flashing same number of lights forever~~~~~
                {
                    for (int i = 0; i < LightNum; i++)
                    {
                        Console.SetCursorPosition(SapinWidth[i], Console.CursorTop = (SapinHeight[i]));
                        Color();
                        Console.SetCursorPosition(0, Console.CursorTop = 0);
                    }
                    Thread.Sleep(SleepC);
                }
          
            case "R":
                ////////////Speed of Rand Lights Appearing /////////
                do
                {
                    Console.WriteLine("Vitesse ?(Je conseille 25 a 75 ou sque vous voulez....)");
                    while (int.TryParse(Console.ReadLine(), out x) == false) ;

                    SleepR = x;
                } while (SleepR < 1);


                         ///////////////Begin////////////////////
                Console.Clear();
                Console.CursorVisible = false;
                ShowTree();
                while (true) // random add light til forever~~~~~~
                {
                    SetCursorStar();
                    Color();
                    Thread.Sleep(SleepR);
                }
        }
    }
}
