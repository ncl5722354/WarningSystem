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
using WpfControls;

namespace WPFDataStruct
{
    /// <summary>
    /// SubWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SubWindow : UserControl
    {
        Running_Data mydata = null;
        public SubWindow(Running_Data data)
        {
            InitializeComponent();
            mydata = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<mydata.Station_Info_List.Count;i++)
            {
                Running_Data_Struct mystruct = (Running_Data_Struct)mydata.Station_Info_List[i];
                int[] a = mystruct.Get_IntData();
                a[30] = a[30] + 1;
                a[31] = a[31] + 1;
                a[32] = a[32] + 1;
                a[33] = a[33] + 1;
            }
        }
    }
}
