using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BaseApp
{
    public partial class ChartForm : Form
    {
        // Paths with filenames holding data bytes
        private string[] dataFiles;
        // Map of filenames and their data
        private Dictionary<string, FileRecords> FileDataMap;

        public ChartForm(string[] dataFilesParam)
        {
            InitializeComponent();
            
            dataFiles = dataFilesParam;
            ExtractData();
            ShowData();

            ShowHideTemp.Tag = "Temperature";
            ShowHideHumid.Tag = "Humidity";
            ShowHideLight.Tag = "Light";


        }

        /// <summary>
        /// Creates a dictionary of strings and Linked Lists of byte arrays for each file in dataFiles string array.
        /// </summary>
        private void ExtractData()
        {
            FileDataMap = new Dictionary<string, FileRecords>();
            foreach (string filename in dataFiles)
            {
                FileDataMap.Add(filename, Logger.Parse(Logger.Parse(filename)));
            }
        }
        #region Tab and Chart
        /// <summary>
        /// Chart building and drawing using data from files in FileDataMap.
        /// For each file in FileDataMap a Tab control is created and given a Chart control.
        /// Each chart contains three series. Series are LinkedList of bytes.
        /// </summary>
        private void ShowData()
        {
            foreach (KeyValuePair<string, FileRecords> pair in FileDataMap)
            {
                string file = Path.GetFileName(pair.Key);
                FileRecords data = pair.Value;

                // Chart building
                Chart chart = new Chart()
                {
                    Dock = DockStyle.Fill,
                    
                };
                
                ChartArea chartArea = new ChartArea()
                {
                    BackColor = Color.Black
                };
                chartArea.AxisX.MajorGrid.LineColor = Color.DarkSeaGreen;
                chartArea.AxisX.MinorGrid.LineColor = Color.DarkSlateGray;
                chartArea.AxisY.MajorGrid.LineColor = Color.DarkSeaGreen;
                chartArea.AxisY.MinorGrid.LineColor = Color.DarkSlateGray;
                chartArea.AxisX.MinorGrid.Enabled = true;
                chartArea.AxisY.MinorGrid.Enabled = true;
                chart.ChartAreas.Add(chartArea);

                Series tempSeries = new Series("Temperature")
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.DateTime
                };
                
                Series humidSeries = new Series("Humidity")
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.DateTime
                };
                Series lightSeries = new Series("Light")
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.DateTime,
                    IsVisibleInLegend = true
                };
                chart.Series.Add(tempSeries);
                chart.Series.Add(humidSeries);
                chart.Series.Add(lightSeries);
                // Link Series with data
                chart.Series["Temperature"].Points.DataBindXY(data.Time, data.Temperature);
                chart.Series["Humidity"].Points.DataBindXY(data.Time, data.Humidity);
                chart.Series["Light"].Points.DataBindXY(data.Time, data.Light);
                chart.Invalidate();

                // TabPage creation and everything...
                TabPage tabPage = new TabPage(Path.GetFileNameWithoutExtension(pair.Key));
                tabPage.Controls.Add(chart);
                tabPage.Tag = pair.Key;

                // TabContainer tweaks and tabs
                TabContainer.TabPages.Add(tabPage);
                TabContainer.SelectedIndexChanged += TabContainer_SelectedIndexChanged;
            }
        }
        #endregion

        private void TabContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabContainer.TabPages.Count == 0) return;

            Series Temperature = (TabContainer.SelectedTab.Controls[0] as Chart).Series[ShowHideTemp.Tag as string];
            Series Humidity = (TabContainer.SelectedTab.Controls[0] as Chart).Series[ShowHideHumid.Tag as string];
            Series Light = (TabContainer.SelectedTab.Controls[0] as Chart).Series[ShowHideLight.Tag as string];
            ShowHideTemp.Text = (Temperature.Enabled) ? "Hide" : "Show";
            ShowHideHumid.Text = (Humidity.Enabled) ? "Hide" : "Show";
            ShowHideLight.Text = (Light.Enabled) ? "Hide" : "Show";
        }


        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseTab();
        }

        private void CloseTab()
        {
            TabContainer.TabPages.Remove(TabContainer.SelectedTab);
            if (TabContainer.TabPages.Count == 0)
            {
                Close();
            }
        }

        private void SaveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Title = "Save Chart to Image File",
                Filter = "Portable Network Graphics (*.png)|*.png",
                FilterIndex = 1,
                RestoreDirectory = true,
                InitialDirectory = Path.GetDirectoryName(dataFiles[0])
            };

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                (TabContainer.SelectedTab.Controls[0] as Chart).SaveImage(sfd.FileName, ChartImageFormat.Png);
            }
        }

        private void DataVisibility_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsItem = sender as ToolStripMenuItem;
            Series series = (TabContainer.SelectedTab.Controls[0] as Chart).Series[tsItem.Tag as string];

            series.Enabled = !series.Enabled;
            tsItem.Text = (series.Enabled) ? "Hide" : "Show";
        }

        private void DataColor_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsItem = sender as ToolStripMenuItem;
            Series series = (TabContainer.SelectedTab.Controls[0] as Chart).Series[tsItem.Text];
            series.Color = ShowColorDialog(series.Color);
        }

        private Color ShowColorDialog(Color oldColor)
        {

            ColorDialog cd = new ColorDialog()
            {
                AllowFullOpen = true,
                AnyColor = true,
                FullOpen = true,
                Color = oldColor
            };
            if (cd.ShowDialog() == DialogResult.OK)
            {
                oldColor = cd.Color;
            }

            return oldColor;
        }

        private void BackgroundColor_Click(object sender, EventArgs e)
        {
            ChartArea ca = (TabContainer.SelectedTab.Controls[0] as Chart).ChartAreas[0];
            ca.BackColor = ShowColorDialog(ca.BackColor);
        }
    }
}
