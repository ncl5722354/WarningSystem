using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileOperation;
using String_Caozuo;
using System.Collections;
using System.IO;
using System.Text;

namespace update
{
    public partial class Form1 : Form
    {
        bool isupdate = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 
            if (isupdate == false)
                isupdate = true;
            else
                return;
            ArrayList list = FileCaozuo.Read_All_Files("D://data//","*.txt");
            foreach(string line in list)
            {
                FileCaozuo.Create_Dir("D://data//"+string_caozuo.Get_HengGang_String(line,1));
                FileCaozuo.Copy("D://data//" + line, "D://data//" + string_caozuo.Get_HengGang_String(line, 1) + "//" + line);
            }
            isupdate = false;
        }
    }
}
