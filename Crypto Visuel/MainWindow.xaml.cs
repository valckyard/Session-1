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
            if (System.IO.File.Exists(File) == false)
            {

            }
            else
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
                    if (TxtB1.Text != "")
                    {
                        sw.Write($"{System.IO.Path.GetFileName(TxtB1.Text)} Key : ");
                        sw.WriteLine(Key1.Text);
                    }
                    if (TxtB2.Text != "")
                    {
                        sw.Write($"{System.IO.Path.GetFileName(TxtB2.Text)} Key : ");
                        sw.WriteLine(Key2.Text);
                    }
                    if (TxtB3.Text != "")
                    {
                        sw.Write($"{System.IO.Path.GetFileName(TxtB3.Text)} Key : ");
                        sw.WriteLine(Key3.Text);
                    }
                }
            }
        }

        private void TxtB1_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((System.IO.File.Exists(TxtB1.Text) == true))
            {
                F1Lab.Content = System.IO.Path.GetFileName(TxtB1.Text) + " In Progress!";
            }
            else
            {
                TxtB1.Text = "";
                F1Lab.Content = "File One : No File Selected...";
            }
        }

        private void TxtB1_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            F1Lab.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            if ((System.IO.File.Exists(TxtB1.Text) == true))
            {
                F1Lab.Content = System.IO.Path.GetFileName(TxtB1.Text) + " In Progress!";
            }
            else
            {
                TxtB1.Text = "";
                F1Lab.Content = "File One : No File Selected...or invalid!";
            }
        }

        private void TxtB1_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            F1Lab.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            if (e.Key == Key.Enter)
            {


                if ((System.IO.File.Exists(TxtB1.Text) == true))
                {
                    F1Lab.Content = System.IO.Path.GetFileName(TxtB1.Text) + " In Progress!";
                }
                else
                {
                    TxtB1.Text = "";
                    F1Lab.Content = "File One : No File Selected...or invalid!";
                }
            }
        }

        private void TxtB2_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            F2Lab.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                if ((System.IO.File.Exists(TxtB2.Text) == true))
                {
                    F2Lab.Content = System.IO.Path.GetFileName(TxtB2.Text) + " In Progress!";
                }
                else
                {
                    TxtB2.Text = "";
                    F2Lab.Content = "File Two : No File Selected...or invalid!";
                }
        }

        private void TxtB2_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            F2Lab.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            if (e.Key == Key.Enter)
            {
                if ((System.IO.File.Exists(TxtB2.Text) == true))
                {
                    F2Lab.Content = System.IO.Path.GetFileName(TxtB2.Text) + " In Progress!";
                }
                else
                {
                    TxtB2.Text = "";
                    F2Lab.Content = "File Two : No File Selected...or invalid!";
                }
            }
        }

        private void TxtB3_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if ((System.IO.File.Exists(TxtB3.Text) == true))
            {
                F3Lab.Content = System.IO.Path.GetFileName(TxtB3.Text) + " In Progress!";
            }
            else
            {
                TxtB3.Text = "";
                F3Lab.Content = "File Three : No File Selected...or invalid!";
            }
        }

        private void TxtB3_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            F3Lab.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            if (e.Key == Key.Enter)
            {
                if ((System.IO.File.Exists(TxtB3.Text) == true))
                {
                    F3Lab.Content = System.IO.Path.GetFileName(TxtB3.Text) + " In Progress!";
                }
                else
                {
                    TxtB3.Text = "";
                    F3Lab.Content = "File Three : No File Selected...or invalid!";
                }
            }
        }

        private void Select1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog Sb1 = new Microsoft.Win32.OpenFileDialog();
            F1Lab.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            if (Sb1.ShowDialog() == true)
            {
                TxtB1.Text = Sb1.FileName;
                F1Lab.Content = System.IO.Path.GetFileName(TxtB1.Text) + " In Progress!";
            }  
            else
            {
                TxtB1.Text = "";
                F1Lab.Content = "File One : No File Selected...";
            }
        }
        private void Select2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog Sb2 = new Microsoft.Win32.OpenFileDialog();
            F2Lab.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            if (Sb2.ShowDialog() == true)
            {
                TxtB2.Text = Sb2.FileName;

                F2Lab.Content = System.IO.Path.GetFileName(TxtB2.Text) + " In Progress!";
            }
        }
        private void Select3_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog Sb3 = new Microsoft.Win32.OpenFileDialog();
            F3Lab.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            if (Sb3.ShowDialog() == true)
            {
                TxtB3.Text = Sb3.FileName;
                F3Lab.Content = System.IO.Path.GetFileName(TxtB3.Text) + " In Progress!";
            }
        }

        private void ENCrypt_Click(object sender, RoutedEventArgs e)
        {

            if (Key1.Text != "" & System.IO.File.Exists(TxtB1.Text) == true)
            {

                KeyField1 = Encoding.ASCII.GetBytes(Key1.Text);
                Crypto.CryptFULL(KeyField1, TxtB1.Text);
                F1Lab.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 12));
                F1Lab.Content = System.IO.Path.GetFileName(TxtB1.Text) + " Done!!!";
            }
            if (Key2.Text != "" & System.IO.File.Exists(TxtB2.Text) == true)
            {
                KeyField2 = Encoding.ASCII.GetBytes(Key2.Text);
                Crypto.CryptFULL(KeyField2, TxtB2.Text);
                F2Lab.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 12));
                F2Lab.Content = System.IO.Path.GetFileName(TxtB2.Text) + " Done!!!";
            }
            if (Key3.Text != "" & System.IO.File.Exists(TxtB3.Text) == true)
            {
                KeyField3 = Encoding.ASCII.GetBytes(Key3.Text);
                Crypto.CryptFULL(KeyField3, TxtB3.Text);
                F3Lab.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 12));
                F3Lab.Content = System.IO.Path.GetFileName(TxtB3.Text) + " Done!!!";
            }
        }
    }
}
