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
using SimpleTCP;

namespace WindowsFormsApp1
{
    public partial class Nonpolar : Form
    {
        public Nonpolar()
        {
            InitializeComponent();

        }

        private Form2 mainForm = null;
        SimpleTcpClient client;
        public delegate void delPassData(TextBox text);
        fo frm = new fo();
        
        private void Nonpolar_Load(object sender, EventArgs e)
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


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

 
            int[] roll = Array.ConvertAll(textBox1.Text.Split(','), int.Parse);

            int[] arr = new int[10];

            arr[0] = 1;

            for (int i = 0; i < 8; i++)
            {
                    if (roll[i] > 0)
                    {
                        arr[i] = 1;
                    }
                    else
                    {
                        arr[i] = 0;
                    }
            }

            int[] y = { 0, 1, 2, 3, 4, 5, 6,7,8};

            chart1.Series.Add("My Data");
            for (int i = 0; i < 9; i++)
            {
                if (i == 8)
                {
                    chart1.Series["My Data"].
                              Points.AddXY(y[i], roll[i - 1]);
                }
                else
                {
                    chart1.Series["My Data"].
                                  Points.AddXY(y[i], roll[i]);
                }
            }
            chart1.Series["My Data"].ChartType =
                    SeriesChartType.StepLine;
            ChartArea area = chart1.ChartAreas[0];
            area.AxisX.Maximum = 9;
            area.AxisX.Minimum = -1;
            area.AxisX.Interval = 1;
            area.BorderWidth = 1;
            chart1.Series["My Data"].Color = Color.Red;
            chart1.Series["My Data"].BorderWidth = 5;

            area.AxisY.Maximum = 5;
            area.AxisY.Minimum = -5;
            area.AxisY.Interval = 1;

            chart2.Series.Add("EN Data");
            for (int i = 0; i < 9; i++)
            {
                if (i == 8)
                {
                    chart2.Series["EN Data"].
                              Points.AddXY(y[i], arr[i - 1]);
                }
                else
                {
                    chart2.Series["EN Data"].
                                  Points.AddXY(y[i], arr[i]);
                }
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

            area1.AxisY.Maximum = 5;
            area1.AxisY.Minimum = -5;
            area1.AxisY.Interval = 1;
            var result = string.Join(",", arr);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
