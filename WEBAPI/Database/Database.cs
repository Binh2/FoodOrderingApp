using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace WEBAPI.Database
{
    public class Database
    {
        public static DataTable ReadTable(string StoredProcedureName,
            Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["QLBConnectionstring"].ConnectionString;
            DataTable result = new DataTable();
            SqlConnection conn = new SqlConnection(SQLconnectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(StoredProcedureName, conn);
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
            catch (Exception) { return null; }
        }

        //public static object Exec_Command(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        //{
        //    string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
        //    object result = null;
        //    SqlConnection conn = new SqlConnection(SQLconnectionString);

        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand(StoredProcedureName, conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    if (dic_param != null)
        //    {
        //        foreach (KeyValuePair<string, object> data in dic_param)
        //        {
        //            if (data.Value == null)
        //            {
        //                cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
        //            }
        //            else
        //            {
        //                cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
        //            }
        //        }
        //    }
        //    cmd.Parameters.Add("@CurrentID", SqlDbType.Int).Direction = ParameterDirection.Output;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        result = cmd.Parameters;
        //        return result;
        //    }
        //    catch (Exception e) { return "hello"; }
        //}
        public static object Exec_Command(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
            object result = null;
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                // Start a local transaction.

                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }
                cmd.Parameters.Add("@CurrentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters["@CurrentID"].Value;
                    // Attempt to commit the transaction.

                }
                catch (Exception ex)
                {

                    result = null;
                }

            }
            return result;
        }
    }
}