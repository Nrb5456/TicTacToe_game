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
    public partial class Form3 : Form
    {
        int[,] matrix = new int [3,3];
        int jatekos=1;
        int scorex = 0;
        int scoreo = 0;
        Font betu=new Font ("arial",110);
        Bitmap xfigura = new Bitmap("X.png");
        Bitmap ofigura = new Bitmap("O.png");
        public Form3()
        {
            InitializeComponent(); 
        }

        private void button10_Click(object sender, EventArgs e)
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
                    //e.Graphics.DrawString(matrix[i, j].ToString(), betu, Brushes.Black, j * 149, i * 130);
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

        private void restart(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matrix[i, j] = 0;
            jatekos = 1;
            if (jatekos == 1)
                label3.Text = "Next : X";
            if (jatekos == -1)
                label3.Text = "Next : O";
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int sor, oszlop;
            sor = e.Y / 140;
            oszlop = e.X / 140;
            if (matrix[sor, oszlop] == 0)
            {
                matrix[sor, oszlop] = jatekos;   
                jatekos = -jatekos;
            }
            pictureBox1.Refresh();
            if (jatekos == 1)
            { 
                label3.Text = "Next : X"; 
            }              
            if (jatekos == -1)
                label3.Text = "Next : O";
            int nyertes=nyert();
            if(nyertes==1)
            {
                scorex++;
                label1.Text = "Player X : " + scorex.ToString();
                MessageBox.Show("Player X wins!");      
            }    
            if (nyertes == -1)
            {
                scoreo++;
                label2.Text = "Player O : " + scoreo.ToString();
                MessageBox.Show("Player O wins!");
            }
            if (nyertes == 2)
            {
                MessageBox.Show("It's a draw!");
            }
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
            if ((matrix[0, 0] != 0) && (matrix[1, 0] != 0) && (matrix[2, 0] != 0) && (matrix[1, 1] != 0) && (matrix[1, 2] != 0) && (matrix[2, 1] != 0) && (matrix[2, 2] != 0))
                return 2;
            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matrix[i, j] = 0;
            jatekos = 1;
            pictureBox1.Refresh();
            scorex =0;
            label1.Text = "Player X : " + scorex.ToString();
            scoreo=0;
            label2.Text = "Player O : " + scoreo.ToString();
            if (jatekos == 1)
                label3.Text = "Next : X";
            if (jatekos == -1)
                label3.Text = "Next : O";
        }
    }
}
