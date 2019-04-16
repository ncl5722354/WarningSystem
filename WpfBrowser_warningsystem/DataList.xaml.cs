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
using System.Collections;

namespace WpfBrowser_warningsystem
{
    /// <summary>
    /// DataList.xaml 的交互逻辑
    /// </summary>
    public partial class DataList : UserControl
    {
        public struct Data_Struct
        {
            public double 位置 { set; get; }
            public double 位置X { set; get; }
            public double 位置Y { set; get; }
            public double 应变量 { set; get; }
            public double 位移量 { set; get; }
        }

        public List<Data_Struct> Data_List=new List<Data_Struct>();    //实时数据的列表
        

        public DataList()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            datagrid1.Margin = new Thickness(0, 0, 0, 0);
            datagrid1.Width = this.Width;
            datagrid1.Height = this.Height;
            datagrid1.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        public void Set_Table(ArrayList list)
        {
            try
            {
                if (list == null) return;
                if (list.Count == 0) return;
                datagrid1.ItemsSource = null;
                Data_List.Clear();
                foreach (Data_Struct mystruct in list)
                {
                    Data_List.Add(mystruct);
                }

                datagrid1.ItemsSource = Data_List;
                
            }
            catch { }
    
        }

        private void datagrid1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            init_view();
        }
    }
}
