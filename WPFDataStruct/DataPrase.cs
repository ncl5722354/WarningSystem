using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlConnect;
using System.Data;
using System.Data.SqlClient;

namespace WPFDataStruct
{
    public class DataPrase
    {
        public static void Parse_All_Table_Struct(SQL_Connect_Builder builder)
        {
            DataTable dt = builder.Select_Table("TableStruct");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    int colcount=dt.Columns.Count;
                    foreach(DataRow dr in dt.Rows)
                    {
                        int value_count=0;
                        for(int i=0;i<colcount;i++)
                        {
                            if(dr[i].ToString()!="")
                            {
                                value_count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        int table_col_count = (value_count - 1) / 2;
                        CreateSqlValueType[] createsqlvaluetype = new CreateSqlValueType[table_col_count];
                        for(int j=0;j<table_col_count;j++)
                        {
                            if (j == 0) createsqlvaluetype[j] = new CreateSqlValueType(dr[2 + j * 2].ToString(), dr[1 + j * 2].ToString(), true);
                            else createsqlvaluetype[j] = new CreateSqlValueType(dr[2 + j * 2].ToString(), dr[1 + j * 2].ToString());
                        }
                        builder.Create_Table(dr[0].ToString(), createsqlvaluetype);
                    }
                }
            }
        }

        public static void Parse_All_Data_Grid(SQL_Connect_Builder builder)
        {
            DataTable dt = builder.Select_Table("AllDataGrid");
            foreach(DataRow dr in dt.Rows)
            {
                string name = dr[0].ToString();
                
                string table_type=dr[1].ToString();
                if(table_type=="OrderTable")
                {
                    // 这个地方数量不对
                    CreateSqlValueType[] create_sql_value_type = new CreateSqlValueType[1+(dr.ItemArray.Length-2)/2];
                    create_sql_value_type[0] = new CreateSqlValueType("integer", "MyOrder", true);
                    for (int i = 0; i < (dr.ItemArray.Length - 12) / 2; i++)
                    {
                        if (dr[12 + i * 2].ToString() == "" || dr[12 + i * 2 + 1].ToString() == "")
                        {
                            break;
                        }
                        create_sql_value_type[1 + i] = new CreateSqlValueType(dr[12 + i * 2 + 1].ToString(), dr[12 + i * 2].ToString());
                    }
                    builder.Create_Table(name, create_sql_value_type);
                }
            }
        }


    }
}
