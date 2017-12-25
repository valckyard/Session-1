using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cours10appwindowsform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nom = txt1.Text;
            btn1.BackColor = Color.Red;
            label1.Text = ($"OH YEAH {nom}");
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
    

        }

        private void Parcourir_Click(object sender, EventArgs e)
        {
            var filedialog = new SaveFileDialog();
            filedialog.FileName = @"C:\Projects\Premiers.txt";
            filedialog.ShowDialog();
            label1.Text = filedialog.FileName;
        }
    }
}
