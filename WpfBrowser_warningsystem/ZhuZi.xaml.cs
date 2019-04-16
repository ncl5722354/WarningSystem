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
    /// ZhuZi.xaml 的交互逻辑
    /// </summary>
    public partial class ZhuZi : UserControl
    {
        ArrayList thislist = new ArrayList();
        int left = 70;
        int height = 100;
        int width = 360;

        public ZhuZi(ArrayList list)
        {
            InitializeComponent();
            thislist = list;
            init();
        }

        public void ReSet(ArrayList list)
        {

            thislist = list;
            subgrid.Children.Clear();
            Image topimage = new Image();
            string path = System.Environment.CurrentDirectory + "\\zhu_tou.png";
            BitmapImage imagetop = new BitmapImage(new Uri(path, UriKind.Absolute));
            topimage.Source = imagetop;
            topimage.Margin = new Thickness(left, 0, 0, 0);
            subgrid.Children.Add(topimage);
            topimage.VerticalAlignment = VerticalAlignment.Top;
            topimage.HorizontalAlignment = HorizontalAlignment.Left;
            topimage.Height = height;
            

            int shu = thislist.Count;
            int tu_shu = (shu + 1) / 2;
            double my_tu_shu = (double)tu_shu / 2 / 3 + 1;

            int a =(int)Math.Ceiling(my_tu_shu);

            for(int i=1;i<=a;i++)
            {
                Image shenimage = new Image();
                string shenpath = System.Environment.CurrentDirectory + "\\zhu_shen.png";
                BitmapImage imageshen = new BitmapImage(new Uri(shenpath, UriKind.Absolute));
                shenimage.Height = height;
                shenimage.Source = imageshen;
                shenimage.Margin = new Thickness(left, topimage.Height * i, 0, 0);
            //    shenimage.Width = width;
                subgrid.Children.Add(shenimage);
                shenimage.VerticalAlignment = VerticalAlignment.Top;
                shenimage.HorizontalAlignment = HorizontalAlignment.Left;
            }

            Image dimage = new Image();
            string dipath = System.Environment.CurrentDirectory + "\\zhu_di.png";
            BitmapImage imagedi = new BitmapImage(new Uri(dipath, UriKind.Absolute));
            dimage.Height = height;
            //dimage.Width = width;
            dimage.Source = imagedi;
            dimage.Margin = new Thickness(left, (my_tu_shu + 1) * topimage.Height, 0, 0);
            subgrid.Children.Add(dimage);
            dimage.VerticalAlignment = VerticalAlignment.Top;
            dimage.HorizontalAlignment = HorizontalAlignment.Left;

            subgrid.VerticalAlignment = VerticalAlignment.Top;
            subgrid.HorizontalAlignment = HorizontalAlignment.Left;
            subgrid.Margin = new Thickness(left, 0, 0, 0);
            subgrid.Height = (my_tu_shu + 3) * topimage.Height;

            for (int i = 0; i < shu / 2 + 3; i++)
            {
                try
                {
                    DataList.Data_Struct datastruct = (DataList.Data_Struct)thislist[i];
                    Label position = new Label();
                    position.Content = datastruct.位移量.ToString("#0.000") + " mm";
                    position.FontSize = 10;
                    position.Margin = new Thickness(0, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                    subgrid.Children.Add(position);
                    position.Foreground = System.Windows.Media.Brushes.White;

                    Label yidong = new Label();
                    yidong.Content = "  ";
                    yidong.FontSize = 10;
                    yidong.Width = datastruct.位移量 * 10;
                    yidong.Height = topimage.Height / 3;
                    yidong.VerticalAlignment = VerticalAlignment.Top;
                    yidong.HorizontalAlignment = HorizontalAlignment.Left;
                    yidong.Margin = new Thickness(140 - yidong.Width, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                    if (datastruct.位移量 <= 0.5)
                    {
                        yidong.Background = System.Windows.Media.Brushes.Blue;
                    }
                    if (datastruct.位移量 > 0.5 && datastruct.位移量 < 2)
                    {
                        yidong.Background = System.Windows.Media.Brushes.Yellow;
                    }
                    if (datastruct.位移量 >= 2)
                    {
                        yidong.Background = System.Windows.Media.Brushes.Red;
                    }
                    subgrid.Children.Add(yidong);



                    Label position1 = new Label();
                    position1.Content = datastruct.位置.ToString("#0");
                    position1.FontSize = 10;
                    position1.Margin = new Thickness(150, topimage.Height + i * ((my_tu_shu - 1) * topimage.Height) / (shu / 2), 0, 0);
                    subgrid.Children.Add(position1);


                    DataList.Data_Struct datastruct1 = (DataList.Data_Struct)thislist[shu - 1 - i];
                    Label position2 = new Label();
                    position2.Content = datastruct1.位移量.ToString("#0.000") + " mm";
                    position2.FontSize = 10;
                    position2.Margin = new Thickness(width, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                    subgrid.Children.Add(position2);
                    position2.Foreground = System.Windows.Media.Brushes.White;

                    Label yidong1 = new Label();
                    yidong1.Content = "  ";
                    yidong1.FontSize = 10;
                    yidong1.Width = datastruct1.位移量 * 10;
                    yidong1.Height = topimage.Height / 3;
                    yidong1.Margin = new Thickness(271, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                    yidong1.VerticalAlignment = VerticalAlignment.Top;
                    yidong1.HorizontalAlignment = HorizontalAlignment.Left;
                    if (datastruct1.位移量 <= 0.5)
                    {
                        yidong1.Background = System.Windows.Media.Brushes.Blue;
                    }
                    if (datastruct1.位移量 > 0.5 && datastruct.位移量 < 2)
                    {
                        yidong1.Background = System.Windows.Media.Brushes.Yellow;
                    }
                    if (datastruct1.位移量 >= 2)
                    {
                        yidong1.Background = System.Windows.Media.Brushes.Red;
                    }

                    subgrid.Children.Add(yidong1);

                    Label position3 = new Label();
                    position3.Content = datastruct1.位置.ToString("#0");
                    position3.FontSize = 10;
                    position3.Margin = new Thickness(230, topimage.Height + i * ((my_tu_shu - 1) * topimage.Height) / (shu / 2), 0, 0);
                    subgrid.Children.Add(position3);
                }
                catch { }
            }
        }

        private void init()
        {
            //int a = 0;
            // 用画来弄个柱子
            // 头
            Image topimage = new Image();
            string path = System.Environment.CurrentDirectory + "\\zhu_tou.png";
            BitmapImage imagetop = new BitmapImage(new Uri(path, UriKind.Absolute));
            topimage.Source = imagetop;
            topimage.Margin = new Thickness(left, 0, 0, 0);
            subgrid.Children.Add(topimage);
            topimage.VerticalAlignment = VerticalAlignment.Top;
            topimage.HorizontalAlignment = HorizontalAlignment.Left;
            topimage.Height = height;
            

            int shu = thislist.Count;
            int tu_shu = (shu + 1) / 2;
            double my_tu_shu = (double)tu_shu / 2 / 3 + 1;

            int a =(int)Math.Ceiling(my_tu_shu);

            for(int i=1;i<=a;i++)
            {
                Image shenimage = new Image();
                string shenpath = System.Environment.CurrentDirectory + "\\zhu_shen.png";
                BitmapImage imageshen = new BitmapImage(new Uri(shenpath, UriKind.Absolute));
                shenimage.Height = height;
                shenimage.Source = imageshen;
                shenimage.Margin = new Thickness(left, topimage.Height * i, 0, 0);
            //    shenimage.Width = width;
                subgrid.Children.Add(shenimage);
                shenimage.VerticalAlignment = VerticalAlignment.Top;
                shenimage.HorizontalAlignment = HorizontalAlignment.Left;
            }

            Image dimage = new Image();
            string dipath = System.Environment.CurrentDirectory + "\\zhu_di.png";
            BitmapImage imagedi = new BitmapImage(new Uri(dipath, UriKind.Absolute));
            dimage.Height = height;
            //dimage.Width = width;
            dimage.Source = imagedi;
            dimage.Margin = new Thickness(left, (my_tu_shu + 1) * topimage.Height, 0, 0);
            subgrid.Children.Add(dimage);
            dimage.VerticalAlignment = VerticalAlignment.Top;
            dimage.HorizontalAlignment = HorizontalAlignment.Left;

            subgrid.VerticalAlignment = VerticalAlignment.Top;
            subgrid.HorizontalAlignment = HorizontalAlignment.Left;
            subgrid.Margin = new Thickness(left, 0, 0, 0);
            subgrid.Height = (my_tu_shu + 3) * topimage.Height;

            for (int i = 0; i < shu / 2+3; i++)
            {
                try
                {
                    DataList.Data_Struct datastruct = (DataList.Data_Struct)thislist[i];
                    Label position = new Label();
                    position.Content = datastruct.位移量.ToString("#0.000") + " mm";
                    position.FontSize = 10;
                    position.Margin = new Thickness(0, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                    subgrid.Children.Add(position);
                    position.Foreground = System.Windows.Media.Brushes.White;

                    Label yidong = new Label();
                    yidong.Content = "  ";
                    yidong.FontSize = 10;
                    yidong.Width = datastruct.位移量*10;
                    yidong.Height = topimage.Height / 3;
                    yidong.VerticalAlignment = VerticalAlignment.Top;
                    yidong.HorizontalAlignment = HorizontalAlignment.Left;
                    yidong.Margin = new Thickness(140 - yidong.Width, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                    if (datastruct.位移量 <= 0.5)
                    {
                        yidong.Background = System.Windows.Media.Brushes.Blue;
                    }
                    if(datastruct.位移量>0.5 && datastruct.位移量<2)
                    {
                        yidong.Background = System.Windows.Media.Brushes.Yellow;
                    }
                    if (datastruct.位移量 >= 2 )
                    {
                        yidong.Background = System.Windows.Media.Brushes.Red;
                    }
                    subgrid.Children.Add(yidong);
                    


                    Label position1 = new Label();
                    position1.Content = datastruct.位置.ToString("#0");
                    position1.FontSize = 10;
                    position1.Margin = new Thickness(150, topimage.Height + i * ((my_tu_shu - 1) * topimage.Height) / (shu / 2), 0, 0);
                    subgrid.Children.Add(position1);


                    DataList.Data_Struct datastruct1 = (DataList.Data_Struct)thislist[shu-1 - i];
                    Label position2 = new Label();
                    position2.Content = datastruct1.位移量.ToString("#0.000") + " mm";
                    position2.FontSize = 10;
                    position2.Margin = new Thickness(width, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                    subgrid.Children.Add(position2);
                    position2.Foreground = System.Windows.Media.Brushes.White;

                    Label yidong1 = new Label();
                    yidong1.Content = "  ";
                    yidong1.FontSize = 10;
                    yidong1.Width = datastruct1.位移量*10;
                    yidong1.Height = topimage.Height / 3;
                    yidong1.Margin = new Thickness(271, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                    yidong1.VerticalAlignment = VerticalAlignment.Top;
                    yidong1.HorizontalAlignment = HorizontalAlignment.Left;
                    if (datastruct1.位移量 <= 0.5)
                    {
                        yidong1.Background = System.Windows.Media.Brushes.Blue;
                    }
                    if (datastruct1.位移量 > 0.5 && datastruct.位移量 < 2)
                    {
                        yidong1.Background = System.Windows.Media.Brushes.Yellow;
                    }
                    if (datastruct1.位移量 >= 2)
                    {
                        yidong1.Background = System.Windows.Media.Brushes.Red;
                    }
                    
                    subgrid.Children.Add(yidong1);

                    Label position3 = new Label();
                    position3.Content = datastruct1.位置.ToString("#0");
                    position3.FontSize = 10;
                    position3.Margin = new Thickness(230, topimage.Height + i * ((my_tu_shu - 1) * topimage.Height) / (shu / 2), 0, 0);
                    subgrid.Children.Add(position3);
                }
                catch { }

            }

            //for (int i = shu / 2+3; i < shu; i++)
            //{
            //    DataList.Data_Struct datastruct = (DataList.Data_Struct)thislist[i];
            //    Label position = new Label();
            //    position.Content = datastruct.位移量.ToString("#0.000")+" mm";
            //    position.FontSize = 10;
            //    position.Margin = new Thickness(width, (my_tu_shu+1 ) * topimage.Height - (i-(double)shu/2) * ((my_tu_shu) * topimage.Height) / ((double)shu - (double)shu / 2), 0, 0);
            //    subgrid.Children.Add(position);

            //    //DataList.Data_Struct datastruct = (DataList.Data_Struct)thislist[i];
            //    Label position1 = new Label();
            //    position1.Content = datastruct.位置.ToString("#0");
            //    position1.FontSize = 10;
            //    position1.Margin = new Thickness(220, (my_tu_shu + 1) * topimage.Height - (i - (double)shu / 2) * ((my_tu_shu) * topimage.Height) / ((double)shu - (double)shu / 2), 0, 0);
            //    subgrid.Children.Add(position1);
            //}
           
        }
    }
}
