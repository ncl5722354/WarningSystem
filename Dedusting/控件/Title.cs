using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dedusting.控件
{
    public partial class Title : UserControl
    {
        public Title(string title)
        {
            InitializeComponent();
            label1.Text = title;
            RESETLABEL();
        }

        // 内部函数

        // 重定位标签位置
        #region
        private void RESETLABEL()
        {
            label1.Left = 0;
            label1.Top = 0;
            label1.Width = this.Width;
            label1.Height = this.Height;
        }
        #endregion


        // 事件
        private void Title_Resize(object sender, EventArgs e)
        {
            RESETLABEL();
        }
    }

}
