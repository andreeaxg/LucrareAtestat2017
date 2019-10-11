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
    public partial class intrebari : Form
    {
        public intrebari(string intrebare)
        {
            int L;
            InitializeComponent();
            L = intrebare.Length * 10 + 100;
            this.Width = L;
            button1.Left = L / 2 - 70;
            button2.Left = L / 2 - 70;
            label1.Text = intrebare;
        }

        private void intrebari_Load(object sender, EventArgs e)
        {
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }


    }
}
