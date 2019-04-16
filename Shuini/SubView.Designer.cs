namespace Shuini
{
    partial class SubView
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label_machine_name = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_communicate = new System.Windows.Forms.Label();
            this.label_chuanganqi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前温度";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSalmon;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(106, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "00℃";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MistyRose;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "当前执行";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.MistyRose;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(106, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "升温";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Snow;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(3, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 35);
            this.label5.TabIndex = 4;
            this.label5.Text = "计时";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Snow;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(106, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 35);
            this.label6.TabIndex = 5;
            this.label6.Text = "00:00:00";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(283, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 28);
            this.button3.TabIndex = 8;
            this.button3.Text = "趋势";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label_machine_name
            // 
            this.label_machine_name.BackColor = System.Drawing.Color.Blue;
            this.label_machine_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_machine_name.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_machine_name.ForeColor = System.Drawing.Color.White;
            this.label_machine_name.Location = new System.Drawing.Point(3, 0);
            this.label_machine_name.Name = "label_machine_name";
            this.label_machine_name.Size = new System.Drawing.Size(108, 33);
            this.label_machine_name.TabIndex = 9;
            this.label_machine_name.Text = "000";
            this.label_machine_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_machine_name.DoubleClick += new System.EventHandler(this.label7_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_communicate
            // 
            this.label_communicate.AutoSize = true;
            this.label_communicate.BackColor = System.Drawing.Color.Yellow;
            this.label_communicate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_communicate.Location = new System.Drawing.Point(223, 47);
            this.label_communicate.Name = "label_communicate";
            this.label_communicate.Size = new System.Drawing.Size(67, 14);
            this.label_communicate.TabIndex = 10;
            this.label_communicate.Text = "通讯状态：";
            // 
            // label_chuanganqi
            // 
            this.label_chuanganqi.AutoSize = true;
            this.label_chuanganqi.BackColor = System.Drawing.Color.Yellow;
            this.label_chuanganqi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_chuanganqi.Location = new System.Drawing.Point(223, 76);
            this.label_chuanganqi.Name = "label_chuanganqi";
            this.label_chuanganqi.Size = new System.Drawing.Size(79, 14);
            this.label_chuanganqi.TabIndex = 11;
            this.label_chuanganqi.Text = "传感器状态：";
            // 
            // SubView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_chuanganqi);
            this.Controls.Add(this.label_communicate);
            this.Controls.Add(this.label_machine_name);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SubView";
            this.Size = new System.Drawing.Size(352, 185);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label_machine_name;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_communicate;
        private System.Windows.Forms.Label label_chuanganqi;
    }
}
