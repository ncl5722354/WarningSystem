using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOperation;
using SqlConnect;
using String_Caozuo;
using MyShape;
using System.Collections;
using System.Threading;

namespace RealPhotonics
{
    public partial class MapConfig : Form
    {
        CreateSqlValueType[] create_map = new CreateSqlValueType[9];
       

        string selected_map_name = "";
        public static ArrayList line_list = new ArrayList();
        int count = 0;
        Image mapimage;

        public MapConfig()
        {
            InitializeComponent();
            Show_Pic_List();
            Show_Voice();
            this.DoubleBuffered = true;
           
            create_map[0] = new CreateSqlValueType("datetime", "createtime", true);
            create_map[1] = new CreateSqlValueType("int", "startX");
            create_map[2] = new CreateSqlValueType("int", "startY");
            create_map[3] = new CreateSqlValueType("int", "endX");
            create_map[4] = new CreateSqlValueType("int", "endY");
            create_map[5] = new CreateSqlValueType("int", "start_value");
            create_map[6] = new CreateSqlValueType("int", "end_value");
            create_map[7] = new CreateSqlValueType("nvarchar(50)", "kind");
            create_map[8] = new CreateSqlValueType("nvarchar(50)","voice");

            pictureBox1.Parent = panel2;
            //pictureBox2.Parent = panel2;
            pictureBox1.BackColor = Color.Transparent;

            comboBox_warningtype.Items.Add("行人");
            comboBox_warningtype.Items.Add("攀爬");
            //pictureBox2.BackColor = Color.Transparent;
        }

        private void Show_Pic_List()
        {
            // 将pic文件夹中的bmp文件显示在列表中
           string path = System.Environment.CurrentDirectory+"\\mappic";
           FileCaozuo.Read_All_Files_Show_List(path, "*.bmp", listBox1);

        }


        private void Show_Voice()
        {
            string path = System.Environment.CurrentDirectory + "\\voice";
            FileCaozuo.Read_All_Files_Show_ComboBox(path,"*.wav",comboBox_warning_voice);
        }
        private void MapConfig_Load(object sender, EventArgs e)
        {
                
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            // 列表中选择的图片放在picture1的界面上显示
            if (listBox1.SelectedIndex != -1)
            {
                string filename = listBox1.Items[listBox1.SelectedIndex].ToString();
                string mapname = string_caozuo.Get_Dian_String(filename, 1);
                selected_map_name = mapname;
                // 创建相应图片的表
                Login.builder.Create_Table(mapname,create_map);
                //pictureBox1.Image = Image.FromFile(System.Environment.CurrentDirectory+"\\mappic\\"+filename);
                mapimage=Image.FromFile(System.Environment.CurrentDirectory + "\\mappic\\" + filename);
                panel2.BackgroundImage = mapimage;
                panel2.Width = mapimage.Width;
                panel2.Height = mapimage.Height;
                // 将地图加载到panel2中

                //Graphics g = panel2.CreateGraphics();
                //g.DrawLine(new Pen(Color.Red, 5), new Point(0, 0), new Point(1000, 1000));
                //g.Dispose();
                Read_Map_Info();
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = pictureBox1.CreateGraphics();

            //g.Clear(Color.White);
            //pictureBox1.Parent = panel2;
            //pictureBox1.BackColor = Color.Transparent;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Line line1 = new Line(selected_map_name, panel1);

            
            //g.Dispose();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            //myGraphics.DrawImage(pictureBox1.Image, default(Point));
            //Graphics g = pictureBox1.CreateGraphics();
            ////g.DrawImage(pictureBox1.Image, default(Point));
            ////g.Clear(this.BackColor);

            //g.DrawLine(new Pen(Color.Red, 5), new Point(0, 0), new Point(1000, 1000));
            //foreach (Line myline in line_list)
            //{

            //}
            //g.Dispose();

            //Graphics g1 = pictureBox2.CreateGraphics();
            //g1.DrawLine(new Pen(Color.Red, 5), new Point(0, 0), new Point(1000, 1000));
            //g1.Dispose();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void ReDraw()
        {
            if (listBox1.SelectedIndex != -1)
            {
                //string filename = listBox1.Items[listBox1.SelectedIndex].ToString();
                //string mapname = string_caozuo.Get_Dian_String(filename, 1);
                //selected_map_name = mapname;
                //// 创建相应图片的表
                //Login.builder.Create_Table(mapname, create_map);
                ////pictureBox1.Image = Image.FromFile(System.Environment.CurrentDirectory+"\\mappic\\"+filename);
                //Image myimage = Image.FromFile(System.Environment.CurrentDirectory + "\\mappic\\" + filename);
                //panel2.BackgroundImage = myimage;
                //panel2.Width = myimage.Width;
                //panel2.Height = myimage.Height;
                // 将地图加载到panel2中
                //pictureBox1.Invalidate();
               
            }
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            pictureBox1.Top = panel2.Top;
            pictureBox1.Left = panel2.Left;
            pictureBox1.Width = panel2.Width;
            pictureBox1.Height = panel2.Height;
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            //ReDraw();
        }

        public void Read_Map_Info()
        {
            listView1.Items.Clear();
            DataTable dt = Login.builder.Select_Table(selected_map_name);
           
            for(int i=0;i<dt.Rows.Count;i++)
            {
                 ListViewItem item=new ListViewItem();
                 item.Text = dt.Rows[i][0].ToString();
                //item.SubItems.Add(dt.Rows[i][1].ToString());
                item.SubItems.Add("("+dt.Rows[i][1].ToString()+","+dt.Rows[i][2].ToString()+")");
                item.SubItems.Add("("+dt.Rows[i][3].ToString()+","+dt.Rows[i][4].ToString()+")");
                item.SubItems.Add(dt.Rows[i][5].ToString());
                item.SubItems.Add(dt.Rows[i][6].ToString());
                item.SubItems.Add(dt.Rows[i][7].ToString());
                item.SubItems.Add(dt.Rows[i][8].ToString());
                listView1.Items.Add(item);
            }
            
        }                        // 刷新列表

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
           if(mapimage!=null)
           {
                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(Color.White);
                g.DrawImage(mapimage, 0, 0,mapimage.Width,mapimage.Height);
                //g.Clear(Color.White);
                //pictureBox1.Parent = panel2;
                //pictureBox1.BackColor = Color.Transparent;
                //g.DrawLine(new Pen(Color.Red, 5), new Point(0, 0), new Point(1000, 1000 + count));

                //ount++;
                //if (count >= 1000)
                //{
                  //  count = 1000;
                //}
               
                DataTable dt = Login.builder.Select_Table(selected_map_name);
                foreach(DataRow dr in dt.Rows)
                {
                    int start_x = int.Parse(dr[1].ToString());
                    int start_y = int.Parse(dr[2].ToString());
                    int end_x = int.Parse(dr[3].ToString());
                    int end_y = int.Parse(dr[4].ToString());
                    g.DrawLine(new Pen(Color.Green, 5), new Point(start_x, start_y), new Point(end_x, end_y));
                }
                g.Dispose();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Read_Map_Info();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ADDLine view = new ADDLine();
           DialogResult result = view.ShowDialog();
            if(result==DialogResult.OK)
            {
                string[] insert_value=new string[9];
                insert_value[0]=ADDLine.ID;
                insert_value[1]=ADDLine.start_x.ToString();
                insert_value[2]=ADDLine.start_y.ToString();
                insert_value[3]=ADDLine.end_x.ToString();
                insert_value[4]=ADDLine.end_y.ToString();
                insert_value[5]=ADDLine.start_value.ToString();
                insert_value[6]=ADDLine.end_value.ToString();
                insert_value[7] = ADDLine.kind;
                insert_value[8] = ADDLine.voice;
                Login.builder.Insert(selected_map_name,insert_value);
            }
            Read_Map_Info();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selected_id = listView1.SelectedItems[0].Text;
                string wherer_cmd = "createtime='" + selected_id + "'";
                Login.builder.Delete(selected_map_name, wherer_cmd);
                Read_Map_Info();
            }catch
            {

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //label_selected_id.Text = listView1.SelectedItems[0].Text;
                //textBox_startX.Text = listView1.SelectedItems[0].SubItems[0].ToString();
                //textBox_startY.Text = listView1.SelectedItems[0].SubItems[1].ToString();
                //textBox_endX.Text = listView1.SelectedItems[0].SubItems[2].ToString();
                //textBox_endY.Text = listView1.SelectedItems[0].SubItems[3].ToString();
                //textBox_startValue.Text = listView1.SelectedItems[0].SubItems[4].ToString();
                //textBox_endValue.Text = listView1.SelectedItems[0].SubItems[5].ToString();
                string selected_id = listView1.SelectedItems[0].Text;
                string where_cmd = "createtime='" + selected_id + "'";
                DataTable dt= Login.builder.Select_Table(selected_map_name,where_cmd);
                if(dt!=null)
                {
                    if(dt.Rows.Count>0)
                    {
                        label_selected_id.Text = dt.Rows[0][0].ToString();
                        textBox_startX.Text = dt.Rows[0][1].ToString();
                        textBox_startY.Text = dt.Rows[0][2].ToString();
                        textBox_endX.Text = dt.Rows[0][3].ToString();
                        textBox_endY.Text = dt.Rows[0][4].ToString();
                        textBox_startValue.Text = dt.Rows[0][5].ToString();
                        textBox_endValue.Text = dt.Rows[0][6].ToString();
                        comboBox_warningtype.Text = dt.Rows[0][7].ToString();
                        comboBox_warning_voice.Text = dt.Rows[0][8].ToString();
                    }
                }
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string selected_id = label_selected_id.Text;
            string where_cmd = "createtime='" + selected_id + "'";
            string[] update_cmd = new string[9];
            try
            {
                int startx = int.Parse(textBox_startX.Text);
                int straty = int.Parse(textBox_startY.Text);
                int endx = int.Parse(textBox_endX.Text);
                int endy = int.Parse(textBox_endY.Text);
                int startvalue = int.Parse(textBox_startValue.Text);
                int endvalue = int.Parse(textBox_endValue.Text);
            }
            catch
            {
                MessageBox.Show("输入格式错误！");
                return;
            }

            if(comboBox_warningtype.Text=="")
            {
                MessageBox.Show("未选择报警类型！");
                return;
            }

            update_cmd[0] = "createtime='" + selected_id + "'";
            update_cmd[1] = "startX='" + textBox_startX.Text + "'";
            update_cmd[2] = "startY='" + textBox_startY.Text + "'";
            update_cmd[3] = "endX='" + textBox_endX.Text + "'";
            update_cmd[4] = "endY='" + textBox_endY.Text + "'";
            update_cmd[5] = "start_value='" + textBox_startValue.Text + "'";
            update_cmd[6] = "end_value='" + textBox_endValue.Text + "'";
            update_cmd[7] = "kind='"+comboBox_warningtype.Text+"'";
            //update_cmd[8]=""
            Login.builder.Updata(selected_map_name,where_cmd,update_cmd);
            Read_Map_Info();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
