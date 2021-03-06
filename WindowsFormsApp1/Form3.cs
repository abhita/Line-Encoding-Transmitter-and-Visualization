using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private Form2 mainForm = null;
        SimpleTcpClient client;
        public delegate void delPassData(TextBox text);
        fo frm = new fo();

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

  

        private void Form3_Load(object sender, EventArgs e)
        {
            frm.Show();
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }
        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            //Update message to txtStatus
            textBox2.Invoke((MethodInvoker)delegate ()
            {
                textBox2.Text = e.MessageString;
            });
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] arr = Array.ConvertAll(textBox1.Text.Split(','), int.Parse);


            int[] roll = new int[10];
            int p = 0;
            int[] mlt = { 0, 1, 0, -1 };

            for (int i = 0; i < 8; i++)
            {
                if (arr[i] == 1)
                {
                    if (p == 3)
                    {
                        p = 0;
                    }
                    else
                    {
                        p++;
                    }
                    roll[i] = mlt[p];

                }
                else
                {
                    roll[i] = mlt[p];
                }
            }

            int[] x = { 1, 0, 1, 1, 1, 1, 0, 1 };
            int[] y = { 0, 1, 2, 3, 4, 5, 6, 7 };
            chart2.Series.Add("My Data");
            for (int i = 0; i < 8; i++)
            {
                chart2.Series["My Data"].
                              Points.AddXY(y[i], arr[i]);
            }
            chart2.Series["My Data"].ChartType =
                    SeriesChartType.StepLine;
            ChartArea area = chart2.ChartAreas[0];
            area.AxisX.Maximum = 9;
            area.AxisX.Minimum = -1;
            area.AxisX.Interval = 1;
            area.BorderWidth = 1;
            chart2.Series["My Data"].Color = Color.Red;
            chart2.Series["My Data"].BorderWidth = 5;

            area.AxisY.Maximum = 1;
            area.AxisY.Minimum = -1;
            area.AxisY.Interval = 1;


            chart1.Series.Add("EN Data");
            for (int i = 0; i < 8; i++)
            {
                chart1.Series["EN Data"].
                              Points.AddXY(y[i], roll[i]);
            }
            chart1.Series["EN Data"].ChartType =
                    SeriesChartType.StepLine;
            ChartArea area1 = chart1.ChartAreas[0];
            area1.AxisX.Maximum = 9;
            area1.AxisX.Minimum = -1;
            area1.AxisX.Interval = 1;
            area1.BorderWidth = 1;
            chart1.Series["EN Data"].Color = Color.Blue;
            chart1.Series["EN Data"].BorderWidth = 5;

            area1.AxisY.Maximum = 1;
            area1.AxisY.Minimum = -1;
            area1.AxisY.Interval = 1;

            var result = string.Join(",", roll);
            textBox2.Text = result;
            client.Connect("127.0.0.1", Convert.ToInt32("8910"));
            client.WriteLineAndGetReply(result, TimeSpan.FromSeconds(3));


            delPassData del = new delPassData(frm.funData);
            del(this.textBox2);
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr = Array.ConvertAll(textBox1.Text.Split(','), int.Parse);


            int[] roll = new int[10];
            int p = 0;
            int[] mlt = { 0, 1, 0, -1 };

            for (int i = 0; i < 8; i++)
            {
                if (arr[i] == 0)
                {
                    if (p == 3)
                    {
                        p = 0;
                    }
                    else
                    {
                        p++;
                    }
                    roll[i] = mlt[p];

                }
                else
                {
                    roll[i] = mlt[p];
                }
            }

            int[] x = { 1, 0, 1, 1, 1, 1, 0, 1 };
            int[] y = { 0, 1, 2, 3, 4, 5, 6, 7 };
            chart2.Series.Add("My Data");
            for (int i = 0; i < 8; i++)
            {
                chart2.Series["My Data"].
                              Points.AddXY(y[i], arr[i]);
            }
            chart2.Series["My Data"].ChartType =
                    SeriesChartType.StepLine;
            ChartArea area = chart2.ChartAreas[0];
            area.AxisX.Maximum = 9;
            area.AxisX.Minimum = -1;
            area.AxisX.Interval = 1;
            area.BorderWidth = 1;
            chart2.Series["My Data"].Color = Color.Red;
            chart2.Series["My Data"].BorderWidth = 5;

            area.AxisY.Maximum = 1;
            area.AxisY.Minimum = -1;
            area.AxisY.Interval = 1;


            chart1.Series.Add("EN Data");
            for (int i = 0; i < 8; i++)
            {
                chart1.Series["EN Data"].
                              Points.AddXY(y[i], roll[i]);
            }
            chart1.Series["EN Data"].ChartType =
                    SeriesChartType.StepLine;
            ChartArea area1 = chart1.ChartAreas[0];
            area1.AxisX.Maximum = 9;
            area1.AxisX.Minimum = -1;
            area1.AxisX.Interval = 1;
            area1.BorderWidth = 1;
            chart1.Series["EN Data"].Color = Color.Blue;
            chart1.Series["EN Data"].BorderWidth = 5;

            area1.AxisY.Maximum = 1;
            area1.AxisY.Minimum = -1;
            area1.AxisY.Interval = 1;

            var result = string.Join(",", roll);
            textBox2.Text = result;
            client.Connect("127.0.0.1", Convert.ToInt32("8910"));
            client.WriteLineAndGetReply(result, TimeSpan.FromSeconds(3));


            delPassData del = new delPassData(frm.funData);
            del(this.textBox2);
            frm.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
