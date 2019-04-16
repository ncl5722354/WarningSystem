using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranji_ControlerX
{
    public partial class NormalControlsWindow : Form
    {
        public NormalControlsWindow()
        {
            InitializeComponent();
        }

        public event EventHandler Selected_Control = null;
       

        private void button1_Click(object sender, EventArgs e)
        {
            // 按下这个按键之后，可以画标签
            MainView.Edit_Info = "NormalLabel";
            this.Hide();
            selected_Trigger(new EventArgs());

        }

        private void selected_Trigger(EventArgs e)
        {
            if (Selected_Control != null)
            {
                Selected_Control(this, e);
            }
        }

        private void NormalControlsWindow_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 按下这个按键之后，可以画变量标签
            MainView.Edit_Info = "ValueLabel";
            this.Hide();
            selected_Trigger(new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 按下这个按键之后，可以画变量标签
            MainView.Edit_Info = "Button";
            this.Hide();
            selected_Trigger(new EventArgs());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainView.Edit_Info = "Light";
            this.Hide();
            selected_Trigger(new EventArgs());
        }


    }
}
