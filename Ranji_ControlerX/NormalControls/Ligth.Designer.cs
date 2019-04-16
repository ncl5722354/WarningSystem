namespace Ranji_ControlerX.NormalControls
{
    partial class Ligth
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
            this.up = new System.Windows.Forms.Label();
            this.leftup = new System.Windows.Forms.Label();
            this.rightup = new System.Windows.Forms.Label();
            this.right = new System.Windows.Forms.Label();
            this.rightdown = new System.Windows.Forms.Label();
            this.down = new System.Windows.Forms.Label();
            this.leftdown = new System.Windows.Forms.Label();
            this.left = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // up
            // 
            this.up.BackColor = System.Drawing.Color.Blue;
            this.up.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.up.Location = new System.Drawing.Point(201, 13);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(7, 7);
            this.up.TabIndex = 0;
            this.up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.up_MouseDown);
            this.up.MouseMove += new System.Windows.Forms.MouseEventHandler(this.up_MouseMove);
            this.up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up_MouseUp);
            // 
            // leftup
            // 
            this.leftup.BackColor = System.Drawing.Color.Blue;
            this.leftup.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.leftup.Location = new System.Drawing.Point(18, 13);
            this.leftup.Name = "leftup";
            this.leftup.Size = new System.Drawing.Size(7, 7);
            this.leftup.TabIndex = 1;
            this.leftup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftup_MouseDown);
            this.leftup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftup_MouseMove);
            this.leftup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.leftup_MouseUp);
            // 
            // rightup
            // 
            this.rightup.BackColor = System.Drawing.Color.Blue;
            this.rightup.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.rightup.Location = new System.Drawing.Point(421, 13);
            this.rightup.Name = "rightup";
            this.rightup.Size = new System.Drawing.Size(7, 7);
            this.rightup.TabIndex = 2;
            this.rightup.Click += new System.EventHandler(this.rightup_Click);
            this.rightup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightup_MouseDown);
            this.rightup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightup_MouseMove);
            this.rightup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightup_MouseUp);
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.Blue;
            this.right.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.right.Location = new System.Drawing.Point(421, 104);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(7, 7);
            this.right.TabIndex = 3;
            this.right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.right_MouseDown);
            this.right.MouseMove += new System.Windows.Forms.MouseEventHandler(this.right_MouseMove);
            this.right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.right_MouseUp);
            // 
            // rightdown
            // 
            this.rightdown.BackColor = System.Drawing.Color.Blue;
            this.rightdown.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.rightdown.Location = new System.Drawing.Point(421, 200);
            this.rightdown.Name = "rightdown";
            this.rightdown.Size = new System.Drawing.Size(7, 7);
            this.rightdown.TabIndex = 4;
            this.rightdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightdown_MouseDown);
            this.rightdown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightdown_MouseMove);
            this.rightdown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightdown_MouseUp);
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.Color.Blue;
            this.down.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.down.Location = new System.Drawing.Point(201, 200);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(7, 7);
            this.down.TabIndex = 5;
            this.down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down_MouseDown);
            this.down.MouseMove += new System.Windows.Forms.MouseEventHandler(this.down_MouseMove);
            this.down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.down_MouseUp);
            // 
            // leftdown
            // 
            this.leftdown.BackColor = System.Drawing.Color.Blue;
            this.leftdown.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.leftdown.Location = new System.Drawing.Point(18, 200);
            this.leftdown.Name = "leftdown";
            this.leftdown.Size = new System.Drawing.Size(7, 7);
            this.leftdown.TabIndex = 6;
            this.leftdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftdown_MouseDown);
            this.leftdown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftdown_MouseMove);
            this.leftdown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.leftdown_MouseUp);
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.Blue;
            this.left.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.left.Location = new System.Drawing.Point(18, 104);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(7, 7);
            this.left.TabIndex = 7;
            this.left.Click += new System.EventHandler(this.left_Click);
            this.left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.left_MouseDown);
            this.left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.left_MouseMove);
            this.left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.left_MouseUp);
            // 
            // Ligth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.left);
            this.Controls.Add(this.leftdown);
            this.Controls.Add(this.down);
            this.Controls.Add(this.rightdown);
            this.Controls.Add(this.right);
            this.Controls.Add(this.rightup);
            this.Controls.Add(this.leftup);
            this.Controls.Add(this.up);
            this.Name = "Ligth";
            this.Size = new System.Drawing.Size(445, 214);
            this.Resize += new System.EventHandler(this.Ligth_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label up;
        private System.Windows.Forms.Label leftup;
        private System.Windows.Forms.Label rightup;
        private System.Windows.Forms.Label right;
        private System.Windows.Forms.Label rightdown;
        private System.Windows.Forms.Label down;
        private System.Windows.Forms.Label leftdown;
        private System.Windows.Forms.Label left;
    }
}
