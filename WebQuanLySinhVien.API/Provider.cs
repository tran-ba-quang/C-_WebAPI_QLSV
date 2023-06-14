using System.Data;
using System.Data.SqlClient;

namespace WebQuanLySinhVien
{
    public class Provider
    {
        static string ConnectionString = "Data Source=BAQUANG-TBQ\\SQLEXPRESS;Initial Catalog=QuanLyHocSinh_SinhVien;Integrated Security=True";
        SqlConnection? Connection { get; set; }

        public void Connect()
        {
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(ConnectionString);
                }
                if (Connection != null
                    && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
                if (Connection != null)
                    Connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DisConnect()
        {
            if (Connection != null
                && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
        // Them, xoa , sua
        public int ExecuteNonQuery(CommandType cmtType,
                string strSql, params SqlParameter[] parameters)
        {
            int nRow = 0;
            try
            {
                Connect();
                SqlCommand command = Connection.CreateCommand();
                command.CommandType = cmtType;
                command.CommandText = strSql;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);
                nRow = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
            return nRow;
        }

        public DataTable Select(CommandType cmtType,
                string strSql, params SqlParameter[] parameters)
        {
            DataTable dt;
            try
            {
                Connect();
                SqlCommand command = Connection.CreateCommand();
                command.CommandType = cmtType;
                command.CommandText = strSql;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
            return dt;
        }
    }
}
