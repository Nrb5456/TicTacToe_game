using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class Form4 : Form
    {
        int[,] matrix = new int[3, 3];
        Bitmap xfigura = new Bitmap("X.png");
        Bitmap ofigura = new Bitmap("O.png");
        int jatekos = 1;
        int scorex = 0, scoreo = 0;
        int lepes = 1;
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int sor, oszlop;
            sor = e.Y / 143;
            oszlop = e.X / 143;
            if (matrix[sor, oszlop] == 0)
            {
                matrix[sor, oszlop] = jatekos;

                pictureBox1.Refresh();
                int nyertes = nyert();
                if (nyertes == 1)
                {
                    scorex++;
                    label1.Text = "Player : " + scorex.ToString();
                    MessageBox.Show("Player wins!");
                    pictureBox1.Enabled = false;
                    return;
                }
                if (nyertes == -1)
                {
                    scoreo++;
                    label2.Text = "Computer : " + scoreo.ToString();
                    MessageBox.Show("Computer wins!");
                    pictureBox1.Enabled = false;
                    return;
                }
                if (nyertes == 2)
                {
                    MessageBox.Show("It's a draw!");
                    pictureBox1.Enabled = false;
                    return;
                }
                pictureBox1.Refresh();
                lepesek();
                pictureBox1.Refresh();
                nyertes = nyert();
                if (nyertes == 1)
                {
                    scorex++;
                    label1.Text = "Player : " + scorex.ToString();
                    MessageBox.Show("Player wins!");
                    pictureBox1.Enabled = false;
                    return;
                }
                if (nyertes == -1)
                {
                    scoreo++;
                    label2.Text = "Computer : " + scoreo.ToString();
                    MessageBox.Show("Computer wins!");
                    pictureBox1.Enabled = false;
                    return;
                }
                if (nyertes == 2)
                {
                    MessageBox.Show("It's a draw!");
                    pictureBox1.Enabled = false;
                    return;
                }
                pictureBox1.Refresh();
            }
            pictureBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 f2 = new Form2();
            f2.Visible = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 6);
            Pen pen2 = new Pen(Color.Blue, 18);
            Pen pen3 = new Pen(Color.Red, 18);
            Pen pen4 = new Pen(Color.Black, 24);
            e.Graphics.DrawLine(pen, 139, 0, 139, 420);
            e.Graphics.DrawLine(pen, 289, 0, 289, 420);
            e.Graphics.DrawLine(pen, 0, 140, 417, 140);
            e.Graphics.DrawLine(pen, 0, 280, 417, 280);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == 1)
                        e.Graphics.DrawImage(xfigura, j * 146, i * 143);
                    if (matrix[i, j] == -1)
                        e.Graphics.DrawImage(ofigura, j * 146, i * 143);
                }
            e.Graphics.DrawLine(pen, 139, 0, 139, 420);
            e.Graphics.DrawLine(pen, 289, 0, 289, 420);
            e.Graphics.DrawLine(pen, 0, 140, 417, 140);
            e.Graphics.DrawLine(pen, 0, 280, 417, 280);
            for (int i = 0; i <= 2; i++)
            {
                if ((matrix[i, 0] == matrix[i, 1]) && (matrix[i, 1] == matrix[i, 2]) && (matrix[i, 0] == 1))
                {
                    e.Graphics.DrawLine(pen4, 26, 70 + 2 * i * 70, 394, 70 + 2 * i * 70);
                    e.Graphics.DrawLine(pen2, 30, 70 + 2 * i * 70, 390, 70 + 2 * i * 70);
                }
                if ((matrix[i, 0] == matrix[i, 1]) && (matrix[i, 1] == matrix[i, 2]) && (matrix[i, 0] == -1))
                {
                    e.Graphics.DrawLine(pen4, 26, 70 + 2 * i * 70, 394, 70 + 2 * i * 70);
                    e.Graphics.DrawLine(pen3, 30, 70 + 2 * i * 70, 390, 70 + 2 * i * 70);
                }
                if ((matrix[0, i] == matrix[1, i]) && (matrix[1, i] == matrix[2, i]) && (matrix[0, i] == 1))
                {
                    e.Graphics.DrawLine(pen4, 70 + 2 * i * 70, 26, 70 + 2 * i * 70, 394);
                    e.Graphics.DrawLine(pen2, 70 + 2 * i * 70, 30, 70 + 2 * i * 70, 390);
                }
                if ((matrix[0, i] == matrix[1, i]) && (matrix[1, i] == matrix[2, i]) && (matrix[0, i] == -1))
                {
                    e.Graphics.DrawLine(pen4, 70 + 2 * i * 70, 26, 70 + 2 * i * 70, 394);
                    e.Graphics.DrawLine(pen3, 70 + 2 * i * 70, 30, 70 + 2 * i * 70, 390);
                }
            }
            if ((matrix[0, 0] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 2]) && (matrix[0, 0] == 1))
            {
                e.Graphics.DrawLine(pen4, 26, 26, 394, 394);
                e.Graphics.DrawLine(pen2, 30, 30, 390, 390);
            }
            if ((matrix[0, 0] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 2]) && (matrix[0, 0] == -1))
            {
                e.Graphics.DrawLine(pen4, 26, 26, 394, 394);
                e.Graphics.DrawLine(pen3, 30, 30, 390, 390);
            }
            if ((matrix[0, 2] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 0]) && (matrix[0, 2] == 1))
            {
                e.Graphics.DrawLine(pen4, 394, 26, 26, 394);
                e.Graphics.DrawLine(pen2, 390, 30, 30, 390);
            }
            if ((matrix[0, 2] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 0]) && (matrix[0, 2] == -1))
            {
                e.Graphics.DrawLine(pen4, 394, 26, 26, 394);
                e.Graphics.DrawLine(pen3, 390, 30, 30, 390);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matrix[i, j] = 0;
            jatekos = 1;
            lepes = 1;
            pictureBox1.Enabled = true;
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matrix[i, j] = 0;
            jatekos = 1;
            lepes = 1;
            pictureBox1.Refresh();
            scorex = 0;
            label1.Text = "Player : " + scorex.ToString();
            scoreo = 0;
            label2.Text = "Computer : " + scoreo.ToString();
        }

        public int nyert()
        {
            for (int i = 0; i <= 2; i++)
            {
                if ((matrix[i, 0] == matrix[i, 1]) && (matrix[i, 1] == matrix[i, 2]) && (matrix[i, 0] == 1))
                    return 1;
                if ((matrix[i, 0] == matrix[i, 1]) && (matrix[i, 1] == matrix[i, 2]) && (matrix[i, 0] == -1))
                    return -1;
                if ((matrix[0, i] == matrix[1, i]) && (matrix[1, i] == matrix[2, i]) && (matrix[0, i] == 1))
                    return 1;
                if ((matrix[0, i] == matrix[1, i]) && (matrix[1, i] == matrix[2, i]) && (matrix[0, i] == -1))
                    return -1;
            }
            if ((matrix[0, 0] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 2]) && (matrix[0, 0] == 1))
                return 1;
            if ((matrix[0, 0] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 2]) && (matrix[0, 0] == -1))
                return -1;
            if ((matrix[0, 2] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 0]) && (matrix[0, 2] == 1))
                return 1;
            if ((matrix[0, 2] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 0]) && (matrix[0, 2] == -1))
                return -1;
            if ((matrix[0, 0] != 0) && (matrix[1, 0] != 0) && (matrix[2, 0] != 0) && (matrix[0, 1] != 0) && (matrix[0, 2] != 0) &&
                (matrix[1, 1] != 0) && (matrix[1, 2] != 0) && (matrix[2, 1] != 0) && (matrix[2, 2] != 0))
                return 2;
            return 0;
        }

        public void lepesek()
        {
            lepes++;
            for (int i = 0; i <= 2; i++)
            {
                if ((matrix[i, 0] == matrix[i, 1]) && (matrix[i, 0] == -1) && (matrix[i, 2] == 0))
                    { matrix[i, 2] = -1; return; }
                if ((matrix[i, 0] == matrix[i, 2]) && (matrix[i, 0] == -1) && (matrix[i, 1] == 0))
                    { matrix[i, 1] = -1; return; }
                if ((matrix[i, 2] == matrix[i, 1]) && (matrix[i, 2] == -1) && (matrix[i, 0] == 0))
                    { matrix[i, 0] = -1; return; }
                if ((matrix[i, 2] == matrix[i, 0]) && (matrix[i, 2] == -1) && (matrix[i, 1] == 0))
                    { matrix[i, 1] = -1; return; }
                if ((matrix[0, i] == matrix[1, i]) && (matrix[0, i] == -1) && (matrix[2, i] == 0))
                    { matrix[2, i] = -1; return; }
                if ((matrix[0, i] == matrix[2, i]) && (matrix[0, i] == -1) && (matrix[1, i] == 0))
                    { matrix[1, i] = -1; return; }
                if ((matrix[2, i] == matrix[0, i]) && (matrix[2, i] == -1) && (matrix[1, i] == 0))
                    { matrix[1, i] = -1; return; }
                if ((matrix[2, i] == matrix[1, i]) && (matrix[2, i] == -1) && (matrix[0, i] == 0))
                    { matrix[0, i] = -1; return; }
            }
            for (int i = 0; i <= 2; i++)
            {
                if ((matrix[i, 0] == matrix[i, 1]) && (matrix[i, 0] == 1) && (matrix[i, 2] == 0))
                    { matrix[i, 2] = -1; return; }
                if ((matrix[i, 2] == matrix[i, 1]) && (matrix[i, 2] == 1) && (matrix[i, 0] == 0))
                    { matrix[i, 0] = -1; return; }
                if ((matrix[i, 0] == matrix[i, 2]) && (matrix[i, 0] == 1) && (matrix[i, 1] == 0))
                    { matrix[i, 1] = -1; return; }
                if ((matrix[i, 2] == matrix[i, 0]) && (matrix[i, 2] == 1) && (matrix[i, 1] == 0))
                    { matrix[i, 1] = -1; return; }
                if ((matrix[0, i] == matrix[1, i]) && (matrix[0, i] == 1) && (matrix[2, i] == 0))
                    { matrix[2, i] = -1; return; }
                if ((matrix[2, i] == matrix[1, i]) && (matrix[2, i] == 1) && (matrix[0, i] == 0))
                    { matrix[0, i] = -1; return; }
                if ((matrix[0, i] == matrix[2, i]) && (matrix[0, i] == 1) && (matrix[1, i] == 0))
                    { matrix[1, i] = -1; return; }
                if ((matrix[2, i] == matrix[1, i]) && (matrix[2, i] == 1) && (matrix[0, i] == 0))
                    { matrix[0, i] = -1; return; }
            }
            if ((matrix[0, 0] == matrix[1, 1]) && (matrix[0, 0] == 1) && (matrix[2, 2] == 0))
                { matrix[2, 2] = -1; return; }
            if ((matrix[0, 0] == matrix[2, 2]) && (matrix[0, 0] == 1) && (matrix[1, 1] == 0))
                { matrix[1, 1] = -1; return; }
            if ((matrix[2, 2] == matrix[1, 1]) && (matrix[2, 2] == 1) && (matrix[0, 0] == 0))
                { matrix[0, 0] = -1; return; }
            if ((matrix[0, 2] == matrix[1, 1])  && (matrix[0, 2] == 1) && (matrix[2, 0] == 0))
                { matrix[2, 0] = -1; return; }
            if ((matrix[0, 2] == matrix[2, 0]) && (matrix[0, 2] == 1) && (matrix[1, 1] == 0))
            { matrix[1, 1] = -1; return; }
            if ((matrix[2, 0] == matrix[1, 1]) && (matrix[2, 0] == 1) && (matrix[0, 2] == 0))
                { matrix[0, 2] = -1; return; }
            if (matrix[1, 1] == 0)
                matrix[1, 1] = -1;
            else 
            {
                if ((lepes == 2) && (matrix[1, 1] != 0))
                {
                    Random veletlen = new Random();
                    int x = veletlen.Next(0, 4);
                    if (x == 0)
                        matrix[0, 0] = -1;
                    if (x == 1)
                        matrix[0, 2] = -1;
                    if (x == 2)
                        matrix[2, 0] = -1;
                    if (x == 3)
                        matrix[2, 2] = -1;
                }
                else
                {  
                    int sor = 0, oszlop = 0;
                    Random veletlen = new Random();
                    if ((matrix[0, 0] == 0) || (matrix[0, 2] == 0) || (matrix[2, 0] == 0) || (matrix[2, 2] == 0))
                    {
                        do
                        {
                            sor = veletlen.Next(0, 3);
                            oszlop = veletlen.Next(0, 3);
                        } while ((matrix[sor, oszlop] != 0) || (sor == 1) || (oszlop == 1));
                        matrix[sor, oszlop] = -1;
                    }
                    else                    
                    {
                        do
                        {
                            sor = veletlen.Next(0, 3);
                            oszlop = veletlen.Next(0, 3);
                        } while (matrix[sor, oszlop] != 0);
                        matrix[sor, oszlop] = -1;
                    }
                }
            }
        }
    }
}
