using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlConnect;
using FileOperation;
using ViewConfig;
using System.Collections;


namespace Ranji_ControlerX
{
    public partial class MainView : Form
    {
        /// <summary>
        /// 工作日志：
        /// 此系统目标为稳定的功能齐全并可编辑的面向染机的，中控控制系统，可将信息与中央数据库共享，管理层可以直接通过网络查看现场生产情况
        /// 2018 7 27日：1.改造现有的现场用的程序，可以编辑与组态，分为编辑模式与运行模式。
        ///              2.此项目所对应的数据库名为RanjiX。
        /// 2018 7 28日：1.完善画面树的功能。
        ///              2.在窗体中新建的窗体。
        ///              3.界面的表格结构：成员 类型
        /// 2018 8  1日：1.完成界面的编辑功能： 1 普通Label   可以编辑文字，字体颜色，背景颜色，字体，大小，字体大小等 
        /// 2018 8  4日：标签要有一张表格，这张表格包括名称，字符，横坐标，纵坐标，宽，高，背景颜色，字体，字体颜色等信息     
        ///              创建调色板，
        ///              接下来的工作，修改标签与读取标签。
        /// 2018 8  9日：内部数据的定义：1.全局数据
        ///                              2.画面数据
        ///                              
        /// 2018 8 10日：数据的标签，标签名称，数据模式，机号，机号编移量，数据位
        ///              
        ///              数据模式1：原来的数
        ///              数据模式2：原数 / 10
        ///              数据模式3：原数 / 100
        ///              数据模式4：时间
        ///                          
        ///              数据模式5：内部数据显示          ***数据位无效***
        ///                            
        /// 2018 8  17日：按钮控件的想法：每个按钮控件有一张列表，直接执行列表上的操作就可以
        ///               新建一个按钮的时候，就新建一个表格，这个表格对应这个按钮
        ///
        /// 2018 8  18日：按钮控件的编写，按钮控件 Button，同样有八个蓝色小点，用来放大缩小
        /// 
        /// 2018 8  25日：执行按钮功能
        ///               1.功能：1.数据设定  DataConfig                参数1：数据名称                参数2：设定值
        ///                       2.切换页面  ChangePage                
        ///                       3.刷新本页面  ReflashPage
        ///                       4.刷新控件    ReflaahControl
        ///                       
        ///               2.参数1
        ///               3.参数2
        ///               4.参数3
        ///               5.参数4
        ///               6.参数5
        ///               7.参数6
        ///               8.参数7
        ///               9.参数8
        ///               10.参数9
        ///               11.参数10
        ///               
        /// 2018 9 5日：指示灯控件
        ///             每个指示灯有两个状态，这两个状态分别对应不同的颜色，还有闪烁与否，闪烁的条件
        ///             两个不同的颜色状态，即为状态0与状态1：
        ///             条件，分为1：等于，2：不等于，3：大于，4：小于，5：大于等于，6：小于等于     每个条件带两个参数：参数1，参数2，参数2是扩展保留
        ///             闪烁条件：0：不闪烁，1：总是闪烁，2：状态0闪烁，3：状态1闪烁
        ///              
        /// </summary>
        
        /// 定义静态常量区
        public static SQL_Connect_Builder Main_DataBase_Builder = new SQL_Connect_Builder(".", "RanjiX", 0, 100);                         // 定义主数据库
        public static IniFile SysConfigFile = new IniFile("D:\\ranji3.0 config\\sysconfig.ini");                                          // 置配文件
        public static bool Is_Edit = false;
        TreeView treeview1 = new TreeView();                                  // 主树
        Panel EditPanel = new Panel();                                        // 编辑界面的编辑画面
        Panel RunPanel = new Panel();                                         // 运行界面
        Form EditForm = null;
        Form RunForm = null;
        public static string Edit_Info = "";

        public static string Selected_View_Name = "";

        public static ArrayList AllValue_Label_List = new ArrayList();                 // 所有数据标签的数组

        // 普通控件窗体
        NormalControlsWindow normalcontrolwindow = new NormalControlsWindow();
        
        /// 
        public MainView()
        {
            InitializeComponent();
            Read_Edit_Is();                                                   // 是否可以手动编辑画面
            Init_Database();                                                  // 初始化数据库
            ViewCaoZuo.Max_Form(this);                                        // 画面最大化
            EditPanel.AutoScroll = true;

            if (Is_Edit == true) Config_EditView();                           // 如果是编辑模式，进入到编辑状态
            if (Is_Edit == false) Config_RunView();                           // 如果是运行模式，进行到运行界面


            // 定义事件具体
            normalcontrolwindow.Selected_Control += new EventHandler(Selected_NormalControl_Trigger);


            /***************************************读取所有的数据标签************************************************/
            Read_All_ValueLabel();                                                                    


        }

        private void MainView_Load(object sender, EventArgs e)
        {
            if (Is_Edit == false) { timer_main.Enabled = true; }
        }

        private void Read_Edit_Is()
        {
            // 从配置文件中读取是编辑模式还是运行模式
            try
            {
                string edit_is = SysConfigFile.IniReadValue("SysConfig","Edit_Is");
                if (edit_is == "False") Is_Edit = false;
                if (edit_is == "True") Is_Edit = true;
            }
            catch { }
        }


        private void Config_EditView()
        {
            /// 配置编辑界面
            /// 左侧的树形结构
            
            // 设置退出键位置
            ViewCaoZuo.Object_Position(0.95, 0.01, 0.05, 0.05, button_exit, this.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.01, 0.1, 0.95, treeview1, this.Controls);

            // 编辑区域
            EditPanel.BorderStyle = BorderStyle.FixedSingle;
            ViewCaoZuo.Object_Position(0.12, 0.1, 0.85, 0.85, EditPanel, this.Controls);

            /// 加入画面选项
            TreeNode viewnode = new TreeNode();
            viewnode.Text = "画面";
            viewnode.Name = "画面";
            treeview1.Nodes.Add(viewnode);


            /// 加入数据编辑选项
            /// 
            TreeNode dataconfignode = new TreeNode();
            dataconfignode.Text = "数据编辑";
            dataconfignode.Name = "数据编辑";
            treeview1.Nodes.Add(dataconfignode);

            // 右键选择菜单
            treeview1.AfterSelect += new TreeViewEventHandler(TreeView_Right_Click);
            treeview1.ContextMenuStrip = contextMenuStrip_viewnoderightmenu;
            Reflush_TreeView_ViewNode(viewnode);

            //  普通控件按钮
            Button NormalControl = new Button();
            NormalControl.Text = "普通控件";
            NormalControl.Name = "NormalControlButton";
            ViewCaoZuo.Object_Position(0.13, 0.02, 0.05, 0.05, NormalControl, this.Controls);


            NormalControl.Click += new EventHandler(ShowNormalControlWindows);
            

        }

        private void Config_RunView()
        {
            /// 配置运行界面
            /// 
            /// 配置编辑界面
            /// 左侧的树形结构

            // 设置退出键位置
            ViewCaoZuo.Object_Position(0.95, 0.01, 0.05, 0.05, button_exit, this.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.01, 0.1, 0.95, treeview1, this.Controls);

            // 运行界面
            RunPanel.BorderStyle = BorderStyle.Fixed3D;
            ViewCaoZuo.Object_Position(0.12, 0.01, 0.8, 0.95, RunPanel, this.Controls);

            // 编辑树形结构
            TreeNode viewnode = new TreeNode();

            treeview1.AfterSelect += new TreeViewEventHandler(TreeView_Right_Click);
            treeview1.ContextMenuStrip = contextMenuStrip_viewnoderightmenu;
            viewnode.Text = "画面";
            viewnode.Name = "画面";
            treeview1.Nodes.Add(viewnode);
            Reflush_TreeView_ViewNode(viewnode);
        }

        private void TreeView_Right_Click(object sender,EventArgs e)
        {
            try
            {
                TreeNode selectednode = treeview1.SelectedNode;
                TreeNode ParentNode = selectednode.Parent;
                if (ParentNode != null)
                {
                    if (ParentNode.Name == "画面")
                    {
                        /// 读取画面
                        /// 
                        if (Is_Edit == true) Read_Edit_View(selectednode.Name);
                        if (Is_Edit == false) Read_Run_View(selectednode.Name);
                    }
                }
                if(selectednode.Name=="数据编辑")
                {
                    DataConfigView view = new DataConfigView();
                    Show_View(view);
                }

            }
            catch { }
             
        }

        private void Read_Edit_View(string viewname)
        {
            // 编辑模式下名叫viewname界面
            EditPanel.Controls.Clear();                      // 清空这个界面

            EditWindow view = new EditWindow();
            EditForm = view;
            view.TopLevel = false;
            EditPanel.Controls.Add(view);
            view.Show();
            ViewCaoZuo.Max_Form(view);
            Selected_View_Name = viewname;               // 被选中的窗体名字
            Show_Windows_Control(view);                  // 展示这个编辑界面


        }

        private void Read_Run_View(string viewname)
        {
            RunPanel.Controls.Clear();
            RunWindow view = new RunWindow();
            RunForm = view;
            view.TopLevel = false;
            RunPanel.Controls.Add(view);
            view.Show();
            ViewCaoZuo.Max_Form(view);
            Selected_View_Name = viewname;
            Show_Windows_Control(view);
        }

        private void Show_View(Form view)
        {
            EditPanel.Controls.Clear();
            view.TopLevel = false;
            EditPanel.Controls.Add(view);
            view.Show();
            ViewCaoZuo.Max_Form(view);
            
        }

        private void Show_Windows_Control(Form view)
        {
            view.Controls.Clear();
            DataTable dt = Main_DataBase_Builder.Select_Table(Selected_View_Name);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    // 解析所有的标签
                    #region
                    if (dr[1].ToString() == "NormalLabel")
                    {
                        string where_cmd = "labelname='" + dr[0].ToString() + "'";
                        DataTable labeldt = Main_DataBase_Builder.Select_Table("Alllabel", where_cmd);
                        if (labeldt != null)
                        {
                            if (labeldt.Rows.Count > 0)
                            {
                                try
                                {
                                    DataRow labeldr = labeldt.Rows[0];
                                    NormalControls.MyLabel mylabel = new NormalControls.MyLabel("Normal");
                                    mylabel.MyName = labeldr[0].ToString();
                                    mylabel.ViewName = view.Name;
                                    mylabel.Set_Text(labeldr[1].ToString());
                                    mylabel.Left = int.Parse(labeldr[2].ToString());
                                    mylabel.Top = int.Parse(labeldr[3].ToString());
                                    mylabel.Width = int.Parse(labeldr[4].ToString());
                                    mylabel.Height = int.Parse(labeldr[5].ToString());
                                    mylabel.Set_BackColor(labeldr[6].ToString());
                                    mylabel.Set_FontSize(int.Parse(labeldr[8].ToString()));
                                    mylabel.Set_ForeColor(labeldr[9].ToString());
                                    view.Controls.Add(mylabel);
                                    //mylabel
                                }
                                catch { }
                            }
                        }
                    }
                    #endregion
                    // 解析所有的数据标签
                    #region
                    if (dr[1].ToString() == "ValueLabel")
                    {
                        NormalControls.MyLabel label = get_valuelabel(dr[0].ToString());
                        if(label!=null)
                        {
                            view.Controls.Add(label);
                        }
                    }
                    #endregion

                    // 解析所有的按钮
                    #region
                    if (dr[1].ToString() == "Button")
                    {
                        string where_cmd = "buttonname='" + dr[0].ToString() + "'";
                        DataTable buttondt = Main_DataBase_Builder.Select_Table("AllButton", where_cmd);
                        if (buttondt != null)
                        {
                            if (buttondt.Rows.Count > 0)
                            {
                                try
                                {
                                    DataRow buttondr = buttondt.Rows[0];
                                    NormalControls.MyButton mybutton = new NormalControls.MyButton();
                                    mybutton.MyName = buttondr[0].ToString();
                                    mybutton.ViewName = view.Name;
                                    mybutton.SetText(buttondr[1].ToString());
                                    mybutton.Left = int.Parse(buttondr[2].ToString());
                                    mybutton.Top = int.Parse(buttondr[3].ToString());
                                    mybutton.Width = int.Parse(buttondr[4].ToString());
                                    mybutton.Height = int.Parse(buttondr[5].ToString());
                                    mybutton.Set_BackColor(buttondr[6].ToString());
                                    mybutton.Set_FontSize(int.Parse(buttondr[8].ToString()));
                                    mybutton.Set_ForeColor(buttondr[9].ToString());
                                    view.Controls.Add(mybutton);
                                    mybutton.Button_Press += new EventHandler(Press_Button);
                                    //mylabel
                                }
                                catch { }
                            }
                        }
                    }
                    #endregion

                }
            }
        }

        private NormalControls.MyLabel get_valuelabel(string name)
        {
            foreach(object mylabel in AllValue_Label_List)
            {
                NormalControls.MyLabel label = (NormalControls.MyLabel)mylabel;
                if (label.MyName == name) return label;
            }
            return null;
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 出现新增窗体页面
            MainSubView.AddView view = new MainSubView.AddView();
            DialogResult result = view.ShowDialog();
            if(result==DialogResult.OK)
            {
                string[] insert_cmd = new string[1];
                insert_cmd[0] = MainSubView.AddView.View_Name;
                bool success = Main_DataBase_Builder.Insert("AllView", insert_cmd);
                TreeNode viewnode = FindTreeNodeWithName("画面",treeview1);

                /// 创建一个这个界面的表
                /// 
                if (success == true)
                {
                    CreateSqlValueType[] create_cmd = new CreateSqlValueType[2];
                    create_cmd[0] = new CreateSqlValueType("nvarchar(50)", "member", true, true);
                    create_cmd[1] = new CreateSqlValueType("nvarchar(50)", "type");
                    Main_DataBase_Builder.Create_Table(MainSubView.AddView.View_Name, create_cmd);
                }

                if(viewnode!=null)
                {
                    Reflush_TreeView_ViewNode(viewnode);               // 刷新画面的父结点的信息
                }
            }
        }


        private void Init_Database()
        {
            // 建立画面列表
            CreateSqlValueType[] create_allview = new CreateSqlValueType[1];
            create_allview[0] = new CreateSqlValueType("nvarchar(50)", "viewname", true, false);
            Main_DataBase_Builder.Create_Table("AllView",create_allview);


            // 建立标签列表
            #region
            CreateSqlValueType[] create_allLabel = new CreateSqlValueType[10];
            create_allLabel[0] = new CreateSqlValueType("nvarchar(50)", "labelname", true, false);
            create_allLabel[1] = new CreateSqlValueType("nvarchar(50)", "txt");
            create_allLabel[2] = new CreateSqlValueType("nvarchar(50)","labelLeft");
            create_allLabel[3] = new CreateSqlValueType("nvarchar(50)","labelTop");
            create_allLabel[4] = new CreateSqlValueType("nvarchar(50)","Width");
            create_allLabel[5] = new CreateSqlValueType("nvarchar(50)","Height");
            create_allLabel[6] = new CreateSqlValueType("nvarchar(50)","BackGroundColor");
            create_allLabel[7] = new CreateSqlValueType("nvarchar(50)","Font");
            create_allLabel[8] = new CreateSqlValueType("nvarchar(50)","FontSize");
            create_allLabel[9] = new CreateSqlValueType("nvarchar(50)","FontColor");
            Main_DataBase_Builder.Create_Table("Alllabel",create_allLabel);
            #endregion

            // 建立数据列表
            #region
            CreateSqlValueType[] create_data = new CreateSqlValueType[7];
            create_data[0] = new CreateSqlValueType("nvarchar(50)", "dataname", true, false);
            create_data[1] = new CreateSqlValueType("nvarchar(50)","datatype");
            create_data[2] = new CreateSqlValueType("nvarchar(50)","datascope");
            create_data[3] = new CreateSqlValueType("nvarchar(50)","Value");
            create_data[4] = new CreateSqlValueType("nvarchar(50)","DataSource");
            create_data[5] = new CreateSqlValueType("nvarchar(50)","Machine_num");
            create_data[6] = new CreateSqlValueType("nvarchar(50)","Address");
            Main_DataBase_Builder.Create_Table("AllData",create_data);
            #endregion

            // 建立数据标签列表
            #region
            CreateSqlValueType[] create_valueLabel = new CreateSqlValueType[14];
            create_valueLabel[0] = new CreateSqlValueType("nvarchar(50)", "labelname", true, false);
            create_valueLabel[1] = new CreateSqlValueType("nvarchar(50)", "txt");
            create_valueLabel[2] = new CreateSqlValueType("nvarchar(50)", "labelLeft");
            create_valueLabel[3] = new CreateSqlValueType("nvarchar(50)", "labelTop");
            create_valueLabel[4] = new CreateSqlValueType("nvarchar(50)", "Width");
            create_valueLabel[5] = new CreateSqlValueType("nvarchar(50)", "Height");
            create_valueLabel[6] = new CreateSqlValueType("nvarchar(50)", "BackGroundColor");
            create_valueLabel[7] = new CreateSqlValueType("nvarchar(50)", "Font");
            create_valueLabel[8] = new CreateSqlValueType("nvarchar(50)", "FontSize");
            create_valueLabel[9] = new CreateSqlValueType("nvarchar(50)", "FontColor");
            create_valueLabel[10] = new CreateSqlValueType("nvarchar(50)","DateType");
            create_valueLabel[11] = new CreateSqlValueType("nvarchar(50)","Machine_Num");
            create_valueLabel[12] = new CreateSqlValueType("nvarchar(50)","offsite");
            create_valueLabel[13] = new CreateSqlValueType("nvarchar(50)","ValueAddress");
            Main_DataBase_Builder.Create_Table("AllValuelabel", create_valueLabel);
            #endregion

            // 建立按钮的标签列表
            #region
            CreateSqlValueType[] create_valueButton = new CreateSqlValueType[10];
            create_valueButton[0] = new CreateSqlValueType("nvarchar(50)", "buttonname", true, false);
            create_valueButton[1] = new CreateSqlValueType("nvarchar(50)","txt");
            create_valueButton[2] = new CreateSqlValueType("nvarchar(50)","buttonLeft");
            create_valueButton[3] = new CreateSqlValueType("nvarchar(50)","buttonTop");
            create_valueButton[4] = new CreateSqlValueType("nvarchar(50)","Width");
            create_valueButton[5] = new CreateSqlValueType("nvarchar(50)","Height");
            create_valueButton[6] = new CreateSqlValueType("nvarchar(50)","BackGroundColor");
            create_valueButton[7] = new CreateSqlValueType("nvarchar(50)","Font");
            create_valueButton[8] = new CreateSqlValueType("nvarchar(50)","FontSize");
            create_valueButton[9] = new CreateSqlValueType("nvarchar(50)", "FontColor");
            Main_DataBase_Builder.Create_Table("AllButton",create_valueButton);
            #endregion


            // 建立指标类的列表
            #region
            CreateSqlValueType[] create_ligth = new CreateSqlValueType[15];
            create_ligth[0] = new CreateSqlValueType("nvarchar(50)", "lightname", true, false);
            create_ligth[1] = new CreateSqlValueType("nvarchar(50)", "lightLight");
            create_ligth[2] = new CreateSqlValueType("nvarchar(50)", "lightTop");
            create_ligth[3] = new CreateSqlValueType("nvarchar(50)", "Width");
            create_ligth[4] = new CreateSqlValueType("nvarchar(50)", "Height");
            create_ligth[5] = new CreateSqlValueType("nvarchar(50)", "State0Color");
            create_ligth[6] = new CreateSqlValueType("nvarchar(50)", "State1Color");
            create_ligth[7] = new CreateSqlValueType("nvarchar(50)", "condition0");
            create_ligth[8] = new CreateSqlValueType("nvarchar(50)", "condition1");
            create_ligth[9] = new CreateSqlValueType("nvarchar(50)", "Value00");
            create_ligth[10] = new CreateSqlValueType("nvarchar(50)", "Value01");
            create_ligth[11] = new CreateSqlValueType("nvarchar(50)", "Value10");
            create_ligth[12] = new CreateSqlValueType("nvarchar(50)", "Value11");
            create_ligth[13] = new CreateSqlValueType("nvarchar(50)", "Value0");
            create_ligth[14] = new CreateSqlValueType("nvarchar(50)", "Value1");
            Main_DataBase_Builder.Create_Table("Alllights", create_ligth);
            #endregion
        }

        private void Reflush_TreeView_ViewNode(TreeNode mytreenode)
        {
            DataTable dt = Main_DataBase_Builder.Select_Table("AllView");
            mytreenode.Nodes.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                TreeNode subnode = new TreeNode();               // 要加入的画面子结点
                subnode.Name = dr[0].ToString();
                subnode.Text = dr[0].ToString();
                subnode.ContextMenuStrip = contextMenuStrip_viewsubnoderightmeun;
                mytreenode.Nodes.Add(subnode);
                
            }
        }


        ///常用功能
        ///
        // 从一个树形结构中找到一个子结点
        private static TreeNode FindTreeNodeWithName(string name,TreeView treeview)
        {
            foreach(TreeNode node in treeview.Nodes)
            {
                if(node.Name==name)
                {
                    return node;
                }
            }
            return null;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainSubView.IsDelete view = new MainSubView.IsDelete();
            DialogResult result = view.ShowDialog();
            if (result == DialogResult.OK)
            {
                TreeNode node = treeview1.SelectedNode;                   // 刚刚点击的点
                string name = node.Name;
                // 从数据库中删除此点
                string delete_cmd = "viewname='" + name + "'";
                Main_DataBase_Builder.Delete("AllView", delete_cmd);

                // 删除数据库中对应页面的表格
                Main_DataBase_Builder.Delete_Table(name);

                //************************** 还有其他信息********************************//
                TreeNode viewnode = FindTreeNodeWithName("画面", treeview1);
                if (viewnode != null)
                    Reflush_TreeView_ViewNode(viewnode);               // 刷新画面的父结点的信息
            }
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeview1.SelectedNode;
            MainSubView.UpdataView view = new MainSubView.UpdataView(node.Name);
            string originName = node.Name;
            DialogResult result = view.ShowDialog();
            if (result == DialogResult.OK)
            {
                string where_cmd="viewname='"+originName+"'";
                string[] updata_cmd=new string[1];
                updata_cmd[0] = "viewname='" + MainSubView.UpdataView.View_Name + "'";
                bool success = Main_DataBase_Builder.Updata("AllView", where_cmd, updata_cmd);
                if (success == true)
                {
                    Main_DataBase_Builder.Updata_Table_Name(originName, MainSubView.UpdataView.View_Name);
                }
                TreeNode viewnode = FindTreeNodeWithName("画面", treeview1);
                if (viewnode != null)
                    Reflush_TreeView_ViewNode(viewnode);               // 刷新画面的父结点的信息


                /// 其他的修改
            }
        }


        private void ShowNormalControlWindows(object sender,EventArgs e)
        {
            normalcontrolwindow.Show();
            normalcontrolwindow.Focus();
        }



        /// 事件
        /// 
        // 选择了普通控件
        private void Selected_NormalControl_Trigger(object sender,EventArgs e)
        {
            try
            {
                
                if (Edit_Info == "NormalLabel")
                    EditForm.Cursor = Cursors.Cross;
                if (Edit_Info == "")
                    EditForm.Cursor = Cursors.Arrow;
                if (Edit_Info == "ValueLabel")
                    EditForm.Cursor = Cursors.Cross;
                if (Edit_Info == "Button")
                    EditForm.Cursor = Cursors.Cross;
            }
            catch { }
        }

        private void Read_All_ValueLabel()
        {
            DataTable dt = Main_DataBase_Builder.Select_Table("AllValuelabel");
            AllValue_Label_List.Clear();
            if (dt != null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    try
                    {
                        NormalControls.MyLabel valuelabel = new NormalControls.MyLabel("Value");
                        valuelabel.MyName = dr[0].ToString();
                        valuelabel.Set_Text(dr[1].ToString());
                        valuelabel.Left = int.Parse(dr[2].ToString());
                        valuelabel.Top = int.Parse(dr[3].ToString());
                        valuelabel.Width = int.Parse(dr[4].ToString());
                        valuelabel.Height = int.Parse(dr[5].ToString());
                        valuelabel.Set_BackColor(dr[6].ToString());
                        valuelabel.Set_FontSize(int.Parse(dr[8].ToString()));
                        valuelabel.Set_ForeColor(dr[9].ToString());
                        valuelabel.DataType = dr[10].ToString();
                        valuelabel.Machine_num = dr[11].ToString();
                        valuelabel.Offsite = dr[12].ToString();
                        valuelabel.ValueAddress = dr[13].ToString();
                        AllValue_Label_List.Add(valuelabel);                                               // 将全部的标签加载进来

                    }
                    catch { }

                }
            }
        }

        private void timer_main_Tick(object sender, EventArgs e)
        {
            /// 所有的数据标签
            /// 
            foreach(NormalControls.MyLabel mylabel in AllValue_Label_List)
            {
                string name = mylabel.MyName;
                string where_cmd = "labelname='" + name + "'";
                DataTable dt = MainView.Main_DataBase_Builder.Select_Table("AllValuelabel", where_cmd);
                if (dt != null)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        DataRow dr = dt.Rows[0];
                        string datatype = dr[10].ToString();
                        string machine_num_string = dr[11].ToString();
                        string offsite = dr[12].ToString();
                        string value_address = dr[13].ToString();

                        if (offsite != "")
                        {
                            string data_where_cmd = "dataname='" + offsite + "'";
                            DataTable mydt = MainView.Main_DataBase_Builder.Select_Table("AllData",data_where_cmd);
                            if (mydt != null)
                            {
                                if(mydt.Rows.Count>=1)
                                {
                                    DataRow datarow = mydt.Rows[0];
                                    if (datarow[1].ToString() == "整型")
                                    {
                                        if (datarow[4].ToString() == "内部数据")
                                        {
                                            int machine_num=int.Parse(datarow[5].ToString());
                                            int address=int.Parse(datarow[6].ToString());
                                            int thisvalue = int.Parse(value_address) + Data.Int_Data[machine_num, address];
                                            mylabel.Set_Text(thisvalue.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Press_Button(object sender, EventArgs e)
        {
            NormalControls.MyButton button = (NormalControls.MyButton)sender;
            if (MainView.Is_Edit == false)
            {
                // 在运行状态下
                DataTable buttondt = MainView.Main_DataBase_Builder.Select_Table(button.MyName);
                if (buttondt != null)
                {
                    if (buttondt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in buttondt.Rows)
                        {
                            // 数据设定
                            #region
                            if (dr[1].ToString() == "数据设定")
                            {
                                string data_name = dr[2].ToString();
                                double value = 0;
                                try
                                {
                                    value = double.Parse(dr[3].ToString());
                                }
                                catch { break; }

                                // 寻找这个量的内部地址
                                string where_cmd = "dataname='" + data_name + "'";
                                DataTable datatable = MainView.Main_DataBase_Builder.Select_Table("AllData", where_cmd);
                                if (datatable != null)
                                {
                                    if (datatable.Rows.Count > 0)
                                    {
                                        DataRow datarow = datatable.Rows[0];
                                        try
                                        {
                                            if (datarow[4].ToString() == "内部数据")
                                            {
                                                int machine_num = int.Parse(datarow[5].ToString());
                                                int address = int.Parse(datarow[6].ToString());
                                                if (datarow[1].ToString() == "整型")
                                                {
                                                    Data.Int_Data[machine_num, address] = (int)value;
                                                }
                                            }
                                        }
                                        catch { break; }
                                    }
                                }
                            }
                            #endregion

                            // 刷新
                            if (dr[1].ToString() == "刷新本页面")
                            {
                                Read_Run_View(Selected_View_Name);
                            }
                        }
                    }
                }
            }

        }
    }
}
