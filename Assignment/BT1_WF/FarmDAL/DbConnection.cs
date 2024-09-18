using System.Data;
using System.Data.SqlClient;

namespace FarmDAL
{
    public class DbConnection
    {
        private SqlConnection sqlConnection;
        private DataTable dataTable;
        public DbConnection()
        {
            this.sqlConnection = new SqlConnection(
                "Data Source=PMQ-DELLPCMS;Initial Catalog=Farm;Integrated Security=True");
            this.dataTable = new DataTable();
        }
        public SqlConnection GetSqlConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed) this.sqlConnection.Open();
            return this.sqlConnection;
        }
        public int ExeNonQuery(SqlCommand sqlCommand)   //Insert-Update-Delete
        {
            sqlCommand.Connection = GetSqlConnection();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            this.sqlConnection.Close();
            return rowsAffected;
        }
        public DataTable ExeRead(SqlCommand sqlCommand) //Get
        {
            sqlCommand.Connection = GetSqlConnection();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            this.dataTable.Load(sqlDataReader);
            this.sqlConnection.Close();
            return this.dataTable;
        }
    }
}
