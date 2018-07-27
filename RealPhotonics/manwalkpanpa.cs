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
    public partial class manwalkpanpa :UserControl
    {
        bool shanshuo = false;
        public manwalkpanpa()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(shanshuo==false)
            {
                pictureBox1.Image = Properties.Resources._466901163338348161;
                shanshuo = true;
            }
            else if(shanshuo==true)
            {
                
                pictureBox1.Image = Properties.Resources._524661961058925671;
                shanshuo = false;
            }
        }

    }
}
