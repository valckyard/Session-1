using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
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


        static public void CryptFULL(byte[] cle, string File)
        {
            byte[] Fichier = System.IO.File.ReadAllBytes(File);

            if (System.IO.Path.GetExtension(File) == ".crypto")
            {
                File = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(File),
                File = System.IO.Path.GetFileNameWithoutExtension(File));

            }
            else
                File = File + ".crypto";

            string OutFile = File;

            Crypto.AppliquerCrypto(cle, Fichier); // 2 x decript

            System.IO.File.WriteAllBytes(OutFile, Fichier);
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SelectAddress(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb != null)
            {
                tb.SelectAll();
            }
        }
        private void SelectivelyIgnoreMouseButton(object sender, MouseButtonEventArgs e)

        {
            TextBox tb = (sender as TextBox);
            if (tb != null)
            {
                if (!tb.IsKeyboardFocusWithin)

                {
                    e.Handled = true;
                    tb.Focus();
                }
            }
        }
        public byte[] KeyField1, KeyField2, KeyField3;
        public byte[] FileField1, FileField2, FileField3;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog SavAll = new Microsoft.Win32.SaveFileDialog();
            SavAll.FileName = "KeySaveMMMMKKKKK";
            SavAll.Filter = "Text Files | *.txt";
            SavAll.DefaultExt = "txt";
            SavAll.InitialDirectory = @"c:\";
            if (SavAll.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(SavAll.OpenFile()))
                {
                    sw.Write("Key 1:");
                    sw.WriteLine(Key1.Text);
                    sw.Write("Key 2:");
                    sw.WriteLine(Key2.Text);
                    sw.Write("Key 3:");
                    sw.WriteLine(Key3.Text);
                }
            }



        }

        private void Select1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog Sb1 = new Microsoft.Win32.OpenFileDialog();
            if (Sb1.ShowDialog() == true)
            {
                TxtB1.Text = Sb1.FileName;
            }
            else
            {
                TxtB1.Text = null;
            }
        }
        private void Select2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog Sb2 = new Microsoft.Win32.OpenFileDialog();
            if (Sb2.ShowDialog() == true)
            {
                TxtB2.Text = Sb2.FileName;
            }
            else
            {
                TxtB2.Text = null;
            }
        }
        private void Select3_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog Sb3 = new Microsoft.Win32.OpenFileDialog();
            if (Sb3.ShowDialog() == true)
            {
                TxtB3.Text = Sb3.FileName;
            }
            else
            {
                TxtB3.Text = null;
            }
        }

        private void ENCrypt_Click(object sender, RoutedEventArgs e)
        {

            if (Key1.Text != "" & TxtB1.Text != "")
            {

                KeyField1 = Encoding.ASCII.GetBytes(Key1.Text);
                Crypto.CryptFULL(KeyField1, TxtB1.Text);
            }
            if (Key2.Text != "" & TxtB2.Text != "")
            {
                KeyField2 = Encoding.ASCII.GetBytes(Key2.Text);
                Crypto.CryptFULL(KeyField2, TxtB2.Text);
            }
            if (Key3.Text != "" & TxtB3.Text != "")
            {
                KeyField3 = Encoding.ASCII.GetBytes(Key3.Text);
                Crypto.CryptFULL(KeyField3, TxtB3.Text);
            }
            Progress.Content = "Done!!!";
        }
    }
}
