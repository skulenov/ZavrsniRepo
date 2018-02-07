namespace BaseApp
{
    partial class ChartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabContainer = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temperatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.humidityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMajorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMinorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yMajorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yMinorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.temperatureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowHideTemp = new System.Windows.Forms.ToolStripMenuItem();
            this.humidityToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowHideHumid = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowHideLight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabContainer
            // 
            this.TabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabContainer.Location = new System.Drawing.Point(0, 24);
            this.TabContainer.Name = "TabContainer";
            this.TabContainer.SelectedIndex = 0;
            this.TabContainer.Size = new System.Drawing.Size(624, 417);
            this.TabContainer.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.dataToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plotToolStripMenuItem
            // 
            this.plotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.saveImageToolStripMenuItem});
            this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            this.plotToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.plotToolStripMenuItem.Text = "Plot";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.SaveImageToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.gridToolStripMenuItem,
            this.backgroundToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temperatureToolStripMenuItem,
            this.humidityToolStripMenuItem,
            this.lightToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // temperatureToolStripMenuItem
            // 
            this.temperatureToolStripMenuItem.Name = "temperatureToolStripMenuItem";
            this.temperatureToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.temperatureToolStripMenuItem.Text = "Temperature";
            this.temperatureToolStripMenuItem.Click += new System.EventHandler(this.DataColor_Click);
            // 
            // humidityToolStripMenuItem
            // 
            this.humidityToolStripMenuItem.Name = "humidityToolStripMenuItem";
            this.humidityToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.humidityToolStripMenuItem.Text = "Humidity";
            this.humidityToolStripMenuItem.Click += new System.EventHandler(this.DataColor_Click);
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.lightToolStripMenuItem.Text = "Light";
            this.lightToolStripMenuItem.Click += new System.EventHandler(this.DataColor_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMajorToolStripMenuItem,
            this.xMinorToolStripMenuItem,
            this.yMajorToolStripMenuItem,
            this.yMinorToolStripMenuItem});
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            // 
            // xMajorToolStripMenuItem
            // 
            this.xMajorToolStripMenuItem.Name = "xMajorToolStripMenuItem";
            this.xMajorToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.xMajorToolStripMenuItem.Text = "X Major";
            this.xMajorToolStripMenuItem.Click += new System.EventHandler(this.XMajorColor_Click);
            // 
            // xMinorToolStripMenuItem
            // 
            this.xMinorToolStripMenuItem.Name = "xMinorToolStripMenuItem";
            this.xMinorToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.xMinorToolStripMenuItem.Text = "X Minor";
            this.xMinorToolStripMenuItem.Click += new System.EventHandler(this.XMinorColor_Click);
            // 
            // yMajorToolStripMenuItem
            // 
            this.yMajorToolStripMenuItem.Name = "yMajorToolStripMenuItem";
            this.yMajorToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.yMajorToolStripMenuItem.Text = "Y Major";
            this.yMajorToolStripMenuItem.Click += new System.EventHandler(this.YMajorColor_Click);
            // 
            // yMinorToolStripMenuItem
            // 
            this.yMinorToolStripMenuItem.Name = "yMinorToolStripMenuItem";
            this.yMinorToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.yMinorToolStripMenuItem.Text = "Y Minor";
            this.yMinorToolStripMenuItem.Click += new System.EventHandler(this.YMinorColor_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.BackgroundColor_Click);
            // 
            // dataToolStripMenuItem1
            // 
            this.dataToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temperatureToolStripMenuItem1,
            this.humidityToolStripMenuItem1,
            this.lightToolStripMenuItem1});
            this.dataToolStripMenuItem1.Name = "dataToolStripMenuItem1";
            this.dataToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem1.Text = "Data";
            // 
            // temperatureToolStripMenuItem1
            // 
            this.temperatureToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowHideTemp});
            this.temperatureToolStripMenuItem1.Name = "temperatureToolStripMenuItem1";
            this.temperatureToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.temperatureToolStripMenuItem1.Text = "Temperature";
            // 
            // ShowHideTemp
            // 
            this.ShowHideTemp.Name = "ShowHideTemp";
            this.ShowHideTemp.Size = new System.Drawing.Size(99, 22);
            this.ShowHideTemp.Text = "Hide";
            this.ShowHideTemp.Click += new System.EventHandler(this.DataVisibility_Click);
            // 
            // humidityToolStripMenuItem1
            // 
            this.humidityToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowHideHumid});
            this.humidityToolStripMenuItem1.Name = "humidityToolStripMenuItem1";
            this.humidityToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.humidityToolStripMenuItem1.Text = "Humidity";
            // 
            // ShowHideHumid
            // 
            this.ShowHideHumid.Name = "ShowHideHumid";
            this.ShowHideHumid.Size = new System.Drawing.Size(99, 22);
            this.ShowHideHumid.Text = "Hide";
            this.ShowHideHumid.Click += new System.EventHandler(this.DataVisibility_Click);
            // 
            // lightToolStripMenuItem1
            // 
            this.lightToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowHideLight});
            this.lightToolStripMenuItem1.Name = "lightToolStripMenuItem1";
            this.lightToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.lightToolStripMenuItem1.Text = "Light";
            // 
            // ShowHideLight
            // 
            this.ShowHideLight.Name = "ShowHideLight";
            this.ShowHideLight.Size = new System.Drawing.Size(99, 22);
            this.ShowHideLight.Text = "Hide";
            this.ShowHideLight.Click += new System.EventHandler(this.DataVisibility_Click);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.TabContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChartForm";
            this.Text = "Data Plot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temperatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem humidityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMajorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMinorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yMajorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yMinorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem temperatureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ShowHideTemp;
        private System.Windows.Forms.ToolStripMenuItem humidityToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ShowHideHumid;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ShowHideLight;
    }
}