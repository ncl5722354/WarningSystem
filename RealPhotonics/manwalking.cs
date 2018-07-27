using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealPhotonics
{
    public partial class manwalking :UserControl
    {
        bool shanshuo = false;
        public manwalking()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(shanshuo==false)
            {
                pictureBox1.Image = Properties.Resources.Warming1;
                shanshuo = true;
            }
            else if(shanshuo==true)
            {
                
                pictureBox1.Image = Properties.Resources.Warming2;
                shanshuo = false;
            }
        }

    }
}
