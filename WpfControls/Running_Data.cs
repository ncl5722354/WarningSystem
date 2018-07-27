using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace WpfControls
{
    public class Running_Data
    {
        public ArrayList Station_Info_List = new ArrayList();

        public event EventHandler value_Change_Event = null;
        public Running_Data(DataTable dt)
        {
            foreach(DataRow dr in dt.Rows)
            {
                string station_name = dr[0].ToString();
                int Int_Num = int.Parse(dr[1].ToString());
                int Double_Num = int.Parse(dr[2].ToString());
                int Switch_Num = int.Parse(dr[3].ToString());
                string com_type = dr[4].ToString();
                string station_num = dr[5].ToString();
                Running_Data_Struct running_data_struct = new Running_Data_Struct(station_name,Int_Num,Double_Num,Switch_Num,com_type,station_num);
                Station_Info_List.Add(running_data_struct);
            }
        }

        public void Set_Value_Int(string Station_Name,int address,int value)
        {
            foreach (object myobject in Station_Info_List)
            {
                Running_Data_Struct mystruct = (Running_Data_Struct)myobject;
                if (mystruct.Get_Name() == Station_Name)
                {
                    int[] data = mystruct.Get_IntData();
                    if (address >= 0 && address < data.Length)
                    {
                        data[address] = value;
                        // 这里加入触发事件
                        Value_Change(new EventArgs());
                    }
                    break;
                }
            }
        }

        public void Set_Value_Double(string Station_Name,int address,double value)
        {
            foreach(object myobject in Station_Info_List)
            {
                Running_Data_Struct mystruct = (Running_Data_Struct)myobject;
                if(mystruct.Get_Name()==Station_Name)
                {
                    double[] data = mystruct.Get_DoubleData();
                    if(address >=0 && address<data.Length)
                    {
                        data[address] = value;
                        // 这里加入触发事件
                        Value_Change(new EventArgs());
                    }
                    break;
                }
            }
        }

        public void Set_Value_Switch(string Station_Name,int address,bool value)
        {
            foreach(object myobject in Station_Info_List)
            {
                Running_Data_Struct mystruct = (Running_Data_Struct)myobject;
                if(mystruct.Get_Name()==Station_Name)
                {
                    bool[] data = mystruct.Get_SwitchData();
                    if(address>=0 && address<data.Length)
                    {
                        data[address] = value;
                        // 这里加入触发事件
                        Value_Change(new EventArgs());
                    }
                    break;
                }
            }
        }

        private void Value_Change(EventArgs e)
        {
            if(value_Change_Event!=null)
            {
                value_Change_Event(this, e);
            }
        }
    }




    public class Running_Data_Struct
    {
        // 这个类用来定义时实库中每一项
        private string Station_Name = "";
        private int[] Int_Data = null;            // 用来保存整理变量
        private double[] Double_Data = null;      // 用来保存浮点型变量
        private bool[] Switch_Data = null;        // 用来保存开关量变量
        private string Com_Type = "";             // 通讯类型
        private string Station_Num = "";          // 通讯站号

        public Running_Data_Struct(string Name,int int_num,int double_num,int switch_num,string com_type,string station_num)
        {
            Station_Name = Name;
            Int_Data = new int[int_num];
            Double_Data = new double[double_num];
            Switch_Data = new bool[switch_num];
            Com_Type = com_type;
            Station_Num = station_num;
        }

        public string Get_Name()
        {
            return Station_Name;
        }
        
        public int[] Get_IntData()
        {
            return Int_Data;
        }

        public double[] Get_DoubleData()
        {
            return Double_Data;
        }

        public bool[] Get_SwitchData()
        {
            return Switch_Data;
        }

        public string Get_Com_Type()
        {
            return Com_Type;
        }
    }
}
