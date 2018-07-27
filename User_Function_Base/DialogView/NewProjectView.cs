using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOperation;

namespace User_Function_Base.DialogView
{
    public partial class NewProjectView : Form
    {
        public NewProjectView()
        {
            InitializeComponent();
            //  初始化中，读取相应的程序根目录
            label_path.Text = System.Environment.CurrentDirectory;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                 label_path.Text= folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string project_name = textBox_project_name.Text.Trim();
            string path = label_path.Text.Trim();
            string pathfile = "";
            // 创建项目
            if(project_name=="")
            {
                // 项目名称为空
                MessageBox.Show("项目名称不能为空！");
                return;
            }
            pathfile = path + "\\" + project_name;
            
            // 检查当前文件夹是否有这个文件夹
            bool exits = DirectoryCaozuo.Directory_Exits(pathfile);
            if (exits == true)
            {
                // 项目文件夹已经存在了
                MessageBox.Show("项目文件夹已经存在！");
                return;
            }
            if(exits==false)
            {
                // 创建项目文件夹与项目文件
                DirectoryCaozuo.Create_Directory(pathfile);
                // 在项目文件夹里创建必要的文件


                // 在配置文件中加入这个路径
                FileCaozuo.Write_Lind_Add(Form1.Project_Config_File,pathfile);
                this.DialogResult = DialogResult.OK;                             // 创建了一个项目
                this.Dispose();
            }
        }
    }
}
