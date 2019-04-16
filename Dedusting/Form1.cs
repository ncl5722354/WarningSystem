using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewConfig;

namespace Dedusting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 最大化窗口
            ViewConfig.ViewCaoZuo.Max_Form(this);
            _init_view();
            
        }

        // 初始化画面
        private void _init_view()
        {
            //标题
            控件.Title title = new 控件.Title("除尘脱硫自动控制系统");
            ViewCaoZuo.Object_Position(0, 0, 1, 0.1, title, this.Controls);

            // 退出控钮
            控件.ExitButton exitbutton = new 控件.ExitButton();
            ViewCaoZuo.Object_Position(0.85, 0.1, 0.15, 0.1,exitbutton,this.Controls);

            // 选项标签
            ViewCaoZuo.Object_Position(0, 0.1, 0.85, 0.9, tabControl1, this.Controls);
        }
    }
}
