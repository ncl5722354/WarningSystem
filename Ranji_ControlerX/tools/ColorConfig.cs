using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranji_ControlerX.tools
{
    public partial class ColorConfig : Form
    {
        public static string Selected_Color = "";
        public ColorConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Select_Color(object sender,EventArgs e)
        {
            Label mylable = (Label)sender;
            label_Selected_Color.BackColor = mylable.BackColor;
            Selected_Color = mylable.BackColor.Name;
        }
    }
}
