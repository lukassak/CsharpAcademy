using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DataLayer;
using sqlit;
using Graph = System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.Entity.Internal;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        FullDataManager dataManager = new FullDataManager();
        MetricsContext database = new MetricsContext();
        private int timer = 0;
        public Form1()
        {

            InitializeComponent();
            using (var context = new MetricsContext()) { }
            chart1.Series.Clear();
            chart1.Series.Add("Cpu usage");

            ComputerSummary ComputerSummary = new ComputerSummary();
            ComputerSummary.Name = dataManager.GetMetric(Name);
        }

        public void chart(object sender, EventArgs e)
        {
            // Data arrays.
            var cpuUsage = dataManager.GetMetric("cpuusage");
            var ramUsage = dataManager.GetMetric("ramusage");

           
        }
    

    private void button1_Click(object sender, EventArgs e)
        {
            var computername = dataManager.GetMetric("computername");
            textBox1.Text = $"{computername}";

        }


       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var cpuUsage = dataManager.GetMetric("cpuusage");
            textBox3.Text = $"{cpuUsage}"; 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var video = dataManager.GetMetric("card");
            textBox2.Text = $"{video}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart(sender,e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ramUsage = dataManager.GetMetric("ramusage");
            textBox4.Text = $"{ramUsage}";

        }

        private void timer_Tick(object sender, EventArgs e )
            {
                chart1.Series["Cpu usage"].ChartType = Graph.SeriesChartType.Line;
            chart1.Series["Cpu usage"].Points.AddXY(timer, new FullDataManager().GetMetric("cpuusage"));
                new FullDataManager().GetMetric("cpusuage");
                timer++;
            }
        }
    }

