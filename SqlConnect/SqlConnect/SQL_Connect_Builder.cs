using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace SqlConnect
{
    /// <summary>
    /// Developed by Tom Ni 2017 12 22
    /// 开发数据库连接池，用于维护数据库连接，最大连接数为100，最小连接数为0
    /// </summary>
    public class SQL_Connect_Builder
    {
        private SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder();
        // 在这个类中，建立一个数据库的连接，其连接的构造函数在下面
        public SQL_Connect_Builder(string DataSource, string InitialCatalog,int minpoolsize,int maxpoolsize)
        {
            // 构造函数，用来构造一个连接
            connStr.DataSource = DataSource;                 // 设置连接源
            connStr.InitialCatalog = InitialCatalog;         // 设置数库据
            connStr.IntegratedSecurity = true;               // true是以windows方式进行访问，false是以用户名密码的方式进行访问
            connStr.MinPoolSize = minpoolsize;               // 设置最小的连接数
            connStr.MaxPoolSize = maxpoolsize;               // 设置最大的连接数
            connStr.UserID = "sa";
            connStr.Password = "js168";
        }

        // 创建表
        public bool Create_Table(string table_name,CreateSqlValueType[] create_sql_value_type)
        {
            bool result;
            using(SqlConnection conn=new SqlConnection(connStr.ConnectionString))
            {
                conn.Open();              //打开此连接
                // 创建command对像
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;               // 将连接赋值给cmd的连接
                string create_cmd = "Create table " + table_name;
                create_cmd = create_cmd + "(";
                for (int i = 0; i < create_sql_value_type.Length; i++)
                {
                    if (create_sql_value_type[i] == null) break;
                    create_cmd = create_cmd + create_sql_value_type[i].Get_Value_Name() + " " + create_sql_value_type[i].Get_Value_Type();
                    if(create_sql_value_type[i].Get_Key_Is()==true)
                    {
                        create_cmd = create_cmd + " primary key";
                    }
                    if (i != create_sql_value_type.Length - 1)
                    {
                        create_cmd = create_cmd + ",";
                    }
                }
                create_cmd = create_cmd + ")";
                cmd.CommandText = create_cmd;
                try
                {
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch { result = false ; }
                conn.Close();             //关闭连接
                return result;
            }
        }

        

        // 查找表格
        public DataTable Select_Table(string table_name,string where_condition="",string[] cols=null)
        {
            // 仔细看这个select里面的实现过程 根据参数的不同，用select_cmd组合成sql语句
            using(SqlConnection conn=new SqlConnection(connStr.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string select_cmd = "";
                if (cols == null)
                {
                    select_cmd = "Select * from "+table_name;           //没有选择行的情况下
                }
                else
                {
                    select_cmd = "Select ";
                    for (int i = 0; i < cols.Length; i++)
                    {
                        select_cmd = select_cmd + cols[i];
                        if (i != cols.Length - 1)
                        {
                            select_cmd = select_cmd + ",";
                        }
                    }
                    select_cmd = select_cmd + " from "+table_name;
                }
                if(where_condition!="")
                {
                    select_cmd = select_cmd + " where " + where_condition;
                }
                cmd.CommandText = select_cmd;
                SqlDataReader sqldatareader;
                try
                {
                    sqldatareader = cmd.ExecuteReader(); // 在这里进行数据库操作，并将查找的返回值给特定的数据类型 sqldatareader
                }
                catch { return null; }
                DataTable dt = new DataTable();                    // 新建一个datatable，下面用一个循环将sqldatareader中的值给datatable,然后返回此表，就可以了
               
                if (sqldatareader != null && sqldatareader.HasRows == true)
                {
                    for (int i = 0; i < sqldatareader.FieldCount; i++)
                    {
                        dt.Columns.Add(i.ToString());
                    }
                    // sqldatareader可读
                    while(sqldatareader.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < sqldatareader.FieldCount; i++)
                        {
                            dr[i] = sqldatareader.GetValue(i).ToString();
                        }
                        dt.Rows.Add(dr);
                    }
                    
                }
                sqldatareader.Close();
                conn.Close();
                return dt;
            }
        }           // 查询

        
        public bool Insert_Array(string table_name,ArrayList insert_info)
        {
            using(SqlConnection conn=new SqlConnection(connStr.ConnectionString))
            {
                bool success = false;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string insert_cmd = "insert into " + table_name + "values";
                int count = 0;
                foreach (string[] string_array in insert_info)
                {
                    insert_cmd = insert_cmd + "(";
                    for (int i = 0; i < string_array.Length; i++)
                    {
                        insert_cmd = insert_cmd + "'" + string_array[i] + "'";
                        if (i != string_array.Length - 1)
                        {
                            insert_cmd = insert_cmd + ",";
                        }
                    }
                    insert_cmd = insert_cmd + ")";
                    count++;
                    if(count!=string_array.Length)
                    {
                        insert_cmd = insert_cmd + ",";
                    }
                   
                    Console.WriteLine(count.ToString());
                }
                cmd.CommandText = insert_cmd;
                try
                {
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch { success = false; }
                conn.Close();

                return success;
            }
        }         // 批量插入信息

        public bool Insert_Data_From_Txt(string table_name,string path)
        {
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                bool success = false;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string insert_cmd = "bulk insert " + table_name + " from '" + path + "'" + "with (fieldterminator=' ',rowterminator='\n')";
                cmd.CommandText = insert_cmd;
                try
                {
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch { success = false; }
                conn.Close();
                return success;

            }

        }

        public bool Insert(string table_name,string[] insert_values)
        {
            using(SqlConnection conn=new SqlConnection(connStr.ConnectionString))
            {

                bool success = false;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    string insert_cmd = "insert into " + table_name + " values(";
                    for (int i = 0; i < insert_values.Length; i++)
                    {
                        insert_cmd = insert_cmd + "'" + insert_values[i] + "'";
                        if (i != insert_values.Length - 1)
                        {
                            insert_cmd = insert_cmd + ",";
                        }
                    }
                    insert_cmd = insert_cmd + ")";
                    cmd.CommandText = insert_cmd;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                    catch { success = false; }
                    conn.Close();
                    return success;
               
            }
        }                                            // 向数据库中添加信息

        public void Delete(string table_name,string where_condition="")
        {
            using(SqlConnection conn=new SqlConnection(connStr.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string delete_cmd = "";
                if (where_condition == "")
                {
                    delete_cmd = "delete from " + table_name;
                }
                else
                {
                    delete_cmd = "delete from " + table_name+" where "+where_condition;
                }
                cmd.CommandText = delete_cmd;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                conn.Close();
            }
        }                                          // 删除

        public bool Updata(string table_name,string where_condition,string[] updata_value)
        {
            bool success = false;
            using(SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string update_cmd = "update "+table_name+" set ";
                for (int i = 0; i < updata_value.Length; i++)
                {
                    update_cmd = update_cmd + " " + updata_value[i];
                    if(i!=updata_value.Length-1)
                    {
                        update_cmd = update_cmd + ",";
                    }
                }
                update_cmd = update_cmd + " where " + where_condition;
                cmd.CommandText = update_cmd;
                try
                {
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch { success = false; }
                conn.Close();
                return success;
            }
        }                       // 更改

        //针对于master数据库，新建立数据库
        public void Create_Database(string Database_Name)
        {
            using(SqlConnection conn=new SqlConnection(connStr.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Create Database "+Database_Name;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                conn.Close();
            }
        }

        // 删除一个表格
        public void Delete_Table(string table_name)
        {
            using(SqlConnection conn=new SqlConnection(connStr.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Drop table " + table_name;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                conn.Close();
            }
        }

        // 修改一个表格的名字
        public void Updata_Table_Name(string old_table_name,string new_table_name)
        {
            using(SqlConnection conn=new SqlConnection(connStr.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "EXEC sp_rename '" + old_table_name + "','" + new_table_name + "'";
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch { }
                conn.Close();
            }
        }
    }
}
