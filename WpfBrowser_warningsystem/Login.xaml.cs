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

namespace WpfBrowser_warningsystem
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 :Window
    {
        //public Page1()
        //{
        //    InitializeComponent();
        //}
        public static string UserName = "";
        public static string PassWord = "";


        //string rootpath = Environment.CurrentDirectory;       //   系统路径
        string rootpath = "D:\\config";

        public Page1()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {

            this.Width = 300;
            this.Height = 250;
            // 窗体位置
            this.Left = MainWindow.screen_width / 2 - this.Width / 2;
            this.Top = MainWindow.scree_height * 0.35 - this.Height / 2;


            // 标题位置
            title.Margin = new Thickness(0, 0, 0, 0);
            title.Width = this.Width;
            title.Height = this.Height * 0.2; 

            // 
            label_username1.Margin = new Thickness(this.Width * 0.05, this.Height * 0.35, 0, 0);
            txt_UserName.Margin = new Thickness(this.Width * 0.25, this.Height * 0.35, 0, 0);

            label_password1.Margin = new Thickness(this.Width * 0.05, this.Height * 0.55, 0, 0);
            txt_PassWord.Margin = new Thickness(this.Width * 0.25, this.Height * 0.55, 0, 0);

            btn_ok.Margin = new Thickness(this.Width * 0.15, this.Height * 0.75, 0, 0);
            btn_cancel.Margin = new Thickness(this.Width * 0.6, this.Height * 0.75, 0, 0);

            title.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(rootpath + "\\title.png"))
            };

            maingrid.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(rootpath + "\\background.jpg"))
            };

            btn_ok.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(rootpath + "\\button.png"))
                
            };

            btn_cancel.Background = new ImageBrush
            {
                ImageSource=new BitmapImage(new Uri(rootpath+"\\button.png"))
            };
            

        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btn_ok_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btn_cancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
    }

