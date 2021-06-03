using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Степенной_метод1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = Convert.ToInt32(textBox1.Text);

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = N;
            dataGridView1.RowCount = N;

            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.RowCount = N;
            dataGridView2.ColumnCount = 1;

            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            dataGridView3.RowCount = N;
            dataGridView3.ColumnCount = 1;

            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
            dataGridView4.RowCount = N;
            dataGridView4.ColumnCount = 1;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            double EPS = Convert.ToDouble(textBox2.Text);
            int N = Convert.ToInt32(textBox1.Text);

            double[,] A = new double[N, N];
            double[] y = new double[N];
            double[] x = new double[N];
            double[] xped = new double[N];
            double[] hl = new double[N];
            double[] prehl = new double[N];
            bool check = false;

            for (int i = 0; i < N; i++) //считывание А
            {
                for (int j = 0; j < (N); j++)
                {
                    A[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }

            for (int i = 0; i < N; i++) //заполнение y
            {
                y[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString());
            }


            for (int i = 0; i < N; i++)
            {
                hl[i] = 0;// нашли хл пердыдущий
            }

            for(int i=0;i<N;i++)
            {
                xped[i] = 0; // задали пред х
            }

            int k = 0;

            /*Алгоритм*/

            while (check == false)
            {
                for (int i = 0; i < N; i++)//х
                {
                    if(k>0)
                    {
                        xped[i] = x[i];
                    }
                    double sum = 0;
                    for (int j = 0; j < N; j++)//Sum
                    {
                        sum += y[j] * y[j];
                    }
                    x[i] = y[i] /Math.Sqrt(sum);// нашли х
                    dataGridView3.Rows[i].Cells[0].Value = x[i];
                }
                k++;
                for (int i = 0; i < N; i++)
                {
                    if (xped[i] != 0)
                    {
                        prehl[i] = hl[i];
                        hl[i] = y[i] / xped[i];// нашли хл
                        dataGridView4.Rows[i].Cells[0].Value = hl[i];
                    }
                }


                for (int i = 0; i < N; i++) // умножение матрицы
                {
                    y[i] = 0;
                    for (int j = 0; j < N; j++)
                    {
                        y[i] += A[i, j] * x[j];
                        dataGridView2.Rows[i].Cells[0].Value = y[i];
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    if (Math.Abs(hl[i] - prehl[i]) > EPS)
                    {
                        check = false;
                    }
                    else if (hl[i] == 0 && prehl[i] == 0)
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для задачи в тетради решена РОВНО с погрешностью 0,1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int N = Convert.ToInt32(textBox1.Text);
            double[] y = new double[N];
            for (int i = 0; i < N; i++) //заполнение y
            {
                 y[i] = 1;

                 if (i>0)
                 {
                     y[i] = 0;
                 }
                 dataGridView2.Rows[i].Cells[0].Value = y[i];
            }

            if (N == 3)
            {
                dataGridView1.Rows[0].Cells[0].Value = 5;
                dataGridView1.Rows[0].Cells[1].Value = 6;
                dataGridView1.Rows[0].Cells[2].Value = 3;

                dataGridView1.Rows[1].Cells[0].Value = -1;
                dataGridView1.Rows[1].Cells[1].Value = 0;
                dataGridView1.Rows[1].Cells[2].Value = 1;

                dataGridView1.Rows[2].Cells[0].Value = 1;
                dataGridView1.Rows[2].Cells[1].Value = 2;
                dataGridView1.Rows[2].Cells[2].Value = -1;
            }
        }
    }
}
