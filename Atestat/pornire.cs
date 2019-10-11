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
    public partial class pornire : Form
    {
        public pornire()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personalizare f = new personalizare();
            f.ShowDialog();

        }
    }
}
