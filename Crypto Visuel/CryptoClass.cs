using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Visuel
{
    class Crypto
    {

        static public void AppliquerCrypto(byte[] Key, byte[] File)
        {
            for (int i = 0; i < File.Length; i++)
            {
                int iKey = i % Key.Length;
                File[i] ^= Key[iKey];
                File[i] ^= (byte)i;
            }

        }

        public static string NewFile;
        static public void CryptFULL(byte[] cle, string OriginFile)
        {
            if (System.IO.File.Exists(OriginFile) == false)
            {

            }
            else
            {
                byte[] Fichier = System.IO.File.ReadAllBytes(OriginFile);

                if (System.IO.Path.GetExtension(OriginFile) == ".crypto")
                {
                    NewFile = System.IO.Path.Combine(
                    System.IO.Path.GetDirectoryName(OriginFile),
                    NewFile = System.IO.Path.GetFileNameWithoutExtension(OriginFile));
                }
                else
                {
                    NewFile = OriginFile + ".crypto";
                }

                string OutFile = NewFile;

                Crypto.AppliquerCrypto(cle, Fichier); // 2 x decript

                System.IO.File.WriteAllBytes(OutFile, Fichier);
                if (MainWindow.DelFiles == true)
                {
                    System.IO.File.Delete(OriginFile);
                }
            }
        }
    }
}
