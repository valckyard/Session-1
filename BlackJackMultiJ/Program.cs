using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime;
using System.Diagnostics;
using System.Runtime.InteropServices;

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
    public static class calculs

    {
        static public Random pmisemavie = new Random();
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);
        public static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }
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
        public static int CALVAL(List<cartes> nom, out int outvalue)
        {
            int valtot = 0;
            foreach (cartes carte in nom)
            {
                valtot += carte.valeur;
            }
            outvalue = valtot;
            return outvalue;
        }
        private static int VALTOT(List<cartes> nomplayer)
        {
            int valeurtot;
            calculs.CALVAL(nomplayer, out valeurtot);
            return valeurtot;
        }
        public static int CHTONCALL(List<cartes> pjc, int cheatin, out int cheatout)
        {
            foreach (cartes carte in pjc)
            {
                cheatin += carte.cheat;
            }
            cheatout = cheatin;
            return cheatout;
        }
        public static void Perdsmise(string playername, int jetons, int mise, out int jetonsout)
        {
            jetonsout = 0;
            if (jetons <= 0)
            {
                jetonsout = 0;
            }
            else
            {
                jetonsout = jetons - mise;
                Console.WriteLine($"{playername} perds sa mise {mise} ...");
            }
        }
        public static int Players(out int joueurs)
        {
            int z;
            do
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Combien de joueurs sont avec vous a votre table?");
                Console.Write($"Entrez un nombre de joueurs de 1 a 4 :");
                while (int.TryParse(Console.ReadLine(), out z) == false)
                    Console.Write($"Entrez un NOMBRE(pas une lettre criss de cave)de joueurs de 1 a 4 :");
                //Console.WriteLine("Ceci n'est pas un chiffre epais ....");
                if (z > 5)
                {
                    Console.WriteLine($"Trop de joueurs!~");
                }
                if (z < 0)
                {
                    Console.WriteLine("Si vous ne voulez pas jouer dites le!");
                }
            } while (z < 0 ^ z > 5);
            joueurs = z;
            return joueurs;
        }
        public static void Misejoueur(int jetons, out int misej)
        {
            int x;
            do
            {
                Console.WriteLine($"Vous avez {jetons} Jetons!");
                Console.Write($"Entrez votre mise de 1-{jetons} :");
                if (int.TryParse(Console.ReadLine(), out x) == false)
                {
                    Console.WriteLine("Ceci n'est pas un chiffre epais ....");
                    Console.WriteLine();
                }
                if (x > jetons)
                {
                    Console.WriteLine($"Trop haut mon champion t'as pas ces jetons la ....@_@");
                    Console.WriteLine();
                }
                if (x <= 0)
                {
                    Console.WriteLine("Il faut miser des jetons pour en gagner evidamment...serieux...");
                    Console.WriteLine();
                }
            } while (x > jetons ^ x <= 0);
            misej = x;
        }
        public static void MisePlayer(int pjetons, int cheatvalue, int playernum, out int miseplayer)
        {
            miseplayer = 0;
            if (pjetons <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Player {playernum} a Perdu  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("||  ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (cheatvalue > -4 & cheatvalue < 4)
                {
                    miseplayer = pmisemavie.Next(10, 38);
                    if (miseplayer > pjetons)
                    {
                        miseplayer = pjetons;
                    }
                }
                if (cheatvalue <= -4)
                {
                    miseplayer = pmisemavie.Next(1, 17);
                    if (miseplayer > pjetons)
                    {
                        miseplayer = pjetons;
                    }
                }
                if (cheatvalue >= 4)
                {
                    miseplayer = pmisemavie.Next(50, 90);
                    if (miseplayer > pjetons)
                    {
                        miseplayer = pjetons;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Player {playernum} mises |");
                Console.Write($" {miseplayer} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|!  ||");
            }
        }
        public static void CroupBJCHKj(int mise, ref int jetons, int jvaleurtot, int cvaleurtot)
        {
            if (jvaleurtot == 21) // BJ croup == 21 et BJ mainj == 21
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Vous avez EGALITE!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Egalite vous avez {jvaleurtot} et le croupier {cvaleurtot} ! Vous recuperez votre mise de {mise} !");
            }
            else if (jvaleurtot != 21) // main != 21 et BJ croup == 21
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous avez PERDU NIGAUD!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Perdu ! Vous avez {jvaleurtot} et le croupier {cvaleurtot} ! Vous perdez votre mise de {mise} ...");
                jetons = jetons - mise;
            }
        }
        public static void CroupBJCHKP(int pvaleurtot, int cvaleurtot, ref int jetons, int pmise, int playernum)
        {
            if (pvaleurtot == 21) // BJ croup == 21 et BJ mainj == 21
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine("EGALITE!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Egalite player {playernum} a {pvaleurtot} et le croupier {cvaleurtot} !Il recupere sa mise de #pasrendula !");
            }
            else if (pvaleurtot != 21) // main != 21 et BJ croup == 21
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"Player {playernum} a perdu!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Player {playernum} a {pvaleurtot} et le croupier {cvaleurtot} ! Vous perdez votre mise de #pasrendula ...");
                jetons -= pmise;
            }
        }
        public static void NBJcheckJ(int jvaleurtot, int jwinloss, out int jwinlossout)
        {
            jwinlossout = 0;
            if (jwinloss == 0)
            {
                if (jvaleurtot == 21)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("VOUS AVEZ UN BLACKJACK ! VOUS AVEZ GAGNE!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Veuillez attendre la fin du tour!");
                    jwinlossout = 3;
                }
                else
                {
                    jwinlossout = 0;
                }
            }

        }
        public static void NBJcheckP(int pvaleurtot, int pwinloss, int playernum, out int pwinlossout)
        {
            pwinlossout = 0;
            if (pwinloss == 0)
            {
                if (pvaleurtot == 21)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Player {playernum} a un BLACKJACK !!! il Gagne!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"En attente de la fin du tour!");
                    pwinlossout = 3;
                }
                else
                {
                    pwinlossout = 0;
                }
            }
        }
        // START VALUE AND CARDS OF AI PLAYERS
        public static void AIPLYRSTART(List<cartes> nomplayer, ref int jetons, ref int cheat, int playernum, ref int valeurtot, ref int winloss)
        {
            if (jetons <= 1)
            {
                Console.WriteLine();
                Console.WriteLine($"Player {playernum} Ne peux plus jouer... Il a deja perdu!");
                winloss = 5;
            }
            else
            {
                CHTONCALL(nomplayer, cheat, out cheat); // add starting hand to cheat
                ASCHK(nomplayer);
                valeurtot = VALTOT(nomplayer);
                Thread.Sleep(1200);
                Console.WriteLine($"        ______________________________--------------_________________________________");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"        |-------------------|           ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"~~Player {playernum}~~");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Carte 1:|{ nomplayer[0].nomcarte} de {nomplayer[0].Type}");
                Console.WriteLine($"Carte 2:|{ nomplayer[1].nomcarte} de {nomplayer[1].Type}");
                Console.Write($"        |-------------------|");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"     Main :");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" <|| ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{valeurtot}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" ||>   ||Cheat Value : {cheat}||");
                winloss = 0;
            }
        }
        // AI PLAYERS HITS TO OUT VALUE cant win need final check
        public static List<cartes> AIPLYR(List<cartes> nomplayer, paquet paqin, int cheat, int pwinloss, out paquet paqout, out int cheatvalue, int playernum, out int pwinlossout)
        {
            if (pwinloss == 0)
            {
                // add a if already won value
                cheatvalue = 0;
                int valeurtot = 0;
                //called values
                ASCHK(nomplayer);
                valeurtot = VALTOT(nomplayer);
                Thread.Sleep(1200);
                Console.WriteLine($"        ______________________________--------------_________________________________");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"        |-------------------|           ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"~~Player {playernum}~~");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Carte 1:|{ nomplayer[0].nomcarte} de {nomplayer[0].Type}");
                Console.WriteLine($"Carte 2:|{ nomplayer[1].nomcarte} de {nomplayer[1].Type}");
                Console.Write($"        |-------------------|");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"     Main :");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" <|| ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{valeurtot}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" ||>   ||Cheat Value : {cheat}||");
                Console.ForegroundColor = ConsoleColor.White;
                cheatvalue = cheat;
                while (valeurtot < 18)  // conditions de jeu
                {
                    nomplayer.Add(paqin.piger(cheat, out cheat)); // add new card to cheat
                    calculs.ASCHK(nomplayer);
                    valeurtot = VALTOT(nomplayer);
                    Thread.Sleep(1200);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"HIT     |  { nomplayer[nomplayer.Count - 1].nomcarte} de {nomplayer[nomplayer.Count - 1].Type}");
                    Console.Write($"        |-------------------|");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"     Main :");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" <|| ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{valeurtot}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" ||>   ||Cheat Value : {cheat}||");
                    Console.ForegroundColor = ConsoleColor.White;
                    cheatvalue = cheat;
                    paqout = paqin;
                }
                if (valeurtot > 21)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Player {playernum} BUST!");
                    Console.WriteLine();
                    //add return of lost already
                    paqout = paqin;
                    pwinlossout = 1;
                    return nomplayer;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Player {playernum} a termine son tour! Avec {valeurtot}");
                    Console.WriteLine($"En attente du croupier");
                    Console.WriteLine();
                    paqout = paqin;
                    pwinlossout = 2;
                    return nomplayer;
                }
            }
            else if (pwinloss == 5)
            {
                Console.WriteLine();
                Console.WriteLine($"Player {playernum} ne peux plus jouer...Il a deja perdu!");
                paqout = paqin;
                cheatvalue = cheat;
                pwinlossout = 5;
                return nomplayer;
            }
            else
            {
                Console.WriteLine($"Player {playernum} a deja termine de jouer");
                Console.WriteLine();
                pwinlossout = 2;
                paqout = paqin;
                cheatvalue = cheat;
                return nomplayer;
            }
        }
        public static void FCheck(List<cartes> Croupier, List<cartes> chkplayer, int mise, int jetonsin, string playernom, int pwinloss, out int jetonsout)
        {
            int pvaleurtot = 0;
            int cvaleurtot = 0;
            jetonsout = 0;
            cvaleurtot = VALTOT(Croupier);
            pvaleurtot = VALTOT(chkplayer);
            if (pwinloss == 2)
            {
                if (cvaleurtot > 21 && pvaleurtot == 21) // condition croup>21 et mainj == 21
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Croupier BUST! {cvaleurtot} et {playernom} a un BlackJack !!!! ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{playernom} gagne sa mise {mise} x2.5! Donc {mise + mise + (mise / 2)}");
                    jetonsin += mise + mise + (mise / 2);
                    Console.WriteLine($"{playernom} a maintenant |{jetonsin}| jetons.");
                    jetonsout = jetonsin;
                }
                else if (cvaleurtot > 21) // croup >21
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Croupier BUST!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Gagne ! {playernom} gagne sa mise {mise}!");
                    jetonsin += mise;
                    Console.WriteLine($"{playernom} a maintenant |{jetonsin}| jetons.");
                    jetonsout = jetonsin + mise;
                }
                else
                {
                    if (pvaleurtot == cvaleurtot) // mainj = croup
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Egalite ~{playernom} a {pvaleurtot} et le croupier {cvaleurtot} !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Retour de la mise de {playernom}");
                        jetonsout = jetonsin;
                        Console.WriteLine($"{playernom} a maintenant |{jetonsin}| jetons.");
                    }
                    else if (cvaleurtot > pvaleurtot) // croup > mainj
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Le Croupier a {cvaleurtot} et {playernom} a {pvaleurtot} ... Le Croupier GAGNE!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{playernom} perd sa mise {mise} ...");
                        jetonsin -= mise;
                        Console.WriteLine($"{playernom} a maintenant |{jetonsin}| jetons.");
                        jetonsout = jetonsin;
                    }
                    else if (pvaleurtot == 21 && pvaleurtot > cvaleurtot) // mainj ==21 et mainj > croup
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Le Croupier a {cvaleurtot} et {playernom} a {pvaleurtot} BLACKJACK! Il Gagne!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{playernom} gagne sa mise {mise} x2.5! Donc {mise + mise + (mise / 2)}");
                        jetonsin += mise + mise + (mise / 2);
                        Console.WriteLine($"{playernom} a maintenant |{jetonsin}| jetons.");
                        jetonsout = jetonsin;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Le Croupier a {cvaleurtot} et {playernom} a {pvaleurtot} ... Victoire !");
                        Console.WriteLine($"{playernom} gagne sa mise {mise} !");
                        Console.ForegroundColor = ConsoleColor.White;
                        jetonsin += mise;
                        Console.WriteLine($"{playernom} a maintenant |{jetonsin}| jetons.");
                        jetonsout = jetonsin;
                    }

                }

            }
            else if (pwinloss == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{playernom} busted earlier with {pvaleurtot}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{playernom} perd sa mise de {mise}...");
                jetonsin -= mise;
                Console.WriteLine($"{playernom} a maintenant |{jetonsin}| jetons.");
                jetonsout = jetonsin;
            }
            else if (pwinloss == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{playernom} a gagne avec un Black Jack naturel au depart !");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{playernom} gagne sa mise {mise} x2.5! Donc {mise + mise + (mise / 2)}");
                jetonsin += mise + mise + (mise / 2);
                Console.WriteLine($"{playernom} a maintenant |{jetonsin}| jetons.");
                jetonsout = jetonsin;
            }
            else if (pwinloss == 5)
            {
                Console.WriteLine($"{playernom} ne peux plus jouer....Il a perdu!");
                if (jetonsin <= 0)
                {
                    jetonsin = 0;
                    jetonsin = jetonsout;
                }
                Console.WriteLine($"{playernom} a |{jetonsin}| jetons.");
            }

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
        public cartes piger(int cheatin, out int cheatout)
        {
            cartes Cartepigee;
            if (cartot.Count <= 0) // si - ou = 0 demarre brasse
            {
                creepaq(); //refait le paquet et le brasse
                brasse();
            }
            Cartepigee = cartot[cartot.Count - 1];
            cartot.RemoveAt(cartot.Count - 1);
            cheatin += Cartepigee.cheat;
            cheatout = cheatin;
            return Cartepigee;
        }
        public cartes pigernr()
        {
            if (cartot.Count <= 0) // si - ou = 0 demarre brasse
            {
                creepaq(); //refait le paquet et le brasse
                brasse();
            }
            cartes Cartepigee = cartot[cartot.Count - 1];
            cartot.RemoveAt(cartot.Count - 1);
            return Cartepigee;
        }
        public int restedescartes()
        {
            return cartot.Count;
        }
    }
    class Program
    {
        static int jetons;
        static int p1jetons;
        static int p2jetons;
        static int p3jetons;
        static int p4jetons;
        static int mise;
        static int p1mise;
        static int p2mise;
        static int p3mise;
        static int p4mise;
        static int p1valeurtot;
        static int p2valeurtot;
        static int p3valeurtot;
        static int p4valeurtot;
        static int jwinloss;
        static int p1winloss;
        static int p2winloss;
        static int p3winloss;
        static int p4winloss;
        static int jvaleurtot;
        static int cvaleurtot;
        static int cheatvalue;
        static int joueurs;
        static paquet paq;
        static List<cartes> mainj;
        static List<cartes> croup;
        static List<cartes> playr1;
        static List<cartes> playr2;
        static List<cartes> playr3;
        static List<cartes> playr4;
        static void Main(string[] args)
        {

            // stating values/////////////////////////////////////////////////////////////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.White;
            calculs.Maximize();
            jetons = 100;
            p1jetons = 100;
            p2jetons = 100;
            p3jetons = 100;
            p4jetons = 100;
            cheatvalue = 0;
            joueurs = 0;
            croup = new List<cartes>();
            mainj = new List<cartes>();
            paq = new paquet();
            paq.brasse();
            // start of the game

            passe();

            //end of the game if jeton < 0
            while (jetons > 0)
                passe();

            Console.WriteLine("Vous navez plus de jetons vous avez PAAAARRRRDDDDUUUUUUU!");
            Console.ReadLine();
        }
        //start of game//////////////////////////////////////////////////////////////////////////////////////////////
        static void passe()
        {
            //creepaq if <15 cards
            if (paq.restedescartes() < 15)
            {
                paq.creepaq();
                paq.brasse();
                // on new paq cheatvalue goes back to 0
                cheatvalue = 0;
            }
            // player AI number
            calculs.Players(out joueurs);
            // mise du joueur
            calculs.Misejoueur(jetons, out mise);
            /////////////////////////////BEGIN VISUAL/CARD DISTRIB PART///////////////////////////////////////
            Console.Clear();
            //MISE AI
            switch (joueurs)
            {
                case 0:
                    break;
                case 1:     // 1 Joueur AI
                    calculs.MisePlayer(p1jetons, cheatvalue, 1, out p1mise);
                    Console.WriteLine();
                    break;
                case 2:     // 2 joueurs AI
                    calculs.MisePlayer(p1jetons, cheatvalue, 1, out p1mise);
                    calculs.MisePlayer(p2jetons, cheatvalue, 2, out p2mise);
                    Console.WriteLine();
                    break;
                case 3:     // 3 joueurs AI
                    calculs.MisePlayer(p1jetons, cheatvalue, 1, out p1mise);
                    calculs.MisePlayer(p2jetons, cheatvalue, 2, out p2mise);
                    calculs.MisePlayer(p3jetons, cheatvalue, 3, out p3mise);
                    Console.WriteLine();
                    break;
                case 4:     // 4 joueurs AI
                    calculs.MisePlayer(p1jetons, cheatvalue, 1, out p1mise);
                    calculs.MisePlayer(p2jetons, cheatvalue, 2, out p2mise);
                    calculs.MisePlayer(p3jetons, cheatvalue, 3, out p3mise);
                    calculs.MisePlayer(p4jetons, cheatvalue, 4, out p4mise);
                    Console.WriteLine();
                    break;
            }
            Console.WriteLine();
            Console.Write($"Votre mise est |");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" {mise} ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"|");
            Console.WriteLine("Passons 2 cartes! Pesez sur enter pour continuer!");
            Console.ReadLine();
            croup = new List<cartes>();
            mainj = new List<cartes>();
            // players card show / value
            bool cheatcrouphidden = true;
            // insure reset of thoses values IE jwinloss stick as 1 **************************************
            p1valeurtot = 0;
            p2valeurtot = 0;
            p3valeurtot = 0;
            p4valeurtot = 0;
            jwinloss = 0;
            p1winloss = 0; // to determine win already 1 =won/lost 0 continue
            p2winloss = 0;
            p3winloss = 0;
            p4winloss = 0;
            switch (joueurs)
            {
                case 0:
                    mainj.Add(paq.pigernr());   // passe les cartes dans un ordre regulier P>C>P>C
                    croup.Add(paq.pigernr());
                    mainj.Add(paq.pigernr());
                    croup.Add(paq.pigernr());
                    break;
                case 1:     // 1 Joueur AI
                    playr1 = new List<cartes>();
                    mainj.Add(paq.pigernr());    // passe les cartes dans un ordre regulier P>C>P>C
                    if (p1jetons > 0)
                    {
                        playr1.Add(paq.pigernr());
                    }
                    croup.Add(paq.pigernr());
                    mainj.Add(paq.pigernr());
                    if (p1jetons > 0)
                    {
                        playr1.Add(paq.pigernr());
                    }
                    croup.Add(paq.pigernr());
                    break;
                case 2:     // 2 joueurs AI
                    playr1 = new List<cartes>();
                    playr2 = new List<cartes>();
                    mainj.Add(paq.pigernr());    // passe les cartes dans un ordre regulier P>C>P>C
                    if (p1jetons > 0)
                    {
                        playr1.Add(paq.pigernr());
                    }
                    if (p2jetons > 0)
                    {
                        playr2.Add(paq.pigernr());
                    }
                    croup.Add(paq.pigernr());
                    mainj.Add(paq.pigernr());
                    if (p1jetons > 0)
                    {
                        playr1.Add(paq.pigernr());
                    }
                    if (p2jetons > 0)
                    {
                        playr2.Add(paq.pigernr());
                    }
                    croup.Add(paq.pigernr());
                    break;
                case 3:     // 3 joueurs AI
                    playr1 = new List<cartes>();
                    playr2 = new List<cartes>();
                    playr3 = new List<cartes>();
                    mainj.Add(paq.pigernr()); // passe les cartes dans un ordre regulier P>C>P>C
                    if (p1jetons > 0)
                    {
                        playr1.Add(paq.pigernr());
                    }
                    if (p2jetons > 0)
                    {
                        playr2.Add(paq.pigernr());
                    }
                    if (p3jetons > 0)
                    {
                        playr3.Add(paq.pigernr());
                    };
                    croup.Add(paq.pigernr());
                    mainj.Add(paq.pigernr());
                    if (p1jetons > 0)
                    {
                        playr1.Add(paq.pigernr());
                    }
                    if (p2jetons > 0)
                    {
                        playr2.Add(paq.pigernr());
                    }
                    if (p3jetons > 0)
                    {
                        playr3.Add(paq.pigernr());
                    }
                    croup.Add(paq.pigernr());
                    break;
                case 4:     // 4 joueurs AI
                    playr1 = new List<cartes>();
                    playr2 = new List<cartes>();
                    playr3 = new List<cartes>();
                    playr4 = new List<cartes>();
                    mainj.Add(paq.pigernr());
                    if (p1jetons > 0)
                    {
                        playr1.Add(paq.pigernr());
                    }
                    if (p2jetons > 0)
                    {
                        playr2.Add(paq.pigernr());
                    }
                    if (p3jetons > 0)
                    {
                        playr3.Add(paq.pigernr());
                    }
                    if (p4jetons > 0)
                    {
                        playr4.Add(paq.pigernr());
                    }
                    croup.Add(paq.pigernr());
                    mainj.Add(paq.pigernr());
                    if (p1jetons > 0)
                    {
                        playr1.Add(paq.pigernr());
                    }
                    if (p2jetons > 0)
                    {
                        playr2.Add(paq.pigernr());
                    }
                    if (p3jetons > 0)
                    {
                        playr3.Add(paq.pigernr());
                    }
                    if (p4jetons > 0)
                    {
                        playr4.Add(paq.pigernr());
                    }
                    croup.Add(paq.pigernr());
                    break;
                default:
                    break;
            }
            calculs.ASCHK(mainj);
            calculs.ASCHK(croup);
            calculs.CALVAL(mainj, out jvaleurtot);// Human Plyer deal valtot
            calculs.CALVAL(croup, out cvaleurtot);// Dealer deal valtot
            Thread.Sleep(1200);
            Console.WriteLine($"   UPTO now Cheat Value: {cheatvalue}");
            calculs.CHTONCALL(mainj, cheatvalue, out cheatvalue); // 1st add to new cheat using last game cheat
            Console.WriteLine($"        ______________________________--------------_________________________________");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"        |-------------------|           ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"~~Joueur~~");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Carte 1:| { mainj[0].nomcarte} de {mainj[0].Type}");
            Console.WriteLine($"Carte 2:| { mainj[1].nomcarte} de {mainj[1].Type}");
            Console.Write($"        |-------------------|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"     Main :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" <|| ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{jvaleurtot}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" ||>   ||Cheat Value : {cheatvalue}||");
            Console.ForegroundColor = ConsoleColor.White;
            switch (joueurs)
            {
                case 0:
                    break;
                case 1:     // 1 Joueur AI
                    calculs.AIPLYRSTART(playr1, ref p1jetons, ref cheatvalue, 1, ref p1valeurtot, ref p1winloss);
                    break;
                case 2:     // 2 joueurs AI
                    calculs.AIPLYRSTART(playr1, ref p1jetons, ref cheatvalue, 1, ref p1valeurtot, ref p1winloss);
                    calculs.AIPLYRSTART(playr2, ref p2jetons, ref cheatvalue, 2, ref p2valeurtot, ref p2winloss);
                    break;
                case 3:     // 3 joueurs AI
                    calculs.AIPLYRSTART(playr1, ref p1jetons, ref cheatvalue, 1, ref p1valeurtot, ref p1winloss);
                    calculs.AIPLYRSTART(playr2, ref p2jetons, ref cheatvalue, 2, ref p2valeurtot, ref p2winloss);
                    calculs.AIPLYRSTART(playr3, ref p3jetons, ref cheatvalue, 3, ref p3valeurtot, ref p3winloss);
                    break;
                case 4:     // 4 joueurs AI
                    calculs.AIPLYRSTART(playr1, ref p1jetons, ref cheatvalue, 1, ref p1valeurtot, ref p1winloss);
                    calculs.AIPLYRSTART(playr2, ref p2jetons, ref cheatvalue, 2, ref p2valeurtot, ref p2winloss);
                    calculs.AIPLYRSTART(playr3, ref p3jetons, ref cheatvalue, 3, ref p3valeurtot, ref p3winloss);
                    calculs.AIPLYRSTART(playr4, ref p4jetons, ref cheatvalue, 4, ref p4valeurtot, ref p4winloss);
                    break;
                default:
                    break;
            }
            cheatvalue += croup[0].cheat;  // add after 1st pass hidden card so no count
            cheatcrouphidden = false; // so it does not happen twice
            Thread.Sleep(1200);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"        ______________________________--------------_________________________________");
            Console.WriteLine($"        |-------------------|           ~~Croupier~~"); // single card val
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Carte 1:| { croup[0].nomcarte} de {croup[0].Type}");
            Console.WriteLine("Carte 2:|   ~~[Cache]~~  ");
            Console.Write($"        |-------------------|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"     Main :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" <|| ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{croup[0].valeur}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" ||>   ||Cheat Value : {cheatvalue}||");
            Console.ForegroundColor = ConsoleColor.White;
            //PEAK to check dealer BJ if 1st card is AS or 10s
            if (croup[0].nomcarte == nomcarte.As || croup[0].valeur == 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("***Le croupier verifie si il a un BlackJack !***");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
                //IF CHECK return a BJ for dealer
                if (cvaleurtot == 21)
                {
                    cheatvalue += croup[1].cheat;  // add hidden card
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le Croupier a un BLACKJACK!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"        ______________________________--------------_________________________________");
                    Console.WriteLine($"        |-------------------|          ~~Croupier~~"); // full reveal value
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Carte 1:| { croup[0].nomcarte} de {croup[0].Type}");
                    Console.WriteLine($"Carte 2:|{ croup[1].nomcarte} de {croup[1].Type}");
                    Console.Write($"        |-------------------|");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"     Main :");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" <|| ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{cvaleurtot}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" ||>   ||Cheat Value : {cheatvalue}||");
                    Console.ForegroundColor = ConsoleColor.White;
                    // CHECK FOR EQUAL VALUES to negate dealer BJ 
                    if (jvaleurtot == 21 ^ p1valeurtot == 21 ^ p2valeurtot == 21 ^ p3valeurtot == 21 ^ p4valeurtot == 21) // BJ croup == 21 et BJ mainj == 21 // unnasigned if ot used
                    {
                        switch (joueurs)
                        {
                            case 0:
                                calculs.CroupBJCHKj(mise, ref jetons, jvaleurtot, cvaleurtot);
                                return;
                            case 1:     // 1 Joueur AI
                                calculs.CroupBJCHKj(mise, ref jetons, jvaleurtot, cvaleurtot);
                                calculs.CroupBJCHKP(p1valeurtot, cvaleurtot, ref p1jetons, p1mise, 1);
                                return;
                            case 2:     // 2 joueurs AI
                                calculs.CroupBJCHKj(mise, ref jetons, jvaleurtot, cvaleurtot);
                                calculs.CroupBJCHKP(p1valeurtot, cvaleurtot, ref p1jetons, p1mise, 1);
                                calculs.CroupBJCHKP(p2valeurtot, cvaleurtot, ref p2jetons, p2mise, 2);
                                return;
                            case 3:     // 3 joueurs AI
                                calculs.CroupBJCHKj(mise, ref jetons, jvaleurtot, cvaleurtot);
                                calculs.CroupBJCHKP(p1valeurtot, cvaleurtot, ref p1jetons, p1mise, 1);
                                calculs.CroupBJCHKP(p2valeurtot, cvaleurtot, ref p2jetons, p2mise, 2);
                                calculs.CroupBJCHKP(p3valeurtot, cvaleurtot, ref p3jetons, p3mise, 3);
                                return;
                            case 4:     // 4 joueurs AI
                                calculs.CroupBJCHKj(mise, ref jetons, jvaleurtot, cvaleurtot);
                                calculs.CroupBJCHKP(p1valeurtot, cvaleurtot, ref p1jetons, p1mise, 1);
                                calculs.CroupBJCHKP(p2valeurtot, cvaleurtot, ref p2jetons, p2mise, 2);
                                calculs.CroupBJCHKP(p3valeurtot, cvaleurtot, ref p3jetons, p3mise, 3);
                                calculs.CroupBJCHKP(p4valeurtot, cvaleurtot, ref p4jetons, p4mise, 4);
                                return;
                        }
                    }
                    // only dealer has BJ so everyone lose automaticly
                    else
                    {
                        Console.WriteLine("Tout le monde perds leurs mises");
                        switch (joueurs)
                        {
                            case 0:
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Joueur", jetons, mise, out jetons);
                                return;
                            case 1:     // 1 Joueur AI
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Joueur", jetons, mise, out jetons);
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Player 1", p1jetons, p1mise, out p1jetons);
                                return;
                            case 2:     // 2 joueurs AI
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Joueur", jetons, mise, out jetons);
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Player 1", p1jetons, p1mise, out p1jetons);
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Player 2", p2jetons, p2mise, out p2jetons);
                                return;
                            case 3:     // 3 joueurs AI
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Joueur", jetons, mise, out jetons);
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Player 1", p1jetons, p1mise, out p1jetons);
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Player 2", p2jetons, p2mise, out p2jetons);
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Player 3", p3jetons, p3mise, out p3jetons);
                                return;
                            case 4:     // 4 joueurs AI
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Joueur", jetons, mise, out jetons);
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Player 1", p1jetons, p1mise, out p1jetons);
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Player 2", p2jetons, p2mise, out p2jetons);
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Player 3", p3jetons, p3mise, out p3jetons);
                                Console.WriteLine("-------------------------------------------------------------");
                                calculs.Perdsmise("Player 4", p4jetons, p4mise, out p4jetons);
                                return;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Le croupier n'a pas de BlackJack");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
            }
            // if a player has a BJ and Dealer does not
            else if (jvaleurtot == 21 ^ p1valeurtot == 21 ^ p2valeurtot == 21 ^ p3valeurtot == 21 ^ p4valeurtot == 21) // check natural BlackJack
            {
                Console.WriteLine("Verifions si les joueurs on des BlackJacks");
                Thread.Sleep(1500);
                switch (joueurs)
                {
                    case 0:
                        calculs.NBJcheckJ(jvaleurtot, jwinloss, out jwinloss);
                        break;
                    case 1:     // 1 Joueur AI
                        calculs.NBJcheckJ(jvaleurtot, jwinloss, out jwinloss);
                        calculs.NBJcheckP(p1valeurtot, p1winloss, 1, out p1winloss);
                        break;
                    case 2:     // 2 joueurs AI
                        calculs.NBJcheckJ(jvaleurtot, jwinloss, out jwinloss);
                        calculs.NBJcheckP(p1valeurtot, p1winloss, 1, out p1winloss);
                        calculs.NBJcheckP(p2valeurtot, p2winloss, 2, out p2winloss);
                        break;
                    case 3:     // 3 joueurs AI
                        calculs.NBJcheckJ(jvaleurtot, jwinloss, out jwinloss);
                        calculs.NBJcheckP(p1valeurtot, p1winloss, 1, out p1winloss);
                        calculs.NBJcheckP(p2valeurtot, p2winloss, 2, out p2winloss);
                        calculs.NBJcheckP(p3valeurtot, p3winloss, 3, out p3winloss);
                        break;
                    case 4:     // 4 joueurs AI
                        calculs.NBJcheckJ(jvaleurtot, jwinloss, out jwinloss);
                        calculs.NBJcheckP(p1valeurtot, p1winloss, 1, out p1winloss);
                        calculs.NBJcheckP(p2valeurtot, p2winloss, 2, out p2winloss);
                        calculs.NBJcheckP(p3valeurtot, p3winloss, 3, out p3winloss);
                        calculs.NBJcheckP(p4valeurtot, p4winloss, 4, out p4winloss);
                        break;
                    default:
                        break;
                }
            }
            // everyone has BJ
            else if (jvaleurtot == 21 & p1valeurtot == 21 & p2valeurtot == 21 & p3valeurtot == 21 & p4valeurtot == 21)
            {
                Console.WriteLine("TLM le monde a un bj ? tlm mise x2.5");
                cheatvalue += croup[1].cheat;  // add after 1st pass hidden card so no count
                switch (joueurs)
                {
                    case 0:
                        jetons += (mise + mise + (mise / 2));
                        return;
                    case 1:
                        jetons += (mise + mise + (mise / 2));
                        p1jetons += (p1mise + p1mise + (p1mise / 2));
                        return;
                    case 2:
                        jetons += (mise + mise + (mise / 2));
                        p1jetons += (p1mise + p1mise + (p1mise / 2));
                        p2jetons += (p2mise + p2mise + (p2mise / 2));
                        return;
                    case 3:
                        jetons += (mise + mise + (mise / 2));
                        p1jetons += (p1mise + p1mise + (p1mise / 2));
                        p2jetons += (p2mise + p2mise + (p2mise / 2));
                        p3jetons += (p3mise + p3mise + (p3mise / 2));
                        return;
                    case 4:
                        jetons += (mise + mise + (mise / 2));
                        p1jetons += (p1mise + p1mise + (p1mise / 2));
                        p2jetons += (p2mise + p2mise + (p2mise / 2));
                        p3jetons += (p3mise + p3mise + (p3mise / 2));
                        p4jetons += (p4mise + p4mise + (p4mise / 2));
                        return;
                }
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("On Continue !");
                Console.WriteLine();
            }
            /////////////////////////////////////HIT OR STAND////////////////////////////////////////////////////////
            {
                do
                {
                    bool vf = false;
                    string hs;

                    do
                    {
                        if (jwinloss == 2)// auto stand
                        {
                            hs = "S";
                            vf = true;
                        }
                        else
                        {

                            Console.Write("Voulez vous faire un Hit ou Stand? Ecrivez  H/S? ");
                            hs = Console.ReadLine();

                            foreach (string hos in new[] { "H", "S" }) // groupe de verification
                                vf |= (hos.ToUpper() == hs.ToUpper()); //h ou s Vrai ou Faux

                            if (vf == false) // pas h ou s
                            {
                                Console.WriteLine("Entrez H pour Hit et S pour Stand!! Pas autre Chose!");
                            }
                        }
                    } while (!vf);
                    {
                        switch (hs.ToUpper())
                        {
                            case "H":
                                //Hit mainj 
                                if (jwinloss == 0 ^ jwinloss == 2)
                                {
                                    mainj.Add(paq.piger(cheatvalue, out cheatvalue)); // add single cards to cheat
                                    calculs.ASCHK(mainj);
                                    calculs.CALVAL(mainj, out jvaleurtot);
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"        ______________________________--------------_________________________________");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write($"        |-------------------|           ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"~~Joueur~~");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"HIT     |   { mainj[mainj.Count - 1].nomcarte} de {mainj[mainj.Count - 1].Type}");
                                    Console.Write($"        |-------------------|");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write($"     Main :");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write($" <|| ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write($"{jvaleurtot}");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($" ||>   ||Cheat Value : {cheatvalue}||");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    if (jvaleurtot > 21) // HIT mainj > 21
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Bust! Mon Chou!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine($"Botre tour est termine...");
                                        jwinloss = 1;
                                        continue;
                                    }
                                    else if (jvaleurtot == 21) // HIT mainj==21
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("BlackJack mon grand!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine($"Vous devriez stand maintenant... a moins que vous vouliez perdre.. hahah");
                                        Console.WriteLine();
                                        jwinloss = 2;
                                        continue;
                                    }
                                    else
                                    {
                                        jwinloss = 0;
                                        continue;
                                    }

                                }
                                else if (jwinloss == 3)
                                {
                                    Console.WriteLine("Vous avez deja termine ! Vous avez gagne par BlackJack au debut!");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine($"Deja BUSTED {jvaleurtot}...");
                                    continue;
                                }


                            case "S": // STAND
                                // PLAYER AI HITS
                                switch (joueurs)
                                {
                                    case 0:
                                        break;
                                    case 1:     // 1 Joueur AI
                                        calculs.AIPLYR(playr1, paq, cheatvalue, p1winloss, out paq, out cheatvalue, 1, out p1winloss);
                                        break;
                                    case 2:     // 2 joueurs AI
                                        calculs.AIPLYR(playr1, paq, cheatvalue, p1winloss, out paq, out cheatvalue, 1, out p1winloss);
                                        calculs.AIPLYR(playr2, paq, cheatvalue, p2winloss, out paq, out cheatvalue, 2, out p2winloss);
                                        break;
                                    case 3:     // 3 joueurs AI
                                        calculs.AIPLYR(playr1, paq, cheatvalue, p1winloss, out paq, out cheatvalue, 1, out p1winloss);
                                        calculs.AIPLYR(playr2, paq, cheatvalue, p2winloss, out paq, out cheatvalue, 2, out p2winloss);
                                        calculs.AIPLYR(playr3, paq, cheatvalue, p3winloss, out paq, out cheatvalue, 3, out p3winloss);
                                        break;
                                    case 4:     // 4 joueurs AI
                                        calculs.AIPLYR(playr1, paq, cheatvalue, p1winloss, out paq, out cheatvalue, 1, out p1winloss);
                                        calculs.AIPLYR(playr2, paq, cheatvalue, p2winloss, out paq, out cheatvalue, 2, out p2winloss);
                                        calculs.AIPLYR(playr3, paq, cheatvalue, p3winloss, out paq, out cheatvalue, 3, out p3winloss);
                                        calculs.AIPLYR(playr4, paq, cheatvalue, p4winloss, out paq, out cheatvalue, 4, out p4winloss);
                                        break;
                                    default:
                                        break;
                                }
                                if (cheatcrouphidden == false)      // if it was not added yet
                                {
                                    cheatvalue += croup[1].cheat;  // add missing card to cheat
                                    cheatcrouphidden = true;        //showed ~ back to false at start of next game
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"        ______________________________--------------_________________________________");
                                Console.WriteLine($"        |-------------------|          ~~Croupier~~"); // full reveal value
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Carte 1:| { croup[0].nomcarte} de {croup[0].Type}");
                                Console.WriteLine($"Carte 2:|{ croup[1].nomcarte} de {croup[1].Type}");
                                Console.Write($"        |-------------------|");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"     Main :");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($" <|| ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"{cvaleurtot}");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($" ||>   ||Cheat Value : {cheatvalue}||");
                                Console.ForegroundColor = ConsoleColor.White;
                                while ((cvaleurtot < 18) & (cvaleurtot < jvaleurtot + 1)) // conditions de jeu du croupier
                                {
                                    croup.Add(paq.piger(cheatvalue, out cheatvalue)); // single cards added to cheat
                                    //increment | complete check cheat
                                    calculs.ASCHK(croup);
                                    calculs.CALVAL(croup, out cvaleurtot);
                                    Thread.Sleep(1200);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    //Console.WriteLine("        |-------------------|");
                                    Console.WriteLine($"HIT     |  { croup[croup.Count - 1].nomcarte} de {croup[croup.Count - 1].Type}");
                                    Console.Write($"        |-------------------|");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write($"     Main :");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write($" <|| ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write($"{cvaleurtot}");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($" ||>   ||Cheat Value : {cheatvalue}||");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;

                            default:
                                break;
                        }
                        if (jwinloss == 0)
                            jwinloss = 2;
                        // END VALUE AND PAYOUTS FCHECK
                        switch (joueurs)
                        {
                            case 0:
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, mainj, mise, jetons, "Joueur", jwinloss, out jetons);
                                return;
                            case 1:     // 1 Joueur AI
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, mainj, mise, jetons, "Joueur", jwinloss, out jetons);
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, playr1, p1mise, p1jetons, "Player 1", p1winloss, out p1jetons);
                                return;
                            case 2:     // 2 joueurs AI
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, mainj, mise, jetons, "Joueur", jwinloss, out jetons);
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, playr1, p1mise, p1jetons, "Player 1", p1winloss, out p1jetons);
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, playr2, p2mise, p2jetons, "Player 2", p2winloss, out p2jetons);
                                return;
                            case 3:     // 3 joueurs AI
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, mainj, mise, jetons, "Joueur", jwinloss, out jetons);
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, playr1, p1mise, p1jetons, "Player 1", p1winloss, out p1jetons);
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, playr2, p2mise, p2jetons, "Player 2", p2winloss, out p2jetons);
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, playr3, p3mise, p3jetons, "Player 3", p3winloss, out p3jetons);
                                return;
                            case 4:     // 4 joueurs AI
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, mainj, mise, jetons, "Joueur", jwinloss, out jetons);
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, playr1, p1mise, p1jetons, "Player 1", p1winloss, out p1jetons);
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, playr2, p2mise, p2jetons, "Player 2", p2winloss, out p2jetons);
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, playr3, p3mise, p3jetons, "Player 3", p3winloss, out p3jetons);
                                Console.WriteLine("---------------------------------------------");
                                calculs.FCheck(croup, playr4, p4mise, p4jetons, "Player 4", p4winloss, out p4jetons);
                                return;
                            default:
                                break;
                        }
                    }
                } while (true);

            }
        }
    }
}


