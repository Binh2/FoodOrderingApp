using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WEBAPI.Database
{
    public class Database
    {
        public static DataTable ReadTable(string StoredProcedureName,
            Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["QLBConnectionstring"].ConnectionString;
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                    }
                }
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(result);
                    return result;
                }
                catch (Exception ex) { return null; }
            }
        }
    }
}