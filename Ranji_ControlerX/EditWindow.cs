using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranji_ControlerX
{
    public partial class EditWindow : Form
    {
       // 复制，粘贴功能相应的量
        public static bool CanPaste = false;                            // 初始化时先不能粘贴
        public static string CopyObject_Name = "";                      // 被复制的物体的名称
        public static string CopyType = "";                             // 被复制的物体的类型

        public static event  EventHandler Reflush_View;

        public EditWindow()
        {
            InitializeComponent();
        }

        private void EditWindow_MouseUp(object sender, MouseEventArgs e)
        {
            // 鼠标拾起的
            if(MainView.Edit_Info=="NormalLabel")
            {
                Add_Lable(e.X, e.Y);
                MainView.Edit_Info = "";
                this.Cursor = Cursors.Arrow;
            }
            if(MainView.Edit_Info=="ValueLabel")
            {
                Add_Value_Label(e.X, e.Y);
                MainView.Edit_Info = "";
                this.Cursor = Cursors.Arrow;
            }
            if (MainView.Edit_Info == "Button")
            {
                Add_Button(e.X, e.Y);
                MainView.Edit_Info = "";
                this.Cursor = Cursors.Arrow;
            }
            if(MainView.Edit_Info=="Light")
            {
                Add_Ligth(e.X, e.Y);
                MainView.Edit_Info = "";
                this.Cursor = Cursors.Arrow;
            }
            }

        private void Add_Lable(int x,int y)
        {
            NormalControls.MyLabel label = new NormalControls.MyLabel("Normal");
            this.Controls.Add(label);
            label.Left = x - label.Width / 2;
            label.Top = y - label.Top / 2;
        }

        private void Add_Value_Label(int x,int y)
        {
            NormalControls.MyLabel label = new NormalControls.MyLabel("Value");
            this.Controls.Add(label);
            label.Left = x - label.Width / 2;
            label.Top = y - label.Top / 2;
        }

        private void Add_Button(int x, int y)
        {
            NormalControls.MyButton button = new NormalControls.MyButton();
            this.Controls.Add(button);
            //button.Button_Press += new EventHandler(Press_Button);
            button.Left = x - button.Width / 2;
            button.Top = y - button.Top / 2;
        }

        private void Add_Ligth(int x, int y)
        {
            NormalControls.Ligth light = new NormalControls.Ligth();
            this.Controls.Add(light);
            light.Left = x - light.Width / 2;
            light.Top = y - light.Top / 2;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                ToolStripItem item = contextMenuStrip1.Items[0];
                
                if (CanPaste == false && item != null) item.Enabled = false;
                if (CanPaste == true && item != null) item.Enabled = true;
            }
            catch { }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 普通标签
            #region
            if (CopyType=="Normal")
            {
                string where_cmd = "labelname='" + CopyObject_Name + "'";
                DataTable dt = MainView.Main_DataBase_Builder.Select_Table("Alllabel",where_cmd);
                if (dt != null)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        DataRow dr = dt.Rows[0];
                        NormalControls.MyLabel label = new NormalControls.MyLabel("Normal");
                        this.Controls.Add(label);
                        label.Left = 300;
                        label.Top = 300;
                        label.Set_Text(dr[1].ToString());
                        label.Width = int.Parse(dr[4].ToString());
                        label.Height = int.Parse(dr[5].ToString());
                        label.Set_BackColor(dr[6].ToString());
                        label.Set_FontSize(int.Parse(dr[8].ToString()));
                        label.Set_ForeColor(dr[9].ToString());
                        label.BringToFront();
                    }
                }
            }
            #endregion

            // 按钮
            #region
            if (CopyType == "Button")
            {
                string where_cmd = "buttonname='" + CopyObject_Name + "'";
                DataTable dt = MainView.Main_DataBase_Builder.Select_Table("AllButton", where_cmd);
                if (dt != null)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        DataRow dr = dt.Rows[0];
                        NormalControls.MyButton button = new NormalControls.MyButton();
                        this.Controls.Add(button);
                        button.Left = 300;
                        button.Top = 300;
                        button.SetText(dr[1].ToString());
                        button.Width = int.Parse(dr[4].ToString());
                        button.Height = int.Parse(dr[5].ToString());
                        button.Set_BackColor(dr[6].ToString());
                        button.Set_FontSize(int.Parse(dr[8].ToString()));
                        button.Set_ForeColor(dr[9].ToString());
                        button.BringToFront();
                        //button.Button_Press += new EventHandler(Press_Button);
                    }
                }
            }
            #endregion
        }
    }
}
