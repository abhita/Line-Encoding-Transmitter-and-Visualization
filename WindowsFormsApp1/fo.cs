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
    public partial class fo : Form
    {


        public fo()
        {
            InitializeComponent();
            
        }
        private Form1 mainForm = null;
        SimpleTcpServer server;
        private void fo_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;


        }
        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            //Update mesage to txtStatus
            textBox1.Invoke((MethodInvoker)delegate ()
            {
                textBox1.Text = e.MessageString.Substring(0, e.MessageString.Length-1); ;
                
             //   e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            });


        }


        private void label1_Click(object sender, EventArgs e)
        {
            System.Net.IPAddress ip = System.Net.IPAddress.Parse("127.0.0.1");
            server.Start(ip, Convert.ToInt32("8910"));
        }

        public void funData(TextBox txtForm1)
        {
             textBox1.Text = txtForm1.Text;

            int[] roll = new int[16];
            roll = Array.ConvertAll(textBox1.Text.Split(','), Int32.Parse);

            chart1.Series.Add("EN Data");
            double[] y = {0, 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7,7.5};
            for (int i = 0; i < roll.Length; i++)
            {
                chart1.Series["EN Data"].
                              Points.AddXY(y[i], roll[i]);
            }
            chart1.Series["EN Data"].ChartType =
                    SeriesChartType.StepLine;
            ChartArea area1 = chart1.ChartAreas[0];
            area1.AxisX.Maximum = roll.Length+1;
            area1.AxisX.Minimum = 0;
            area1.AxisX.Interval = 0.5;
            area1.BorderWidth = 1;
            chart1.Series["EN Data"].Color = Color.Blue;
            chart1.Series["EN Data"].BorderWidth = 5;
            area1.AxisX.LabelStyle.Enabled = false;
            area1.AxisY.Maximum = 3;
            area1.AxisY.Minimum = -3;
            area1.AxisY.Interval = 1;

            // textBox1.Text += "Server starting...";





        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] roll = new int[8];
            roll = Array.ConvertAll(textBox1.Text.Split(','), Int32.Parse);

            chart1.Series.Add("EN Data");
            int[] y = {0, 1, 2, 3, 4, 5, 6,7,8};
            
            for (int i = 0; i < 9; i++)
            {
                if (i == 8)
                {
                    chart1.Series["EN Data"].
                              Points.AddXY(y[i], roll[i - 1]);
                }
                else
                {
                    chart1.Series["EN Data"].
                                  Points.AddXY(y[i], roll[i]);
                }
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

            area1.AxisY.Maximum = 3;
            area1.AxisY.Minimum = -3;
            area1.AxisY.Interval = 1;
            if (server.IsStarted)
                server.Stop();
        }
    }
}
