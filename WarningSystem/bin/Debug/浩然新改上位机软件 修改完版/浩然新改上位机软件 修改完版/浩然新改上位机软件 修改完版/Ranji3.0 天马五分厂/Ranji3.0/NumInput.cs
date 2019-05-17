using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ranji3._0
{
    public partial class NumInput :Form
    {
        public static long myvalue = 0;
        public NumInput()
        {
            InitializeComponent();
            myvalue = 0;
            label1.Text = "0";
        }

        private void NumInput_Load(object sender, EventArgs e)
        {

        }

        private void Press_Button(int num)
        {
            try
            {
                myvalue = myvalue * 10 + num;
                label1.Text = myvalue.ToString();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Press_Button(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Press_Button(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Press_Button(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Press_Button(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Press_Button(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Press_Button(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Press_Button(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Press_Button(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Press_Button(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Press_Button(0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            myvalue = 0;
            label1.Text = "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (myvalue != 0)
                myvalue = myvalue / 10;
            label1.Text = myvalue.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
