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
    public partial class ExitButton : UserControl
    {
        public ExitButton()
        {
            InitializeComponent();
            _EXITBUTTON_RESET();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        
        // 退出按钮重置
        private void _EXITBUTTON_RESET()
        {
            button1.Left = 0;
            button1.Top = 0;
            button1.Width = this.Width;
            button1.Height = this.Height;
        }


        
        private void ExitButton_Resize(object sender, EventArgs e)
        {
            _EXITBUTTON_RESET();
        }

    }
}
