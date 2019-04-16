using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlConnect;

namespace Ranji_ControlerX.NormalControls
{
    public partial class MyButton : UserControl
    {
        public string MyName = "";
        public string UpName = "";                               // 更新后的名称
        public string ViewName = "";

        private Label Selected_Lable = null;                 // 被拖动的标签

        public event EventHandler Button_Press;

        public MyButton()
        {
            InitializeComponent();
            if (MainView.Is_Edit == false) { button1.Cursor = Cursors.Arrow; button1.ContextMenuStrip = null; }
            if (MainView.Is_Edit == true) { button1.Cursor = Cursors.SizeAll; }
            Resize_Points();
        }

        private void Resize_Points()
        {

            button1.Width = this.Width - 10;
            button1.Height = this.Height - 10;

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


            button1.Left = 5;
            button1.Top = 5;

            up.Visible = false;
            down.Visible = false;
            left.Visible = false;
            right.Visible = false;
            rightup.Visible = false;
            rightdown.Visible = false;
            leftup.Visible = false;
            leftdown.Visible = false;

        }

        private void MyButton_Resize(object sender, EventArgs e)
        {
            Resize_Points();
        }

        private void rightdown_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = rightdown;
        }

        private void right_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = right;
        }

        private void rightup_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = rightup;
        }

        private void up_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = up;
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

        private void down_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
                Selected_Lable = down;
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
                        //Console.Write(e.Y);
                    }
                }
            }
        }

        private void right_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Button();
        }

        public void Update_My_Button()
        {
            // 更新按钮信息
            string[] update_cmd = new string[10];
            update_cmd[0] = "buttonname='" + MyName + "'";
            update_cmd[1] = "txt='" + button1.Text + "'";
            update_cmd[2] = "buttonLeft='" + this.Left.ToString() + "'";
            update_cmd[3] = "buttonTop='" + this.Top.ToString() + "'";
            update_cmd[4] = "Width='" + this.Width.ToString() + "'";
            update_cmd[5] = "Height='" + this.Height.ToString() + "'";
            update_cmd[6] = "BackGroundColor='" + button1.BackColor.Name + "'";
            update_cmd[7] = "Font=''";
            update_cmd[8] = "FontSize='" + button1.Font.Size.ToString() + "'";
            update_cmd[9] = "FontColor='" + button1.ForeColor.Name + "'";

            string where_cmd = "buttonname='" + MyName + "'";
            MainView.Main_DataBase_Builder.Updata("AllButton", where_cmd, update_cmd);
        }

        private void rightdown_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Button();
        }

        private void down_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Button();
        }

        private void leftdown_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Button();
        }

        private void left_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Button();
        }

        private void leftup_Move(object sender, EventArgs e)
        {

        }

        private void leftup_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Button();
        }

        private void up_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Button();
        }

        private void rightup_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Button();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            //if (MainView.Is_Edit == false) return;
            //up.Visible = true;
            //down.Visible = true;
            //left.Visible = true;
            //right.Visible = true;
            //rightup.Visible = true;
            //rightdown.Visible = true;
            //leftup.Visible = true;
            //leftdown.Visible = true;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = label1;                     //
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

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            if (e.Button == MouseButtons.Left)
            {
                if (Selected_Lable != null)
                {
                    if (Selected_Lable.Name == "label1")
                    {
                        this.Left = this.Left + e.X - this.Width / 2;
                        this.Top = this.Top + e.Y - this.Height / 2;
                    }
                }
            }
        }

        private void button1_Move(object sender, EventArgs e)
        {

        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            Selected_Lable = null;
            Update_My_Button();
        }

        private void MyButton_Load(object sender, EventArgs e)
        {

        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            ButtonConfig.ButtonName = MyName;
            ButtonConfig.ButtontTxt = button1.Text;
            ButtonConfig.ButtonLeft = this.Left.ToString();
            ButtonConfig.ButtonTop = this.Top.ToString();
            ButtonConfig.ButtonWidth = this.Width.ToString();
            ButtonConfig.ButtonHeight = this.Height.ToString();
            ButtonConfig.BackColor = button1.BackColor.Name;
            ButtonConfig.Font = "";
            ButtonConfig.FontSize = button1.Font.Size.ToString();
            ButtonConfig.FontColor = button1.ForeColor.Name;


            ButtonConfig view = new ButtonConfig();
            
            DialogResult result = view.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    UpName = ButtonConfig.ButtonName;
                    ViewName = MainView.Selected_View_Name;
                    button1.Text = ButtonConfig.ButtontTxt;
                    this.Left = int.Parse(ButtonConfig.ButtonLeft);
                    this.Top = int.Parse(ButtonConfig.ButtonTop);
                    this.Width = int.Parse(ButtonConfig.ButtonWidth);
                    this.Height = int.Parse(ButtonConfig.ButtonHeight);
                    button1.BackColor = Color.FromName(ButtonConfig.BackColor);
                    button1.Font = new Font(Font.FontFamily, float.Parse(ButtonConfig.FontSize), FontStyle.Regular);
                    button1.ForeColor = Color.FromName(ButtonConfig.FontColor);
                }
                catch { MessageBox.Show("属性数据有误！"); return; }

                // 插入或更新
                if(MyName=="")
                {
                    // 插入数据库
                    string[] insert_cmd = new string[10];
                    insert_cmd[0] = UpName;
                    insert_cmd[1] = ButtonConfig.ButtontTxt;
                    insert_cmd[2] = ButtonConfig.ButtonLeft;
                    insert_cmd[3] = ButtonConfig.ButtonTop;
                    insert_cmd[4] = ButtonConfig.ButtonWidth;
                    insert_cmd[5] = ButtonConfig.ButtonHeight;
                    insert_cmd[6] = ButtonConfig.BackColor;
                    insert_cmd[7] = "";
                    insert_cmd[8] = ButtonConfig.FontSize;
                    insert_cmd[9] = ButtonConfig.FontColor;
                    bool success = MainView.Main_DataBase_Builder.Insert("AllButton",insert_cmd);
                    if (success == true)
                    {
                        string[] sub_insert_cmd = new string[2];
                        sub_insert_cmd[0] = UpName;
                        sub_insert_cmd[1] = "Button";
                        MainView.Main_DataBase_Builder.Insert(ViewName,sub_insert_cmd);
                        MyName = UpName;
                    }

                    // 创建与铵钮相关的功能表格
                    CreateSqlValueType[] button_funciton_table = new CreateSqlValueType[12];
                    button_funciton_table[0] = new CreateSqlValueType("nvarchar(50)", "functionkey",true,false);
                    button_funciton_table[1] = new CreateSqlValueType("nvarchar(50)", "myfunction");
                    button_funciton_table[2] = new CreateSqlValueType("nvarchar(50)", "Value1");
                    button_funciton_table[3] = new CreateSqlValueType("nvarchar(50)", "Value2");
                    button_funciton_table[4] = new CreateSqlValueType("nvarchar(50)", "Value3");
                    button_funciton_table[5] = new CreateSqlValueType("nvarchar(50)", "Value4");
                    button_funciton_table[6] = new CreateSqlValueType("nvarchar(50)", "Value5");
                    button_funciton_table[7] = new CreateSqlValueType("nvarchar(50)", "Value6");
                    button_funciton_table[8] = new CreateSqlValueType("nvarchar(50)", "Value7");
                    button_funciton_table[9] = new CreateSqlValueType("nvarchar(50)", "Value8");
                    button_funciton_table[10] = new CreateSqlValueType("nvarchar(50)", "Value9");
                    button_funciton_table[11] = new CreateSqlValueType("nvarchar(50)", "Value10");
                    MainView.Main_DataBase_Builder.Create_Table(UpName, button_funciton_table);
                    
                }
                if(MyName!="")
                {
                    // 更新数据库
                    string[] update_cmd = new string[10];
                    update_cmd[0] = "buttonname='" + UpName + "'";
                    update_cmd[1] = "txt='" + ButtonConfig.ButtontTxt + "'";
                    update_cmd[2] = "buttonLeft='" + ButtonConfig.ButtonLeft + "'";
                    update_cmd[3] = "buttonTop='" + ButtonConfig.ButtonTop + "'";
                    update_cmd[4] = "Width='" + ButtonConfig.ButtonWidth + "'";
                    update_cmd[5] = "Height='" + ButtonConfig.ButtonHeight + "'";
                    update_cmd[6] = "BackGroundColor='" + ButtonConfig.BackColor + "'";
                    update_cmd[7] = "Font=''";
                    update_cmd[8] = "FontSize='" + ButtonConfig.FontSize + "'";
                    update_cmd[9] = "FontColor='" + ButtonConfig.FontColor + "'";

                    string where_cmd = "buttonname='" + MyName + "'";
                    bool success = MainView.Main_DataBase_Builder.Updata("AllButton", where_cmd, update_cmd);
                    if (success == true)
                    {
                        string[] sub_update_cmd = new string[2];
                        sub_update_cmd[0] = "member='" + UpName + "'";
                        sub_update_cmd[1] = "type='Button'";
                        string sub_where_cmd = "member='" + MyName + "'";
                        MainView.Main_DataBase_Builder.Updata(ViewName, sub_where_cmd, sub_update_cmd);
                        // 更新表名
                        MainView.Main_DataBase_Builder.Updata_Table_Name(MyName, UpName);

                        MyName = UpName;

                        
                       
                    }
                }

            }
        }

        

        public void SetText(string txt)
        {
            button1.Text = txt;
        }

        public void Set_BackColor(string color)
        {
            button1.BackColor = Color.FromName(color);
        }

        public void Set_FontSize(int size)
        {
            button1.Font = new Font(Font.FontFamily, size, FontStyle.Regular);
        }

        public void Set_ForeColor(string color)
        {
            button1.ForeColor = Color.FromName(color);
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditWindow.CanPaste = true;
            EditWindow.CopyObject_Name = MyName;
            EditWindow.CopyType = "Button";
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainView.Is_Edit == false) return;
            // 删除一共有三项，删除在界面里的变量，删除在button数组里的量，删除这个button本身的功能列表
            string where_cmd1 = "member='" + MyName + "'";
            MainView.Main_DataBase_Builder.Delete(ViewName, where_cmd1);

            string where_cmd2 = "buttonname='" + MyName + "'";
            MainView.Main_DataBase_Builder.Delete("AllButton", where_cmd2);


            MainView.Main_DataBase_Builder.Delete_Table(MyName);

            this.Dispose();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Button_Press!=null)
            {
                Button_Press(this, e);
            }
        }

    }
}
