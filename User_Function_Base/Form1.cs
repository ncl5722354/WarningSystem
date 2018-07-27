using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Communication;
using FileOperation;
using SqlConnect;
using ViewConfig;

namespace User_Function_Base
{
    public partial class Form1 : Form
    {
        //public static IniFile inifile = new IniFile(System.AppDomain.CurrentDomain.BaseDirectory + "projectmananger.ini");                          // 管理工程的配置文件

        public static string Project_Config_File = System.AppDomain.CurrentDomain.BaseDirectory + "projectmananger.smt";                              // 工程配置文件

        // 用master数据库来新建数据库
        SQL_Connect_Builder master_sql_builder = new SQL_Connect_Builder(".", "master", 0, 100);


        // 各个窗体初始化
        public static View.ProjectManager projectmanager = new View.ProjectManager();               // 项目管理配置

        public Form1()
        {
            InitializeComponent();
            // 初始化
            projectmanager.TopLevel = false;

            // 最开始显示的是工程管理界面
            Show_View(projectmanager);

            // 新建数据库
            master_sql_builder.Create_Database("MyMES");

            // 设置比例
            ViewCaoZuo.Max_Form(this);
            ViewCaoZuo.Object_Position(0, 0, 0.1, 1, treeView_select, this.Controls);
            ViewCaoZuo.Object_Position(0.12, 0.08, 0.8, 0.9, panel_view, this.Controls);
            
            string[] a = FileCaozuo.Read_All_Line(Project_Config_File);
            if(a!=null)
            {
                // 当配置文件不为空时

            }
        }

        private void Show_View(Form showform)
        {
            // 在显示区域显示某个画面
            panel_view.Controls.Clear();                   // 清除控件
            panel_view.Controls.Add(showform);
            showform.Left = 0;
            showform.Top = 0;
            showform.Width = panel_view.Width;
            showform.Height = panel_view.Height;
            showform.Show();
        }

        private void 新建项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 新创建项目窗体
            DialogView.NewProjectView view = new DialogView.NewProjectView();
            DialogResult resut = view.ShowDialog();
            // 如果创建了新项目，且当前是项目管理界面，就直接刷新
            if(resut==DialogResult.OK)
            {
                if(panel_view.Controls.Count==1)
                {
                    if (panel_view.Controls[0].Name == "ProjectManager")
                    {
                        projectmanager.Read_Project_List();            
                    }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ReSet_View()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void panel_view_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
