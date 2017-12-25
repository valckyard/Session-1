using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime;

namespace BlackJack
{
    using static System.ValueTuple;

    public enum Type
    {
        Coeur,
        Pic,
        Carreau,
        Trefle,
    }
    public enum nomcarte
    {
        As,
        Deux,
        Trois,
        Quatre,
        Cinq,
        Six,
        Sept,
        Huit,
        Neuf,
        Dix,
        Valet,
        Dame,
        Roi,
    }
    public class cartes       // lien entre les cartes pour ma liste
    {
        public Type Type { get; set; }
        public nomcarte nomcarte { get; set; }
        public int valeur { get; set; }
        public int cheat { get; set; }
    }
    public static class Utryshit
    {
       public static void ASCHK(List<cartes> nom)
        {
            int valeurtot = 0;
            /*
            foreach (cartes carte in nom) // valeur croup w/  1|11 as
            {
                valeurtot += carte.valeur;
            }
            */
            foreach (cartes carte in nom) // valeur as = 1
                if (carte.nomcarte == nomcarte.As)
                {
                    carte.valeur = 1;
                }
            foreach (cartes carte in nom) // valeur mainj w/ 1 as
            {
                valeurtot += carte.valeur;
            }
            foreach (cartes carte in nom) // check total mainj for as ....  mainj<=11 as +10 | mainj>11 as = 1
            {
                if (carte.nomcarte == nomcarte.As)
                {
                    if (valeurtot <= 11)
                    {
                        carte.valeur += 10;
                    }
                    if (valeurtot > 11)
                    {
                        carte.valeur = 1;
                    }
                }
            }
          // return mainj;
        }
        public static int CALVAL(List<cartes> nom , int valtot, out int outvalue)
        {
            foreach (cartes carte in nom)
            {
                valtot += carte.valeur;
            }
            outvalue = valtot;
            return outvalue;
        }
        public static int CHTVALEND(List<cartes> joueur, List<cartes> croupier, int valtot, out int outvalue)
        {
            foreach (cartes carte in croupier)
            {
                valtot += carte.cheat;
            }
            foreach (cartes carte in joueur)
            {
                valtot += carte.cheat;
            }
            outvalue = valtot;
            return outvalue;
        }
        public static int CHTONCALL(List<cartes> cheat, int valtot, out int outvalue)
        {
            foreach (cartes carte in cheat)
            {
                valtot += carte.cheat;
            }
            outvalue = valtot;
            return outvalue;
        }

    }
    public class paquet
    {
        private List<cartes> cartot;  //total des cartes d un paquet

        public paquet() // creer le paquet
        {
            creepaq();
        }

        public void creepaq()
        {
            cartot = new List<cartes>(); // nouvelle liste de cartes

            for (int t = 0; t < 4; t++) //type 4 x 13 pour le total 51
            {
                for (int nc = 0; nc < 13; nc++) //nom
                {
                    cartot.Add(new cartes() { Type = (Type)t, nomcarte = (nomcarte)nc }); //cree les cartes avec type i et nomcarte j dans mes enums

                    if (nc <= 8)
                        cartot[cartot.Count - 1].valeur = nc + 1; // si la carte est 9(8 ++j) ou moins la valeur est j+1 
                    else
                        cartot[cartot.Count - 1].valeur = 10; //les autres on la valeur 10

                }
            }
            foreach (cartes carte in cartot)
            {
                if (carte.valeur > 1 & carte.valeur < 7)
                {
                    carte.cheat = 1;
                }
                else if (carte.valeur == 10 ^ carte.valeur == 1)
                {
                    carte.cheat = -1;
                }
                else
                {
                    carte.cheat = 0;
                }

            }
        }       
        public void brasse()
        {
            Random brasser = new Random();
            int n = cartot.Count;    //51 cartes
            while (n > 1)            // > que une carte fait
            {
                n--;                    // enleve 1 n
                int r = brasser.Next(n + 1); // choisi une carte de 1-51 > 1-50 etc apres cette action  n-- deviens --n et est activee
                cartes carte = cartot[r];    //card = le numero dans le tablau des brassage #used
                cartot[r] = cartot[n];      //tableau de brassage au tableau brasse k -> n
                cartot[n] = carte;           //revoie au paquet avec son nombre
            }
        }

        public cartes piger()
        {
            if (cartot.Count <= 0) // si - ou = 0 demarre brasse
            {
                creepaq(); //refait le paquet et le brasse
                brasse();
            }

            cartes cardToReturn = cartot[cartot.Count - 1];
            cartot.RemoveAt(cartot.Count - 1);
            return cardToReturn;
        }
        public int restedescartes()
        {
            return cartot.Count;
        }
    }
    class Program
    {
        static int jetons;
        static int mise;
        static int jvaleurtot = 0;
        static int cvaleurtot = 0;
        static int cheatvalue;
        static int cheatvalueend;
        static paquet paq;
        static List<cartes> mainj;
        static List<cartes> croup;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            jetons = 100;
            cheatvalue = 0;
            cheatvalueend = 0;
            croup = new List<cartes>();
            mainj = new List<cartes>();
            paq = new paquet();
            paq.brasse();

                passe();

            while (jetons > 0)
                passe();

            Console.WriteLine("Vous navez plus de jetons vous avez PAAAARRRRDDDDUUUUUUU!");
            Console.ReadLine();
        }
        static void passe()
        {
            if (paq.restedescartes() < 15)
            {
                paq.creepaq();
                paq.brasse();
                cheatvalue = 0;
                cheatvalueend = 0;
            }
            int x;
            do
            {
                cheatvalueend = cheatvalue;
                Console.WriteLine($"Vous avez {jetons} Jetons!");
                Console.Write($"Entrez votre mise de 1-{jetons} :");
                if (int.TryParse(Console.ReadLine(), out x) == false)
                {
                    Console.WriteLine("Ceci n'est pas un chiffre epais ....");
                    Console.WriteLine();
                    return;
                }
                if (x > jetons)
                {
                    Console.WriteLine($"Trop haut mon champion t'as pas ces jetons la ....@_@");
                    Console.WriteLine();
                    return;
                }
                if (x <= 0)
                {
                    Console.WriteLine("Il faut miser des jetons pour en gagner evidamment...serieux...");
                    Console.WriteLine();
                    return;
                }
            } while (x > jetons ^ x <= 0);
            mise = x;
            int v = 0;
            Console.Clear();
            Console.WriteLine($"Votre mise est | {mise} |");
            Console.WriteLine("Passons 2 cartes!");
            Console.WriteLine();
            Utryshit.CHTVALEND(mainj, croup, (v), out cheatvalueend);
            cheatvalue = cheatvalueend;
            croup = new List<cartes>();
            mainj = new List<cartes>();
            mainj.Add(paq.piger());   // passe les cartes dans un ordre regulier P>C>P>C
            croup.Add(paq.piger());
            mainj.Add(paq.piger());
            croup.Add(paq.piger());
            Utryshit.ASCHK(mainj);
            Utryshit.ASCHK(croup);
            Utryshit.CHTONCALL(mainj, (v), out cheatvalue);
            Utryshit.CALVAL(mainj, (v), out jvaleurtot);
            Utryshit.CALVAL(croup, (v), out cvaleurtot);
            cheatvalue += croup[0].cheat;  // for 1st pass hidden card
            Console.WriteLine($"   UPTO now Cheat Value: {cheatvalueend}");
            Console.WriteLine("        ______________________");
            Console.WriteLine("            ~~Joueur~~");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("        |-------------------|");
            Console.WriteLine($"Carte 1:| { mainj[0].nomcarte} de {mainj[0].Type}");
            Console.WriteLine($"Carte 2:| { mainj[1].nomcarte} de {mainj[1].Type}");
            Console.WriteLine("        |-------------------|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"          Valeur: {jvaleurtot}");
            Console.WriteLine("        ______________________");
            Console.WriteLine();
            Console.WriteLine("        ______________________");
            Console.WriteLine("            ~~Croupier~~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("        |-------------------|");
            Console.WriteLine($"Carte 1:| { croup[0].nomcarte} de {croup[0].Type}");
            Console.WriteLine("Carte 2:|   ~~[Cache]~~  ");
            Console.WriteLine("        |-------------------|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"          Valeur: {croup[0].valeur}");
            Console.WriteLine("        ______________________");
            Console.WriteLine();
            Console.WriteLine($"          Cheat Value: {cheatvalue}");
            Utryshit.CALVAL(croup, (v), out cvaleurtot);
            Utryshit.CALVAL(mainj, (v), out jvaleurtot);
            if (croup[0].nomcarte == nomcarte.As || croup[0].valeur == 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Le croupier verifie si il a un BlackJack !");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
                if (cvaleurtot == 21) // BJ croup == 21
                {
                    Utryshit.CHTVALEND(mainj, croup, (v), out cheatvalue);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Croupier :  BLACKJACK!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("            ~~Croupier~~");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("        |-------------------|");
                    Console.WriteLine($"Carte 1:| { croup[0].nomcarte} de {croup[0].Type}");
                    Console.WriteLine($"Carte 2:|{ croup[1].nomcarte} de {croup[1].Type}");
                    Console.WriteLine("        |-------------------|");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"            Valeur Totale: {cvaleurtot}");
                    Console.WriteLine($"              Cheat Value: {cheatvalue}");


                    if (jvaleurtot == 21) // BJ croup == 21 et BJ mainj == 21
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine();
                        Console.WriteLine("EGALITE!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Egalite vous avez {jvaleurtot} et le croupier {cvaleurtot} ! Vous recuperez votre mise de {mise} !");
                    }
                    else if (jvaleurtot != 21) // main != 21 et BJ croup == 21
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("PERDU NIGAUD!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Perdu ! Vous avez {jvaleurtot} et le croupier {cvaleurtot} ! Vous perdez votre mise de {mise} ...");
                        jetons = jetons - mise;
                    }
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Le croupier n'a pas de BlackJack");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            if (jvaleurtot == 21) // mainj == 21 naturel BlackJack
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("VOUS AVEZ UN BLACKJACK ! VOUS AVEZ GAGNE!!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Vous gagnez votre mise {mise} x 2.5!");
                jetons += (mise + mise + (mise / 2));
                Console.WriteLine();
                return;

            }
            Console.WriteLine();
            Console.WriteLine("On Continue !");
            Console.WriteLine();
            bool vf = false;
            string hs;
            do
            {
                do
                {
                    Console.Write("Voulez vous faire un Hit ou Stand? Ecrivez  H/S? ");
                    hs = Console.ReadLine();

                    foreach (string hos in new[] { "H", "S" }) // groupe de verification
                        vf |= (hos.ToUpper() == hs.ToUpper()); //h ou s Vrai ou Faux

                    if (vf == false) // pas h ou s
                    {
                        Console.WriteLine("Entrez H pour Hit et S pour Stand!! Pas autre Chose!");
                    }

                } while (!vf);

                switch (hs.ToUpper())
                {
                    case "H":
                        mainj.Add(paq.piger());
                        Utryshit.CHTVALEND(mainj, croup, (v), out cheatvalue);
                        Utryshit.ASCHK(mainj);
                        Utryshit.CALVAL(mainj, (v), out jvaleurtot);
                        Thread.Sleep(1000);
                        Console.WriteLine();
                        Console.WriteLine("        ______________________");
                        Console.WriteLine("            ~~Joueur~~");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("        |-------------------|");
                        Console.WriteLine($"HIT     |   { mainj[mainj.Count - 1].nomcarte} de {mainj[mainj.Count - 1].Type}");
                        Console.WriteLine("        |-------------------|");
                        Console.WriteLine("        ______________________");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"          Valeur Totale : {jvaleurtot}");
                        Console.WriteLine($"            Cheat Value : {cheatvalue}");
                        Console.WriteLine();
                        if (jvaleurtot > 21) // HIT mainj > 21
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Bust! Mon Chou!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Vous perdez votre mise de {mise}...");
                            jetons -= mise;
                            Console.WriteLine();
                            return;
                        }
                        else if (jvaleurtot == 21) // HIT mainj==21
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("BlackJack mon grand!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Vous devriez stand maintenant... a moins que vous vouliez perdre.. hahah");
                            Console.WriteLine();
                            continue;
                        }
                        else
                        {
                            continue;
                        }

                    case "S": // STAND
                        Utryshit.CHTVALEND(mainj, croup, (v), out cheatvalue);
                        Console.WriteLine();
                        Console.WriteLine("        ______________________");
                        Console.WriteLine("            ~~Croupier~~");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("        |-------------------|");
                        Console.WriteLine($"Carte 1:|{ croup[0].nomcarte} de {croup[0].Type}");
                        Console.WriteLine($"Carte 2:|{ croup[1].nomcarte} de {croup[1].Type}");
                        Console.WriteLine("        |-------------------|");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("        ______________________");
                        Console.WriteLine($"          Valeur Totale : {cvaleurtot}");
                        Console.WriteLine($"            Cheat Value : {cheatvalue}");
                        while ((cvaleurtot < 18) & (cvaleurtot < jvaleurtot + 1)) // conditions de jeu du croupier
                        {
                            croup.Add(paq.piger());
                            Utryshit.CHTVALEND(mainj, croup, (v), out cheatvalue);
                            Utryshit.ASCHK(croup);
                            Utryshit.CALVAL(croup, (v), out cvaleurtot);
                            Thread.Sleep(1000);
                            Console.WriteLine("        ______________________");
                            Console.WriteLine("            ~~Croupier~~");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("        |-------------------|");
                            Console.WriteLine($"HIT     |  { croup[croup.Count - 1].nomcarte} de {croup[croup.Count - 1].Type}");
                            Console.WriteLine("        |-------------------|");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ______________________");
                            Console.WriteLine($"          Valeur Totale : {cvaleurtot}");
                            Console.WriteLine($"            Cheat Value : {cheatvalue}");
                            Console.WriteLine();
                        }
                        if (cvaleurtot > 21 && jvaleurtot == 21) // condition croup>21 et mainj == 21
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Croupier BUST!");
                            Console.WriteLine();
                            Console.WriteLine("De plus vous avez un BlackJack !!!! ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Vous gagnez votre mise {mise} x2.5!");
                            Console.WriteLine();
                            jetons += mise + mise + (mise / 2);
                            return;
                        }
                        else if (cvaleurtot > 21) // croup >21
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Croupier BUST!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Vous gagnez votre mise {mise}!");
                            Console.WriteLine();
                            jetons += mise;
                            return;
                        }
                        else
                        {
                            if (jvaleurtot == cvaleurtot) // mainj = croup
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"Egalite vous avez {jvaleurtot} et le croupier {cvaleurtot} ! Retour de votre mise {mise} ... ");
                                Console.ForegroundColor = ConsoleColor.White;
                                return;
                            }
                            else if (cvaleurtot > jvaleurtot) // croup > mainj
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Le Croupier a {cvaleurtot} et vous avez {jvaleurtot} ... Le Croupier GAGNE!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Vous perdez votre mise de {mise}...");
                                Console.WriteLine();
                                jetons -= mise;
                                return;
                            }
                            else if (jvaleurtot == 21 && jvaleurtot > cvaleurtot) // mainj ==21 et mainj > croup
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Le Croupier a {cvaleurtot} et vous avez {jvaleurtot} BLACKJACK! Vous GAGNEZ!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Vous gagnez votre mise {mise} x2.5!!");
                                Console.WriteLine();
                                jetons += mise + mise + (mise / 2);
                                return;
                            }
                            else //mainj > croup
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Le Croupier a {cvaleurtot} et vous avez {jvaleurtot} ... Vous GAGNEZ!");
                                Console.WriteLine($"Vous gagnez votre mise {mise}!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                jetons += mise;
                                return;
                            }
                        }

                    default:
                        break;
                }
            } while (true);
        }
    }

}