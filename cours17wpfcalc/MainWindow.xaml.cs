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

namespace cours17wpfcalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        static void EntryCNT(ref int x, ref string[] y, char z)
        {
            Calcx[NewEntry] = z;
            NewEntry++;
            //LblRes.Content += z;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
             public static string[] Calcx;
        static int NewEntry = 0;

    

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            
            EntryCNT(ref NewEntry,ref Calcx, '1');
           // LblRes.Content += "1";
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "2";
            NewEntry++;
            LblRes.Content += "2";
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "3";
            NewEntry++;
            LblRes.Content += "3";
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "4";
            NewEntry++;
            LblRes.Content += "4";
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "5";
            NewEntry++;
            LblRes.Content += "5";
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "6";
            NewEntry++;
            LblRes.Content += "6";
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "7";
            NewEntry++;
            LblRes.Content += "7";
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "8";
            NewEntry++;
            LblRes.Content += "8";
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "9";
            NewEntry++;
            LblRes.Content += "9";
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "0";
            NewEntry++;
            LblRes.Content += "0";
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = ".";
            NewEntry++;
            LblRes.Content += ".";
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "+";
            NewEntry++;
            LblRes.Content += "+";
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "-";
            NewEntry++;
            LblRes.Content += "-";
        }

        private void ButtonTime_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "*";
            NewEntry++;
            LblRes.Content += "*";
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            Calcx[NewEntry] = "/";
            NewEntry++;
            LblRes.Content += "/";
        }

        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPlusMinus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
