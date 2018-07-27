using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace WpfControls
{
    /// <summary>
    /// MyTreeView.xaml 的交互逻辑
    /// </summary>
    public partial class MyTreeView : UserControl
    {
        public string value1;
        public string value2;
        public string value3;
        public string value4;
        public string value5;
        public string value6;
        public string value7;
        public string value8;
        public string value9;
        public string value10;
        public string ClickAction;
        public TreeViewItem treeviewitem = null;

        // 定义外部引用的事件
        public event EventHandler JumpWindow = null;                             // 定义跳转窗体事件

        public TreeView Get_Treeview()
        {
            return mytreeview;
        }
        public MyTreeView(DataTable dt)
        {
            InitializeComponent();
            mytreeview.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(Jump_Window_Event);
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            foreach(DataRow dr in dt.Rows)
            {
                TreeViewItem item = new TreeViewItem();
                item.Name = dr[0].ToString();
                item.Header = dr[1].ToString();
                if (dr[3].ToString() == "jumpwindow")
                {
                    //value1 = dr[4].ToString();
                    //value2 = dr[5].ToString();
                    //treeviewitem = item;
                    //item.MouseLeftButtonDown += new MouseButtonEventHandler(Jump_Window_Event);
                }
                if(dr[2].ToString()=="")
                {
                    mytreeview.Items.Add(item);
                }
                else
                {
                    foreach(object thisitem in mytreeview.Items)
                    {
                        string parent_point = dr[2].ToString();
                        TreeViewItem myitem = (TreeViewItem)thisitem;
                        if(myitem.Name==parent_point)
                        {
                            myitem.Items.Add(item);
                            break;
                        }
                    }
                }
            }
        }

        private void Jump_Window_Event(object sender,RoutedPropertyChangedEventArgs<object> e)
        {
            if(JumpWindow!=null)
            {
                JumpWindow(this, new EventArgs());
            }
        }
    }
}
