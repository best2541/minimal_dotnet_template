using System.Data.SqlClient;
using System.Data;

namespace minimalAPIDemo.Services.Sql
{
    public class AuthSql
    {
        private static string[] args;
        public static DataTable Connect(string sqlCom)
        {
            var builder = WebApplication.CreateBuilder(args);
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.Configuration["ConnectionStrings:DefaultConnection"]))
                {
                    String sql = sqlCom;
                    SqlCommand cmd = new SqlCommand(sql, connection); ;
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    return dt;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                throw e;
            }
        }
    }
}
