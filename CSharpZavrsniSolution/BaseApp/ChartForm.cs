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
        }

        /// <summary>
        /// Creates a dictionary of strings and Linked Lists of byte arrays for each file in dataFiles string array.
        /// </summary>
        private void ExtractData()
        {
            FileDataMap = new Dictionary<string, FileRecords>();
            foreach (string filename in dataFiles)
            {
                //LinkedList<Record> recList = Logger.Parse(filename);
                //FileRecords fileRecs = Logger.Parse(recList);
                FileDataMap.Add(filename, Logger.Parse(Logger.Parse(filename)));
            }
        }

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

                TabContainer.Controls.Add(tabPage);
                TabContainer.MouseUp += TabContainer_MouseUp;
            }
        }

        private void TabContainer_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Right)
            {
                MenuItem miClose = new MenuItem("Close chart");
                miClose.Click += MiClose_Click;
                MenuItem miSaveImage = new MenuItem("Save chart image");
                miSaveImage.Click += MiSaveImage_Click;

                ContextMenu tabCtxMenu = new ContextMenu(new MenuItem[] { miClose,miSaveImage });
                TabContainer.ContextMenu = tabCtxMenu;
                TabContainer.ContextMenu.Show(TabContainer, e.Location);
            }
        }

        private void MiSaveImage_Click(object sender, EventArgs e)
        {
            (sender as MenuItem).GetContextMenu().Dispose();
            Chart chart = TabContainer.SelectedTab.Controls[0] as Chart;
            string tabTag = TabContainer.SelectedTab.Tag.ToString();
            chart.SaveImage(Path.Combine(Path.GetDirectoryName(tabTag), Path.GetFileNameWithoutExtension(tabTag)+"_chartImage.png"), ChartImageFormat.Png);
        }

        private void MiClose_Click(object sender, EventArgs e)
        {
            
            (sender as MenuItem).GetContextMenu().Dispose();
            CloseTab();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseTab();
        }

        private void CloseTab()
        {
            TabContainer.Controls.Remove(TabContainer.SelectedTab);

            if (TabContainer.Controls.Count == 0)
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


    }
}
