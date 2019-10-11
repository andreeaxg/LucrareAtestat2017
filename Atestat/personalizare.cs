using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Atestat_Gherghev_Andreea
{
    public partial class personalizare : Form
    {
        int nr = 1, juc = 1;
        public personalizare()
        {
            InitializeComponent();
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labirint f = new labirint(nr, juc);
            f.ShowDialog();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            nr = 14;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            nr = 13;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            nr = 22;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            nr = 21;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            nr = 26;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            juc = 1;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            juc = 3;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            juc = 2;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            juc = 7;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            juc = 5;
        }

        private void personalizare_Load(object sender, EventArgs e)
        {

        }

        private void personalizare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

     
    }
}
