using Mile.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(new WindowsXamlHost());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProgressForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new SettingForm().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DetailViewForm().ShowDialog();
        }
    }
}
