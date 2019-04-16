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
    public partial class MyLabel : UserControl
    {
        public string MyName = "";
        public string UpName = "";                               // 更新后的名称
        public string ViewName = "";
        public string Type = "";                                 // 名称的种类

        // 数据标签的属性
        public string DataType = "";
        public string Machine_num = "";
        public string Offsite = "";
        public string ValueAddress = "";

        public MyLabel(string type)
        {
            InitializeComponent();
            Type = type;
            Resize_Points();                                  // 重定义用来拉伸的点


            // 不同的情况有不同的鼠标标志
            if (MainView.Is_Edit == false) { label1.Cursor = Cursors.Arrow; label1.ContextMenuStrip = null; }
            if (MainView.Is_Edit == true) { label1.Cursor = Cursors.SizeAll; }
        }

        private Label Selected_Lable = null;                 // 被拖动的标签

        private void Resize_Points()
        {

            label1.Width = this.Width - 10;
            label1.Height = this.Height - 10;

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


            label1.Left = 5;
            label1.Top = 5;

            up.Visible = false;
            down.Visible = false;
            left.Visible = false;
            right.Visible = false;
            rightup.Visible = false;
            rightdown.Visible = false;
            leftup.Visible = false;
            leftdown.Visible = false;
           
        }

        private void MyLabel_Enter(object sender, EventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            up.Visible = true;
            down.Visible = true;
            left.Visible = true;
            right.Visible = true;
            rightup.Visible = true;
            rightdown.Visible = true;
            leftup.Visible = true;
            leftdown.Visible = true;

        }

        private void MyLabel_Leave(object sender, EventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            up.Visible = false;
            down.Visible = false;
            left.Visible = false;
            right.Visible = false;
            rightup.Visible = false;
            rightdown.Visible = false;
            leftup.Visible = false;
            leftdown.Visible = false;
        }

        private void label1_Enter(object sender, EventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            up.Visible = true;
            down.Visible = true;
            left.Visible = true;
            right.Visible = true;
            rightup.Visible = true;
            rightdown.Visible = true;
            leftup.Visible = true;
            leftdown.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            up.Visible = true;
            down.Visible = true;
            left.Visible = true;
            right.Visible = true;
            rightup.Visible = true;
            rightdown.Visible = true;
            leftup.Visible = true;
            leftdown.Visible = true;
        }

        private void rightdown_Click(object sender, EventArgs e)
        {

        }

        private void right_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if(e.Button==MouseButtons.Left)
               Selected_Lable = right;
        }

        private void rightup_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = rightup;
        }

        private void rightdown_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = rightdown;
        }

        private void up_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = up;
        }

        private void down_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = down;
        }

        private void leftup_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = leftup;
        }

        private void left_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = left;
        }

        private void leftdown_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = leftdown;
        }

        private void left_Click(object sender, EventArgs e)
        {

        }

        private void rightdown_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Label();
        }

        private void down_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Label();
        }

        private void left_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Label();
        }

        private void leftup_Click(object sender, EventArgs e)
        {

        }

        private void leftup_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Label();
        }

        private void up_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Label();
        }

        private void rightup_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Label();
        }

        private void right_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Label();
        }

        private void leftdown_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Label();
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
                        Selected_Lable.Left = Selected_Lable.Left+e.X;
                        this.Width = this.Width+e.X;
                    }
                }
            }

        }

        private void MyLabel_Resize(object sender, EventArgs e)
        {
            Resize_Points();
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

        private void rightup_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if(e.Button==MouseButtons.Left)
            {
                if(Selected_Lable!=null)
                {
                    if(Selected_Lable.Name=="rightup")
                    {
                        Selected_Lable.Left = Selected_Lable.Left + e.X;
                        this.Width = this.Width + e.X;
                        this.Top=this.Top + e.Y;
                        this.Height = this.Height - e.Y;
                        //Console.Write(e.Y);
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

        private void up_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if(e.Button==MouseButtons.Left)
            {
                if(Selected_Lable!=null)
                {
                    if(Selected_Lable.Name=="up")
                    {
                        this.Top = this.Top + e.Y;
                        this.Height = this.Height - e.Y;
                    }
                }
            }
        }

        private void down_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if(e.Button==MouseButtons.Left)
            {
                if(Selected_Lable!=null)
                {
                    if(Selected_Lable.Name=="down")
                    {
                        Selected_Lable.Top = Selected_Lable.Top + e.Y;
                        this.Height = this.Height + e.Y;
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
                    if(Selected_Lable.Name=="leftup")
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

        private void leftdown_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if(Selected_Lable.Name=="leftdown")
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

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = label1;                     //
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Label();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if(Selected_Lable.Name=="label1")
                    {
                        this.Left = this.Left + e.X - this.Width / 2;
                        this.Top = this.Top + e.Y - this.Height / 2;
                    }
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (Type == "Normal")
            {
                Delete_Is view = new Delete_Is();
                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string where2 = "labelname='" + MyName + "'";
                    string where1 = "member='" + MyName + "'";
                    MainView.Main_DataBase_Builder.Delete(ViewName, where1);
                    MainView.Main_DataBase_Builder.Delete("Alllabel", where2);
                    this.Dispose();
                }
            }
            if (Type == "Value")
            {
                Delete_Is view = new Delete_Is();
                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string where2 = "labelname='" + MyName + "'";
                    string where1 = "member='" + MyName + "'";
                    MainView.Main_DataBase_Builder.Delete(ViewName, where1);
                    MainView.Main_DataBase_Builder.Delete("AllValuelabel", where2);
                    this.Dispose();
                }
            }
        }

        private void 属性ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 普通标签 
            if (MainView.Is_Edit == false) return;
            #region
            if (Type == "Normal")
            {
                NormalLabelConfig.Label_Name = MyName;
                NormalLabelConfig.Label_Txt = label1.Text;
                NormalLabelConfig.Label_Left = this.Left;
                NormalLabelConfig.Label_Top = this.Top;
                NormalLabelConfig.Label_Width = this.Width;
                NormalLabelConfig.Label_Height = this.Height;
                NormalLabelConfig.BackColor = label1.BackColor.Name.ToString();
                NormalLabelConfig.MyFont = label1.Font.FontFamily.ToString();
                NormalLabelConfig.MyFontSize = (int)(label1.Font.Size);
                NormalLabelConfig.FontColor = label1.ForeColor.Name.ToString();
                NormalLabelConfig view = new NormalLabelConfig("Normal");
                view.Set_Normal();


                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    UpName = NormalLabelConfig.Label_Name;
                    label1.Text = NormalLabelConfig.Label_Txt;
                    ViewName = MainView.Selected_View_Name;
                    this.Left = NormalLabelConfig.Label_Left;
                    this.Top = NormalLabelConfig.Label_Top;
                    this.Width = NormalLabelConfig.Label_Width;
                    this.Height = NormalLabelConfig.Label_Height;
                    label1.BackColor = System.Drawing.Color.FromName(NormalLabelConfig.BackColor);
                    label1.Font = new Font(Font.FontFamily, NormalLabelConfig.MyFontSize, FontStyle.Regular);
                    label1.ForeColor = System.Drawing.Color.FromName(NormalLabelConfig.FontColor);

                    /// 插入或者更新
                    /// 如果插入失败就更新，如果更新失败
                    /// 
                    if (MyName == "")
                    {
                        string[] insert_cmd = new string[10];
                        insert_cmd[0] = UpName;
                        insert_cmd[1] = label1.Text;
                        insert_cmd[2] = this.Left.ToString();
                        insert_cmd[3] = this.Top.ToString();
                        insert_cmd[4] = this.Width.ToString();
                        insert_cmd[5] = this.Height.ToString();
                        insert_cmd[6] = label1.BackColor.Name;
                        insert_cmd[7] = "";
                        insert_cmd[8] = label1.Font.Size.ToString();
                        insert_cmd[9] = label1.ForeColor.Name;

                        bool insert_success = MainView.Main_DataBase_Builder.Insert("Alllabel", insert_cmd);
                        if (insert_success == true)
                        {
                            // 已经插进去了
                            string[] sub_insert_cmd = new string[2];
                            sub_insert_cmd[0] = UpName;
                            sub_insert_cmd[1] = "NormalLabel";
                            MyName = UpName;
                            bool sub_insert_success = MainView.Main_DataBase_Builder.Insert(MainView.Selected_View_Name, sub_insert_cmd);

                        }
                        else
                        {
                            MessageBox.Show("创建标签失败，查看名称是否重复！");
                        }
                    }

                    if (MyName != "")
                    {
                        string[] update_cmd = new string[10];
                        update_cmd[0] = "labelname='" + UpName + "'";
                        update_cmd[1] = "txt='" + label1.Text + "'";
                        update_cmd[2] = "labelLeft='" + this.Left.ToString() + "'";
                        update_cmd[3] = "labelTop='" + this.Top.ToString() + "'";
                        update_cmd[4] = "Width='" + this.Width.ToString() + "'";
                        update_cmd[5] = "Height='" + this.Height.ToString() + "'";
                        update_cmd[6] = "BackGroundColor='" + label1.BackColor.Name + "'";
                        update_cmd[7] = "Font=''";
                        update_cmd[8] = "FontSize='" + label1.Font.Size.ToString() + "'";
                        update_cmd[9] = "FontColor='" + label1.ForeColor.Name + "'";

                        string where_cmd = "labelname='" + MyName + "'";
                        MainView.Main_DataBase_Builder.Updata("Alllabel", where_cmd, update_cmd);

                        string[] update_cmd1 = new string[1];
                        update_cmd1[0] = "member='" + UpName + "'";
                        string where_cmd1 = "member='" + MyName + "'";
                        MainView.Main_DataBase_Builder.Updata(MainView.Selected_View_Name, where_cmd1, update_cmd1);
                        MyName = UpName;
                    }
                }
            }
            #endregion                   

            // 数据标签
            #region
            if (Type == "Value")
            {
                NormalLabelConfig.Label_Name = MyName;
                NormalLabelConfig.Label_Txt = label1.Text;
                NormalLabelConfig.Label_Left = this.Left;
                NormalLabelConfig.Label_Top = this.Top;
                NormalLabelConfig.Label_Width = this.Width;
                NormalLabelConfig.Label_Height = this.Height;
                NormalLabelConfig.BackColor = label1.BackColor.Name.ToString();
                NormalLabelConfig.MyFont = label1.Font.FontFamily.ToString();
                NormalLabelConfig.MyFontSize = (int)(label1.Font.Size);
                NormalLabelConfig.FontColor = label1.ForeColor.Name.ToString();
                NormalLabelConfig.DataType = DataType;
                NormalLabelConfig.Machine_num = Machine_num;
                NormalLabelConfig.offsite = Offsite;
                NormalLabelConfig.ValueAddress = ValueAddress;
                NormalLabelConfig view = new NormalLabelConfig("ValueLabel");
                


                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    UpName = NormalLabelConfig.Label_Name;
                    label1.Text = NormalLabelConfig.Label_Txt;
                    ViewName = MainView.Selected_View_Name;
                    this.Left = NormalLabelConfig.Label_Left;
                    this.Top = NormalLabelConfig.Label_Top;
                    this.Width = NormalLabelConfig.Label_Width;
                    this.Height = NormalLabelConfig.Label_Height;
                    label1.BackColor = System.Drawing.Color.FromName(NormalLabelConfig.BackColor);
                    label1.Font = new Font(Font.FontFamily, NormalLabelConfig.MyFontSize, FontStyle.Regular);
                    label1.ForeColor = System.Drawing.Color.FromName(NormalLabelConfig.FontColor);

                    /// 插入或者更新
                    /// 如果插入失败就更新，如果更新失败
                    /// 
                    if (MyName == "")
                    {
                        string[] insert_cmd = new string[14];
                        insert_cmd[0] = UpName;
                        insert_cmd[1] = label1.Text;
                        insert_cmd[2] = this.Left.ToString();
                        insert_cmd[3] = this.Top.ToString();
                        insert_cmd[4] = this.Width.ToString();
                        insert_cmd[5] = this.Height.ToString();
                        insert_cmd[6] = label1.BackColor.Name;
                        insert_cmd[7] = "";
                        insert_cmd[8] = label1.Font.Size.ToString();
                        insert_cmd[9] = label1.ForeColor.Name;
                        insert_cmd[10] = NormalControls.NormalLabelConfig.DataType;
                        insert_cmd[11] = NormalControls.NormalLabelConfig.Machine_num;
                        insert_cmd[12] = NormalControls.NormalLabelConfig.offsite;
                        insert_cmd[13] = NormalControls.NormalLabelConfig.ValueAddress;


                        bool insert_success = MainView.Main_DataBase_Builder.Insert("AllValuelabel", insert_cmd);
                        if (insert_success == true)
                        {
                            // 已经插进去了
                            string[] sub_insert_cmd = new string[2];
                            sub_insert_cmd[0] = UpName;
                            sub_insert_cmd[1] = "ValueLabel";
                            MyName = UpName;
                            bool sub_insert_success = MainView.Main_DataBase_Builder.Insert(MainView.Selected_View_Name, sub_insert_cmd);

                        }
                        else
                        {
                            MessageBox.Show("创建标签失败，查看名称是否重复！");
                        }
                    }

                    if (MyName != "")
                    {
                        string[] update_cmd = new string[14];
                        update_cmd[0] = "labelname='" + UpName + "'";
                        update_cmd[1] = "txt='" + label1.Text + "'";
                        update_cmd[2] = "labelLeft='" + this.Left.ToString() + "'";
                        update_cmd[3] = "labelTop='" + this.Top.ToString() + "'";
                        update_cmd[4] = "Width='" + this.Width.ToString() + "'";
                        update_cmd[5] = "Height='" + this.Height.ToString() + "'";
                        update_cmd[6] = "BackGroundColor='" + label1.BackColor.Name + "'";
                        update_cmd[7] = "Font=''";
                        update_cmd[8] = "FontSize='" + label1.Font.Size.ToString() + "'";
                        update_cmd[9] = "FontColor='" + label1.ForeColor.Name + "'";
                        update_cmd[10] = "DateType='" + NormalControls.NormalLabelConfig.DataType + "'";
                        update_cmd[11] = "Machine_Num='" + NormalControls.NormalLabelConfig.Machine_num + "'";
                        update_cmd[12] = "offsite='" + NormalControls.NormalLabelConfig.offsite + "'";
                        update_cmd[13] = "ValueAddress='" + NormalControls.NormalLabelConfig.ValueAddress + "'";

                        string where_cmd = "labelname='" + MyName + "'";
                        MainView.Main_DataBase_Builder.Updata("AllValuelabel", where_cmd, update_cmd);

                        // 修改本界面上的值
                        string[] update_cmd1 = new string[1];
                        update_cmd1[0] = "member='" + UpName + "'";
                        string where_cmd1 = "member='" + MyName + "'";
                        MainView.Main_DataBase_Builder.Updata(MainView.Selected_View_Name, where_cmd1, update_cmd1);

                        MyName = UpName;
                    }
                }
            }
            #endregion
        }

        public void Set_Text(string txt)
        {
            // 设定文字内容
            label1.Text = txt;
        }


        public void Set_BackColor(string color)
        {
            label1.BackColor = System.Drawing.Color.FromName(color);
        }

        public void Set_ForeColor(string color)
        {
            label1.ForeColor = System.Drawing.Color.FromName(color);
        }

        public void Set_FontSize(int size)
        {
            label1.Font = new Font(Font.FontFamily, size, FontStyle.Regular);
        }


        public void Update_My_Label()
        {
            string[] update_cmd = new string[10];
            update_cmd[0] = "labelname='" + MyName + "'";
            update_cmd[1] = "txt='" + label1.Text + "'";
            update_cmd[2] = "labelLeft='" + this.Left.ToString() + "'";
            update_cmd[3] = "labelTop='" + this.Top.ToString() + "'";
            update_cmd[4] = "Width='" + this.Width.ToString() + "'";
            update_cmd[5] = "Height='" + this.Height.ToString() + "'";
            update_cmd[6] = "BackGroundColor='" + label1.BackColor.Name + "'";
            update_cmd[7] = "Font=''";
            update_cmd[8] = "FontSize='" + label1.Font.Size.ToString() + "'";
            update_cmd[9] = "FontColor='" + label1.ForeColor.Name + "'";

            string where_cmd = "labelname='" + MyName + "'";
            MainView.Main_DataBase_Builder.Updata("Alllabel", where_cmd, update_cmd);
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditWindow.CanPaste = true;
            EditWindow.CopyObject_Name = MyName;
            EditWindow.CopyType = Type;
        }

        private void label1_FontChanged(object sender, EventArgs e)
        {

        }

        private void MyLabel_Load(object sender, EventArgs e)
        {

        }
        
    }
}
