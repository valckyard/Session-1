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
        public static void MyButtons()        { }
        
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Button x = (Button)sender;
                CalcTxt.Text += x.Content.ToString();
            }

            private void Button_Result(object sender, RoutedEventArgs e)
            {

            }
        
    }
}
