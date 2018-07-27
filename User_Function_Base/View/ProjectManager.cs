using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOperation;

namespace User_Function_Base.View
{
    public partial class ProjectManager : Form
    {
        public ProjectManager()
        {
            InitializeComponent();
            Read_Project_List();
        }

        public void Read_Project_List()
        {
            //listBox1.Items.Clear();

            // 读取项目文件
            string[] allproject = FileCaozuo.Read_All_Line(Form1.Project_Config_File);
            for(int i=0;i<allproject.Length;i++)
            {
                if (allproject[i] != null)
                {
                    //listBox1.Items.Add(allproject[i]);
                }
            }
        }
    }
}
