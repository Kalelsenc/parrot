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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ParrotProject
{
    public partial class MainWindow : Form
    {
        NeuroContainer neuroContainer = new NeuroContainer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            neuroContainer.Save();
            
        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            neuroContainer.Load();
        }


        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        public static void setPoints(List<object> vectors)
        {
            MainWindow mainWindow = new MainWindow();
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.CustomProperties = "IsXAxisQuantitative=True";
            for (int i=0;i<vectors.Count();i++)
                series.Points.AddXY(((Vector2)vectors[i]).x, ((Vector2)vectors[i]).y);
            mainWindow.chart1.Series.Add(series);
            mainWindow.ShowDialog();
        }


    }
}
