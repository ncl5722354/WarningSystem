namespace MyShape
{
    partial class Line
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
            this.point1 = new System.Windows.Forms.Label();
            this.point2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // point1
            // 
            this.point1.BackColor = System.Drawing.Color.Blue;
            this.point1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.point1.Location = new System.Drawing.Point(3, 11);
            this.point1.Name = "point1";
            this.point1.Size = new System.Drawing.Size(7, 7);
            this.point1.TabIndex = 0;
            this.point1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.point1_MouseClick);
            this.point1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.point1_MouseDown);
            this.point1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.point1_MouseMove);
            this.point1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.point1_MouseUp);
            // 
            // point2
            // 
            this.point2.BackColor = System.Drawing.Color.Blue;
            this.point2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.point2.Location = new System.Drawing.Point(112, 103);
            this.point2.Name = "point2";
            this.point2.Size = new System.Drawing.Size(7, 7);
            this.point2.TabIndex = 1;
            this.point2.Click += new System.EventHandler(this.point2_Click);
            this.point2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.point2_MouseDown);
            this.point2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.point2_MouseMove);
            this.point2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.point2_MouseUp);
            // 
            // Line
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.point2);
            this.Controls.Add(this.point1);
            this.Size = new System.Drawing.Size(134, 120);
            this.Resize += new System.EventHandler(this.Line_Resize);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label point1;
        private System.Windows.Forms.Label point2;

    }
}
