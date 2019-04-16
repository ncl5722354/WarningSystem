using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranji_ControlerX.NormalControls
{
    public partial class Ligth : UserControl
    {
        private Label Selected_Lable = null;                 // 被拖动的标签
        public Ligth()
        {
            InitializeComponent();
            if (MainView.Is_Edit == false) { this.Cursor = Cursors.Arrow; this.ContextMenuStrip = null; }
            if (MainView.Is_Edit == true) { this.Cursor = Cursors.SizeAll; }
            Resize_Points();
        }

        private void Resize_Points()
        {
            up.Top = 0;
            up.Left = this.Width / 2 - up.Width / 2;

            down.Top = this.Height - down.Height;
            down.Left = this.Width / 2 - down.Width / 2;

            left.Left = 0;
            left.Top = this.Height / 2 - down.Height / 2;

            right.Left = this.Width - right.Width;
            right.Top = this.Height / 2 - right.Height / 2;

            leftup.Left = 0;
            leftup.Top = 0;

            rightup.Top = 0;
            rightup.Left = this.Width - rightup.Width;

            leftdown.Top = this.Height - down.Height;
            leftdown.Left = 0;

            rightdown.Top = this.Height - rightdown.Height;
            rightdown.Left = this.Width - rightdown.Width;

            up.Visible = false;
            down.Visible = false;
            left.Visible = false;
            right.Visible = false;
            rightup.Visible = false;
            rightdown.Visible = false;
            leftup.Visible = false;
            leftdown.Visible = false;

        }

        private void Ligth_Resize(object sender, EventArgs e)
        {
            Resize_Points();
        }

        private void right_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = right;
        }

        private void rightdown_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = rightdown;
        }

        private void down_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = down;
        }

        private void leftdown_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = leftdown;
        }

        private void left_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = left;
        }

        private void left_Click(object sender, EventArgs e)
        {

        }

        private void leftup_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = leftup;
        }

        private void up_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = up;
        }

        private void rightup_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = rightup;
        }

        private void rightup_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if (Selected_Lable.Name == "rightup")
                    {
                        Selected_Lable.Left = Selected_Lable.Left + e.X;
                        this.Width = this.Width + e.X;
                        this.Top = this.Top + e.Y;
                        this.Height = this.Height - e.Y;
                        
                    }
                }
            }
        }

        private void right_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if (Selected_Lable.Name == "right")
                    {
                        Selected_Lable.Left = Selected_Lable.Left + e.X;
                        this.Width = this.Width + e.X;
                    }
                }
            }
        }

        private void rightdown_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if (Selected_Lable.Name == "rightdown")
                    {
                        Selected_Lable.Left = Selected_Lable.Left + e.X;
                        this.Width = this.Width + e.X;
                        Selected_Lable.Top = Selected_Lable.Top + e.Y;
                        this.Height = this.Height + e.Y;
                    }
                }
            }
        }

        private void down_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if (Selected_Lable.Name == "down")
                    {
                        Selected_Lable.Top = Selected_Lable.Top + e.Y;
                        this.Height = this.Height + e.Y;
                    }
                }
            }
        }

        private void leftdown_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if (Selected_Lable.Name == "leftdown")
                    {
                        Selected_Lable.Left = Selected_Lable.Left + e.X;
                        this.Width = this.Width - e.X;
                        this.Left = this.Left + e.X;
                        Selected_Lable.Top = Selected_Lable.Top + e.Y;
                        this.Height = this.Height + e.Y;
                    }
                }
            }
        }

        private void left_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if (Selected_Lable.Name == "left")
                    {
                        Selected_Lable.Left = Selected_Lable.Left + e.X;
                        this.Width = this.Width - e.X;
                        this.Left = this.Left + e.X;
                        //Console.Write(e.X);
                    }
                }
            }
        }

        private void leftup_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if (Selected_Lable.Name == "leftup")
                    {
                        Selected_Lable.Left = Selected_Lable.Left + e.X;
                        this.Width = this.Width - e.X;
                        this.Left = this.Left + e.X;
                        this.Top = this.Top + e.Y;
                        this.Height = this.Height - e.Y;
                    }
                }
            }
        }

        private void up_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if (Selected_Lable.Name == "up")
                    {
                        this.Top = this.Top + e.Y;
                        this.Height = this.Height - e.Y;
                    }
                }
            }
        }

        private void up_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Ligth();
        }

        public void Update_My_Ligth()
        {
        }

        private void rightup_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Ligth();
        }

        private void right_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Ligth();
        }

        private void rightdown_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Ligth();
        }

        private void down_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Ligth();
        }

        private void leftdown_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Ligth();
        }

        private void left_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Ligth();
        }

        private void leftup_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Ligth();
        }

        private void rightup_Click(object sender, EventArgs e)
        {

        }
    }
}
