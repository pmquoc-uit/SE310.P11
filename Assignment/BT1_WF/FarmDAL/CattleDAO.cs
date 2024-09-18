using System.Data;
using System.Data.SqlClient;
using FarmDAL.Entity;

namespace FarmDAL
{
    public class CattleDAO
    {
        private DbConnection dbConnection;

        public CattleDAO()
        {
            this.dbConnection = new DbConnection();
        }
        public DataTable GetCattles()
        {
            try
            {
                string query = "SELECT * FROM Cattle";
                SqlCommand sqlCommand = new SqlCommand(query);
                return dbConnection.ExeRead(sqlCommand);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving cattle data.", ex);
            }
        }
        public int AddCattle(CattleEntity cattleEntity)
        {
            try
            {
                string query = "INSERT INTO Cattle (Loai, SoCon, SoSua) VALUES (@Loai, @SoCon, @SoSua)";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.Parameters.AddWithValue("@Loai", cattleEntity.Loai);
                sqlCommand.Parameters.AddWithValue("@SoCon", cattleEntity.SoCon);
                sqlCommand.Parameters.AddWithValue("@SoSua", cattleEntity.SoSua);
                return dbConnection.ExeNonQuery(sqlCommand);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding data.", ex);
            }

        }
    }
}
