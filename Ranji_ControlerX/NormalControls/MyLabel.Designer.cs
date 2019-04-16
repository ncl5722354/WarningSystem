namespace Ranji_ControlerX.NormalControls
{
    partial class MyLabel
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.up = new System.Windows.Forms.Label();
            this.down = new System.Windows.Forms.Label();
            this.leftup = new System.Windows.Forms.Label();
            this.left = new System.Windows.Forms.Label();
            this.leftdown = new System.Windows.Forms.Label();
            this.rightup = new System.Windows.Forms.Label();
            this.right = new System.Windows.Forms.Label();
            this.rightdown = new System.Windows.Forms.Label();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ContextMenuStrip = this.contextMenuStrip1;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(94, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.FontChanged += new System.EventHandler(this.label1_FontChanged);
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.Enter += new System.EventHandler(this.label1_Enter);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.属性ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.属性ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 属性ToolStripMenuItem
            // 
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.属性ToolStripMenuItem.Text = "删除";
            this.属性ToolStripMenuItem.Click += new System.EventHandler(this.属性ToolStripMenuItem_Click);
            // 
            // 属性ToolStripMenuItem1
            // 
            this.属性ToolStripMenuItem1.Name = "属性ToolStripMenuItem1";
            this.属性ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.属性ToolStripMenuItem1.Text = "属性";
            this.属性ToolStripMenuItem1.Click += new System.EventHandler(this.属性ToolStripMenuItem1_Click);
            // 
            // up
            // 
            this.up.BackColor = System.Drawing.Color.Blue;
            this.up.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.up.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.up.Location = new System.Drawing.Point(146, 9);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(7, 7);
            this.up.TabIndex = 1;
            this.up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.up_MouseDown);
            this.up.MouseMove += new System.Windows.Forms.MouseEventHandler(this.up_MouseMove);
            this.up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up_MouseUp);
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.Color.Blue;
            this.down.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.down.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.down.Location = new System.Drawing.Point(146, 92);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(7, 7);
            this.down.TabIndex = 2;
            this.down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down_MouseDown);
            this.down.MouseMove += new System.Windows.Forms.MouseEventHandler(this.down_MouseMove);
            this.down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.down_MouseUp);
            // 
            // leftup
            // 
            this.leftup.BackColor = System.Drawing.Color.Blue;
            this.leftup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftup.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.leftup.Location = new System.Drawing.Point(3, 9);
            this.leftup.Name = "leftup";
            this.leftup.Size = new System.Drawing.Size(7, 7);
            this.leftup.TabIndex = 3;
            this.leftup.Click += new System.EventHandler(this.leftup_Click);
            this.leftup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftup_MouseDown);
            this.leftup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftup_MouseMove);
            this.leftup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.leftup_MouseUp);
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.Blue;
            this.left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.left.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.left.Location = new System.Drawing.Point(3, 54);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(7, 7);
            this.left.TabIndex = 4;
            this.left.Click += new System.EventHandler(this.left_Click);
            this.left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.left_MouseDown);
            this.left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.left_MouseMove);
            this.left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.left_MouseUp);
            // 
            // leftdown
            // 
            this.leftdown.BackColor = System.Drawing.Color.Blue;
            this.leftdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftdown.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.leftdown.Location = new System.Drawing.Point(3, 92);
            this.leftdown.Name = "leftdown";
            this.leftdown.Size = new System.Drawing.Size(7, 7);
            this.leftdown.TabIndex = 5;
            this.leftdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftdown_MouseDown);
            this.leftdown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftdown_MouseMove);
            this.leftdown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.leftdown_MouseUp);
            // 
            // rightup
            // 
            this.rightup.BackColor = System.Drawing.Color.Blue;
            this.rightup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightup.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.rightup.Location = new System.Drawing.Point(282, 9);
            this.rightup.Name = "rightup";
            this.rightup.Size = new System.Drawing.Size(7, 7);
            this.rightup.TabIndex = 6;
            this.rightup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightup_MouseDown);
            this.rightup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightup_MouseMove);
            this.rightup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightup_MouseUp);
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.Blue;
            this.right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.right.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.right.Location = new System.Drawing.Point(282, 54);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(7, 7);
            this.right.TabIndex = 7;
            this.right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.right_MouseDown);
            this.right.MouseMove += new System.Windows.Forms.MouseEventHandler(this.right_MouseMove);
            this.right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.right_MouseUp);
            // 
            // rightdown
            // 
            this.rightdown.BackColor = System.Drawing.Color.Blue;
            this.rightdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightdown.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.rightdown.Location = new System.Drawing.Point(282, 92);
            this.rightdown.Name = "rightdown";
            this.rightdown.Size = new System.Drawing.Size(7, 7);
            this.rightdown.TabIndex = 8;
            this.rightdown.Click += new System.EventHandler(this.rightdown_Click);
            this.rightdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightdown_MouseDown);
            this.rightdown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightdown_MouseMove);
            this.rightdown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightdown_MouseUp);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // MyLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rightdown);
            this.Controls.Add(this.right);
            this.Controls.Add(this.rightup);
            this.Controls.Add(this.leftdown);
            this.Controls.Add(this.left);
            this.Controls.Add(this.leftup);
            this.Controls.Add(this.down);
            this.Controls.Add(this.up);
            this.Controls.Add(this.label1);
            this.Name = "MyLabel";
            this.Size = new System.Drawing.Size(303, 112);
            this.Load += new System.EventHandler(this.MyLabel_Load);
            this.Enter += new System.EventHandler(this.MyLabel_Enter);
            this.Leave += new System.EventHandler(this.MyLabel_Leave);
            this.Resize += new System.EventHandler(this.MyLabel_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label up;
        private System.Windows.Forms.Label down;
        private System.Windows.Forms.Label leftup;
        private System.Windows.Forms.Label left;
        private System.Windows.Forms.Label leftdown;
        private System.Windows.Forms.Label rightup;
        private System.Windows.Forms.Label right;
        private System.Windows.Forms.Label rightdown;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
    }
}
