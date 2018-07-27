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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace WpfControls
{
    /// <summary>
    /// MyNormalDataGridView.xaml 的交互逻辑
    /// 与结构与数据表的结构有关，数据表结构专门来保存并解析
    /// </summary>
    public partial class MyOrderDataGridView : UserControl
    {
        public MyOrderDataGridView(DataTable sourcedt,DataRow setrow)
        {
            InitializeComponent();
            for (int i = 1; i <= sourcedt.Columns.Count; i++)
            {
                sourcedt.Columns[0].ColumnName = "序号";
                if (setrow[10 + i * 2].ToString() != "")
                {
                    sourcedt.Columns[i].ColumnName = setrow[10 + i * 2].ToString();
                }
            }

            datagridview.ItemsSource = sourcedt.DefaultView;

            datagridview.IsReadOnly = true;

            datagridview.FontSize = 10;
            

            if (setrow[2].ToString() == "" || setrow[3].ToString()=="") return;
            if(setrow!=null && setrow.ItemArray.Length==72)
            {
                switch(setrow[4].ToString())
                {
                    case "Left":
                        HorizontalAlignment = HorizontalAlignment.Left;
                        break;
                    case "Right":
                        HorizontalAlignment = HorizontalAlignment.Right;
                        break;
                    case "Center":
                        HorizontalAlignment = HorizontalAlignment.Center;
                        break;
                    default :
                        break;
                }

                switch(setrow[5].ToString())
                {
                    case "Top":
                        VerticalAlignment = VerticalAlignment.Top;
                        break;
                    case "Bottom":
                        VerticalAlignment = VerticalAlignment.Bottom;
                        break;
                    case "Center":
                        VerticalAlignment = VerticalAlignment.Center;
                        break;
                    default:
                        break;
                }
                try
                {
                    double Margin_Left = double.Parse(setrow[6].ToString());
                    double Margin_Right = double.Parse(setrow[7].ToString());
                    double Margin_Top = double.Parse(setrow[8].ToString());
                    double Margin_Bottom = double.Parse(setrow[9].ToString());
               
                
                    Margin = new Thickness(Margin_Left, Margin_Top, Margin_Right, Margin_Bottom);
                    Width = double.Parse(setrow[10].ToString());
                    Height = double.Parse(setrow[11].ToString());
                }
                catch { return; }
            }
            else
            {
                return;
            }
        }
    }
}
