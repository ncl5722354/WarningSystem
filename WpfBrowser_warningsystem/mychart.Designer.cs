namespace WpfBrowser_warningsystem
{
    partial class mychart
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_yidong = new System.Windows.Forms.Label();
            this.trackBar_shu_yidong = new System.Windows.Forms.TrackBar();
            this.label_shu_fangsuo = new System.Windows.Forms.Label();
            this.trackBar_shu_fangsuo = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label_heng_yidong = new System.Windows.Forms.Label();
            this.trackBar_heng_yidong = new System.Windows.Forms.TrackBar();
            this.label_heng_fangsuo = new System.Windows.Forms.Label();
            this.trackBar_heng_fangsuo = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_shu_yidong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_shu_fangsuo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_heng_yidong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_heng_fangsuo)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea3.AxisX.Interval = 100D;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisX.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea3.AxisX.Title = "长度(M)";
            chartArea3.AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.AxisY.Maximum = 10D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.AxisY.Title = "值";
            chartArea3.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea3.BackColor = System.Drawing.Color.Black;
            chartArea3.CursorX.IsUserEnabled = true;
            chartArea3.CursorY.IsUserEnabled = true;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(19, 17);
            this.chart1.Name = "chart1";
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.Red;
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series9.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.Name = "Series2";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.Name = "Series3";
            series11.YValuesPerPoint = 2;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.Name = "Series4";
            this.chart1.Series.Add(series9);
            this.chart1.Series.Add(series10);
            this.chart1.Series.Add(series11);
            this.chart1.Series.Add(series12);
            this.chart1.Size = new System.Drawing.Size(494, 217);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // label_yidong
            // 
            this.label_yidong.AutoSize = true;
            this.label_yidong.Location = new System.Drawing.Point(562, 17);
            this.label_yidong.Name = "label_yidong";
            this.label_yidong.Size = new System.Drawing.Size(29, 12);
            this.label_yidong.TabIndex = 1;
            this.label_yidong.Text = "移动";
            // 
            // trackBar_shu_yidong
            // 
            this.trackBar_shu_yidong.Location = new System.Drawing.Point(564, 54);
            this.trackBar_shu_yidong.Maximum = 100;
            this.trackBar_shu_yidong.Minimum = -100;
            this.trackBar_shu_yidong.Name = "trackBar_shu_yidong";
            this.trackBar_shu_yidong.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_shu_yidong.Size = new System.Drawing.Size(45, 237);
            this.trackBar_shu_yidong.TabIndex = 2;
            this.trackBar_shu_yidong.ValueChanged += new System.EventHandler(this.trackBar_shu_yidong_ValueChanged);
            // 
            // label_shu_fangsuo
            // 
            this.label_shu_fangsuo.AutoSize = true;
            this.label_shu_fangsuo.Location = new System.Drawing.Point(645, 17);
            this.label_shu_fangsuo.Name = "label_shu_fangsuo";
            this.label_shu_fangsuo.Size = new System.Drawing.Size(29, 12);
            this.label_shu_fangsuo.TabIndex = 3;
            this.label_shu_fangsuo.Text = "放缩";
            // 
            // trackBar_shu_fangsuo
            // 
            this.trackBar_shu_fangsuo.Location = new System.Drawing.Point(647, 54);
            this.trackBar_shu_fangsuo.Maximum = 100;
            this.trackBar_shu_fangsuo.Minimum = 1;
            this.trackBar_shu_fangsuo.Name = "trackBar_shu_fangsuo";
            this.trackBar_shu_fangsuo.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_shu_fangsuo.Size = new System.Drawing.Size(45, 237);
            this.trackBar_shu_fangsuo.TabIndex = 4;
            this.trackBar_shu_fangsuo.Value = 1;
            this.trackBar_shu_fangsuo.Scroll += new System.EventHandler(this.trackBar_shu_fangsuo_Scroll);
            this.trackBar_shu_fangsuo.ValueChanged += new System.EventHandler(this.trackBar_shu_fangsuo_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "复位";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_heng_yidong
            // 
            this.label_heng_yidong.AutoSize = true;
            this.label_heng_yidong.Location = new System.Drawing.Point(134, 249);
            this.label_heng_yidong.Name = "label_heng_yidong";
            this.label_heng_yidong.Size = new System.Drawing.Size(29, 12);
            this.label_heng_yidong.TabIndex = 6;
            this.label_heng_yidong.Text = "移动";
            // 
            // trackBar_heng_yidong
            // 
            this.trackBar_heng_yidong.Location = new System.Drawing.Point(191, 240);
            this.trackBar_heng_yidong.Maximum = 100;
            this.trackBar_heng_yidong.Minimum = -100;
            this.trackBar_heng_yidong.Name = "trackBar_heng_yidong";
            this.trackBar_heng_yidong.Size = new System.Drawing.Size(335, 45);
            this.trackBar_heng_yidong.TabIndex = 7;
            this.trackBar_heng_yidong.Scroll += new System.EventHandler(this.trackBar_heng_yidong_Scroll);
            this.trackBar_heng_yidong.ValueChanged += new System.EventHandler(this.trackBar_heng_yidong_ValueChanged);
            // 
            // label_heng_fangsuo
            // 
            this.label_heng_fangsuo.AutoSize = true;
            this.label_heng_fangsuo.Location = new System.Drawing.Point(134, 295);
            this.label_heng_fangsuo.Name = "label_heng_fangsuo";
            this.label_heng_fangsuo.Size = new System.Drawing.Size(29, 12);
            this.label_heng_fangsuo.TabIndex = 8;
            this.label_heng_fangsuo.Text = "放缩";
            // 
            // trackBar_heng_fangsuo
            // 
            this.trackBar_heng_fangsuo.Location = new System.Drawing.Point(191, 282);
            this.trackBar_heng_fangsuo.Maximum = 1000;
            this.trackBar_heng_fangsuo.Minimum = 10;
            this.trackBar_heng_fangsuo.Name = "trackBar_heng_fangsuo";
            this.trackBar_heng_fangsuo.Size = new System.Drawing.Size(335, 45);
            this.trackBar_heng_fangsuo.TabIndex = 9;
            this.trackBar_heng_fangsuo.Value = 1000;
            this.trackBar_heng_fangsuo.ValueChanged += new System.EventHandler(this.trackBar_heng_fangsuo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // mychart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar_heng_fangsuo);
            this.Controls.Add(this.label_heng_fangsuo);
            this.Controls.Add(this.trackBar_heng_yidong);
            this.Controls.Add(this.label_heng_yidong);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar_shu_fangsuo);
            this.Controls.Add(this.label_shu_fangsuo);
            this.Controls.Add(this.trackBar_shu_yidong);
            this.Controls.Add(this.label_yidong);
            this.Controls.Add(this.chart1);
            this.Name = "mychart";
            this.Size = new System.Drawing.Size(727, 317);
            this.Load += new System.EventHandler(this.mychart_Load);
            this.Resize += new System.EventHandler(this.mychart_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_shu_yidong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_shu_fangsuo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_heng_yidong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_heng_fangsuo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       public  System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label_yidong;
        private System.Windows.Forms.TrackBar trackBar_shu_yidong;
        private System.Windows.Forms.Label label_shu_fangsuo;
        private System.Windows.Forms.TrackBar trackBar_shu_fangsuo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_heng_yidong;
        private System.Windows.Forms.TrackBar trackBar_heng_yidong;
        private System.Windows.Forms.Label label_heng_fangsuo;
        private System.Windows.Forms.TrackBar trackBar_heng_fangsuo;
        private System.Windows.Forms.Label label1;
    }
}
