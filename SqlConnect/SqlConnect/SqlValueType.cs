using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SqlConnect
{
    /// <summary>
    /// Developed By Tom Ni 2017 12 22
    /// 用来新建数据库的数据结构
    /// </summary>
    public class CreateSqlValueType
    {
        private string Value_Type;  // 值的类型
        private string Value_Name;  // 值的名称
        bool Key_is;                // 是否是键值
        bool Null_is;               // 是否允许是空值
        public CreateSqlValueType(string value_type,string value_name,bool key_is=false,bool null_is=false)
        {
            Value_Type = value_type;
            Value_Name = value_name;
            Key_is = key_is;
            Null_is = null_is;
        }

        public string Get_Value_Type()
        {
            return Value_Type;
        }

        public string Get_Value_Name()
        {
            return Value_Name;
        }

        public bool Get_Key_Is()
        {
            return Key_is;
        }

        public bool Get_Null_Is()
        {
            return Null_is;
        }
    }
}
