using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace ViewConfig
{
    public class ViewCaoZuo
    {
        static public int width = Screen.PrimaryScreen.Bounds.Width;
        static public  int height = Screen.PrimaryScreen.Bounds.Height;
        public static void Max_Form(Form myform)
        {
            //int width = Screen.PrimaryScreen.Bounds.Width;
            //int height = Screen.PrimaryScreen.Bounds.Height;
            myform.Left = 0;
            myform.Top = 0;
            myform.Width = width;
            myform.Height = height;
        }    // 最大化窗体

        public static void Show_Form_In_Panel(Form myform,Panel mypanel)
        {
            myform.TopLevel = false;
            mypanel.Controls.Clear();
            myform.Show();
            mypanel.Controls.Add(myform);
            ViewCaoZuo.Max_Form(myform);
        }                               // 将窗体在panel中显示

        public static void Object_Position_Screen(double left,double top,Control myobject)
        {
            myobject.Left = (int)(left * width - myobject.Width / 2);
            myobject.Top = (int)(top * height - myobject.Height / 2);
        }
        public static void Object_Position(double left,double top,double width,double height,Control myobject,Control.ControlCollection myControls)
        {
            if (myControls != null)
            {
                myControls.Add(myobject);
            }
            Control ParentControl = myobject.Parent;
            myobject.Left = (int)(left * ParentControl.Width);
            myobject.Top = (int)(top * ParentControl.Height);
            myobject.Width = (int)(width * ParentControl.Width);
            myobject.Height = (int)(height * ParentControl.Height);
        }

        public object Get_Control(Control.ControlCollection mycontrols,string control_name)
        {
            foreach(Control mycontrol in mycontrols)
            {
                if(mycontrol.Name==control_name)
                {
                    return mycontrol;
                }
            }
            return null;
        }

        public void Combo_Add(string combo_name,string[] item,Control.ControlCollection mycontrols)
        {
            try
            {
                ComboBox mycombo = null;
                foreach (Control mycontrol in mycontrols)
                {
                    if (mycontrol.Name == combo_name)
                    {
                        mycombo = (ComboBox)mycontrol;
                        break;
                    }
                }
                for (int i = 0; i < item.Length; i++)
                {
                    mycombo.Items.Add(item[i]);
                }
            }
            catch { }
        }
    }
}
