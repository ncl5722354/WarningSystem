using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data;

namespace DataGridViewCaoZuo
{
    public class DataGridView_CaoZuo
    {
        public static void Fill_DataGridView_With_DataTable(DataGridView datagridview,DataTable dt)
        {
            datagridview.RowCount = 1;
            for (int i = 0; i < datagridview.ColumnCount; i++)
            {
                datagridview[i, 0].Value = "";
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
                {
                    datagridview.RowCount = dt.Rows.Count;
                    datagridview.ColumnCount = dt.Columns.Count;
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        for(int j=0;j<dt.Columns.Count;j++)
                        {
                            datagridview[j, i].Value = dt.Rows[i][j].ToString();
                        }
                    }
                }
            }
        }
    }
}
