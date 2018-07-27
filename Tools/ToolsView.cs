using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FileOperation;

namespace Tools
{
    public partial class ToolsView : UserControl
    {
        /// <summary>
        /// Developed By Tom Ni 2018 1 2
        /// 开发一个工具箱工具
        /// 在相应的文件夹中应该有一个配置文件和图片文件夹
        /// 每个项目有：名称，所在行，所在列，图片  对应的toolcomponent控件（这个控件属于内部控件）
        /// </summary>
        /// 

        private IniFile inifile = new IniFile(System.AppDomain.CurrentDomain.BaseDirectory + "toolsconfig.ini");
        public ToolsView()
        {
            InitializeComponent();
            inifile.IniWriteValue("tools", "label", "true");
            inifile.IniWriteValue("tools", "button", "true");
            inifile.IniWriteValue("tools","combobox","true");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
