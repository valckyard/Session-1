using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cours16app
{
    class Program
    {
        static string DemanderCle()
        {
            Console.WriteLine("Entrez la cle d'encription:");
            return Console.ReadLine();
        }
        static void AppliquerCrypto(byte[] Key, byte[] File)
        {
                for (int i = 0; i < File.Length; i++)
                {
                int iKey = i % Key.Length;
                File[i] ^= Key[iKey];
                File[i] ^= (byte)i;
            }
            
        }
        
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {

                Console.WriteLine("Vous avez oublie de preciser le ficher.");
                return;
            }
            string CleCrypto;
            CleCrypto = DemanderCle();
            byte[] cle = Encoding.ASCII.GetBytes(CleCrypto);

            foreach (string NFichier in args)
                newCrypt(cle, NFichier);

        }

        private static void newCrypt(byte[] cle, string File)
        {
            byte[] Fichier = System.IO.File.ReadAllBytes(File);

            if (Path.GetExtension(File) == ".crypto")
            {
                File = Path.Combine(
                Path.GetDirectoryName(File),
                File = Path.GetFileNameWithoutExtension(File));

            }
            else
                File = File + ".crypto";

            string OutFile = File;

            AppliquerCrypto(cle, Fichier); // 2 x decript

            System.IO.File.WriteAllBytes(OutFile, Fichier);
        }
    }
}
