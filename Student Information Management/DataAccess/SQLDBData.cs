using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_Management.DataAccess
{
    internal class SQLDBData
    {
        string connect = @"Server = .; Initial Catalog = BelgiumCampusStudentsDB; Integrated Security = SSPI";

        public DataTable ReadFromDB(string viewTable)
        {
            string query = $"SELECT * FROM {viewTable}";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public void WriteToDB(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
