using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MizyBureau
{
    public static class Request_Local_db
    {
        public const string LocalDB_connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MizyLocalDB.mdf;Integrated Security = True";

        public static SqlDataReader GetRequest(string str)
        {
            using (SqlConnection connection = new SqlConnection(Constants.LocalDB_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd1 = new SqlCommand(str, connection))
                {
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        return reader;
                    }
                }
            }
        }

        public static void SetRequest(string str, object[] objs)
        {
            using (SqlConnection conn = new SqlConnection(LocalDB_connectionString))
            {
                using (SqlCommand comm = new SqlCommand(str))
                {
                    comm.Connection = conn;
                    foreach (object obj in objs)
                    {
                        comm.Parameters.AddWithValue("@val1", obj);
                    }

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (SqlException err)
                    {
                    }
                }
            }
        }
    }
}
