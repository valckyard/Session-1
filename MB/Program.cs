using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJOnePlayer
{
    class CalcDeck
    {
        static int[] CreeLeDeck()
        {
            int[] deckCard = new int[52];  //le new  c'est ce qui vient de travailler aec le type reference et vient chercher son pointeur. Manipule l'objet originale
            Random rand = new Random();
            return deckCard;
        }

        static void BrasserLeDeck(int[] deckCard)
        {
            var rand = new Random();
            for (int i = 0; i < 52; ++i)
            {
                int cardNb = rand.Next() % (i + 1);
                deckCard[i] = deckCard[cardNb];
                deckCard[cardNb] = i;
            }
        }

        static string GraphCarte(int carte)
        {
            const string suite = "♥♦♣♠";
            const string valeuralpha = "A23456789TJQK";
            int val = carte % 13;
            int coul = carte / 13;
            char txtVal = valeuralpha[val];
            char txtsuite = suite[coul];
            return $"{txtVal}{txtsuite}";
        }

        static int CalculTotMain(char value)
        {
            Console.WriteLine(value);
            int total;
            if (value == 'T' || value == 'J' || value == 'Q' || value == 'K')
            {
                return total = 10;
            }
            else if (value == 'A')
            {
                return total = 1;
            }
            else
            {
                return total = Convert.ToInt32(value);
            }
           
        }
        static void Piger(ref int[] deck, ref int CardCount,int incrementpaq, ref List<List<string>> main, ref List<List<int>> ttlesmains)
        {
            int carte = deck[CardCount];
            //Crée la carte graphiquement
            string fullCard = GraphCarte(carte);

            //Ajoute la carte dans la main du joueur
            main[incrementpaq].Add(fullCard);
            //Calcul et ajoute la valeur de la carte à la maison du joueur
            char valueCard = fullCard[0];
            int valeur = CalculTotMain(valueCard);
            ttlesmains[incrementpaq].Add(valeur);
            // IncrÉmente la paquet
            ++CardCount;
            ++incrementpaq;

        }
    class Program
    {
        static void Main(string[] args)
        {
            //Création des main des joueurs
            List<List<string>> hand = new List<List<string>>();
            for (int i = 1; i < 3; ++i)
                hand.Add(new List<string>());
            //Création de la pour le comptage du Total des joueurs
            List<List<int>> handTotal = new List<List<int>>();
            for (int i = 1; i < 3; ++i)
                handTotal.Add(new List<int>());
            int CountDeck = 0; //CardCount
            int[] deckCard = CreeLeDeck();
            BrasserLeDeck(deckCard);

            int distru = 1;
            int incremJ = 0;
                int joueurs = 0;
                    // demande switch
                    Piger(ref deckCard, ref CountDeck, 0, ref hand, ref handTotal);
                    Piger(ref deckCard, ref CountDeck, 1, ref hand, ref handTotal);

                
            Console.WriteLine("Test");
            int p = 0;
        }

       
        }
    }
}

