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
using System.Data;
using FileOperation;
using System.IO;
using String_Caozuo;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace WarningSystem
{
    /// <summary>
    /// MyView.xaml 的交互逻辑
    /// </summary>
    public partial class MyView : UserControl
    {
        public static string rootpath = Environment.CurrentDirectory;
        public static  double suofang = 1;
        public static double  origin_width = 0;   // 图片原始大小
        public static double origin_height = 0;
        private System.Windows.Forms.Timer show_warning_timer = new System.Windows.Forms.Timer();
        double now_pos_y = 0;
        double now_pos_x = 0;
        double pre_pos_x = 0;
        double pre_pos_y = 0;
        double myimage_left = 0;
        double myimage_top = 0;

        int warn_index = 0;                                       // 报警索引

        public static string show_point_name = "";                // 展示点的名称   空为全部展示

        ArrayList warnpoint_arraylist = new ArrayList();
        public static ArrayList all_dizhuang_list = new ArrayList();     // 所有的地桩点
        public static ArrayList all_line_list = new ArrayList();
        public static ArrayList all_putong_point = new ArrayList();      // 所有的普通点

        DateTime oldupdate_time = new DateTime();

        private bool move_enable = false;

        public bool warn_bofang1 = false;
        public bool warn_bofang2 = false;

        System.Media.SoundPlayer player = new System.Media.SoundPlayer("warn.wav");

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        ArrayList all_warn_list = new ArrayList();                    //所有的表

        bool play_is = false;
        
        public MyView()
        {
            InitializeComponent();
            datascrollviewer.Visibility = Visibility.Hidden;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Warn_Tick);
            timer.Enabled = true;
            init_view();
            

        }
        struct BITMAPFILEHEADER
        {
            public short bfType;
            public int bfSize;
            public short bfReserved1;
            public short bfReserved2;
            public int bfOffBits;
        }
        public static System.Drawing.Image GetDwgImage(string FileName)
        {
            if (!(File.Exists(FileName)))
            {
                throw new FileNotFoundException("文件没有被找到");
            }

            FileStream DwgF = null;   //文件流
            int PosSentinel;   //文件描述块的位置
            BinaryReader br = null;   //读取二进制文件
            int TypePreview;   //缩略图格式
            int PosBMP;    //缩略图位置 
            int LenBMP;    //缩略图大小
            short biBitCount; //缩略图比特深度 
            BITMAPFILEHEADER biH; //BMP文件头，DWG文件中不包含位图文件头，要自行加上去
            byte[] BMPInfo;    //包含在DWG文件中的BMP文件体
            MemoryStream BMPF = new MemoryStream(); //保存位图的内存文件流
            BinaryWriter bmpr = new BinaryWriter(BMPF); //写二进制文件类
            System.Drawing.Image myImg = null;
            try
            {

                DwgF = new FileStream(FileName, FileMode.Open, FileAccess.Read); //文件流

                br = new BinaryReader(DwgF);
                DwgF.Seek(13, SeekOrigin.Begin); //从第十三字节开始读取
                PosSentinel = br.ReadInt32();   //第13到17字节指示缩略图描述块的位置
                DwgF.Seek(PosSentinel + 30, SeekOrigin.Begin);   //将指针移到缩略图描述块的第31字节
                TypePreview = br.ReadByte();   //第31字节为缩略图格式信息，2 为BMP格式，3为WMF格式
                if (TypePreview == 1)
                {
                }
                else if (TypePreview == 2 || TypePreview == 3)
                {
                    PosBMP = br.ReadInt32(); //DWG文件保存的位图所在位置
                    LenBMP = br.ReadInt32(); //位图的大小
                    DwgF.Seek(PosBMP + 14, SeekOrigin.Begin); //移动指针到位图块
                    biBitCount = br.ReadInt16(); //读取比特深度
                    DwgF.Seek(PosBMP, SeekOrigin.Begin); //从位图块开始处读取全部位图内容备用
                    BMPInfo = br.ReadBytes(LenBMP); //不包含文件头的位图信息
                    br.Close();
                    DwgF.Close();
                    biH.bfType = 19778; //建立位图文件头
                    if (biBitCount < 9)
                    {
                        biH.bfSize = 54 + 4 * (int)(Math.Pow(2, biBitCount)) + LenBMP;
                    }
                    else
                    {
                        biH.bfSize = 54 + LenBMP;
                    }
                    biH.bfReserved1 = 0; //保留字节
                    biH.bfReserved2 = 0; //保留字节
                    biH.bfOffBits = 14 + 40 + 1024; //图像数据偏移
                    //以下开始写入位图文件头
                    bmpr.Write(biH.bfType); //文件类型
                    bmpr.Write(biH.bfSize);   //文件大小
                    bmpr.Write(biH.bfReserved1); //0
                    bmpr.Write(biH.bfReserved2); //0
                    bmpr.Write(biH.bfOffBits); //图像数据偏移
                    bmpr.Write(BMPInfo); //写入位图
                    BMPF.Seek(0, SeekOrigin.Begin); //指针移到文件开始处 
                    myImg = System.Drawing.Image.FromStream(BMPF); //创建位图文件对象                    
                    bmpr.Close();
                    BMPF.Close();
                }
                return myImg;
            }
            catch (EndOfStreamException)
            {
                throw new EndOfStreamException("文件不是标准的DWG格式文件，无法预览！");
            }
            catch (IOException ex)
            {
                if (ex.Message == "试图将文件指针移到文件开头之前。/r/n")
                {
                    throw new IOException("文件不是标准的DWG格式文件，无法预览！");
                }
                else if (ex.Message == "文件“" + FileName + "”正由另一进程使用，因此该进程无法访问该文件。")
                {
                    //复制文件，继续预览
                    File.Copy(FileName, Environment.CurrentDirectory + "\\map.dwg", true);
                    System.Drawing.Image image = GetDwgImage(Environment.CurrentDirectory + "\\map.dwg");
                    File.Delete(Environment.CurrentDirectory + "\\map.dwg");
                    return image;
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (DwgF != null)
                {
                    DwgF.Close();
                }
                if (br != null)
                {
                    br.Close();
                }
                bmpr.Close();
                BMPF.Close();

            }
        }
        public static System.Drawing.Image ShowDWG(int Pwidth, int PHeight, string FilePath)
        {
            System.Drawing.Image image = GetDwgImage(FilePath);
            Bitmap bitmap = new Bitmap(image);
            int Height = bitmap.Height;
            int Width = bitmap.Width;
            Bitmap newbitmap = new Bitmap(Width, Height);
            Bitmap oldbitmap = (Bitmap)bitmap;
            System.Drawing.Color pixel;
            for (int x = 1; x < Width; x++)
            {
                for (int y = 1; y < Height; y++)
                {

                    pixel = oldbitmap.GetPixel(x, y);
                    int r = pixel.R, g = pixel.G, b = pixel.B;
                    if (pixel.Name == "ffffffff" || pixel.Name == "ff000000")
                    {
                        r = 255 - pixel.R;
                        g = 255 - pixel.G;
                        b = 255 - pixel.B;
                    }

                    newbitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(r, g, b));
                }
            }
            Bitmap bt = new Bitmap(newbitmap, Pwidth, PHeight);

            return newbitmap;
        }
        private void Warn_Tick(object sender,EventArgs e)
        {
            try
            {

                // 报警

                 // 试验
                show.Content = MainWindow.copyed_num.ToString() + ":" + MainWindow.all_file_num.ToString();
                try
                {
                    string mystring = (string)all_warn_list[warn_index];
                    label_warninfo.Content = mystring;
                    warn_index++;
                }
                catch { warn_index = 0; label_warninfo.Content = ""; }

                if (warn_bofang1 == true || warn_bofang2==true)
                {
                    if (play_is == false)
                    {
                        player.PlayLooping();
                        play_is = true;
                    }
                }
                else
                {
                    player.Stop();
                    play_is = false;
                }
            }
            catch { }
        }


       
            

        private void init_view()
        {
            Imageborder.Margin = new Thickness(0.005 * MainWindow.screen_width, 0.07 * MainWindow.scree_height, 0, 0);
            Imageborder.Width = 0.96 * MainWindow.screen_width;
            Imageborder.Height = 0.81 * MainWindow.scree_height;

            ImageScrollviewer.Margin = new Thickness(0.01, 0.01, 0, 0);
            ImageScrollviewer.Width = 0.96 * MainWindow.screen_width;
            Imageborder.Height = 0.78 * MainWindow.scree_height;

            myimage.Margin = new Thickness(0, 0, 0, 0);
            myimage.Width =  0.96* MainWindow.screen_width;
            myimage.Height = 0.78 * MainWindow.scree_height;

            // 放缩标签
            label_suofang.Margin = new Thickness(0.25 * MainWindow.screen_width, 0.8 * MainWindow.scree_height, 0, 0);

            try
            {
                //myimage.Source = BitmapToBitmapImage((Bitmap)ShowDWG((int)myimage.Width, (int)myimage.Height, rootpath + "\\map.dwg"));
                myimage.Source = new BitmapImage(new Uri(rootpath + "//pic.png", UriKind.RelativeOrAbsolute));
            }
            catch { MessageBox.Show("地图图片未找到！"); System.Environment.Exit(0); }
            
            // 放大与缩小的按钮
            btn_fangda.Margin = new Thickness(0.05 * MainWindow.screen_width, 0.82 * MainWindow.scree_height, 0, 0);
            btn_suoxiao.Margin = new Thickness(0.15 * MainWindow.screen_width, 0.82 * MainWindow.scree_height, 0, 0);

            // 放缩滑动块
            image_slider.Margin = new Thickness(0.35 * MainWindow.screen_width, 0.77 * MainWindow.scree_height, 0, 0);

            // 原始大小
            origin_width = myimage.Width;
            origin_height = myimage.Height;

            // 报警列表外框
            //warning_list_scrollviewer.Margin = new Thickness(0.05 * MainWindow.screen_width, 0.55 * MainWindow.scree_height, 0, 0);
            //warning_list_scrollviewer.Width = 0.3 * MainWindow.screen_width;
            //warning_list_scrollviewer.Height = 0.3 * MainWindow.scree_height;

            datascrollviewer.Margin = new Thickness(0.80 * MainWindow.screen_width, 0.07 * MainWindow.scree_height, 0, 0);
            datascrollviewer.Width = 0.185 * MainWindow.screen_width;
            datascrollviewer.Height = 0.80 * MainWindow.scree_height;

            // 报警列表
            //warn_list.Margin = new Thickness(0, 0, 0, 0);
            //warn_list.Width = warning_list_scrollviewer.Width;
            //warn_list.Height = warning_list_scrollviewer.Height;

            myDataList.Margin = new Thickness(0, 0, 0, 0);
            myDataList.Width = datascrollviewer.Width;
            myDataList.Height = datascrollviewer.Height;

            // 报警列表标签
            //label_warnlist.Margin = new Thickness(0.05*MainWindow.screen_width, 0.48*MainWindow.scree_height, 0, 0);

            
            

            //warn_list.Start();

            // 实时数据标签
            //label_data.Margin = new Thickness(0.4 * MainWindow.screen_width, 0.49 * MainWindow.scree_height, 0, 0);

            // 更新时间标签
            label_updatetime.Margin = new Thickness(0.72 * MainWindow.screen_width, 0.01 * MainWindow.scree_height, 0, 0);
            label_warninfo.Margin = new Thickness(0.3 * MainWindow.screen_width, 0.01 * MainWindow.scree_height, 0, 0);

            // 报警时钟
            show_warning_timer.Interval = 2000;
            show_warning_timer.Enabled = true;
            show_warning_timer.Tick += new EventHandler(Warn_Timer_Tick);

            timer1.Interval = 10000;
            timer1.Tick += new EventHandler(My_Warn_Tick);
            timer1.Enabled = true;

           // ImageScrollviewer.scrolle
           //ImageScrollviewer.MouseWheel +=new MouseWheelEventHandler(wheel);
            
        }

        public void wheel(object sender,EventArgs e)
        {

        }
        public BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            Bitmap bitmapSource = new Bitmap(bitmap.Width, bitmap.Height);
            int i, j;
            for (i = 0; i < bitmap.Width; i++)
                for (j = 0; j < bitmap.Height; j++)
                {
                    System.Drawing.Color pixelColor = bitmap.GetPixel(i, j);
                    System.Drawing.Color newColor = System.Drawing.Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    bitmapSource.SetPixel(i, j, newColor);
                }
            MemoryStream ms = new MemoryStream();
            bitmapSource.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(ms.ToArray());
            bitmapImage.EndInit();

            return bitmapImage;
        }

        public void putong_warn()
        {
            all_warn_list.Clear();

            try
            {
                bool warning_is = false;

                foreach (putongpoint point in all_putong_point)
                {
                    try
                    {
                       
                        double position = double.Parse(point.key);
                        int index = MainWindow.Dizhi_Index.IndexOf(position);
                        DataList.Data_Struct data_struct = (DataList.Data_Struct)MainWindow.Real_Data_List[index];

                        point.weiyi = data_struct.应变量;
                       

                        if (point.key == data_struct.位置.ToString())
                        {
                            
                            try
                            {
                                point.weiyi = data_struct.位移量;
                                if (point.weiyi >= MainWindow.yuzhi)
                                {
                                    string warn_string = "报警位置：" + data_struct.位置.ToString() + "  位移值：" + data_struct.位移量.ToString() + "mm";
                                    all_warn_list.Add(warn_string);

                                    point.Set_Warn_is();
                                    warning_is = true;
                                    warn_bofang1 = true;
                                }

                                else
                                    point.Set_Warn_is_not();
                               
                            }
                            catch { }
                        }

                    }
                    catch { }
                }

                if (warning_is == false) warn_bofang1 = false;

            }
            catch { }
        }
        private void My_Warn_Tick(object sender,EventArgs e)
        {
            putong_warn();
        }

        private void Warn_Timer_Tick(object sender,EventArgs e)
        {
            bool warning_is = false;                              // 是否产生了报警
            try
            {
                bool gengxin_is = false;                              // 更新标志
                

                //warn_bofang = false;
                //Show_Warning_List();
                ArrayList show_arraylist = new ArrayList();
                //myDataList.Set_Table(MainWindow.Real_Data_List);
                label_updatetime.Content = "更新时间：" + MainWindow.updatetime.ToString("yyyy-MM-dd HH:mm:ss");
                if (MainWindow.updatetime != oldupdate_time)
                {
                    oldupdate_time = MainWindow.updatetime;   // 更新了
                    gengxin_is = true;
                }

                // 在表格上显示有效的数据
                if (show_point_name != "")
                {
                    datascrollviewer.Visibility = Visibility.Visible;
                    foreach (DataList.Data_Struct data_struct in MainWindow.Real_Data_List)
                    {
                        bool isexit = false;
                        for (int i = 0; i < MainWindow.zhuzi_name.Length; i++)
                        {
                            if (data_struct.位置 >= MainWindow.rukou[i] && data_struct.位置 <= MainWindow.chukou[i] && MainWindow.zhuzi_name[i] == show_point_name)
                            {
                                // 选定特定的名称
                                isexit = true;
                                break;
                            }

                        }
                        if (isexit == true)
                        {
                            show_arraylist.Add(data_struct);
                        }

                    }
                    myDataList.Set_Table(show_arraylist);
                }

                foreach (DiZhuang_Item item in all_dizhuang_list)
                {
                    item.Background = System.Windows.Media.Brushes.Transparent;
                }

                foreach (myline item in all_line_list)
                {
                    item.warn_is = false;
                    item.Draw_Line();
                }
                if (true)
                {
                    // 全部展示
                    foreach (DataList.Data_Struct data_struct in MainWindow.Real_Data_List)
                    {
                        bool isexit = false;
                        for (int i = 0; i < MainWindow.zhuzi_name.Length; i++)
                        {
                            if (data_struct.位置 >= MainWindow.rukou[i] && data_struct.位置 <= MainWindow.chukou[i])
                            {
                                isexit = true;

                                // 在这里判断报警信息
                                if (data_struct.位移量 >= MainWindow.yuzhi && warning_is == false && gengxin_is == true)
                                {
                                    // 产生了报警
                                    // 报警信息：点名称  位置  位移量
                                    warning_is = true;
                                    FileCaozuo.Create_File("D:\\config\\warning\\" + MainWindow.updatetime.ToString("yyyy MM dd HH mm ss") + ".txt");
                                    string warn_string = "报警位置：" + data_struct.位置.ToString() + "  位移值：" + data_struct.位移量.ToString() + "mm";
                                    all_warn_list.Add(warn_string);

                                }

                                if (data_struct.位移量 >= MainWindow.yuzhi)
                                {
                                    foreach (DiZhuang_Item item in all_dizhuang_list)
                                    {
                                        if (item.label_center.Content.ToString() == MainWindow.zhuzi_name[i])
                                        {
                                            item.Background = System.Windows.Media.Brushes.Red;
                                            warning_is = true;
                                            warn_bofang2 = true;
                                            break;
                                        }
                                    }

                                    foreach (myline item in all_line_list)
                                    {
                                        if (item.Key == MainWindow.zhuzi_name[i])
                                        {
                                            item.warn_is = true;
                                            warning_is = true;
                                            warn_bofang2 = true;
                                            item.Draw_Line();
                                            break;
                                        }
                                    }
                                }
                                if (data_struct.位移量 >= MainWindow.yuzhi && gengxin_is == true)
                                {
                                    // 写入报警信息
                                    StreamWriter sw = new StreamWriter("D:\\config\\warning\\" + MainWindow.updatetime.ToString("yyyy MM dd HH mm ss") + ".txt", true);    // 向文件尾加入报警信息
                                    sw.WriteLine(MainWindow.zhuzi_name[i] + " " + data_struct.位置.ToString() + " " + data_struct.位移量.ToString());
                                    sw.Close();
                                }
                                break;
                            }

                        }
                        if (isexit == true && show_point_name == "")
                        {
                            show_arraylist.Add(data_struct);
                        }

                    }
                    if (show_point_name == "")
                    {
                        datascrollviewer.Visibility = Visibility.Hidden;
                        myDataList.Set_Table(show_arraylist);
                    }
                    if (warning_is == false) warn_bofang2 = false;
                }

                
            }
            catch
            {
                 
            } 

        }

        private void Image_Suofang(double suofang)
        {
            double mywidth = origin_width * suofang;
            double myheight = origin_height * suofang;

            myimage.Margin = new Thickness(myimage.Margin.Left - (mywidth - myimage.Width) / 2, myimage.Margin.Top - (myheight - myimage.Height) / 2, 0, 0);

            myimage.Width = mywidth;
            myimage.Height = myheight;
            //myimage
            image_slider.Value = suofang;
            label_suofang.Content = "缩放大小：" + Math.Round(suofang,2).ToString();
            Reset_All_Point();
           
        }

        public  void Reset_All_Point()
        {
            foreach (DiZhuang_Item item in all_dizhuang_list)
            {
                item.Margin = new Thickness(item.pos_x * suofang + myimage.Margin.Left + Imageborder.Margin.Left - item.Width / 2- ImageScrollviewer.HorizontalOffset, item.pos_y * suofang + Imageborder.Margin.Top + myimage.Margin.Top - item.Height / 2 - ImageScrollviewer.ContentVerticalOffset, 0, 0);
                if (item.Margin.Left + item.Width > Imageborder.Margin.Left + Imageborder.Width || item.Margin.Left < Imageborder.Margin.Left || item.Margin.Top - item.Height > Imageborder.Margin.Top + Imageborder.Height || item.Margin.Top < Imageborder.Margin.Top)
                {
                    item.Visibility = Visibility.Hidden;
                }
                else
                {
                    item.Visibility = Visibility.Visible;
                }
            }

            foreach (myline item in all_line_list)
            {
                item.Width = suofang * item.mywidth;
                item.Height = suofang * item.myheight;
                item.Margin = new Thickness(item.pos_x * suofang + myimage.Margin.Left + Imageborder.Margin.Left - item.Width / 2-ImageScrollviewer.HorizontalOffset, item.pos_y * suofang + Imageborder.Margin.Top + myimage.Margin.Top - item.Height / 2-ImageScrollviewer.VerticalOffset, 0, 0);
                item.Draw_Line();
                Console.WriteLine("left:" + item.Margin.Left.ToString() + " top:" + item.Margin.Top.ToString());
                if (item.Margin.Left + item.Width > Imageborder.Margin.Left + Imageborder.Width || item.Margin.Left < Imageborder.Margin.Left || item.Margin.Top - item.Height > Imageborder.Margin.Top + Imageborder.Height || item.Margin.Top < Imageborder.Margin.Top)
                {
                    item.Visibility = Visibility.Hidden;
                }
                else
                {
                    item.Visibility = Visibility.Visible;
                }
            }
            foreach (putongpoint item in all_putong_point)
            {
                item.Margin = new Thickness(item.pos_x * suofang + myimage.Margin.Left + Imageborder.Margin.Left - item.Width / 2-ImageScrollviewer.HorizontalOffset, item.pos_y * suofang + Imageborder.Margin.Top + myimage.Margin.Top - item.Height / 2-ImageScrollviewer.VerticalOffset, 0, 0);
                
                ScaleTransform scaleTransform = new ScaleTransform();
                scaleTransform.ScaleX = 1 + suofang * 0.1;
                scaleTransform.ScaleY = 1 + suofang * 0.1;
                item.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                item.RenderTransform = scaleTransform;
                
                if (item.Margin.Left + item.Width > Imageborder.Margin.Left + Imageborder.Width || item.Margin.Left < Imageborder.Margin.Left || item.Margin.Top + item.Height > Imageborder.Margin.Top + Imageborder.Height || item.Margin.Top < Imageborder.Margin.Top)
                {
                    item.Visibility = Visibility.Hidden;
                }
                else
                {
                    item.Visibility = Visibility.Visible;
                }
            }
        }

        public void Read_All_Point()
        {
            // 读取所有的点
            ArrayList list = MainWindow.Point_ini.ReadSections();

            

            // 去掉点
            foreach (DiZhuang_Item item in all_dizhuang_list)
            {
                maingrid.Children.Remove(item);
            }
            all_dizhuang_list.Clear();
            
            foreach(myline item in all_line_list)
            {
                maingrid.Children.Remove(item);

            }
            all_line_list.Clear();

            foreach(putongpoint item in all_putong_point)
            {
                maingrid.Children.Remove(item);
            }

            all_putong_point.Clear();

            foreach (string name in list)
            {
                //  加入点
                // 加入普通图片
                if (string_caozuo.Get_Xiahuaxian_String(name, 2) == "putong")
                {
                    try
                    {
                        double width = double.Parse(MainWindow.Point_ini.IniReadValue(name, "width"));     // 图片宽度
                        double height = double.Parse(MainWindow.Point_ini.IniReadValue(name, "height"));   // 图片高度

                        double pos_x = double.Parse(MainWindow.Point_ini.IniReadValue(name, "pos_x"));     // 图片X位置 
                        double pos_y = double.Parse(MainWindow.Point_ini.IniReadValue(name, "pos_y"));     // 图片Y位置

                        int count = int.Parse(MainWindow.Point_ini.IniReadValue(name, "count"));           // 的数量
                        double[] x_arr = new double[count];
                        double[] y_arr = new double[count];

                        for(int i=1;i<=count;i++)
                        {
                            x_arr[i - 1] = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X" + i.ToString()));
                            y_arr[i - 1] = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y" + i.ToString()));

                        }

                        putong myputong = new putong(x_arr, y_arr);
                        myputong.Width = width;
                        myputong.Height = height;

                        myputong.Margin = new Thickness(pos_x - width / 2, pos_y - height / 2, 0, 0);
                        
                        maingrid.Children.Add(myputong);


                    }
                    catch { }
                }

                // 加入线
                #region
                if (string_caozuo.Get_Xiahuaxian_String(name, 2) == "line")
                {

                    //double x1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X1"));
                    //double y1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y1"));
                    //double x2 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X2"));
                    //double y2 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y2"));

                    //double 
                    try
                    {
                        double width = double.Parse(MainWindow.Point_ini.IniReadValue(name, "width"));     // 图片宽度
                        double height = double.Parse(MainWindow.Point_ini.IniReadValue(name, "height"));   // 图片高度

                        double pos_x = double.Parse(MainWindow.Point_ini.IniReadValue(name, "pos_x"));     // 图片X位置 
                        double pos_y = double.Parse(MainWindow.Point_ini.IniReadValue(name, "pos_y"));     // 图片Y位置

                        int count = int.Parse(MainWindow.Point_ini.IniReadValue(name, "count"));           // 的数量
                        double[] x_arr = new double[count];
                        double[] y_arr = new double[count];

                        for (int i = 1; i <= count; i++)
                        {
                            x_arr[i - 1] = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X" + i.ToString()));
                            y_arr[i - 1] = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y" + i.ToString()));

                        }


                        myline item = new myline(x_arr, y_arr);
                        item.Key = name;




                        item.mywidth = item.Width;
                        item.myheight = item.Height;

                        //item.Margin = new Thickness(x * suofang + myimage.Margin.Left + Imageborder.Margin.Left - item.Width / 2, y * suofang + myimage.Margin.Top + Imageborder.Margin.Top - item.Height / 2, 0, 0);

                        item.Width = width;
                        item.Height = height;

                        item.Margin = new Thickness(pos_x - width / 2, pos_y - height / 2, 0, 0);
                        //maingrid.Children.Add(myputong);


                        maingrid.Children.Add(item);
                        all_line_list.Add(item);

                    }
                    catch { }

                }
                #endregion

                // 加入点
                #region
                if (string_caozuo.Get_Xiahuaxian_String(name, 2) == null)
                {

                    DiZhuang_Item item = new DiZhuang_Item();

                    item.edit_able = false;
                    double x = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X"));
                    double y = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y"));
                    try
                    {
                        item.Set_Center(name);
                        item.Set_Left(int.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou")));
                        item.Set_Right(int.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou")));
                        item.pos_x = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X"));
                        item.pos_y = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y"));
                    }
                    catch { }
                    item.Margin = new Thickness(x * suofang + myimage.Margin.Left + Imageborder.Margin.Left - item.Width / 2, y * suofang + myimage.Margin.Top + Imageborder.Margin.Top - item.Height / 2, 0, 0);

                    maingrid.Children.Add(item);
                    all_dizhuang_list.Add(item);

                }
                #endregion

                // 加入群点

                #region
                if (string_caozuo.Get_Xiahuaxian_String(name, 2) == "points")
                {
                    int points_count = 0;
                    int my_count = 0;
                    double rukou = double.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou"));
                    double chukou = double.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou"));
                    double X1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X1"));
                    double X2 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X2"));
                    double Y1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y1"));
                    double Y2 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y2"));
                    points_count = (int)(Math.Abs(chukou - rukou) * 5);
                    foreach (DataList.Data_Struct item in MainWindow.Real_Data_List)
                    {
                        if (item.位置 >= rukou && item.位置 <= chukou)
                        {
                            try
                            {
                                my_count++;
                                double x = (X2 - X1) / points_count * my_count + X1;
                                double y = (Y2 - Y1) / points_count * my_count + Y1;

                                putongpoint point = new putongpoint(x, y);
                                point.key = item.位置.ToString();
                                point.Width = 2;
                                point.Height = 2;
                                point.Margin = new Thickness(x * suofang + myimage.Margin.Left + Imageborder.Margin.Left - point.Width / 2, y * suofang + myimage.Margin.Top + Imageborder.Margin.Top - point.Height / 2, 0, 0);
                               // maingrid.Children.Add(point);
                               // point.Visibility = Visibility.Hidden;
                                all_putong_point.Add(point);
                            }
                            catch { }
                        }

                    }

                }

                #endregion
            }

        }


       public void Read_Real_Data()
        {
            try
            {


                DateTime newtime = new DateTime();
                DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);

                ArrayList allpoints = MainWindow.Point_ini.ReadSections();            // 地图上所有的点
                bool is_exit = false;                                      // 是否在柱子上


                foreach (DirectoryInfo dir in dirs)
                {
                    try
                    {
                        string nowtime_string = dir.Name;
                        string nowtime_sub_string = nowtime_string.Substring(4, nowtime_string.Length - 4);
                        string year = nowtime_sub_string.Substring(0, 4);
                        string month = nowtime_sub_string.Substring(4, 2);
                        string day = nowtime_sub_string.Substring(6, 2);
                        string hour = nowtime_sub_string.Substring(8, 2);
                        string min = nowtime_sub_string.Substring(10, 2);
                        DateTime nowtime = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min + ":00");
                        if (nowtime > newtime) newtime = nowtime;
                    }
                    catch { }
                }

                string newpath = MainWindow.path + "data" + newtime.ToString("yyyyMMddHHmm") + "\\";


                ArrayList filelist = FileCaozuo.Read_All_Files(newpath, "*.txt");
                ArrayList timelist = new ArrayList();                                      // 时间列表
                foreach (string name in filelist)
                {
                    // 每个文件的的名称
                    string filename = string_caozuo.Get_Dian_String(name, 1);
                    string mydate = string_caozuo.Get_HengGang_String(filename, 1);
                    string mytime = string_caozuo.Get_HengGang_String(filename, 2);
                    string year = string_caozuo.Get_Xiahuaxian_String(mydate, 1);
                    string month = string_caozuo.Get_Xiahuaxian_String(mydate, 2);
                    string day = string_caozuo.Get_Xiahuaxian_String(mydate, 3);

                    string hour = string_caozuo.Get_Xiahuaxian_String(mytime, 1);
                    string min = string_caozuo.Get_Xiahuaxian_String(mytime, 2);
                    string sec = string_caozuo.Get_Xiahuaxian_String(mytime, 3);
                    DateTime nowtime = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min + ":" + sec);
                    timelist.Add(nowtime);
                }

                DateTime maxtime = new DateTime();
                DateTime mintime = DateTime.Now;
                // 找出最近的时候
                foreach (DateTime time in timelist)
                {
                    if (time >= maxtime)
                    {
                        maxtime = time;
                    }
                    if (time < mintime)
                    {
                        mintime = time;
                    }
                }

                MainWindow.updatetime = maxtime;       //更新时间
                // 最新的文件就是maxtime的文件
                string nowfilename = maxtime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";
                string oldfilename = mintime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";


                // 读取些文件信息
                // 最新值
                string[] all_line = FileCaozuo.Read_All_Line(newpath + nowfilename);



                double position = 0;
                double value = 0;

                // 标准值
                string[] all_line_old = FileCaozuo.Read_All_Line(newpath + oldfilename);
                double value_old = 0;


                //MainWindow.Real_Data_List.Clear();

                for (int i = 0; i < all_line.Length; i++)
                {
                    try
                    {

                        string str_new = all_line[i];
                        string str_old = all_line_old[i];
                        position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                        value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                        value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

                        DataList.Data_Struct datasrtuct = new DataList.Data_Struct();
                        datasrtuct.位置 = position;
                        datasrtuct.位置X = 0;
                        datasrtuct.位置Y = 0;
                        datasrtuct.应变量 = double.Parse(Math.Abs(value - value_old).ToString("#0.0000"));
                        datasrtuct.位移量 = double.Parse(Jisuan_Weiyi(Math.Abs(value - value_old)).ToString("#0.0000"));
                        // 将值放入数据队列中
                        if (MainWindow.Real_Data_List.Count < all_line.Length)
                        {
                            MainWindow.Real_Data_List.Add(datasrtuct);
                            MainWindow.Dizhi_Index.Add(position);
                        }
                        else
                        {
                            MainWindow.Real_Data_List[i] = datasrtuct;
                            MainWindow.Dizhi_Index[i] = position;
                        }

                    }
                    catch { }

                    //int a = 0;
                }
                //myreal_data_list = Real_Data_List;
            }
            catch { }
        }

       public static double Jisuan_Weiyi(double value)
       {
           value = Math.Abs(value);
           value = (value - value * Math.Sqrt(3) / 2) / 0.0482;       // 应变 *1000/0.0482
           // 温度 *1000/1.12

           return value;
       }

        private void Show_Warning_List()
        {
            //List<Warning_List.WarnData> list=warn_list.warnlist;
            //foreach (WarnPoint point in warnpoint_arraylist)
            //{
            //    try
            //    {
            //        maingrid.Children.Remove(point);
            //    }
            //    catch { }
            //}
            //warnpoint_arraylist.Clear();
            //foreach(WarningSystem.Warning_List.WarnData mydata in list)
            //{
            //    WarnPoint point = new WarnPoint();
            //    point.x = mydata.地点X坐标;
            //    point.y = mydata.地点Y坐标;
            //    point.key = mydata.报警时间.ToString();
            //    point.Margin = new Thickness((Imageborder.Margin.Left + point.x)*suofang - ImageScrollviewer.ContentHorizontalOffset, (Imageborder.Margin.Top + point.y)*suofang - ImageScrollviewer.ContentVerticalOffset, 0, 0);
            //    double Point_Offset_X = (Imageborder.Margin.Left + point.x) * suofang - ImageScrollviewer.ContentHorizontalOffset;
            //    double Point_Offset_Y = (Imageborder.Margin.Top + point.y) * suofang - ImageScrollviewer.ContentVerticalOffset;
            //    warnpoint_arraylist.Add(point);

            //    if (Point_Offset_X - Imageborder.Margin.Left >= 0 && Point_Offset_X - Imageborder.Margin.Left <= Imageborder.Width && Point_Offset_Y - Imageborder.Margin.Top >= 0 && Point_Offset_Y - Imageborder.Margin.Top <= Imageborder.Height*0.85)
            //        maingrid.Children.Add(point);
            //}

        }

        private void btn_fangda_Click(object sender, RoutedEventArgs e)
        {
            // 放大
            if(suofang<=5)
            {
                suofang = suofang + 0.13;
            }
            if(suofang>5)
            {
                suofang = 5;
            }
            
            Image_Suofang(suofang);
            //label_suofang.Content = "缩放大小："+suofang.ToString();
        }

        private void btn_suoxiao_Click(object sender, RoutedEventArgs e)
        {
            // 缩小
            if (suofang >= 1)
            {
                suofang = suofang - 0.13;
            }
            if (suofang < 1)
            {
                suofang = 1;
            }
            Image_Suofang(suofang);
            Show_Warning_List();
            
        }

        private void image_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            suofang = image_slider.Value;
            Image_Suofang(suofang);
        }

        private void myimage_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (suofang <= 20)
                {
                    suofang = suofang + 0.1;
                }
                if (suofang > 20)
                {
                    suofang = 5;
                }
            }

            if (e.Delta < 0)
            {
                if (suofang >= 1)
                {
                    suofang = suofang - 0.1;
                }
                if (suofang < 1)
                {
                    suofang = 1;
                }
            }

            Image_Suofang(suofang);
        }

        private void myimage_MouseDown(object sender, MouseButtonEventArgs e) 
        {
            move_enable = true;
            pre_pos_x = e.GetPosition(Imageborder).X;
            pre_pos_y = e.GetPosition(Imageborder).Y;
        }

        private void myimage_MouseMove(object sender, MouseEventArgs e)
        {
            if (move_enable == true)
            {
                // 这一次的坐标
                now_pos_x = e.GetPosition(Imageborder).X;
                now_pos_y = e.GetPosition(Imageborder).Y;

                double move_x = now_pos_x - pre_pos_x;
                double move_y = now_pos_y - pre_pos_y;

                // 移动图片

                myimage.Margin = new Thickness(myimage.Margin.Left + move_x, myimage.Margin.Top + move_y, 0, 0);
                pre_pos_x = now_pos_x;
                pre_pos_y = now_pos_y;
                myimage_left = myimage.Margin.Left;
                myimage_top = myimage.Margin.Top;
                Reset_All_Point();

                //myimage.Top = myimage.Margin.Top + move_y;
            }
        }

        private void myimage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            move_enable = false;
        }

        private void ImageScrollviewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
           
            //Reset_All_Point();
            
        }

        private void Imageborder_MouseWheel(object sender, MouseWheelEventArgs e)
        {

        }
    }
}
