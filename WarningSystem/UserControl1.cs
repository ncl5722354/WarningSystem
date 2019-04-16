using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections;
using System.Collections.Generic;
using FileOperation;

using Microsoft.Reporting.WinForms;

namespace WarningSystem
{
    public partial class myreportview : UserControl
    {
        //printPreviewDialog 
        PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        DataGridViewPrinter printer1;
        PrintDocument printDocument1 = new PrintDocument();
        public myreportview()
        {
            InitializeComponent();
            //reportViewer1.da
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        public void Reset_Report(DataTable dt)
        {
            if (dt == null)
            {
                return;
            }



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // 日期上显示是否有这一天
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print1();
        }
        private void Print1()
        {
            if (System.Windows.Forms.MessageBox.Show("是否要预览打印文档", "打印预览", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.printPreviewDialog1.UseAntiAlias = true;
                this.printPreviewDialog1.Document = this.printDocument1;

                printer1 = new DataGridViewPrinter(dataGridView1, printDocument1, true, true,
                "坝体位移日报表", DateTime.Now.ToString("yyyy-MM-dd"), new Font("宋体", 30, FontStyle.Regular),
                new Font("宋体", 30, FontStyle.Regular), Color.Black);
                printPreviewDialog1.ShowDialog();

            }
            else
            {
                this.printDocument1.Print();//不预览，直接打印
            }
        }


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            //e.HasMorePage为真，系统会自动调用printDocument1_PrintPage方法。实现在预览时的分页
            if (printer1.DrawDataGridView(e.Graphics))
                e.HasMorePages = true;
            else
                e.HasMorePages = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelOperation.DataGridViewToExcelFast(dataGridView1);
            }
            catch { }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 读取第一个日期与第二个日期的差距
            DataTable dt = null;                                          // 第一个表格
            DataTable nowdt = null;
            DataTable lastdt = null;
            int count = 0;
            double start_time_double = dateTimePicker1.Value.ToOADate();
            double end_time_doubel = dateTimePicker1.Value.ToOADate();
            if (end_time_doubel < start_time_double) { MessageBox.Show("结束时间不能在开始时间之前！"); return; }

            DateTime idatetime = new DateTime();
            for (idatetime = dateTimePicker1.Value; idatetime <= dateTimePicker2.Value;idatetime=idatetime.AddDays(1))
            {
                if(lastdt==null)
                {
                    SqlConnect.SQL_Connect_Builder builder = MainWindow.builder;
                    dt = builder.Select_Table("report" + idatetime.ToString("yyyyMMdd"));
                    lastdt = dt;
                    //count = count + 1;
                }
                else
                {
                    SqlConnect.SQL_Connect_Builder builder = MainWindow.builder;
                    nowdt = builder.Select_Table("report" + idatetime.ToString("yyyyMMdd"));
                    if(nowdt==null)
                    {
                        //dt = nowdt;
                    }
                    if (nowdt != null)
                    {
                        //lastdt.Clear();
                        
                        for (int i = 0; i < nowdt.Rows.Count; i++)
                        {
                            try
                            {
                                DataRow addrow = nowdt.NewRow();
                                addrow[0] = nowdt.Rows[i][0].ToString();
                                addrow[1] = nowdt.Rows[i][1].ToString();
                                addrow[2] = (double.Parse(nowdt.Rows[i][2].ToString()) + double.Parse(lastdt.Rows[i][2].ToString())).ToString();
                                if (i == 0)
                                {
                                    Console.WriteLine(addrow[2].ToString());
                                }
                                double a = double.Parse(lastdt.Rows[i][3].ToString());
                                double b = double.Parse(nowdt.Rows[i][3].ToString());
                                if (double.Parse(dt.Rows[i][3].ToString()) >= double.Parse(nowdt.Rows[i][3].ToString()))
                                {
                                    addrow[3] = dt.Rows[i][3];
                                    addrow[4] = dt.Rows[i][4];
                                }
                                else
                                {
                                    addrow[3] = nowdt.Rows[i][3];
                                    addrow[4] = nowdt.Rows[i][4];
                                }
                                try
                                {
                                    
                                }
                                catch { }
                                if (lastdt.Rows.Count < i + 1)
                                    lastdt.Rows.Add(addrow);
                                else
                                    for (int z = 0; z < lastdt.Columns.Count; z++)
                                    {
                                        lastdt.Rows[i][z] = addrow[z];
                                    }
                               
                              
                            }
                            catch { }
                        }
                        count++;

                    }


                   
                }


               
            }

            if (lastdt == null) { dataGridView1.DataSource = null; return; }
            for (int i = 0; i < lastdt.Rows.Count; i++)
            {
                if (lastdt.Rows.Count != 0)
                {
                    if (count == 0) count = 1;
                    double a = double.Parse(lastdt.Rows[i][2].ToString()) / count;
                    lastdt.Rows[i][2] = a.ToString("#0.000");
                }
                    //lastdt.Rows[i][2] = 
            }

            try
            {
                dataGridView1.DataSource = null;
            }
            catch { }
            try
            {
                lastdt.Columns[0].ColumnName = "位置范围";
                lastdt.Columns[1].ColumnName = "所属线路";
                lastdt.Columns[2].ColumnName = "平均位移(mm)";
                lastdt.Columns[3].ColumnName = "最大位移(mm)";
                lastdt.Columns[4].ColumnName = "最大位移位置(m)";
                lastdt.Columns[5].ColumnName = "备注";
            }
            catch { }
             dataGridView1.DataSource = lastdt;

             for (int i = 0; i < dataGridView1.Rows.Count; i++)
             {
                 try
                 {
                     if ((double.Parse(dataGridView1[2, i].Value.ToString())) >= 2)
                     {
                         dataGridView1.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Red;
                     }
                     if ((double.Parse(dataGridView1[3, i].Value.ToString())) >= 2)
                     {
                         dataGridView1.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.Red;
                     }
                 }
                 catch { }
             }


            //{
            //    SqlConnect.SQL_Connect_Builder builder = MainWindow.builder;
            //    DataTable dt = builder.Select_Table("report" + dateTimePicker1.Value.ToString("yyyyMMdd"));
            //    dt.Columns[0].ColumnName = "位置范围";
            //    dt.Columns[1].ColumnName = "所属线路";
            //    dt.Columns[2].ColumnName = "平均位移(mm)";
            //    dt.Columns[3].ColumnName = "最大位移(mm)";
            //    dt.Columns[4].ColumnName = "最大位移位置(m)";
            //    dt.Columns[5].ColumnName = "备注";
            //    dataGridView1.DataSource = dt;
            //}
            //catch { }
        }

    }

    class DataGridViewPrinter
    {
        //定义成员变量
        private DataGridView TheDataGridView; 
        private PrintDocument ThePrintDocument; 
        private bool IsCenterOnPage; 
        private bool IsWithTitle; 
        private string TheTitleText; 
        private string TheTitleTextTwo;
        private Font TheTitleFont; 
        private Font TheTitleFontTwo;
        private Color TheTitleColor;

        static int CurrentRow; 

        static int PageNumber;
        static int PageNumberson;
        static int lastnumber;

        private int PageWidth;
        private int PageHeight;
        private int LeftMargin;
        private int TopMargin;
        private int RightMargin;
        private int BottomMargin;

        private float CurrentY; 

        private float RowHeaderHeight;
        private List<float> RowsHeight;
        private List<float> ColumnsWidth;
        private float TheDataGridViewWidth;

        
        private List<int[]> mColumnPoints;
        private List<float> mColumnPointsWidth;
        private int mColumnPoint;
       

        //构造函数
        public DataGridViewPrinter(DataGridView aDataGridView, PrintDocument aPrintDocument, 
            bool CenterOnPage, bool WithTitle, string aTitleText, 
            string bTitleText, Font aTitleFont, Font bTitleFont, 
            Color aTitleColor)
        {
            TheDataGridView = aDataGridView;
            ThePrintDocument = aPrintDocument;
            IsCenterOnPage = CenterOnPage;
            IsWithTitle = WithTitle;
            TheTitleText = aTitleText;
            TheTitleTextTwo = bTitleText;
            TheTitleFont = aTitleFont;
            TheTitleFontTwo = bTitleFont;
            TheTitleColor = aTitleColor;
            

            PageNumber = 0;
            PageNumberson = 0;

            RowsHeight = new List<float>();
            ColumnsWidth = new List<float>();

            mColumnPoints = new List<int[]>();
            mColumnPointsWidth = new List<float>();

            //利用ThePrintDocument.DefaultPageSettings.PaperSize获取页面的宽度和高度
            if (!ThePrintDocument.DefaultPageSettings.Landscape)
            {
                PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
                PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
            }
            else
            {
                PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
                PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
            }

            // 计算页边距
            LeftMargin = ThePrintDocument.DefaultPageSettings.Margins.Left;
            TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
            RightMargin = ThePrintDocument.DefaultPageSettings.Margins.Right;
            BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;

           
            CurrentRow = 0;
            lastnumber = 0;
        }

        //构造函数，初始化变量
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        private float intergered(float num)
        {
            float num_interger;
            int point = 0;//小数点的位置
            string num_temp = num.ToString();
            for (int i = 0; i < num_temp.Length; i++)
            {
                if (num_temp[i] == '.')
                {
                    point = i;
                    break;
                }
            }
            if (point == 0)
                num_interger = num;
            else
                num_interger = Convert.ToSingle(num_temp.Substring(0, point + 1)) + 1;
            return num_interger;
        }

        //这个方法后面用到了。用于将小数宽度转换成整数宽度
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void Calculate(Graphics g)
        {
            //和分页有关,只有在绘制第一页的时候计算这些数据
            //后续页不再重复计算
            if (PageNumber == 0)
            {
                //获取dataGridView的一些参数，行高、列宽、表格的宽度等
                //根据这些参数来绘制打印内容
                //因为dataGridView中的内容就是要用来打印的内容
                //是需要在PrintDocument的PrintPage事件中绘制的

                //局部变量定义
                float totalwidth = PageWidth - (float)LeftMargin - RightMargin;//总宽度
                int cols = 0;//记录列数
                float minwidth;//最小宽度

                //记录可见列数，用于计算列的平均宽度
                for (int ic = 0; ic < TheDataGridView.Columns.Count; ic++)//calculate the numbers of columns
                {
                    if (TheDataGridView.Columns[ic].Visible)
                        cols++;
                }
                //表示列平均宽度的局部变量，后面有用到，用来初始化tmpWidth
                minwidth = totalwidth / cols;     
                //局部变量，临时保存中间结果
                //最终结果会保存到成员变量（字段）里

                //存储浮点数，通常的宽度和高度的矩形的有序对
                SizeF tmpSize = new SizeF();//表示矩形？
                Font tmpFont;               //字体    
                float tmpWidth = minwidth;   //列宽

                //表示dataGridView宽度的字段
                TheDataGridViewWidth = 0;

                //两层for循环。外层逐列，内层逐行。
                //获取绘制列标题的参数
                for (int i = 0; i < TheDataGridView.Columns.Count; i++)
                {
                    //决定字体？是的，决定列标题的字体
                   tmpFont = TheDataGridView.ColumnHeadersDefaultCellStyle.Font;
                    if (tmpFont == null)
                        tmpFont = TheDataGridView.DefaultCellStyle.Font;
                    if (tmpFont.Size < 13)
                        tmpFont = new Font(tmpFont.Name.ToString(), 13, FontStyle.Regular, GraphicsUnit.Point);
                    //干什么？测量用指定Font绘制的指定字符串
                    tmpSize = g.MeasureString(TheDataGridView.Columns[i].HeaderText, tmpFont);

                    //获取表头高度，后面有用到
                    //将高度设置为含有的字符个数
                    RowHeaderHeight = tmpSize.Height;
                        
                  //设置逐行绘制的参数
                    for (int j = 0; j < TheDataGridView.Rows.Count; j++)
                    {
                        //确定字体，单元中使用的字体
                        tmpFont = TheDataGridView.Rows[j].DefaultCellStyle.Font;
                        if (tmpFont == null) // If the there is no special font style of the CurrentRow, then use the default one associated with the DataGridView control
                           tmpFont = TheDataGridView.DefaultCellStyle.Font;
                        if (tmpFont.Size < 12)
                        {
                            tmpFont = new Font(tmpFont.Name.ToString(), 12, FontStyle.Regular, GraphicsUnit.Point);
                        }

                        //这个结构体是用来干什么的？获取dataGridView的宽度和高度？
                        //测量当前列的每一行的单元格
                        tmpSize = g.MeasureString("Anything", tmpFont);
                        tmpSize = g.MeasureString(TheDataGridView.Rows[j].Cells[i].EditedFormattedValue.ToString(), tmpFont);

                        //字段行高，后面有用到

                        RowsHeight.Add(tmpSize.Height);
                    }

                    //局部变量tmpWidth最终用来确定成员变量TheDataGridViewWidth
                    //遍历每一列的时候累加每一列的列宽，进而得到表格的宽度
                    //这样不会使计算得到的表格宽度大于表格实际宽度么？

                    if (TheDataGridView.Columns[i].Visible)
                    {
                        TheDataGridViewWidth += tmpWidth;
                    }

                    //当前列中最宽的单元格的宽度
                    tmpWidth = intergered(tmpWidth);
                    ColumnsWidth.Add(tmpWidth);
                }

                //循环变量
                int k;
                    
                int mStartPoint = 0;
                //for循环，正向遍历确定第一个可见的列的序号
                for (k = 0; k < TheDataGridView.Columns.Count; k++)
                    if (TheDataGridView.Columns[k].Visible)
                    {
                        mStartPoint = k;
                        break;
                    }

                int mEndPoint = TheDataGridView.Columns.Count;
                //for循环，逆向遍历确定最后一个可见的列的序号
                for (k = TheDataGridView.Columns.Count - 1; k >= 0; k--)
                    if (TheDataGridView.Columns[k].Visible)
                    {
                        mEndPoint = k + 1;
                        break;
                    }

                //宽度、打印区域
                float mTempWidth = TheDataGridViewWidth;

                // 
                mColumnPoints.Add(new int[] { mStartPoint, mEndPoint });
                mColumnPointsWidth.Add(mTempWidth);
                mColumnPoint = 0;
                }
            }

        //到目前为止还什么都没有绘制呢？但是几乎设置了与绘制所有表格内容相关的参数

        //当DataGridView中列数过多时，单元格内的内容可能显示不全，尝试了一些方法

        //比如更改页面大小，增加高度让文本竖向排列（竖向绘制文本比较麻烦），但是都没有成功。
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        // The funtion that print the title, page number, and the header row
        private void DrawHeader(Graphics g)
        {
            //当前纵坐标
            CurrentY = (float)TopMargin;

            #region  分页时绘制页号和打印日期
            // Printing the page number (if isWithPaging is set to true)
            //分页处理

                if (lastnumber == mColumnPoint)
                {
                    PageNumber++;
                }
                else
                {
                    PageNumber = 1;
                    lastnumber = mColumnPoint;
                }
                //绘制页号
                PageNumberson = mColumnPoint + 1;
                string PageString = "页号: " + PageNumber.ToString() + "-" + PageNumberson.ToString();
                StringFormat PageStringFormat = new StringFormat();
                PageStringFormat.Trimming = StringTrimming.Word;
                PageStringFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                PageStringFormat.Alignment = StringAlignment.Far;
                Font PageStringFont = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
                RectangleF PageStringRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(PageString, PageStringFont).Height);
                g.DrawString(PageString, PageStringFont, new SolidBrush(Color.Black), PageStringRectangle, PageStringFormat);


                //绘制打印日期
                string printtime = "打印日期: " + DateTime.Now.Year.ToString() + "." 
                    + DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString();
                StringFormat PrintTimeFormat = new StringFormat();
                PrintTimeFormat.Trimming = StringTrimming.Word;
                PrintTimeFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                PrintTimeFormat.Alignment = StringAlignment.Near;
                g.DrawString(printtime, PageStringFont, new SolidBrush(Color.Black), PageStringRectangle, PrintTimeFormat);


                CurrentY += g.MeasureString(PageString, PageStringFont).Height;

            //分页处理结束
            #endregion


            #region  有标题的时候才会用到
            // Printing the title (if IsWithTitle is set to true)
            //绘制标题
            if (IsWithTitle)
            {
                StringFormat TitleFormat = new StringFormat();
                TitleFormat.Trimming = StringTrimming.Word;
                TitleFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                if (IsCenterOnPage)
                    TitleFormat.Alignment = StringAlignment.Center;
                else
                    TitleFormat.Alignment = StringAlignment.Near;


                if (TheTitleFont.Size < 13)
                {
                    TheTitleFont = new Font(TheTitleFont.Name.ToString(), 13, FontStyle.Bold, GraphicsUnit.Point);
                }


                RectangleF TitleRectangle = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(TheTitleText, TheTitleFont).Height);

                g.DrawString(TheTitleText, TheTitleFont, new SolidBrush(TheTitleColor), TitleRectangle, TitleFormat);

                CurrentY += g.MeasureString(TheTitleText, TheTitleFont).Height;

                RectangleF TitleRectangleTwo = new RectangleF((float)LeftMargin, CurrentY, (float)PageWidth - (float)RightMargin - (float)LeftMargin, g.MeasureString(TheTitleTextTwo, TheTitleFontTwo).Height);
                g.DrawString(TheTitleTextTwo, TheTitleFontTwo, new SolidBrush(TheTitleColor), TitleRectangleTwo, TitleFormat);
                CurrentY += g.MeasureString(TheTitleTextTwo, TheTitleFontTwo).Height;
            }
            //绘制标题结束
            #endregion

            // Calculating the starting x coordinate that the printing process will start from
            //当前横坐标
            float CurrentX = (float)LeftMargin;
            if (IsCenterOnPage)
                CurrentX += (((float)PageWidth - (float)RightMargin - (float)LeftMargin) - mColumnPointsWidth[mColumnPoint]) / 2.0F;

            // Setting the HeaderFore style
            Color HeaderForeColor = TheDataGridView.ColumnHeadersDefaultCellStyle.ForeColor;
            if (HeaderForeColor.IsEmpty) 
                HeaderForeColor = TheDataGridView.DefaultCellStyle.ForeColor;
            //实例化一个画笔
            SolidBrush HeaderForeBrush = new SolidBrush(HeaderForeColor);

            // Setting the HeaderBack style
            Color HeaderBackColor = TheDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            if (HeaderBackColor.IsEmpty) 
                HeaderBackColor = TheDataGridView.DefaultCellStyle.BackColor;
            SolidBrush HeaderBackBrush = new SolidBrush(HeaderBackColor);

            // Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
            Pen TheLinePen = new Pen(TheDataGridView.GridColor, 1);

            // Setting the HeaderFont style
            Font HeaderFont = TheDataGridView.ColumnHeadersDefaultCellStyle.Font;

            if (HeaderFont == null) // If there is no special HeaderFont style, then use the default DataGridView font style
                HeaderFont = TheDataGridView.DefaultCellStyle.Font;


            if (HeaderFont.Size < 13)
            {
                HeaderFont = new Font(HeaderFont.Name.ToString(), 13, FontStyle.Bold, GraphicsUnit.Point);
            }


            // Calculating and drawing the HeaderBounds       
            RectangleF HeaderBounds = new RectangleF(CurrentX, CurrentY, 
                mColumnPointsWidth[mColumnPoint], RowHeaderHeight);
            g.FillRectangle(HeaderBackBrush, HeaderBounds);//用矩形来绘制单元格

            // Setting the format that will be used to print each cell of the header row
            StringFormat CellFormat = new StringFormat();
            CellFormat.Trimming = StringTrimming.Word;
            CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            // Printing each visible cell of the header row
            //表示单元格的矩形
            RectangleF CellBounds;
            float ColumnWidth;
            for (int i = (int)mColumnPoints[mColumnPoint].GetValue(0); i < (int)mColumnPoints[mColumnPoint].GetValue(1); i++)
            {
                if (!TheDataGridView.Columns[i].Visible) continue; // If the column is not visible then ignore this iteration

                ColumnWidth = ColumnsWidth[i];

                CellFormat.Alignment = StringAlignment.Center;


                CellBounds = new RectangleF(CurrentX, CurrentY, ColumnWidth, RowHeaderHeight);

                // Printing the cell text
                g.DrawString(TheDataGridView.Columns[i].HeaderText, HeaderFont, HeaderForeBrush, CellBounds, CellFormat);

                // Drawing the cell bounds
                if (TheDataGridView.RowHeadersBorderStyle != DataGridViewHeaderBorderStyle.None) // Draw the cell border only if the HeaderBorderStyle is not None
                    g.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, RowHeaderHeight);

                CurrentX += ColumnWidth;
            }

            CurrentY += RowHeaderHeight;
        }
        //绘制表格标题以及列标题，可能有问题，因为运行的时候一些条件下无法完全显示所有列
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //动态绘制行数、列数！
        //动态绘制行高、列宽？
        private bool DrawRows(Graphics g)
        {

            // Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
            Pen TheLinePen = new Pen(TheDataGridView.GridColor, 1);

            // The style paramters that will be used to print each cell
            Font RowFont;
            Color RowForeColor;
            Color RowBackColor;

            //三支画笔？
            SolidBrush RowForeBrush;
            SolidBrush RowBackBrush;
            SolidBrush RowAlternatingBackBrush;

            // Setting the format that will be used to print each cell
            StringFormat CellFormat = new StringFormat();
            CellFormat.Trimming = StringTrimming.Word;
            CellFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

            
            //表示矩形相关参数的结构
            RectangleF RowBounds;
            float CurrentX;
            float ColumnWidth;
            
            //逐行绘制，绘制所有可见的单元格
            while (CurrentRow < TheDataGridView.Rows.Count - 1)
            {
                if (TheDataGridView.Rows[CurrentRow].Visible) 
                {
                    // Setting the row font style
                    //确定字体
                    RowFont = TheDataGridView.Rows[CurrentRow].DefaultCellStyle.Font;
                    if (RowFont == null) 
                        RowFont = TheDataGridView.DefaultCellStyle.Font;
                    if (RowFont.Size < 12)
                    {
                        RowFont = new Font(RowFont.Name.ToString(), 12, FontStyle.Regular, GraphicsUnit.Point);
                    }

                    // 设置行单元格的前景风格
                    RowForeColor = TheDataGridView.Rows[CurrentRow].DefaultCellStyle.ForeColor;
                    if (RowForeColor.IsEmpty) 
                        RowForeColor = TheDataGridView.DefaultCellStyle.ForeColor;
                    RowForeBrush = new SolidBrush(RowForeColor);

                    //设置行单元格背景风格 
                    RowBackColor = TheDataGridView.Rows[CurrentRow].DefaultCellStyle.BackColor;
                    if (RowBackColor.IsEmpty) 
                    {
                        RowBackBrush = new SolidBrush(TheDataGridView.DefaultCellStyle.BackColor);
                        RowAlternatingBackBrush = new SolidBrush(TheDataGridView.AlternatingRowsDefaultCellStyle.BackColor);
                    }
                    else 
                    {
                        RowBackBrush = new SolidBrush(RowBackColor);
                        RowAlternatingBackBrush = new SolidBrush(RowBackColor);
                    }

                    // 根据左页边距确定绘制起始点的横坐标
                    CurrentX = (float)LeftMargin;
                    if (IsCenterOnPage)
                        CurrentX += (((float)PageWidth - (float)RightMargin - (float)LeftMargin) - mColumnPointsWidth[mColumnPoint]) / 2.0F;

                    // 计算行边界            
                    RowBounds = new RectangleF(CurrentX, CurrentY, mColumnPointsWidth[mColumnPoint], RowsHeight[CurrentRow]);

                    //填充行背景
                    if (CurrentRow % 2 == 0)
                        g.FillRectangle(RowBackBrush, RowBounds);
                    else
                        g.FillRectangle(RowAlternatingBackBrush, RowBounds);

                    // 绘制当前行的所有可见的单元格，这个没有问题               
                    for (int CurrentCell = (int)mColumnPoints[mColumnPoint].GetValue(0); CurrentCell < (int)mColumnPoints[mColumnPoint].GetValue(1); CurrentCell++)
                    {
                        if (!TheDataGridView.Columns[CurrentCell].Visible) continue; 

                        if (TheDataGridView.Columns[CurrentCell].ValueType.ToString() == "System.Single" 
                            || TheDataGridView.Columns[CurrentCell].ValueType.ToString() == "System.Double")
                            CellFormat.Alignment = StringAlignment.Far;
                        else
                            CellFormat.Alignment = StringAlignment.Near;

                        ColumnWidth = ColumnsWidth[CurrentCell];
                        RectangleF CellBounds = new RectangleF(CurrentX, CurrentY, ColumnWidth, RowsHeight[CurrentRow]);

                        // 绘制单元格中的文本
                        g.DrawString(TheDataGridView.Rows[CurrentRow].Cells[CurrentCell].EditedFormattedValue.ToString(), RowFont, RowForeBrush, CellBounds, CellFormat);

                        // 绘制单元格边界
                        if (TheDataGridView.CellBorderStyle != DataGridViewCellBorderStyle.None) 
                            g.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, RowsHeight[CurrentRow]);

                        CurrentX += ColumnWidth;
                    }
                    CurrentY += RowsHeight[CurrentRow];

                    // 每绘制完一行，判断是否到达页边界
                    // 如果到达边界，就开始另一页的绘制
                    //return true此函数就退出了
                    if ((int)CurrentY > (PageHeight - TopMargin - BottomMargin))
                    {
                        CurrentRow++;
                        return true;
                    }
                }
                CurrentRow++;
            }

            CurrentRow = 0;//why excute the word and then jump to DrawHeader()
            mColumnPoint++; // Continue to print the next group of columns

            //绘制完所有行的时候，才执行下面的代码
            //才会返回bool值
            //这是在一页内或当前页内绘制了dataGridView中的所有行
            if (mColumnPoint == mColumnPoints.Count) // Which means all columns are printed
            {
                mColumnPoint = 0;
                return false;
            }
            else
                return true;
        }
        //绘制行的方法
        //当dataGridView中行特别多时不能在一页内全显示，但是也没有自动分页
        //指定分页后，也只是绘制相关信息，但是并没有真的分页
        //而对分页的处理，主要是相关信息的绘制只出现在DrawHeader中
        //不过,分页处理应该是在绘制行的时候根据实际情况进行的啊
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public bool DrawDataGridView(Graphics g)
        {

            bool hasMorePages;
 
           
                try
                {
                    //是其他方法的基础，若是删除，只能绘制标题
                    Calculate(g);

                    //绘制列标题，有问题，一些情况下不能绘制出DataGridView中的所有的列
                    //也可能是Calculate()方法中有问题
                    DrawHeader(g);

                    //绘制所有行
                    hasMorePages = DrawRows(g);

                    return hasMorePages;
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Operation failed: " + ex.Message.ToString(), Application.ProductName + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            
        }
        //调用其他方法，其他方法没问题，此方法就不会有什么问题
        //为什么返回值为bool型呢？为真会怎样？为假又会怎样？怎么实现分页绘制？
        //是void也可以，但是不能分页
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


    }


}
