using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Man : Form
    {
        public Man()
        {
            InitializeComponent();
        }
        private Form2 mainForm = null;
        public delegate void delPassData(TextBox text);
        private void Man_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] arr = Array.ConvertAll(textBox2.Text.Split(','), int.Parse);


            int[] roll = new int[16];
            int p = 0;
            int[] man = { 1, -1, -1, 1 };

            for (int i = 0; i < 15; i+=2)
            {
                if (arr[i / 2] == 1)
                {
                    roll[i] = -1;
                    roll[i + 1] = 1;
                }
                else
                {
                    roll[i] = 1;
                    roll[i + 1] = -1;
                }

            }

            
            double[] y = { 0, 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5 };
            chart1.Series.Add("My Data");
            for (int i = 0; i < 8; i++)
            {
                chart1.Series["My Data"].
                              Points.AddXY(y[i], arr[i]);
            }
            chart1.Series["My Data"].ChartType =
                    SeriesChartType.StepLine;
            ChartArea area = chart2.ChartAreas[0];
            area.AxisX.Maximum = 9;
            area.AxisX.Minimum = -1;
            area.AxisX.Interval = 1;
            area.BorderWidth = 1;
            chart1.Series["My Data"].Color = Color.Red;
            chart1.Series["My Data"].BorderWidth = 5;

            area.AxisY.Maximum = 2;
            area.AxisY.Minimum = -2;
            area.AxisY.Interval = 1;


            chart2.Series.Add("EN Data");
            for (int i = 0; i < 16; i++)
            {
                chart2.Series["EN Data"].
                              Points.AddXY(y[i], roll[i]);
            }
            chart2.Series["EN Data"].ChartType =
                    SeriesChartType.StepLine;
            ChartArea area1 = chart2.ChartAreas[0];
            area1.AxisX.Maximum = 9;
            area1.AxisX.Minimum = -1;
            area1.AxisX.Interval = 1;
            area1.BorderWidth = 1;
            chart2.Series["EN Data"].Color = Color.Blue;
            chart2.Series["EN Data"].BorderWidth = 5;

            area1.AxisY.Maximum = 2;
            area1.AxisY.Minimum = -2;
            area1.AxisY.Interval = 1;
            var result = string.Join(",", roll);
            textBox1.Text = result;

            fo frm = new fo();
            delPassData del = new delPassData(frm.funData);
            del(this.textBox1);
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr = Array.ConvertAll(textBox2.Text.Split(','), int.Parse);


            int[] roll = new int[16];
            int p = 0;
            int[] man = { 1, -1, -1, 1 };

            if(arr[0]==0)
            {
                roll[0] = 1;
                roll[1] = -1;
            }
            else if(arr[0]==1)
            {
                roll[0] = -1;
                roll[1] = 1;
                p = 2;
            }

            for (int i = 2; i < 15; i += 2)
            {
                if (arr[i / 2] == 1)
                {
                    if(p==2)
                    {
                        p = 0;
                    }
                    else
                    {
                        p = 2;
                    }
                    roll[i] = man[p];
                    roll[i + 1] = man[p + 1];
                }

                else
                {
                    roll[i] = man[p];
                    roll[i + 1] = man[p+1];
                }

            }

            int[] x = { 1, 0, 1, 1, 1, 1, 0, 1 };
            double[] y = { 0, 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5 };
            chart1.Series.Add("My Data");
            for (int i = 0; i < 8; i++)
            {
                chart1.Series["My Data"].
                              Points.AddXY(y[i], arr[i]);
            }
            chart1.Series["My Data"].ChartType =
                    SeriesChartType.StepLine;
            ChartArea area = chart2.ChartAreas[0];
            area.AxisX.Maximum = 9;
            area.AxisX.Minimum = -1;
            area.AxisX.Interval = 1;
            area.BorderWidth = 1;
            chart1.Series["My Data"].Color = Color.Red;
            chart1.Series["My Data"].BorderWidth = 5;

            area.AxisY.Maximum = 2;
            area.AxisY.Minimum = -2;
            area.AxisY.Interval = 1;


            chart2.Series.Add("EN Data");
            for (int i = 0; i < 16; i++)
            {
                chart2.Series["EN Data"].Points.AddXY(y[i], roll[i]);
            }
            chart2.Series["EN Data"].ChartType =
                    SeriesChartType.StepLine;
            ChartArea area1 = chart2.ChartAreas[0];
            area1.AxisX.Maximum = 9;
            area1.AxisX.Minimum = -1;
            area1.AxisX.Interval = 1;
            area1.BorderWidth = 1;
            chart2.Series["EN Data"].Color = Color.Blue;
            chart2.Series["EN Data"].BorderWidth = 5;

            area1.AxisY.Maximum = 2;
            area1.AxisY.Minimum = -2;
            area1.AxisY.Interval = 1;
            var result = string.Join(",", roll);
            textBox1.Text = result;

            fo frm = new fo();
            delPassData del = new delPassData(frm.funData);
            del(this.textBox1);
            frm.Show();
        }
    }
}
