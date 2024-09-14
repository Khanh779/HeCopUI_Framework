using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using HeCopUI_Framework.Controls.Charts;
using System.Collections.Generic;
using HeCopUI_Framework.Controls.Charts.FunnelChart;
using HeCopUI_Framework.Controls;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using static HeCopUI_Framework.Forms.HMessageBox;
using HeCopUI_Framework.HDialog;
using HeCopUI_Framework.Forms;

namespace HecopUI_Test
{
    public partial class Form1 : HeCopUI_Framework.Forms.HForm
    {
     
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDataChart();

        }

        private void hCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            hCheckBox1.Text = hCheckBox1.Name+" (Checked: "+ hCheckBox1.Checked+")";
        }

        private void hCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            hCheckBox2.Text = hCheckBox2.Name + " (Checked: " + hCheckBox2.Checked + ")";
        }

        private void hCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            hCheckBox3.Text = hCheckBox3.Name + " (Checked: " + hCheckBox3.Checked + ")";
        }

        private void hButton10_MouseClick(object sender, MouseEventArgs e)
        {
           hProgressBar4.ProgressValue= hProgressBar5.ProgressValue=  hProgressBar2.ProgressValue = hProgressBar3.ProgressValue = new Random().Next(0, 100);
        }

        void loadDataChart()
        {
            #region Bar Chart
            // Ví dụ mẫu đi
            Dictionary<object, int> item1 = new Dictionary<object, int>();
            item1.Add("A", 10);
            item1.Add("B", 20);
            item1.Add("C", 30);

            hBarChart1. AddItems("Example 1", item1, Color.MediumVioletRed);

            Dictionary<object, int> item2 = new Dictionary<object, int>();
            item2.Add("A", 30);
            item2.Add("B", 70);
            item2.Add("C", 20);
            hBarChart1.AddItems("Example 2", item2, Color.DodgerBlue);

            Dictionary<object, int> item3 = new Dictionary<object, int>();
            item3.Add("A", 50);
            item3.Add("B", 20);
            item3.Add("C", 10);
            hBarChart1.AddItems("Example 3", item3, Color.FromArgb(0, 168, 138));
            #endregion

            #region Pie Chart
            Dictionary<object, int> item4 = new Dictionary<object, int>();
            item4.Add("A", 10);
            item4.Add("B", 20);
            item4.Add("C", 30);
            
            hPieChart1.AddItems("Example 1", item4, Color.MediumVioletRed);

            Dictionary<object, int> item5 = new Dictionary<object, int>();
            item5.Add("A", 30);
            item5.Add("B", 70);
            item5.Add("C", 20);
            hPieChart1.AddItems("Example 2", item5, Color.DodgerBlue);

            Dictionary<object, int> item6 = new Dictionary<object, int>();
            item6.Add("A", 50);
            item6.Add("B", 20);
            item6.Add("C", 10);
            hPieChart1.AddItems("Example 3", item6, Color.FromArgb(0, 168, 138));
            #endregion

            #region Line Chart
            Dictionary<object, int> item7 = new Dictionary<object, int>();
            item7.Add("A", 10);
            item7.Add("B", 20);
            item7.Add("C", 30);
            hLineAreaChart1.AddItems("Example 1", item7, Color.MediumVioletRed);

            Dictionary<object, int> item8 = new Dictionary<object, int>();
            item8.Add("A", 30);
            item8.Add("B", 70);
            item8.Add("C", 20);
            hLineAreaChart1.AddItems("Example 2", item8, Color.DodgerBlue);

            Dictionary<object, int> item9 = new Dictionary<object, int>();
            item9.Add("A", 50);
            item9.Add("B", 20);
            item9.Add("C", 10);
            hLineAreaChart1.AddItems("Example 3", item9, Color.FromArgb(0, 168, 138));
            #endregion

            #region Radar Chart
            // Thằng hRadar1 này xài Series là mảng ấy
            // Ví dụ mẫu đi
            List<HeCopUI_Framework.Controls.Charts.Series> series = new List<HeCopUI_Framework.Controls.Charts.Series>();
            
            HeCopUI_Framework.Controls.Charts.Series s1 = new HeCopUI_Framework.Controls.Charts.Series();
            s1.Text = "Example 1";
            s1.Values = new float[] { 10, 20, 30, 40, 50, 60 };
            s1.Color = Color.MediumVioletRed;

            HeCopUI_Framework.Controls.Charts.Series s2 = new HeCopUI_Framework.Controls.Charts.Series();
            s2.Text = "Example 2";
            s2.Values = new float[] { 60, 50, 40, 30, 20, 10 };
            s2.Color = Color.MediumSeaGreen;

            HeCopUI_Framework.Controls.Charts.Series s3 = new HeCopUI_Framework.Controls.Charts.Series();
            s3.Text = "Example 3";
            s3.Values = new float[] { 30, 40, 50, 60, 70, 80 };
            s3.Color = Color.MediumAquamarine;

            series.Add(s1);
            series.Add(s2);
            series.Add(s3);

            hRadarChart1.Series = series.ToArray() ; 


            #endregion

        }

        private void hCircleAnglePicker1_ValueChanged(object sender, EventArgs e)
        {
            hTextBox3.Text = hCircleAnglePicker1.Value.ToString();
        }

        private void hButton12_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void hButton11_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }
    }
}
