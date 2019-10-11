using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Atestat_Gherghev_Andreea
{
    public partial class labirint : Form
    {
        PictureBox[,] b = new PictureBox[30, 30];
        int[,] a = new int[30, 30];
        int[,] a1 = new int[30, 30];
        int x, y, x1, y1, niv, max = 3;
        int[] dx = { 0, -1, 0, 1, 0 };
        int[] dy = { 0, 0, 1, 0, -1 };
        int n, nrint, muzica;
        string s, s1, fis = "teren";
        string[] si = new string[50];
        string[] sr = new string[50];
        int[] v = new int[50];
        Random ran = new Random();
        SoundPlayer simpleSound = new SoundPlayer("piesa9.wav");

        private void labirint_Load(object sender, EventArgs e)
        {

        }

        public labirint(int f, int juc)
        {
            InitializeComponent();
            s = "fundal" + f.ToString() + ".jpg";
            s1 = "pers" + juc.ToString() + ".gif";
            niv = 1;
            citire("teren1.txt");
            citireintrebari();
            generare_labirint();




        }
        void citireintrebari()
        {
            string linie;
            string[] s = new string[100];
            StreamReader fis = new StreamReader("intrebari.txt");
            nrint = 0;
            while ((linie = fis.ReadLine()) != null)
            {
                si[nrint] = linie;
                sr[nrint] = fis.ReadLine();
                nrint++;
            }
        }

        void genintrebare()
        {
            int k;
            do
            {
                k = ran.Next(0, nrint);
            } while (v[k] != 0);
            v[k] = 1;

            intrebari f = new intrebari(si[k]);
            DialogResult rez = f.ShowDialog();

            switch (rez)
            {
                case DialogResult.OK:
                    if (sr[k] == "a")
                    {
                        a[x, y] = 3;
                        a[x1, y1] = 3;
                        b[x, y].Image = Image.FromFile("iarba2.jpg");
                        b[x1, y1].Image = Image.FromFile(s1);
                        x = x1;
                        y = y1;

                    }
                    else
                    {

                        b[x1, y1].Image = Image.FromFile("gardf2.jpg");
                        a[x1, y1] = 4;
                    }
                    break;
                case DialogResult.Cancel:
                    if (sr[k] == "f")
                    {
                        a[x, y] = 3;
                        a[x1, y1] = 3;
                        b[x, y].Image = Image.FromFile("iarba2.jpg");
                        b[x1, y1].Image = Image.FromFile(s1);
                        x = x1;
                        y = y1;
                    }
                    else
                    {
                        b[x1, y1].Image = Image.FromFile("gardf2.jpg");
                        a[x1, y1] = 4;
                    }
                    break;
            }


        }
        void citire(string fisier)
        {
            int i, j;
            string linie;
            string[] s = new string[100];
            StreamReader sr = new StreamReader(fisier);
            linie = sr.ReadLine();
            n = Convert.ToInt32(linie);
            i = 1;
            while ((linie = sr.ReadLine()) != null)
            {
                j = 1;
                s = linie.Split(' ');
                foreach (string c in s)
                {
                    a[i, j] = Convert.ToInt32(c);
                    a1[i, j] = a[i, j];
                    j++;
                }
                i++;
            }

        }
        void generare_labirint()
        {
            int i, j;
            BackgroundImage = Image.FromFile(s);
            BackgroundImageLayout = ImageLayout.Stretch;

            for (i = 1; i <= n; i++)
                for (j = 1; j <= n; j++)
                {
                    b[i, j] = new PictureBox();
                    b[i, j].Width = 30;
                    b[i, j].Height = 30;
                    b[i, j].Left = 0 + j * 28;
                    b[i, j].Top = 0 + 28 * i;
                    if (a[i, j] == 0)
                        b[i, j].Image = Image.FromFile("cer1.jpg");
                    if (a[i, j] == 1)
                        b[i, j].Image = Image.FromFile("cer2.jpg");
                    if (a[i, j] == 2)
                        b[i, j].Image = Image.FromFile("cer3.jpg");
                    if (a[i, j] == 3 || a[i, j] == 10)
                        b[i, j].Image = Image.FromFile("iarba2.jpg");
                    if (a[i, j] == 4)
                        b[i, j].Image = Image.FromFile("gardf3.jpg");
                    if (a[i, j] == 5)
                        b[i, j].Image = Image.FromFile("gardf2.jpg");
                    if (a[i, j] == 6)
                        b[i, j].Image = Image.FromFile("gardf1.jpg");
                    if (a[i, j] == 7)
                        b[i, j].Image = Image.FromFile("comoara2.gif");
                    if (a[i, j] == 8)
                        b[i, j].Image = Image.FromFile(s1);
                    if (a[i, j] == 9)
                        b[i, j].Image = Image.FromFile("cer4.jpg");

                    if (a[i, j] == 8)
                    {
                        b[i, j].Image = Image.FromFile(s1);
                        a[i, j] = 3;
                        x = i;
                        y = j;
                    }
                    b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(b[i, j]);
                    b[i, j].Visible = true;
                }

        }
        void reset()
        {
            int i, j;
            for (i = 1; i <= n; i++)
                for (j = 1; j <= n; j++)
                {
                    a[i, j] = a1[i, j];
                    if (a[i, j] == 0)
                        b[i, j].Image = Image.FromFile("cer1.jpg");
                    if (a[i, j] == 1)
                        b[i, j].Image = Image.FromFile("cer2.jpg");
                    if (a[i, j] == 2)
                        b[i, j].Image = Image.FromFile("cer3.jpg");
                    if (a[i, j] == 3 || a[i, j] == 10)
                        b[i, j].Image = Image.FromFile("iarba2.jpg");
                    if (a[i, j] == 4)
                        b[i, j].Image = Image.FromFile("gardf3.jpg");
                    if (a[i, j] == 5)
                        b[i, j].Image = Image.FromFile("gardf2.jpg");
                    if (a[i, j] == 6)
                        b[i, j].Image = Image.FromFile("gardf1.jpg");
                    if (a[i, j] == 7)
                        b[i, j].Image = Image.FromFile("comoara2.gif");
                    if (a[i, j] == 8)
                        b[i, j].Image = Image.FromFile(s1);
                    if (a[i, j] == 9)
                        b[i, j].Image = Image.FromFile("cer4.jpg");


                    if (a[i, j] == 8)
                    {

                        a[i, j] = 3;
                        x = i;
                        y = j;
                    }


                }
            for (i = 0; i < 50; i++)
                v[i] = 0;

        }

        void nivel()
        {
            int i, j;
            fis = "teren";
            if (niv > max) niv = 1;
            label1.Text = "nivelul " + niv;
            fis += niv.ToString();
            fis += ".txt";
            citire(fis);
            for (i = 1; i <= n; i++)
                for (j = 1; j <= n; j++)
                {

                    if (a[i, j] == 0)
                        b[i, j].Image = Image.FromFile("cer1.jpg");
                    if (a[i, j] == 1)
                        b[i, j].Image = Image.FromFile("cer2.jpg");
                    if (a[i, j] == 2)
                        b[i, j].Image = Image.FromFile("cer3.jpg");
                    if (a[i, j] == 3 || a[i, j] == 10)
                        b[i, j].Image = Image.FromFile("iarba2.jpg");
                    if (a[i, j] == 4)
                        b[i, j].Image = Image.FromFile("gardf3.jpg");
                    if (a[i, j] == 5)
                        b[i, j].Image = Image.FromFile("gardf2.jpg");
                    if (a[i, j] == 6)
                        b[i, j].Image = Image.FromFile("gardf1.jpg");
                    if (a[i, j] == 7)
                        b[i, j].Image = Image.FromFile("comoara2.gif");
                    if (a[i, j] == 8)
                        b[i, j].Image = Image.FromFile(s1);
                    if (a[i, j] == 9)
                        b[i, j].Image = Image.FromFile("cer4.jpg");


                    if (a[i, j] == 8)
                    {

                        a[i, j] = 3;
                        x = i;
                        y = j;
                    }


                }
            for (i = 0; i < 50; i++)
                v[i] = 0;

        }

        private void labirint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                reset();

            if (e.KeyCode == Keys.Up)
            {
                x1 = x + dx[1];
                y1 = y + dy[1];
                if (x1 >= 1 && x1 <= n && y1 >= 1 && y1 <= n)
                    if (a[x1, y1] == 7)
                    {
                        b[x1, y1].Height = 100;
                        b[x1, y1].Width = 100;
                        b[x1, y1].Image = Image.FromFile("castig3.gif");
                        b[x, y].Image = Image.FromFile("iarba2.jpg");
                        a[x, y] = 3;
                       

                        
                        MessageBox.Show("Felicitari!Ai trecut la nivelul urmator.");
                        b[x1, y1].Height = 30;
                        b[x1, y1].Width = 30;
                        niv++;
                        nivel();



                    }
                    else
                        if (a[x1, y1] == 10)
                        {
                            genintrebare();
                        }
                        else

                            if (a[x1, y1] == 3)
                            {
                                if (a[x, y] == 3)
                                {
                                    b[x, y].Image = Image.FromFile("iarba2.jpg");
                                    a[x, y] = 3;
                                }


                                b[x1, y1].Image = Image.FromFile(s1);
                                x = x1;
                                y = y1;


                            }
            }
            if (e.KeyCode == Keys.Down)
            {
                x1 = x + dx[3];
                y1 = y + dy[3];
                if (x1 >= 1 && x1 <= n && y1 >= 1 && y1 <= n)
                    if (a[x1, y1] == 7)
                    {
                        b[x1, y1].Height = 100;
                        b[x1, y1].Width = 100;
                        b[x1, y1].Image = Image.FromFile("castig3.gif");
                        if (a[x, y] == 3)
                        {
                            b[x, y].Image = Image.FromFile("iarba2.jpg");
                            a[x, y] = 3;
                        }

                        MessageBox.Show("Felicitari!Ai trecut la nivelul urmator.");
                        b[x1, y1].Height = 30;
                        b[x1, y1].Width = 30;
                        niv++;
                        nivel();



                    }
                    else
                        if (a[x1, y1] == 10)
                        {
                            genintrebare();
                        }
                        else

                            if (a[x1, y1] == 3)
                            {
                                if (a[x, y] == 3)
                                {
                                    b[x, y].Image = Image.FromFile("iarba2.jpg");
                                    a[x, y] = 3;
                                }


                                b[x1, y1].Image = Image.FromFile(s1);
                                x = x1;
                                y = y1;


                            }
            }
            if (e.KeyCode == Keys.Right)
            {
                x1 = x + dx[2];
                y1 = y + dy[2];
                if (x1 >= 1 && x1 <= n && y1 >= 1 && y1 <= n)
                    if (a[x1, y1] == 7)
                    {
                        b[x1, y1].Height = 100;
                        b[x1, y1].Width = 100;
                        b[x1, y1].Image = Image.FromFile("castig3.gif");
                        if (a[x, y] == 3)
                        {
                            b[x, y].Image = Image.FromFile("iarba2.jpg");
                            a[x, y] = 3;
                        }

                        MessageBox.Show("Felicitari!Ai trecut la nivelul urmator.");

                        b[x1, y1].Height = 30;
                        b[x1, y1].Width = 30;
                        niv++;
                        nivel();


                    }
                    else
                        if (a[x1, y1] == 10)
                        {
                            genintrebare();
                        }
                        else
                            if (a[x1, y1] == 3)
                            {
                                if (a[x, y] == 3)
                                {
                                    b[x, y].Image = Image.FromFile("iarba2.jpg");
                                    a[x, y] = 3;
                                }


                                b[x1, y1].Image = Image.FromFile(s1);
                                x = x1;
                                y = y1;


                            }
            }
            if (e.KeyCode == Keys.Left)
            {
                x1 = x + dx[4];
                y1 = y + dy[4];
                if (x1 >= 1 && x1 <= n && y1 >= 1 && y1 <= n)
                    if (a[x1, y1] == 7)
                    {
                        b[x1, y1].Height = 100;
                        b[x1, y1].Width = 100;
                        b[x1, y1].Image = Image.FromFile("castig3.gif");
                        if (a[x, y] == 3)
                        {
                            b[x, y].Image = Image.FromFile("iarba2.jpg");
                            a[x, y] = 3;
                        }

                        MessageBox.Show("Felicitari!Ai trecut la nivelul urmator.");
                        b[x1, y1].Height = 30;
                        b[x1, y1].Width = 30;
                        niv++;
                        nivel();



                    }
                    else
                        if (a[x1, y1] == 10)
                        {
                            genintrebare();
                        }
                        else
                            if (a[x1, y1] == 3)
                            {
                                if (a[x, y] == 3)
                                {
                                    b[x, y].Image = Image.FromFile("iarba2.jpg");
                                    a[x, y] = 3;
                                }


                                b[x1, y1].Image = Image.FromFile(s1);
                                x = x1;
                                y = y1;


                            }
            }

        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (muzica % 2 == 0)
                simpleSound.Play();
            else
                simpleSound.Stop();
            muzica++;
        }

 


    }
}
