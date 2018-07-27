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


namespace Ranji_ControlerX
{
    public partial class MainView : Form
    {
        /// <summary>
        /// 工作日志：
        /// 此系统目标为稳定的功能齐全并可编辑的面向染机的，中控控制系统，可将信息与中央数据库共享，管理层可以直接通过网络查看现场生产情况
        /// 2018 7 27日：1.改造现有的现场用的程序，可以编辑与组态，分为编辑模式与运行模式
        ///              2.此项目所对应的数据库名为RanjiX
        /// </summary>
        
        /// 定义静态常量区
        public static SQL_Connect_Builder Main_DataBase_Builder = new SQL_Connect_Builder(".", "RanjiX", 0, 100);                         // 定义主数据库
        public static IniFile SysConfigFile = new IniFile("D:\\ranji3.0 config\\sysconfig.ini");                                          // 置配文件
        public static bool Is_Edit = false;
        TreeView treeview1 = new TreeView();                                  // 主树
        /// 
        public MainView()
        {
            InitializeComponent();
            Read_Edit_Is();                                                   // 是否可以手动编辑画面
            Init_Database();                                                  // 初始化数据库
            ViewCaoZuo.Max_Form(this);                                        // 画面最大化

            if (Is_Edit == true) Config_EditView();                           // 如果是编辑模式，进入到编辑状态
            if (Is_Edit == false) Config_RunView();                           // 如果是运行模式，进行到运行界面
 
        }

        private void MainView_Load(object sender, EventArgs e)
        {

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

            /// 加入画面选项
            TreeNode viewnode = new TreeNode();
            viewnode.Text = "画面";
            viewnode.Name = "画面";
            treeview1.Nodes.Add(viewnode);

            // 右键选择菜单
            treeview1.NodeMouseClick += new TreeNodeMouseClickEventHandler(TreeView_Right_Click);
            treeview1.ContextMenuStrip = contextMenuStrip_viewnoderightmenu;
            Reflush_TreeView_ViewNode(viewnode);

            

        }

        private void Config_RunView()
        {
            /// 配置运行界面
            /// 

        }

        private void TreeView_Right_Click(object sender,TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.ToString() == "Right")
            {
                // 右键的情况下
                
            }
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
                Main_DataBase_Builder.Insert("AllView", insert_cmd);
                TreeNode viewnode = FindTreeNodeWithName("画面",treeview1);
                if(viewnode!=null)
                {
                    Reflush_TreeView_ViewNode(viewnode);
                }
            }
        }


        private void Init_Database()
        {
            // 建立画面列表
            CreateSqlValueType[] create_allview = new CreateSqlValueType[1];
            create_allview[0] = new CreateSqlValueType("nvarchar(50)", "viewname", true, false);
            Main_DataBase_Builder.Create_Table("AllView",create_allview);
                                                  
        }

        private void Reflush_TreeView_ViewNode(TreeNode mytreenode)
        {
            DataTable dt = Main_DataBase_Builder.Select_Table("AllView");
            mytreenode.Nodes.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                mytreenode.Nodes.Add(dr[0].ToString());
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
    }
}
